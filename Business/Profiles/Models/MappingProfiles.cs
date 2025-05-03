using AutoMapper;
using Business.Dtos.Requests.Model;
using Business.Dtos.Responses.Model;
using Entities;

namespace Business.Profiles.Models;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelRequest>().ReverseMap();
        CreateMap<Model, CreatedModelResponse>().ReverseMap();
        CreateMap<Model, GetListModelResponse>().ReverseMap();
    }
}
