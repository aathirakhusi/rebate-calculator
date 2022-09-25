using AutoMapper;
using Business;
using Business.Interface;
using Business.Model;
using Microsoft.AspNetCore.Mvc;
using PricingWebAPI.Model;

namespace PricingWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        private readonly ILogger<CalculatorController> _logger;
        public readonly IMapper _mapper;
        private readonly IPriceCalculatorService _priceCalculatorService;

        public CalculatorController(ILogger<CalculatorController> logger, IMapper mapper, IPriceCalculatorService priceCalculatorService)
        {
            _logger = logger;
            _mapper = mapper;
            _priceCalculatorService = priceCalculatorService;
        }

        [HttpPost(Name = "CalculatePrice")]
        public async Task<IActionResult> Get(PurchaseModel purchaseModel)
        {
            try
            {
                var _mappedUser = _mapper.Map<PurchaseModelDto>(purchaseModel);
                var result = _priceCalculatorService.GenerateBill(_mappedUser, GetRebateRules());

                return Ok(GetResponseModel(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }
        private static string GetRebateRules()
        {
            try
            {
                string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                using (StreamReader r = new StreamReader(filePath + "\\RebateRules.json"))
                {
                    return r.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new FileNotFoundException();
            }
        }
        private static RebatePriceResponseModel GetResponseModel(ApplicableRebate result)
        {
            RebatePriceResponseModel rebatePriceResponseModel = new();
            rebatePriceResponseModel.ActualCost = result.PurchaseDetails.SubTotal;
            rebatePriceResponseModel.AppliedDiscountType = result.Type.ToString();
            rebatePriceResponseModel.DiscountText = result.Text;
            rebatePriceResponseModel.GrandTotal = result.GrandTotal;
            rebatePriceResponseModel.CustomerId = result.PurchaseDetails.PurchaseModelDto.CustomerId;
            rebatePriceResponseModel.TotalUnits = result.PurchaseDetails.PurchaseModelDto.Quantity;
            rebatePriceResponseModel.DateOfPurchase = result.PurchaseDetails.PurchaseModelDto.DateOfPurchase;
            return rebatePriceResponseModel;
        }
    }
}