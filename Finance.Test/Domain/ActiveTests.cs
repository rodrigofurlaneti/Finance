using Bogus;
using Finance.Domain;
using Xunit;

namespace Finance.Tests.Domain
{
    public class ActiveTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Active()
        {
            // Arrange
            var fakerFinancials = new Faker<Financials>()
                .RuleFor(f => f.Equity, f => f.Random.Long())
                .RuleFor(f => f.Equity_per_share, f => f.Random.Decimal())
                .RuleFor(f => f.Price_to_book_ratio, f => f.Random.Decimal())
                .RuleFor(f => f.Quota_count, f => f.Random.Long())
                .RuleFor(f => f.Dividends, f => new Dividends()); // Preencha com regras apropriadas

            var fakerMarketTime = new Faker<MarketTime>()
                .RuleFor(m => m.OpenTime, m => m.Date.Recent().ToString())
                .RuleFor(m => m.CloseTime, m => m.Date.Recent().ToString())
                .RuleFor(m => m.Timezone, m => m.Random.Int());

            var fakerLogo = new Faker<Logo>()
                .RuleFor(l => l.IdLogo, f => f.Random.Guid().ToString())
                .RuleFor(l => l.Small, f => f.Image.PicsumUrl())
                .RuleFor(l => l.Big, f => f.Image.PicsumUrl());

            var fakerActive = new Faker<Active>()
                .RuleFor(a => a.IdActive, f => f.Random.Int())
                .RuleFor(a => a.Kind, f => f.Commerce.ProductMaterial())
                .RuleFor(a => a.Symbol, f => f.Finance.Currency().Code)
                .RuleFor(a => a.Name, f => f.Company.CompanyName())
                .RuleFor(a => a.CompanyName, f => f.Company.CompanyName())
                .RuleFor(a => a.Document, f => f.Random.String2(10))
                .RuleFor(a => a.Description, f => f.Lorem.Paragraph())
                .RuleFor(a => a.Website, f => f.Internet.Url())
                .RuleFor(a => a.Sector, f => f.Commerce.Department())
                .RuleFor(a => a.Financials, f => fakerFinancials.Generate())
                .RuleFor(a => a.Region, f => f.Address.Country())
                .RuleFor(a => a.Currency, f => f.Finance.Currency().Code)
                .RuleFor(a => a.MarketTime, f => fakerMarketTime.Generate())
                .RuleFor(a => a.Logo, f => fakerLogo.Generate())
                .RuleFor(a => a.MarketCap, f => f.Finance.Amount())
                .RuleFor(a => a.Price, f => f.Finance.Amount())
                .RuleFor(a => a.ChangePercent, f => f.Finance.Amount())
                .RuleFor(a => a.ChangePrice, f => f.Finance.Amount())
                .RuleFor(a => a.UpdatedAt, f => f.Date.Past().ToString());

            // Act
            var active = fakerActive.Generate();

            // Assert
            Assert.NotNull(active);
            Assert.NotNull(active.Kind);
            Assert.NotNull(active.Symbol);
            Assert.NotNull(active.Name);
            Assert.NotNull(active.CompanyName);
            Assert.NotNull(active.Document);
            Assert.NotNull(active.Description);
            Assert.NotNull(active.Website);
            Assert.NotNull(active.Sector);
            Assert.NotNull(active.Financials);
            Assert.NotNull(active.Region);
            Assert.NotNull(active.Currency);
            Assert.NotNull(active.MarketTime);
            Assert.NotNull(active.Logo);
            Assert.NotNull(active.UpdatedAt);

            // Output for demonstration
            Console.WriteLine($"IdActive: {active.IdActive}");
            Console.WriteLine($"Kind: {active.Kind}");
            Console.WriteLine($"Symbol: {active.Symbol}");
            Console.WriteLine($"Name: {active.Name}");
            Console.WriteLine($"CompanyName: {active.CompanyName}");
            Console.WriteLine($"Document: {active.Document}");
            Console.WriteLine($"Description: {active.Description}");
            Console.WriteLine($"Website: {active.Website}");
            Console.WriteLine($"Sector: {active.Sector}");
            Console.WriteLine($"Region: {active.Region}");
            Console.WriteLine($"Currency: {active.Currency}");
            Console.WriteLine($"MarketCap: {active.MarketCap}");
            Console.WriteLine($"Price: {active.Price}");
            Console.WriteLine($"ChangePercent: {active.ChangePercent}");
            Console.WriteLine($"ChangePrice: {active.ChangePrice}");
            Console.WriteLine($"UpdatedAt: {active.UpdatedAt}");
        }

        [Fact]
        public void Todas_As_Propriedades_De_Texto_Devem_Ser_Do_Tipo_String()
        {
            // Arrange
            var stringProperties = new[]
            {
            nameof(Active.Kind),
            nameof(Active.Symbol),
            nameof(Active.Name),
            nameof(Active.CompanyName),
            nameof(Active.Document),
            nameof(Active.Description),
            nameof(Active.Website),
            nameof(Active.Sector),
            nameof(Active.Region),
            nameof(Active.Currency),
            nameof(Active.UpdatedAt)
        };

            // Act & Assert
            foreach (var propertyName in stringProperties)
            {
                var property = typeof(Active).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(string), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Int_Devem_Ser_Do_Tipo_Int()
        {
            // Arrange
            var intProperties = new[]
            {
                nameof(Active.IdActive)
            };

            // Act & Assert
            foreach (var propertyName in intProperties)
            {
                var property = typeof(Active).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(int), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Decimais_Devem_Ser_Do_Tipo_Decimal()
        {
            // Arrange
            var decimalProperties = new[]
            {
            nameof(Active.MarketCap),
            nameof(Active.Price),
            nameof(Active.ChangePercent),
            nameof(Active.ChangePrice)
        };

            // Act & Assert
            foreach (var propertyName in decimalProperties)
            {
                var property = typeof(Active).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(decimal), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Financeiras_Devem_Ser_Do_Tipo_Finanças()
        {
            // Arrange
            var financialsProperties = new[]
            {
            nameof(Active.Financials)
        };

            // Act & Assert
            foreach (var propertyName in financialsProperties)
            {
                var property = typeof(Active).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(Financials), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_Logo_Devem_Ser_Do_Tipo_Logo()
        {
            // Arrange
            var financialsProperties = new[]
            {
            nameof(Active.Logo)
        };

            // Act & Assert
            foreach (var propertyName in financialsProperties)
            {
                var property = typeof(Active).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(Logo), property.PropertyType);
            }
        }

        [Fact]
        public void Todas_As_Propriedades_MarketTime_Devem_Ser_Do_Tipo_MarketTime()
        {
            // Arrange
            var financialsProperties = new[]
            {
            nameof(Active.MarketTime)
        };

            // Act & Assert
            foreach (var propertyName in financialsProperties)
            {
                var property = typeof(Active).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(typeof(MarketTime), property.PropertyType);
            }
        }
    }
}
