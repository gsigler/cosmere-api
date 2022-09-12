using AutoMapper;
public class AutoMapping : Profile
{
    public const string baseUrl = "https://localhost:7071/api";
    public AutoMapping()
    {
        CreateMap<API.Cosmere.Data.Model.Planet, API.Cosmere.Repository.DTO.Planet>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/planets/{src.Id}/"))
            .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{baseUrl}/books/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.System, API.Cosmere.Repository.DTO.System>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/systems/{src.Id}/"))
            .ForMember(dest => dest.Planets, act => act.MapFrom(src => src.Planets.Select(x => $"{baseUrl}/planets/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.Realm, API.Cosmere.Repository.DTO.Realm>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/realms/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Person, API.Cosmere.Repository.DTO.Person>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/people/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Magic, API.Cosmere.Repository.DTO.Magic>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/magics/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Shard, API.Cosmere.Repository.DTO.Shard>()
                    .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/shards/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Author, API.Cosmere.Repository.DTO.Author>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/authors/{src.Id}/"))
            .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{baseUrl}/books/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.Illustrator, API.Cosmere.Repository.DTO.Illustrator>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/illustrators/{src.Id}/"))
            .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{baseUrl}/books/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.Book, API.Cosmere.Repository.DTO.Book>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{baseUrl}/books/{src.Id}/"))
            .ForMember(dest => dest.Planets, act => act.MapFrom(src => src.Planets.Select(x => $"{baseUrl}/planets/{x.Id}/")))
            .ForMember(dest => dest.Authors, act => act.MapFrom(src => src.Authors.Select(x => $"{baseUrl}/authors/{x.Id}/")))
            .ForMember(dest => dest.Illustrators, act => act.MapFrom(src => src.Illustrators.Select(x => $"{baseUrl}/illustrators/{x.Id}/")))
            .ForMember(dest => dest.FollowedBy, act => act.MapFrom(src => src.FollowedBy != null ? $"{baseUrl}/books/{src.FollowedBy.Id}/" : null))
            .ForMember(dest => dest.PrecededBy, act => act.MapFrom(src => src.PrecededBy != null ? $"{baseUrl}/books/{src.PrecededBy.Id}/" : null));
    }
}