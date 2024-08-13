using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class TrendTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Trend()
        {
            // Arrange
            var coinFaker = new Faker<Coin>()
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Buy, f => Math.Round(f.Random.Double(1, 10000), 2))
                .RuleFor(c => c.Sell, f => (object)Math.Round(f.Random.Double(1, 10000), 2))
                .RuleFor(c => c.Variation, f => Math.Round(f.Random.Double(-10, 10), 2));

            var currenciesFaker = new Faker<Currencies>()
                .RuleFor(c => c.source, f => f.Internet.DomainName())
                .RuleFor(c => c.USD, f => coinFaker.Generate())
                .RuleFor(c => c.EUR, f => coinFaker.Generate())
                .RuleFor(c => c.GBP, f => coinFaker.Generate())
                .RuleFor(c => c.ARS, f => coinFaker.Generate())
                .RuleFor(c => c.CAD, f => coinFaker.Generate())
                .RuleFor(c => c.AUD, f => coinFaker.Generate())
                .RuleFor(c => c.JPY, f => coinFaker.Generate())
                .RuleFor(c => c.CNY, f => coinFaker.Generate())
                .RuleFor(c => c.BTC, f => coinFaker.Generate());

            var stockExchangeFaker = new Faker<StockExchange>()
                .RuleFor(s => s.Id, f => f.Random.Int(1, 1000))
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Location, f => f.Address.City())
                .RuleFor(s => s.Points, f => Math.Round(f.Random.Double(1000, 30000), 2))
                .RuleFor(s => s.Variation, f => Math.Round(f.Random.Double(-5, 5), 2))
                .RuleFor(s => s.IsActive, f => f.Random.Bool());

            var stocksFaker = new Faker<Stocks>()
                .RuleFor(s => s.IBOVESPA, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.IFIX, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.NASDAQ, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.DOWJONES, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.CAC, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.NIKKEI, f => stockExchangeFaker.Generate());

            var resultsSuccessFaker = new Faker<ResultsSuccess>()
                .RuleFor(r => r.Currencies, f => currenciesFaker.Generate())
                .RuleFor(r => r.Stocks, f => stocksFaker.Generate())
                .RuleFor(r => r.Available_sources, f => f.Make(3, () => f.Internet.DomainName()))
                .RuleFor(r => r.Taxes, f => f.Make(3, () => (object)f.Random.Int(1, 100)));

            var trendFaker = new Faker<Trend>()
                .RuleFor(t => t.By, f => f.Person.FullName)
                .RuleFor(t => t.Valid_key, f => f.Random.Bool())
                .RuleFor(t => t.Results, f => resultsSuccessFaker.Generate())
                .RuleFor(t => t.Execution_time, f => Math.Round(f.Random.Double(0, 10), 2))
                .RuleFor(t => t.From_cache, f => f.Random.Bool());

            // Act
            var trend = trendFaker.Generate();

            // Assert
            Assert.NotNull(trend);
            Assert.NotNull(trend.By);
            Assert.NotNull(trend.Results);
            Assert.InRange(trend.Execution_time, 0, 10);
            Assert.NotNull(trend.From_cache);

            // Output for demonstration
            Console.WriteLine($"By: {trend.By}");
            Console.WriteLine($"Valid_key: {trend.Valid_key}");
            Console.WriteLine($"Results: {trend.Results.Currencies.source}");
            Console.WriteLine($"Execution_time: {trend.Execution_time}");
            Console.WriteLine($"From_cache: {trend.From_cache}");
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Bool()
        {
            // Arrange
            var boolProperties = new[]
            {
            nameof(Trend.Valid_key),
            nameof(Trend.From_cache)
        };

            // Act & Assert
            foreach (var propertyName in boolProperties)
            {
                var property = typeof(Trend).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(bool), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Double()
        {
            // Arrange
            var doubleProperties = new[]
            {
            nameof(Trend.Execution_time)
        };

            // Act & Assert
            foreach (var propertyName in doubleProperties)
            {
                var property = typeof(Trend).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(double), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
            nameof(Trend.By)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Trend).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_ResultsSuccess()
        {
            // Arrange
            var propertyName = nameof(Trend.Results);

            // Act
            var property = typeof(Trend).GetProperty(propertyName);

            // Assert
            Assert.NotNull(property);
            Assert.Equal(typeof(ResultsSuccess), property.PropertyType);
        }
    }
}
