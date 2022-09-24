using Business.Helpers;
using Business.Model;
using Business.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rebates
{
    public class CustomerRebateService : IRebate
    {
        private decimal _percentage = 0.0m;
        private List<CustomerRebate> _customerRebates;
        public CustomerRebateService(List<CustomerRebate> customerRebate)
        {
            _customerRebates = customerRebate;
        }
        private decimal CalculateDiscount(ProductWithSubTotal item) => Math.Round((item.SubTotal) * _percentage, 2);


        public IEnumerable<ApplicableRebate> DiscountsApplicable(ProductWithSubTotal product)
        {
            var rebatesApplied = new List<ApplicableRebate>();
            foreach (var customerRebate in _customerRebates)
            {
                if (product.PurchaseModelDto.CustomerId == Convert.ToInt16(customerRebate.Id))
                {
                    _percentage = decimal.Parse(customerRebate.RebatePercent);
                    var discountedData = CalculateDiscount(product);
                    var appliedRebate = new ApplicableRebate
                    {
                        Type =Enums.RebateType.CustomerRebate,
                        Text = $"{product.PurchaseModelDto.ProductId} {_percentage:P0} OFF: - {discountedData.ToCurrencyString()}",
                        GrandTotal = discountedData
                    };

                    rebatesApplied.Add(appliedRebate);

                }
            }
            return rebatesApplied;
        }
    }
}
