using MarketTestApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkelTestApi.UnitTest
{
    public class DBInitializer
    {
        public DBInitializer()
        {

        }
        public void Seed(TestMarkelContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Company.AddRange(
                new Company()
                {
                    Id = 1,
                    Name = "Name1",
                    Address1 = "Test Address1-1",
                    Address2 = "Test Address2-1",
                    Address3 = "Test Address3-1",
                    Active=true,
                    Country="India",
                    PostCode="12345",
                    InsuranceEndDate = DateTime.Now,
                    
                },
                new Company()
                {
                    Id = 2,
                    Name = "Name2",
                    Address1 = "Test Address1-2",
                    Address2 = "Test Address2-2",
                    Address3 = "Test Address3-2",
                    Active = true,
                    Country = "India",
                    PostCode = "12345",
                    InsuranceEndDate = DateTime.Now.AddDays(10),

                }

            );


            context.SaveChanges();
        }
    }
}
