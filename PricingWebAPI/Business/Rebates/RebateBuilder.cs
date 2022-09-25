using Business.Rebate;

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
