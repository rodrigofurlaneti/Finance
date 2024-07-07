﻿using Finance.Domain;
using Finance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service.Implementation
{
    public class CalculationOfTheBarsiService : ICalculationOfTheBarsiService
    {
        public IEnumerable<Barsi> GetCalculationOfTheBarsi(IEnumerable<Active> model, IEnumerable<Barsi> result)
        {
            foreach (var item in model)
            {
                if (item.Price != 0)
                {
                    if (item.Financials.Dividends.Yield_12m != 0)
                    {
                        result.ToList().Add(new Barsi
                        {
                            Kind = item.Kind,
                            Small = item.Logo.Small,
                            Symbol = item.Symbol,
                            Name = item.Name,
                            CompanyName = item.CompanyName,
                            Sector = item.Sector,
                            Price = item.Price,
                            Yield_12m = item.Financials.Dividends.Yield_12m_sum,
                        });
                    }
                }
            }

            result = result.Select(p => new Barsi
            {
                Kind = p.Kind,
                Small = p.Small,
                Symbol = p.Symbol,
                Name = p.Name,
                CompanyName = p.CompanyName,
                Sector = p.Sector,
                Price = p.Price,
                Yield_12m = p.Yield_12m,
                Result = (p.Yield_12m / p.Price) * 100
            }).OrderByDescending(p => p.Result).ToList();

            return result;
        }

        public async Task<IEnumerable<Barsi>> GetCalculationOfTheBarsiAsync(IEnumerable<Active> model, IEnumerable<Barsi> result)
        {
            return await Task.Run(() =>
            {
                foreach (var item in model)
                {
                    if (item.Price != 0)
                    {
                        if (item.Financials.Dividends.Yield_12m != 0)
                        {
                            result.ToList().Add(new Barsi
                            {
                                Kind = item.Kind,
                                Small = item.Logo.Small,
                                Symbol = item.Symbol,
                                Name = item.Name,
                                CompanyName = item.CompanyName,
                                Sector = item.Sector,
                                Price = item.Price,
                                Yield_12m = item.Financials.Dividends.Yield_12m_sum,
                            });
                        }
                    }
                }

                result = result.Select(p => new Barsi
                {
                    Kind = p.Kind,
                    Small = p.Small,
                    Symbol = p.Symbol,
                    Name = p.Name,
                    CompanyName = p.CompanyName,
                    Sector = p.Sector,
                    Price = p.Price,
                    Yield_12m = p.Yield_12m,
                    Result = (p.Yield_12m / p.Price) * 100
                }).OrderByDescending(p => p.Result).ToList();

                return result;
            });
        }
    }
}