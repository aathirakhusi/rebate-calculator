﻿using Business.Interface;
using Business.Model;
using Business.Rebates;
using Newtonsoft.Json;

namespace Business
{
    public class PriceCalculatorService : IPriceCalculatorService
    {

        public ApplicableRebate GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules)
        {
            PriceCalculatorModel priceCalculatorModel;
            priceCalculatorModel = JsonConvert.DeserializeObject<PriceCalculatorModel>(pricingRules);
            PurchaseWithSubTotal productWithSubTotal = new PurchaseWithSubTotal();
            productWithSubTotal.PurchaseModelDto = purchaseModelDto;
            productWithSubTotal.SubTotal = GetSubTotal(purchaseModelDto.ProductId, purchaseModelDto.Quantity, priceCalculatorModel.Products);
            RebateService rebateService = new(RebateBuilder.CreateRebates(priceCalculatorModel.RebateTypes), productWithSubTotal);
            var calculatedRebates = GetRebateWithLessGrandTotal(rebateService.GetApplicableRebates(purchaseModelDto));
            return calculatedRebates;

        }
        private static decimal GetSubTotal(int productId, int quantity, List<ProductModelDto> products)
        {
            return products.Count * GetUnitPrice(productId, products);
        }
        private static decimal GetUnitPrice(int productId, List<ProductModelDto> products)
        {
            foreach (var unitPrice in from product in products
                                      where Convert.ToUInt32(product.Id) == productId
                                      let unitPrice = product.UnitPrice
                                      select unitPrice)
            {
                return decimal.Parse(Convert.ToString(unitPrice));
            }

            return 0;
        }
        private static ApplicableRebate GetRebateWithLessGrandTotal(List<ApplicableRebate> applicableRebates)
        {
            return applicableRebates.Where(c => c.GrandTotal > 0)
                .OrderBy(c => c.GrandTotal)
                .First();
        }

    }
}
