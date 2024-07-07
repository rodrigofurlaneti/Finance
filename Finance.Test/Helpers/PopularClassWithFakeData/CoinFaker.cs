using Bogus;
using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Tests.Helpers.PopularClassWithFakeData
{
    public static class CoinFaker
    {
        public static Coin GetCoin()
        {
            var faker = new Faker<Coin>()
                .RuleFor(c => c.Name, f => f.Finance.Currency().Code)
                .RuleFor(c => c.Buy, f => f.Finance.Amount().Scale)
                .RuleFor(c => c.Sell, f => f.PickRandom(f.Finance.Amount(1, 100), (object)null))
                .RuleFor(c => c.Variation, f => f.Random.Double(-10, 10));

            return faker.Generate(); // Gera um objeto do tipo Coin
        }

        public static List<Coin> GetListCoin()
        {
            var faker = new Faker<Coin>()
                .RuleFor(c => c.Name, f => f.Finance.Currency().Code)
                .RuleFor(c => c.Buy, f => f.Finance.Amount().Scale)
                .RuleFor(c => c.Sell, f => f.PickRandom(f.Finance.Amount(1, 100), (object)null))
                .RuleFor(c => c.Variation, f => f.Random.Double(-10, 10));

            return faker.Generate(10); // Gera uma lista do objeto do tipo Coin com 10 itens
        }
    }
}
