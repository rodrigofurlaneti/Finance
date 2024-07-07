using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class GrahamTests
    {
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
