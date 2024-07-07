using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service.Interface
{
    public interface ICalculationOfTheBarsiService
    {
        IEnumerable<Barsi> GetCalculationOfTheBarsi(IEnumerable<Active> model, IEnumerable<Barsi> result);
        Task<IEnumerable<Barsi>> GetCalculationOfTheBarsiAsync(IEnumerable<Active> model, IEnumerable<Barsi> result);
    }
}
