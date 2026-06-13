using AutoMapper;
using Fiap.Api.Students.Models;
using Fiap.Api.Students.ViewModel;

namespace Fiap.Api.Students.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RepresentativeModel, RepresentativeViewModel>()
            .ForMember(
                destination => destination.NameRepresentative,
                options => options.MapFrom(source => source.RepresentativeName));

        CreateMap<RepresentativeViewModel, RepresentativeModel>()
            .ForMember(
                destination => destination.RepresentativeName,
                options => options.MapFrom(source => source.NameRepresentative));

        CreateMap<ClientModel, ClientViewModel>()
            .ForMember(
                destination => destination.ClientId,
                options => options.MapFrom(source => source.ClientId)
            );

        CreateMap<ClientViewModel, ClientModel>()
            .ForMember(
                destination => destination.ClientId,
                options => options.MapFrom(source => source.ClientId)
            );
    }
}
