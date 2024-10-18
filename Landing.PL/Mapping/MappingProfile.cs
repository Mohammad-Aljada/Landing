using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;

namespace Landing.PL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {
            //Services
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service , ServiceVM>();
            CreateMap<Service , ServiceDetailsVM>();
            //Sliders
            CreateMap<SliderFormVM, Slider>().ReverseMap();
            CreateMap<Slider, SliderVM>();
            CreateMap<Slider, SliderDetailsVM>();
            //Portfolios
            CreateMap<PortfolioFormVM, Portfolio>().ReverseMap();
            CreateMap<Portfolio, PortfolioVM>();
            CreateMap<Portfolio, PortfolioDetailsVM>();
            //Items
            CreateMap<ItemFormVM, Item>().ReverseMap();
            CreateMap<Item, ItemVM>().ForMember(dest => dest.Portfolios, opt => opt.MapFrom(src => src.Portfolio.Name));
            CreateMap<Item, ItemDetailsVM>().ForMember(dest => dest.Portfolios, opt => opt.MapFrom(src => src.Portfolio.Name));
            //Clients
            CreateMap<ClientFormVM, Client>().ReverseMap();
            CreateMap<Client, ClientVM>();
            CreateMap<Client, ClientDetailsVM>();
            //Skills
            CreateMap<SkillFormVM, Skill>().ReverseMap();
            CreateMap<Skill, SkillVM>();
            CreateMap<Skill, SkillDetailsVM>();
            //Price
            CreateMap<PriceFormVM, Price>().ReverseMap();
            CreateMap<Price, PriceVM>();
            CreateMap<Price, PriceDetailsVM>();
            //Blogs
            CreateMap<BlogFormVM, Blog>().ReverseMap();
            CreateMap<Blog, BlogVM>();
            CreateMap<Blog, BlogDetailsVM>();
        }
    }
}
