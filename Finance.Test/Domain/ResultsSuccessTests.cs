using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class ResultsSuccessTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_ResultsSuccess()
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

            // Act
            var resultsSuccess = resultsSuccessFaker.Generate();

            // Assert
            Assert.NotNull(resultsSuccess);
            Assert.NotNull(resultsSuccess.Currencies);
            Assert.NotNull(resultsSuccess.Stocks);
            Assert.NotNull(resultsSuccess.Available_sources);
            Assert.NotEmpty(resultsSuccess.Available_sources);
            Assert.NotNull(resultsSuccess.Taxes);
            Assert.NotEmpty(resultsSuccess.Taxes);

            // Output for demonstration
            Console.WriteLine($"Source: {resultsSuccess.Currencies.source}");
            Console.WriteLine($"USD: {resultsSuccess.Currencies.USD.Name} - Buy: {resultsSuccess.Currencies.USD.Buy} - Sell: {resultsSuccess.Currencies.USD.Sell} - Variation: {resultsSuccess.Currencies.USD.Variation}");
            Console.WriteLine($"Available sources: {string.Join(", ", resultsSuccess.Available_sources)}");
            Console.WriteLine($"Taxes: {string.Join(", ", resultsSuccess.Taxes)}");
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Lista_De_Texto_Strings()
        {
            // Arrange
            var stringListProperties = new[]
            {
            nameof(ResultsSuccess.Available_sources)
        };

            // Act & Assert
            foreach (var propertyName in stringListProperties)
            {
                var property = typeof(ResultsSuccess).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(List<string>), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Lista_De_Objetos_Object()
        {
            // Arrange
            var objectListProperties = new[]
            {
            nameof(ResultsSuccess.Taxes)
        };

            // Act & Assert
            foreach (var propertyName in objectListProperties)
            {
                var property = typeof(ResultsSuccess).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(List<object>), property.PropertyType);
            }
        }
    }
}
