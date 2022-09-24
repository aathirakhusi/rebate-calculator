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
            CreateMap<ApplicableRebate,RebatePriceResponseModel>()
                .ForMember(
                    dest => dest.ActualCost,
                    opt => opt.MapFrom(src => $"{src.PurchaseDetails.SubTotal}")
                )
                .ForMember(
                    dest => dest.AppliedDiscountType,
                    opt => opt.MapFrom(src => $"{src.Type}")
                )
                .ForMember(
                    dest => dest.DiscountText,
                    opt => opt.MapFrom(src => $"{src.Text}")
                )
                .ForMember(
                    dest => dest.GrandTotal,
                    opt => opt.MapFrom(src => $"{src.GrandTotal}")
                )
                .ForMember(
                    dest => dest.CustomerId,
                    opt => opt.MapFrom(src => $"{src.PurchaseDetails.PurchaseModelDto.CustomerId}")
                )
                .ForMember(
                    dest => dest.DateOfPurchase,
                    opt => opt.MapFrom(src => $"{src.PurchaseDetails.PurchaseModelDto.DateOfPurchase}")
                )

                .ForMember(
                    dest => dest.TotalUnits,
                    opt => opt.MapFrom(src => src.PurchaseDetails.PurchaseModelDto.Quantity)
                );

        }
    }
}
