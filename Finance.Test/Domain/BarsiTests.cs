using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class BarsiTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Barsi()
        {
            // Arrange
            var faker = new Faker<Barsi>()
                .RuleFor(b => b.Kind, f => f.Commerce.ProductMaterial())
                .RuleFor(b => b.Small, f => f.Commerce.ProductAdjective())
                .RuleFor(b => b.Symbol, f => f.Finance.Currency().Code)
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(b => b.CompanyName, f => f.Company.CompanyName())
                .RuleFor(b => b.Sector, f => f.Commerce.Department())
                .RuleFor(b => b.Price, f => f.Finance.Amount())
                .RuleFor(b => b.Yield_12m, f => f.Finance.Amount())
                .RuleFor(b => b.Result_Month, f => f.Finance.Amount())
                .RuleFor(b => b.Result_Year, f => f.Finance.Amount());

            // Act
            var barsi = faker.Generate();

            // Assert
            Assert.NotNull(barsi);
            Assert.NotNull(barsi.Kind);
            Assert.NotNull(barsi.Small);
            Assert.NotNull(barsi.Symbol);
            Assert.NotNull(barsi.Name);
            Assert.NotNull(barsi.CompanyName);
            Assert.NotNull(barsi.Sector);
            Assert.True(barsi.Price > 0);
            Assert.True(barsi.Yield_12m > 0);
            Assert.True(barsi.Result_Month > 0);
            Assert.True(barsi.Result_Year > 0);

            // Output for demonstration
            Console.WriteLine($"Kind: {barsi.Kind}");
            Console.WriteLine($"Small: {barsi.Small}");
            Console.WriteLine($"Symbol: {barsi.Symbol}");
            Console.WriteLine($"Name: {barsi.Name}");
            Console.WriteLine($"CompanyName: {barsi.CompanyName}");
            Console.WriteLine($"Sector: {barsi.Sector}");
            Console.WriteLine($"Price: {barsi.Price}");
            Console.WriteLine($"Yield_12m: {barsi.Yield_12m}");
            Console.WriteLine($"Result_Month: {barsi.Result_Month}");
            Console.WriteLine($"Result_Year: {barsi.Result_Year}");
        }

        [Fact]
        public void Todas_As_Propriedades_De_Texto_Devem_Ser_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
            nameof(Barsi.Kind),
            nameof(Barsi.Small),
            nameof(Barsi.Symbol),
            nameof(Barsi.Name),
            nameof(Barsi.CompanyName),
            nameof(Barsi.Sector)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Barsi).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Decimais_Devem_Ser_Do_Tipo_Decimal()
        {
            // Arrange
            var decimalProperties = new[]
            {
                nameof(Barsi.Price),
                nameof(Barsi.Yield_12m),
                nameof(Barsi.Result_Month),
                nameof(Barsi.Result_Year),
            };

            // Act & Assert
            foreach (var propertyName in decimalProperties)
            {
                var property = typeof(Barsi).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(decimal), property.PropertyType);
            }
        }

    }
}
