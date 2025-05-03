using AutoMapper;
using Business.Dtos.Requests.Brand;
using Business.Dtos.Responses.Brand;
using Entities;

namespace Business.Profiles.Brands;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandRequest>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, GetListBrandResponse>().ReverseMap();
    }
}
