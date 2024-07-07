using Bogus;
using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class FinancialsTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Financials()
        {
            // Arrange
            var fakerDividends = new Faker<Dividends>()
                .RuleFor(d => d.Yield_12m, f => Math.Round(f.Finance.Amount(0, 100), 2)) // Percentual entre 0 e 100 com 2 casas decimais
                .RuleFor(d => d.Yield_12m_sum, f => Math.Round(f.Finance.Amount(0, 10000), 2)); // Soma entre 0 e 10000 com 2 casas decimais

            var fakerFinancials = new Faker<Financials>()
                .RuleFor(f => f.Equity, f => f.Random.Long(0, 1000000)) // Valor patrimonial
                .RuleFor(f => f.Equity_per_share, f => Math.Round(f.Finance.Amount(0, 1000), 2)) // Valor patrimonial por cota
                .RuleFor(f => f.Price_to_book_ratio, f => Math.Round(f.Finance.Amount(0, 10), 2)) // Preço sobre valor patrimonial
                .RuleFor(f => f.Quota_count, f => f.Random.Long(0, 1000000)) // Cotas emitidas
                .RuleFor(f => f.Dividends, f => fakerDividends.Generate()); // Dividends

            // Act
            var financials = fakerFinancials.Generate();

            // Assert
            Assert.NotNull(financials);
            Assert.True(financials.Equity >= 0);
            Assert.True(financials.Equity_per_share >= 0);
            Assert.True(financials.Price_to_book_ratio >= 0);
            Assert.True(financials.Quota_count >= 0);
            Assert.NotNull(financials.Dividends);
            Assert.True(financials.Dividends.Yield_12m >= 0);
            Assert.True(financials.Dividends.Yield_12m_sum >= 0);

            // Output for demonstration
            Console.WriteLine($"Equity: {financials.Equity}");
            Console.WriteLine($"Equity_per_share: {financials.Equity_per_share}");
            Console.WriteLine($"Price_to_book_ratio: {financials.Price_to_book_ratio}");
            Console.WriteLine($"Quota_count: {financials.Quota_count}");
            Console.WriteLine($"Dividends.Yield_12m: {financials.Dividends.Yield_12m}");
            Console.WriteLine($"Dividends.Yield_12m_sum: {financials.Dividends.Yield_12m_sum}");
        }

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
