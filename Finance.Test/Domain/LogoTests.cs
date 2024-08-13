using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class LogoTests
    {
        [Fact]
        public void Todas_As_Propriedades_De_Texto_Devem_Ser_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
            nameof(Logo.IdLogo),
            nameof(Logo.Small),
            nameof(Logo.Big)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Logo).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Logo()
        {
            // Arrange
            var faker = new Faker<Logo>()
                .RuleFor(l => l.IdLogo, f => f.Random.Guid().ToString())
                .RuleFor(l => l.Small, f => f.Image.PicsumUrl())
                .RuleFor(l => l.Big, f => f.Image.PicsumUrl());

            // Act
            var logo = faker.Generate();

            // Assert
            Assert.NotNull(logo.IdLogo);
            Assert.NotNull(logo.Small);
            Assert.NotNull(logo.Big);

            Console.WriteLine($"IdLogo: {logo.IdLogo}");
            Console.WriteLine($"Small: {logo.Small}");
            Console.WriteLine($"Big: {logo.Big}");
        }


    }
}
