using AutoMapper;


namespace SmartEstimate.Models;

public class SmartEstimateMappingProfile : Profile
{
    public SmartEstimateMappingProfile()
    {
        CreateMap<Quote, QuoteView>().ReverseMap();
        CreateMap<Room, RoomView>().ReverseMap();
        CreateMap<Product, ProductView>().ReverseMap();
    }
}
