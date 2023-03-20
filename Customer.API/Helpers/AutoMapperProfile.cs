namespace Customer.API.Helpers;

using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CustomerDetails, CustomerDetailsModel>().ReverseMap();
        CreateMap<CustomerDetails, CustomerDetailsModel>();
    }
}
