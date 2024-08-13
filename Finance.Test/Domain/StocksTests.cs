using Bogus;
using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Finance.Tests.Domain
{
    public class StocksTests
    {
        [Fact]
        public void Deve_Verificar_As_Propriedades_Do_Tipo_StockExchange()
        {
            // Arrange
            var stockExchangeType = typeof(StockExchange);
            var properties = new[]
            {
            nameof(Stocks.IBOVESPA),
            nameof(Stocks.IFIX),
            nameof(Stocks.NASDAQ),
            nameof(Stocks.DOWJONES),
            nameof(Stocks.CAC),
            nameof(Stocks.NIKKEI)
        };

            // Act & Assert
            foreach (var propertyName in properties)
            {
                var property = typeof(Stocks).GetProperty(propertyName);
                Assert.NotNull(property);
                Assert.Equal(stockExchangeType, property.PropertyType);
            }
        }

        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_Stock()
        {
            // Arrange
            var stockExchangeFaker = new Faker<StockExchange>()
                .RuleFor(s => s.Id, f => f.Random.Int(1, 1000))
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Location, f => f.Address.City())
                .RuleFor(s => s.Points, f => Math.Round(f.Random.Double(1000, 30000), 2))
                .RuleFor(s => s.Variation, f => Math.Round(f.Random.Double(-5, 5), 2))
                .RuleFor(s => s.IsActive, f => f.Random.Bool());

            var stocksFaker = new Faker<Stocks>()
                .RuleFor(s => s.IBOVESPA, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.IFIX, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.NASDAQ, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.DOWJONES, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.CAC, f => stockExchangeFaker.Generate())
                .RuleFor(s => s.NIKKEI, f => stockExchangeFaker.Generate());

            // Act
            var stocks = stocksFaker.Generate();

            // Assert
            Assert.NotNull(stocks);
            Assert.NotNull(stocks.IBOVESPA);
            Assert.NotNull(stocks.IFIX);
            Assert.NotNull(stocks.NASDAQ);
            Assert.NotNull(stocks.DOWJONES);
            Assert.NotNull(stocks.CAC);
            Assert.NotNull(stocks.NIKKEI);

            // Output for demonstration
            Console.WriteLine($"IBOVESPA: {stocks.IBOVESPA.Name} - Location: {stocks.IBOVESPA.Location} - Points: {stocks.IBOVESPA.Points}");
            Console.WriteLine($"IFIX: {stocks.IFIX.Name} - Location: {stocks.IFIX.Location} - Points: {stocks.IFIX.Points}");
            Console.WriteLine($"NASDAQ: {stocks.NASDAQ.Name} - Location: {stocks.NASDAQ.Location} - Points: {stocks.NASDAQ.Points}");
            Console.WriteLine($"DOWJONES: {stocks.DOWJONES.Name} - Location: {stocks.DOWJONES.Location} - Points: {stocks.DOWJONES.Points}");
            Console.WriteLine($"CAC: {stocks.CAC.Name} - Location: {stocks.CAC.Location} - Points: {stocks.CAC.Points}");
            Console.WriteLine($"NIKKEI: {stocks.NIKKEI.Name} - Location: {stocks.NIKKEI.Location} - Points: {stocks.NIKKEI.Points}");
        }
    }
}
