using Business.Interface;
using Business.Model;
using Business.Rebates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        public ProductWithSubTotal GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules)
        {
            PriceCalculatorModel priceCalculatorModel;
            priceCalculatorModel = JsonConvert.DeserializeObject<PriceCalculatorModel>(pricingRules);
            ProductWithSubTotal productWithSubTotal = new ProductWithSubTotal();
            productWithSubTotal.PurchaseModelDto = purchaseModelDto;
            productWithSubTotal.SubTotal = GetSubTotal(purchaseModelDto.ProductId, purchaseModelDto.Quantity, priceCalculatorModel.Products);
            RebateBuilder rebateBuilder = new RebateBuilder();
            RebateService rebateService = new RebateService(RebateBuilder.CreateRebates(priceCalculatorModel.RebateTypes),productWithSubTotal);
            rebateService.CalculateRebate(purchaseModelDto);
            return null;

        }
        private static decimal GetSubTotal(int productId, int quantity, List<ProductModelDto> products)
        {
            var val = products.Count * GetUnitPrice(productId, products);
            return decimal.Parse( Convert.ToString(val));
        }
        private static float GetUnitPrice(int productId, List<ProductModelDto> products)
        {

            var val = float.Parse(products[productId].UnitPrice, CultureInfo.InvariantCulture.NumberFormat);
            return val;
        }
    }
}
