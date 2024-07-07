using Bogus;
using Finance.Domain;

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
        public void Todas_As_Propriedades_De_Tipo_Texto_Não_Devem_Aceitar_Valor_Nulo()
        {
            // Arrange
            var logo = new Logo();

            // Act
            // Assign null values to the properties
            Action act1 = () => logo.IdLogo = null;
            Action act2 = () => logo.Small = null;
            Action act3 = () => logo.Big = null;

            // Assert
            Assert.Throws<ArgumentNullException>(act1);
            Assert.Throws<ArgumentNullException>(act2);
            Assert.Throws<ArgumentNullException>(act3);
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
