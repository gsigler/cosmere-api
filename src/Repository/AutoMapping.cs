using AutoMapper;
public class AutoMapping : Profile
{
    public const string baseUrl = "https://localhost:7071";
    public AutoMapping()
    {
        CreateMap<API.Cosmere.Data.Model.Planet, API.Cosmere.Repository.DTO.Planet>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/planets/{src.ID}/"));

        CreateMap<API.Cosmere.Data.Model.System, API.Cosmere.Repository.DTO.System>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/systems/{src.ID}/"))
            .ForMember(dest => dest.Planets, act => act.MapFrom(src => src.Planets.Select(x => $"{baseUrl}/planets/{x.ID}/")));

        CreateMap<API.Cosmere.Data.Model.Realm, API.Cosmere.Repository.DTO.Realm>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/realms/{src.ID}/"));
    }
}