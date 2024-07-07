using Bogus;
using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Tests.Helpers.PopularClassWithFakeData
{
    public static class BarsiFaker
    {
        public static Barsi GetBarsi()
        {
            var faker = new Faker<Barsi>()
           .RuleFor(b => b.Kind, f => f.Commerce.ProductMaterial())
           .RuleFor(b => b.Small, f => f.Image.PicsumUrl())
           .RuleFor(b => b.Symbol, f => f.Finance.Currency().Code)
           .RuleFor(b => b.Name, f => f.Company.CompanyName())
           .RuleFor(b => b.CompanyName, f => f.Company.CompanyName())
           .RuleFor(b => b.Sector, f => f.Commerce.Department())
           .RuleFor(b => b.Price, f => f.Random.Decimal(10, 500))
           .RuleFor(b => b.Yield_12m, f => f.Random.Decimal(-5, 5))
           .RuleFor(b => b.Result, f => f.Random.Decimal(1000, 100000));

            return faker.Generate();
        }

        public static List<Barsi> GetListBarsi()
        {
            var faker = new Faker<Barsi>()
           .RuleFor(b => b.Kind, f => f.Commerce.ProductMaterial())
           .RuleFor(b => b.Small, f => f.Image.PicsumUrl())
           .RuleFor(b => b.Symbol, f => f.Finance.Currency().Code)
           .RuleFor(b => b.Name, f => f.Company.CompanyName())
           .RuleFor(b => b.CompanyName, f => f.Company.CompanyName())
           .RuleFor(b => b.Sector, f => f.Commerce.Department())
           .RuleFor(b => b.Price, f => f.Random.Decimal(10, 500))
           .RuleFor(b => b.Yield_12m, f => f.Random.Decimal(-5, 5))
           .RuleFor(b => b.Result, f => f.Random.Decimal(1000, 100000));

            return faker.Generate(10);
        }
    }
}
