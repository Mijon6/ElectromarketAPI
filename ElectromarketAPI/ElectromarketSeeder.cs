using ElectromarketAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI
{
    public class ElectromarketSeeder
    {
        private readonly ElectromarketDbContext _dbContext;
        public ElectromarketSeeder(ElectromarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Electromarkets.Any())
                {
                    var electromarkets = GetElectromarkets();
                    _dbContext.Electromarkets.AddRange(electromarkets);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Electromarket> GetElectromarkets()
        {
            var electromarkets = new List<Electromarket>()
            {
                new Electromarket()
                {
                    Name = "MediaExpert",
                    Category = "GSM Shop",
                    Description = "MediaExpert is an Polish Electromarket",
                    ContactEmail = "contact@me.pl",
                    HasDelivery =true,
                    Stuffs = new List<Stuff>()
                    {
                        new Stuff()
                        {
                            Name = "Samsung S21",
                            Price= 2799,
                        },
                        new Stuff()
                        {
                            Name = "Samsung Note 20 Ultra",
                            Price = 5900,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Puławska 5",
                        PostalCode = "77-777",

                    }
                },
                new Electromarket()
                {
                    Name = "MediaMarkt",
                    Category = "GSM Shop",
                    Description = "MediaMarkt is an Polish Electromarket",
                    ContactEmail = "contact@mm.pl",
                    HasDelivery =false,
                    Stuffs = new List<Stuff>()
                    {
                        new Stuff()
                        {
                            Name = "Samsung S20 FE",
                            Price= 1899,
                        },
                        new Stuff()
                        {
                            Name = "Samsung Note 10 Ultra",
                            Price = 2500,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001",

                    }
                }
            };
            return electromarkets;
        }
    }
}
