using API.Data.Cosmere.Config;
using AutoMapper;
using Microsoft.Extensions.Options;

public class OneMapperToRuleThemAll : Profile
{

    public OneMapperToRuleThemAll()
    {

    }
    public OneMapperToRuleThemAll(IOptions<AppConfig> config)
    {
        _config = config.Value;
        CreateMap<API.Cosmere.Data.Model.Planet, API.Cosmere.Repository.DTO.Planet>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/planets/{src.Id}/"))
            .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{_config.BaseUrl}/books/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.System, API.Cosmere.Repository.DTO.System>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/systems/{src.Id}/"))
            .ForMember(dest => dest.Planets, act => act.MapFrom(src => src.Planets.Select(x => $"{_config.BaseUrl}/planets/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.Realm, API.Cosmere.Repository.DTO.Realm>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/realms/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Person, API.Cosmere.Repository.DTO.Person>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/people/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Magic, API.Cosmere.Repository.DTO.Magic>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/magics/{src.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Shard, API.Cosmere.Repository.DTO.Shard>()
                    .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/shards/{src.Id}/"))
                    .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{_config.BaseUrl}/books/{x.Id}/")))
                    .ForMember(dest => dest.Magics, act => act.MapFrom(src => src.Magics.Select(x => $"{_config.BaseUrl}/magics/{x.Id}/")))
                    .ForMember(dest => dest.Slivers, act => act.MapFrom(src => src.Slivers.Select(x => $"{_config.BaseUrl}/people/{x.Id}/")))
                    .ForMember(dest => dest.Planets, act => act.MapFrom(src => src.Planets.Select(x => $"{_config.BaseUrl}/planets/{x.Id}/")))
                    .ForMember(dest => dest.Vessel, act => act.MapFrom(src => $"{_config.BaseUrl}/people/{src.Vessel.Id}/"));

        CreateMap<API.Cosmere.Data.Model.Author, API.Cosmere.Repository.DTO.Author>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/authors/{src.Id}/"))
            .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{_config.BaseUrl}/books/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.Illustrator, API.Cosmere.Repository.DTO.Illustrator>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/illustrators/{src.Id}/"))
            .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books.Select(x => $"{_config.BaseUrl}/books/{x.Id}/")));

        CreateMap<API.Cosmere.Data.Model.Book, API.Cosmere.Repository.DTO.Book>()
            .ForMember(dest => dest.Url, act => act.MapFrom(src => $"{_config.BaseUrl}/books/{src.Id}/"))
            .ForMember(dest => dest.Planets, act => act.MapFrom(src => src.Planets.Select(x => $"{_config.BaseUrl}/planets/{x.Id}/")))
            .ForMember(dest => dest.Authors, act => act.MapFrom(src => src.Authors.Select(x => $"{_config.BaseUrl}/authors/{x.Id}/")))
            .ForMember(dest => dest.Illustrators, act => act.MapFrom(src => src.Illustrators.Select(x => $"{_config.BaseUrl}/illustrators/{x.Id}/")))
            .ForMember(dest => dest.FollowedBy, act => act.MapFrom(src => src.FollowedBy != null ? $"{_config.BaseUrl}/books/{src.FollowedBy.Id}/" : null))
            .ForMember(dest => dest.PrecededBy, act => act.MapFrom(src => src.PrecededBy != null ? $"{_config.BaseUrl}/books/{src.PrecededBy.Id}/" : null));
    }

    public class UrlConverter : ITypeConverter<int, string>
    {
        private AppConfig _config;
        public OneMapperToRuleThemAll(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public string Convert(int source, string destination, ResolutionContext context)
        {
            return $"{_config.BaseUrl}/realms/{src.Id}/";
            throw new NotImplementedException();
        }
    }
}