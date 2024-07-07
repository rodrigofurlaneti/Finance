using Bogus;
using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class StockExchangeTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_StockExchange()
        {
            // Arrange
            var faker = new Faker<StockExchange>()
                .RuleFor(s => s.Id, f => f.Random.Int(1, 1000))
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Location, f => f.Address.City())
                .RuleFor(s => s.Points, f => Math.Round(f.Random.Double(1000, 30000), 2))
                .RuleFor(s => s.Variation, f => Math.Round(f.Random.Double(-5, 5), 2))
                .RuleFor(s => s.IsActive, f => f.Random.Bool());

            // Act
            var stockExchange = faker.Generate();

            // Assert
            Assert.NotNull(stockExchange);
            Assert.NotEmpty(stockExchange.Name);
            Assert.NotEmpty(stockExchange.Location);
            Assert.InRange(stockExchange.Id, 1, 1000);
            Assert.InRange(stockExchange.Points, 1000, 30000);
            Assert.InRange(stockExchange.Variation, -5, 5);

            // Output for demonstration
            Console.WriteLine($"Id: {stockExchange.Id}");
            Console.WriteLine($"Name: {stockExchange.Name}");
            Console.WriteLine($"Location: {stockExchange.Location}");
            Console.WriteLine($"Points: {stockExchange.Points}");
            Console.WriteLine($"Variation: {stockExchange.Variation}");
            Console.WriteLine($"IsActive: {stockExchange.IsActive}");
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Bool()
        {
            // Arrange
            var boolProperties = new[]
            {
            nameof(StockExchange.IsActive)
        };

            // Act & Assert
            foreach (var propertyName in boolProperties)
            {
                var property = typeof(StockExchange).GetProperty(propertyName);
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
            nameof(StockExchange.Points),
            nameof(StockExchange.Variation)
        };

            // Act & Assert
            foreach (var propertyName in doubleProperties)
            {
                var property = typeof(StockExchange).GetProperty(propertyName);
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
            nameof(StockExchange.Name),
            nameof(StockExchange.Location)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(StockExchange).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Int()
        {
            // Arrange
            var intProperties = new[]
            {
            nameof(StockExchange.Id)
        };

            // Act & Assert
            foreach (var propertyName in intProperties)
            {
                var property = typeof(StockExchange).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(int), property.PropertyType);
            }
        }
    }
}
