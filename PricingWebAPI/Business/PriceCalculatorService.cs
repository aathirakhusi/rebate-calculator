using Business.Interface;
using Business.Model;
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
        public PriceModel GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules)
        {
            PriceCalculatorModel priceCalculatorModel;
            priceCalculatorModel = JsonConvert.DeserializeObject<PriceCalculatorModel>(pricingRules);
            PriceModel priceModel = new PriceModel();
            priceModel.SubTotal = GetSubTotal(purchaseModelDto.ProductId, purchaseModelDto.Quantity, priceCalculatorModel.Products);
            return null;

        }
        private static float GetSubTotal(int productId, int quantity, List<ProductModelDto> products)
        {
            var val = products.Count * GetUnitPrice(productId, products);
            return val;
        }
        private static float GetUnitPrice(int productId, List<ProductModelDto> products)
        {

            var val = float.Parse(products[productId].UnitPrice, CultureInfo.InvariantCulture.NumberFormat);
            return val;
        }
    }
}
