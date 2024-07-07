using Bogus;
using Finance.Domain;

namespace Finance.Tests.Helpers.PopularClassWithFakeData
{
    public static class ActiveFaker
    {
        public static Active GetActive()
        {
            // Configurando o Faker para a classe Active
            var faker = new Faker<Active>()
                .RuleFor(a => a.IdActive, f => f.Random.Int(1, 1000))
                .RuleFor(a => a.Kind, f => f.Commerce.ProductMaterial())
                .RuleFor(a => a.Symbol, f => f.Finance.Currency().Code)
                .RuleFor(a => a.Name, f => f.Company.CompanyName())
                .RuleFor(a => a.CompanyName, f => f.Company.CompanyName())
                .RuleFor(a => a.Document, f => f.Commerce.Product())
                .RuleFor(a => a.Description, f => f.Lorem.Paragraph())
                .RuleFor(a => a.Website, f => f.Internet.Url())
                .RuleFor(a => a.Sector, f => f.Commerce.Department())
                .RuleFor(a => a.Financials, f => new Financials
                {
                    Equity = f.Random.Long(1000000, 100000000),
                    Equity_per_share = f.Random.Decimal(10, 500),
                    Price_to_book_ratio = f.Random.Decimal(0.5M, 5.0M),
                    Quota_count = f.Random.Long(1000, 1000000),
                    Dividends = new Dividends
                    {
                        Yield_12m = f.Random.Decimal(0.01M, 0.10M),
                        Yield_12m_sum = f.Random.Decimal(1000M, 100000M)
                    }
                })
                .RuleFor(a => a.Region, f => f.Address.Country())
                .RuleFor(a => a.Currency, f => f.Finance.Currency().Code)
                .RuleFor(a => a.MarketTime, f => new MarketTime
                {
                    OpenTime = f.Date.Past().ToString("HH:mm"),
                    CloseTime = f.Date.Future().ToString("HH:mm"),
                    Timezone = f.PickRandom(-12, 14)
                })
                .RuleFor(a => a.Logo, f => new Logo
                {
                    IdLogo = f.Random.Guid().ToString(),
                    Small = f.Image.PicsumUrl(100, 100),
                    Big = f.Image.PicsumUrl(500, 500)
                })
                .RuleFor(a => a.MarketCap, f => f.Random.Decimal(1_000_000, 1_000_000_000))
                .RuleFor(a => a.Price, f => f.Random.Decimal(10, 500))
                .RuleFor(a => a.ChangePercent, f => f.Random.Decimal(-5, 5))
                .RuleFor(a => a.ChangePrice, f => f.Random.Decimal(-50, 50))
                .RuleFor(a => a.UpdatedAt, f => f.Date.Recent().ToString("yyyy-MM-ddTHH:mm:ssZ"));

            // Gerar um objeto Active falso
            return faker.Generate();
        }

        public static List<Active> GetListActive()
        {
            var faker = new Faker<Active>()
                        .RuleFor(a => a.IdActive, f => f.Random.Int(1, 1000))
                        .RuleFor(a => a.Kind, f => f.Commerce.ProductMaterial())
                        .RuleFor(a => a.Symbol, f => f.Finance.Currency().Code)
                        .RuleFor(a => a.Name, f => f.Company.CompanyName())
                        .RuleFor(a => a.CompanyName, f => f.Company.CompanyName())
                        .RuleFor(a => a.Document, f => f.Commerce.Product())
                        .RuleFor(a => a.Description, f => f.Lorem.Paragraph())
                        .RuleFor(a => a.Website, f => f.Internet.Url())
                        .RuleFor(a => a.Sector, f => f.Commerce.Department())
                        .RuleFor(a => a.Financials, f => new Financials
                        {
                            Equity = f.Random.Long(1000000, 100000000),
                            Equity_per_share = f.Random.Decimal(10, 500),
                            Price_to_book_ratio = f.Random.Decimal(0.5M, 5.0M),
                            Quota_count = f.Random.Long(1000, 1000000),
                            Dividends = new Dividends
                            {
                                Yield_12m = f.Random.Decimal(0.01M, 0.10M),
                                Yield_12m_sum = f.Random.Decimal(1000M, 100000M)
                            }
                        })
                        .RuleFor(a => a.Region, f => f.Address.Country())
                        .RuleFor(a => a.Currency, f => f.Finance.Currency().Code)
                        .RuleFor(a => a.MarketTime, f => new MarketTime
                        {
                            OpenTime = f.Date.Past().ToString("HH:mm"),
                            CloseTime = f.Date.Future().ToString("HH:mm"),
                            Timezone = f.PickRandom(-12, 14)
                        })
                        .RuleFor(a => a.Logo, f => new Logo
                        {
                            IdLogo = f.Random.Guid().ToString(),
                            Small = f.Image.PicsumUrl(100, 100),
                            Big = f.Image.PicsumUrl(500, 500)
                        })
                        .RuleFor(a => a.MarketCap, f => f.Random.Decimal(1_000_000, 1_000_000_000))
                        .RuleFor(a => a.Price, f => f.Random.Decimal(10, 500))
                        .RuleFor(a => a.ChangePercent, f => f.Random.Decimal(-5, 5))
                        .RuleFor(a => a.ChangePrice, f => f.Random.Decimal(-50, 50))
                        .RuleFor(a => a.UpdatedAt, f => f.Date.Recent().ToString("yyyy-MM-ddTHH:mm:ssZ"));

            return faker.Generate(10); // Gerar uma lista de 3 itens

        }
    }
}
