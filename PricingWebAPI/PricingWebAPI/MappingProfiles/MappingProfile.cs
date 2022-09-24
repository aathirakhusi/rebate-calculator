using AutoMapper;
using Business.Model;
using PricingWebAPI.Model;

namespace PricingWebAPI.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PurchaseModelDto, PurchaseModel>().ReverseMap();

        }
    }
}
