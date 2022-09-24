using Business.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rebates
{
    public class RebateBuilder
    {
        public static IEnumerable<IRebate> CreateRebates(RebateTypes rebateTypes)
        {
            return new List<IRebate>
            {
                new CustomerRebateService(rebateTypes.CustomerRebate),
                new MonthRebateService(rebateTypes.MonthRebate),
                new VolumeRebateService(rebateTypes.VolumeRebate),
                new ProductRebateService(rebateTypes.ProductRebate)
            };
        }
    }
}
