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

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            PurchaseModel purchaseModel = new PurchaseModel();
            purchaseModel.CustomerId = 332;
            purchaseModel.Quantity = 1;
            purchaseModel.ProductId = 1;
            purchaseModel.DateOfPurchase = DateTime.Now;
            var _mappedUser = _mapper.Map<PurchaseModelDto>(purchaseModel);
            _priceCalculatorService.GenerateBill(_mappedUser,GetRebateRules());

            return Ok(1);
        }
        private static string GetRebateRules()
        {
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            using (StreamReader r = new StreamReader(filePath +"\\RebateRules.json"))
            {
                return r.ReadToEnd();
            }
        }
    }
}