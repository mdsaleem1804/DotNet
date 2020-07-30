using FluentAssertions;
using MarketTestApi.Controllers;
using MarketTestApi.Models;
using MarketTestApi.Repository;
using MarketTestApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarkelTestApi.UnitTest
{
   public  class MarkelUnitTestController
    {
        private MarkelRepository repository;
        public static DbContextOptions<TestMarkelContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-C09JVA0\\SQLEXPRESS;Database=TestMarkel;Trusted_Connection=True;";

        static MarkelUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TestMarkelContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public MarkelUnitTestController()
        {
            var context = new TestMarkelContext(dbContextOptions);
            DBInitializer db = new DBInitializer();
            db.Seed(context);

            repository = new MarkelRepository(context);
        }

        [Fact]
        public async void Task_GetCompanyById_Return_OkResult()
        {
            //Arrange
            var controller = new MarkelController(repository);
            var companyId = 2;

            //Act
            var data = await controller.GetCompany(companyId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
           
        }
        [Fact]
        public async void Task_GetCompanyById_Return_ExactCompanyName()
        {
            //Arrange
            var controller = new MarkelController(repository);
            var companyId = 1;

            //Act
            var data = await controller.GetCompany(companyId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var company = okResult.Value.Should().BeAssignableTo<CompanyViewModel>().Subject;


            Assert.Equal("Name1", company.Name);
        }
    }
}
