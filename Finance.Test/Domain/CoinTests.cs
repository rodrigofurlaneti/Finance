using Bogus;
using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class CoinTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Coin()
        {
            // Arrange
            var faker = new Faker<Coin>()
                .RuleFor(c => c.Name, f => f.Commerce.ProductName()) // Utilizando Commerce.ProductName() para gerar nomes fictícios
                .RuleFor(c => c.Buy, f => Math.Round(f.Random.Double(1, 10000), 2)) // Valor entre 1 e 10000 com 2 casas decimais
                .RuleFor(c => c.Sell, f => (object)Math.Round(f.Random.Double(1, 10000), 2)) // Valor entre 1 e 10000 com 2 casas decimais
                .RuleFor(c => c.Variation, f => Math.Round(f.Random.Double(-10, 10), 2)); // Valor entre -10 e 10 com 2 casas decimais

            // Act
            var coin = faker.Generate();

            // Assert
            Assert.NotNull(coin);
            Assert.NotNull(coin.Name);
            Assert.True(coin.Buy >= 1 && coin.Buy <= 10000);
            Assert.NotNull(coin.Sell);
            Assert.True((double)coin.Sell >= 1 && (double)coin.Sell <= 10000);
            Assert.True(coin.Variation >= -10 && coin.Variation <= 10);

            // Output for demonstration
            Console.WriteLine($"Name: {coin.Name}");
            Console.WriteLine($"Buy: {coin.Buy}");
            Console.WriteLine($"Sell: {coin.Sell}");
            Console.WriteLine($"Variation: {coin.Variation}");
        }
            [Fact]
        public void Todas_As_Propriedades_De_Texto_Devem_Ser_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
                nameof(Coin.Name)
            };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Coin).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_De_Objeto_Devem_Ser_Do_Tipo_Objeto()
        {
            // Arrange
            var stringProperties = new[]
            {
            nameof(Coin.Sell)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Coin).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(object), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Double_Devem_Ser_Do_Tipo_Double()
        {
            // Arrange
            var doubleProperties = new[]
            {
            nameof(Coin.Buy),
            nameof(Coin.Variation)
        };

            // Act & Assert
            foreach (var propertyName in doubleProperties)
            {
                var property = typeof(Coin).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(double), property.PropertyType);
            }
        }
    }
}
