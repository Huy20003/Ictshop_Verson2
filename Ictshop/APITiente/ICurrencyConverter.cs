using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ictshop.APITiente
{
    public interface ICurrencyConverter
    {
        
    Task<decimal> ConvertVNDToUSD(decimal amount);
    }
}
