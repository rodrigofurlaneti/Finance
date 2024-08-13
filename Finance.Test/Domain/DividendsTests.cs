using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class DividendsTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Dividends()
        {
            // Arrange
            var faker = new Faker<Dividends>()
                .RuleFor(d => d.Yield_12m, f => Math.Round(f.Random.Decimal(0, 100), 2)) // Percentual entre 0 e 100 com 2 casas decimais
                .RuleFor(d => d.Yield_12m_sum, f => Math.Round(f.Finance.Amount(0, 10000), 2)); // Soma entre 0 e 10000 com 2 casas decimais

            // Act
            var dividends = faker.Generate();

            // Assert
            Assert.NotNull(dividends);
            Assert.True(dividends.Yield_12m >= 0 && dividends.Yield_12m <= 100);
            Assert.True(dividends.Yield_12m_sum >= 0 && dividends.Yield_12m_sum <= 10000);

            // Output for demonstration
            Console.WriteLine($"Yield_12m: {dividends.Yield_12m}");
            Console.WriteLine($"Yield_12m_sum: {dividends.Yield_12m_sum}");
        }

        [Fact]
        public void Todas_As_Propriedades_Decimais_Devem_Ser_Do_Tipo_Decimal()
        {
            // Arrange
            var decimalProperties = new[]
            {
            nameof(Dividends.Yield_12m),
            nameof(Dividends.Yield_12m_sum)
        };

            // Act & Assert
            foreach (var propertyName in decimalProperties)
            {
                var property = typeof(Dividends).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(decimal), property.PropertyType);
            }
        }
    }
}
