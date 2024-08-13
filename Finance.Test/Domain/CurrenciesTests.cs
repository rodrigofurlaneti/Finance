using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class CurrenciesTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Currencies()
        {
            // Arrange
            var coinFaker = new Faker<Coin>()
                .RuleFor(c => c.Name, f => f.Commerce.ProductName()) // Utilizando Commerce.ProductName() para gerar nomes fictícios
                .RuleFor(c => c.Buy, f => Math.Round(f.Random.Double(1, 10000), 2)) // Valor entre 1 e 10000 com 2 casas decimais
                .RuleFor(c => c.Sell, f => (object)Math.Round(f.Random.Double(1, 10000), 2)) // Valor entre 1 e 10000 com 2 casas decimais
                .RuleFor(c => c.Variation, f => Math.Round(f.Random.Double(-10, 10), 2)); // Valor entre -10 e 10 com 2 casas decimais

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

            // Act
            var currencies = currenciesFaker.Generate();

            // Assert
            Assert.NotNull(currencies);
            Assert.NotNull(currencies.source);
            Assert.NotNull(currencies.USD);
            Assert.NotNull(currencies.EUR);
            Assert.NotNull(currencies.GBP);
            Assert.NotNull(currencies.ARS);
            Assert.NotNull(currencies.CAD);
            Assert.NotNull(currencies.AUD);
            Assert.NotNull(currencies.JPY);
            Assert.NotNull(currencies.CNY);
            Assert.NotNull(currencies.BTC);

            // Output for demonstration
            Console.WriteLine($"Source: {currencies.source}");
            Console.WriteLine($"USD: {currencies.USD.Name} - Buy: {currencies.USD.Buy} - Sell: {currencies.USD.Sell} - Variation: {currencies.USD.Variation}");
            Console.WriteLine($"EUR: {currencies.EUR.Name} - Buy: {currencies.EUR.Buy} - Sell: {currencies.EUR.Sell} - Variation: {currencies.EUR.Variation}");
            Console.WriteLine($"GBP: {currencies.GBP.Name} - Buy: {currencies.GBP.Buy} - Sell: {currencies.GBP.Sell} - Variation: {currencies.GBP.Variation}");
            Console.WriteLine($"ARS: {currencies.ARS.Name} - Buy: {currencies.ARS.Buy} - Sell: {currencies.ARS.Sell} - Variation: {currencies.ARS.Variation}");
            Console.WriteLine($"CAD: {currencies.CAD.Name} - Buy: {currencies.CAD.Buy} - Sell: {currencies.CAD.Sell} - Variation: {currencies.CAD.Variation}");
            Console.WriteLine($"AUD: {currencies.AUD.Name} - Buy: {currencies.AUD.Buy} - Sell: {currencies.AUD.Sell} - Variation: {currencies.AUD.Variation}");
            Console.WriteLine($"JPY: {currencies.JPY.Name} - Buy: {currencies.JPY.Buy} - Sell: {currencies.JPY.Sell} - Variation: {currencies.JPY.Variation}");
            Console.WriteLine($"CNY: {currencies.CNY.Name} - Buy: {currencies.CNY.Buy} - Sell: {currencies.CNY.Sell} - Variation: {currencies.CNY.Variation}");
            Console.WriteLine($"BTC: {currencies.BTC.Name} - Buy: {currencies.BTC.Buy} - Sell: {currencies.BTC.Sell} - Variation: {currencies.BTC.Variation}");
        }

        [Fact]
        public void Todas_As_Propriedades_De_Texto_Devem_Ser_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
                nameof(Currencies.source)
            };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Currencies).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Coin_Devem_Ser_Do_Tipo_Coin()
        {
            // Arrange
            var coinProperties = new[]
            {
            nameof(Currencies.USD),
            nameof(Currencies.EUR),
            nameof(Currencies.GBP),
            nameof(Currencies.ARS),
            nameof(Currencies.CAD),
            nameof(Currencies.AUD),
            nameof(Currencies.JPY),
            nameof(Currencies.CNY),
            nameof(Currencies.BTC)
        };

            // Act & Assert
            foreach (var propertyName in coinProperties)
            {
                var property = typeof(Currencies).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(Coin), property.PropertyType);
            }
        }
    }
}
