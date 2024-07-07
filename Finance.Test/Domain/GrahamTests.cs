using Bogus;
using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class GrahamTests
    {
        [Fact]
        public void ShouldPopulateGrahamPropertiesUsingBogus()
        {
            // Arrange
            var faker = new Faker<Graham>()
                .RuleFor(g => g.Kind, f => f.Commerce.ProductMaterial())
                .RuleFor(g => g.Small, f => f.Commerce.ProductAdjective())
                .RuleFor(g => g.Symbol, f => f.Finance.Currency().Code)
                .RuleFor(g => g.Name, f => f.Company.CompanyName())
                .RuleFor(g => g.CompanyName, f => f.Company.CompanyName())
                .RuleFor(g => g.Sector, f => f.Commerce.Department())
                .RuleFor(g => g.Price, f => Math.Round(f.Finance.Amount(0, 1000), 2)) // Valor entre 0 e 1000 com 2 casas decimais
                .RuleFor(g => g.Yield_12m, f => Math.Round(f.Finance.Amount(0, 100), 2)) // Valor entre 0 e 100 com 2 casas decimais
                .RuleFor(g => g.AnnualGrowthRate, f => Math.Round(f.Finance.Amount(0, 50), 2)) // Valor entre 0 e 50 com 2 casas decimais
                .RuleFor(g => g.ReturnRate, f => Math.Round(f.Finance.Amount(0, 20), 2)) // Valor entre 0 e 20 com 2 casas decimais
                .RuleFor(g => g.Result, f => Math.Round(f.Finance.Amount(0, 10000), 2)); // Valor entre 0 e 10000 com 2 casas decimais

            // Act
            var graham = faker.Generate();

            // Assert
            Assert.NotNull(graham);
            Assert.NotNull(graham.Kind);
            Assert.NotNull(graham.Small);
            Assert.NotNull(graham.Symbol);
            Assert.NotNull(graham.Name);
            Assert.NotNull(graham.CompanyName);
            Assert.NotNull(graham.Sector);
            Assert.True(graham.Price >= 0);
            Assert.True(graham.Yield_12m >= 0);
            Assert.True(graham.AnnualGrowthRate >= 0);
            Assert.True(graham.ReturnRate >= 0);
            Assert.True(graham.Result >= 0);

            // Output for demonstration
            Console.WriteLine($"Kind: {graham.Kind}");
            Console.WriteLine($"Small: {graham.Small}");
            Console.WriteLine($"Symbol: {graham.Symbol}");
            Console.WriteLine($"Name: {graham.Name}");
            Console.WriteLine($"CompanyName: {graham.CompanyName}");
            Console.WriteLine($"Sector: {graham.Sector}");
            Console.WriteLine($"Price: {graham.Price}");
            Console.WriteLine($"Yield_12m: {graham.Yield_12m}");
            Console.WriteLine($"AnnualGrowthRate: {graham.AnnualGrowthRate}");
            Console.WriteLine($"ReturnRate: {graham.ReturnRate}");
            Console.WriteLine($"Result: {graham.Result}");
        }

        [Fact]
        public void Todas_As_Propriedades_De_Texto_Devem_Ser_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
            nameof(Graham.Kind),
            nameof(Graham.Small),
            nameof(Graham.Symbol),
            nameof(Graham.Name),
            nameof(Graham.CompanyName),
            nameof(Graham.Sector)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Graham).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        public void Todas_As_Propriedades_Decimais_Devem_Ser_Do_Tipo_Decimal()
        {
            // Arrange
            var decimalProperties = new[]
            {
            nameof(Graham.Price),
            nameof(Graham.Yield_12m),
            nameof(Graham.AnnualGrowthRate),
            nameof(Graham.ReturnRate),
            nameof(Graham.Result)
        };

            // Act & Assert
            foreach (var propertyName in decimalProperties)
            {
                var property = typeof(Graham).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(decimal), property.PropertyType);
            }
        }
    }
}
