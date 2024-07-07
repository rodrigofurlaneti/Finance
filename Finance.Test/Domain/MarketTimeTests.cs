using Bogus;
using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class MarketTimeTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_MarketTime()
        {
            // Arrange
            var faker = new Faker<MarketTime>()
                .RuleFor(m => m.OpenTime, f => f.Date.Future().ToString("HH:mm")) // Gerando um horário futuro fictício
                .RuleFor(m => m.CloseTime, f => f.Date.Future().ToString("HH:mm")) // Gerando um horário futuro fictício
                .RuleFor(m => m.Timezone, f => f.Random.Int(-12, 14)); // Gerando um fuso horário fictício entre -12 e +14

            // Act
            var marketTime = faker.Generate();

            // Assert
            Assert.NotNull(marketTime);
            Assert.NotNull(marketTime.OpenTime);
            Assert.NotNull(marketTime.CloseTime);
            Assert.InRange(marketTime.Timezone, -12, 14);

            // Output for demonstration
            Console.WriteLine($"OpenTime: {marketTime.OpenTime}");
            Console.WriteLine($"CloseTime: {marketTime.CloseTime}");
            Console.WriteLine($"Timezone: {marketTime.Timezone}");
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Texto_String()
        {
            // Arrange
            var stringProperties = new[]
            {
                nameof(MarketTime.OpenTime),
                nameof(MarketTime.CloseTime)
            };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(MarketTime).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_Número_Inteiro_Int()
        {
            // Arrange
            var intProperties = new[]
            {
                nameof(MarketTime.Timezone)
            };

            // Act & Assert
            foreach (var propertyName in intProperties)
            {
                var property = typeof(MarketTime).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(int), property.PropertyType);
            }
        }
    }
    }
