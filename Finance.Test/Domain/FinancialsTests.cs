using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class FinancialsTests
    {
        [Fact]
        public void Todas_As_PropriedadesDo_Tipo_Nullable_Long_Devem_Ser_Do_Tipo_Nullable_Long()
        {
            // Arrange
            var longProperties = new[]
            {
                nameof(Financials.Equity),
                nameof(Financials.Quota_count)
            };

            // Act & Assert
            foreach (var propertyName in longProperties)
            {
                var property = typeof(Financials).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(long?), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_PropriedadesDo_Tipo_Nullable_Decimal_Devem_Ser_Do_Tipo_Nullable_Decimal()
        {
            // Arrange
            var decimalProperties = new[]
            {
                nameof(Financials.Equity_per_share),
                nameof(Financials.Price_to_book_ratio)
            };

            // Act & Assert
            foreach (var propertyName in decimalProperties)
            {
                var property = typeof(Financials).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(decimal?), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_PropriedadesDo_Tipo_Dividends_Devem_Ser_Do_Tipo_Dividends()
        {
            // Arrange
            var property = typeof(Financials).GetProperty(nameof(Financials.Dividends));

            // Act & Assert
            Assert.NotNull(property);
            Assert.Equal(typeof(Dividends), property.PropertyType);
        }

    }
}
