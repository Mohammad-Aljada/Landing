using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.ViewModels;
using Landing.PL.Areas.Dashboard.ViewModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Landing.PL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {
            //Services
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service , ServiceVM>();
            CreateMap<Service , ServiceDetailsVM>();
            CreateMap<Service, ServiceDisplayVM>();

            //Sliders
            CreateMap<SliderFormVM, Slider>().ReverseMap();
            CreateMap<Slider, SliderVM>();
            CreateMap<Slider, SliderDetailsVM>();
            CreateMap<Slider, SliderDisplayVM>();

            //Portfolios
            CreateMap<PortfolioFormVM, Portfolio>().ReverseMap();
            CreateMap<Portfolio, PortfolioVM>();
            CreateMap<Portfolio, PortfolioDetailsVM>();
            CreateMap<Portfolio, PortfolioDisplayVM>();

            //Items
            CreateMap<ItemFormVM, Item>().ReverseMap();
            CreateMap<Item, ItemVM>().ForMember(dest => dest.Portfolios, opt => opt.MapFrom(src => src.Portfolio.Name));
            CreateMap<Item, ItemDetailsVM>().ForMember(dest => dest.Portfolios, opt => opt.MapFrom(src => src.Portfolio.Name));
            CreateMap<Item, ItemDisplayVM>().ForMember(dest => dest.Portfolios, opt => opt.MapFrom(src => src.Portfolio.Name));

            //Clients
            CreateMap<ClientFormVM, Client>().ReverseMap();
            CreateMap<Client, ClientVM>();
            CreateMap<Client, ClientDetailsVM>();
            CreateMap<Client, ClientDisplayVM>();

            //Skills
            CreateMap<SkillFormVM, Skill>().ReverseMap();
            CreateMap<Skill, SkillVM>();
            CreateMap<Skill, SkillDetailsVM>();
            CreateMap<Skill, SkillDisplayVM>();

            //Price
            CreateMap<PriceFormVM, Price>().ReverseMap();
            CreateMap<Price, PriceVM>();
            CreateMap<Price, PriceDetailsVM>();
            CreateMap<Price, PriceDisplayVM>();

            //Blogs
            CreateMap<BlogFormVM, Blog>().ReverseMap();
            CreateMap<Blog, BlogVM>();
            CreateMap<Blog, BlogDetailsVM>();
            CreateMap<Blog, BlogDisplayVM>()
                       .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments)); 
            //Teams
            CreateMap<TeamFormVM, Team>().ReverseMap();
            CreateMap<Team, TeamVM>();
            CreateMap<Team, TeamDetailsVM>();
            CreateMap<Team, TeamDisplayVM>();

            //comments
            CreateMap<CommentVM, Comment>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            //Users
            CreateMap<UserFormVM, ApplicationUser>()
             .ForMember(dest => dest.PriceId, opt => opt.MapFrom(src => src.PriceId)) // Map directly to PriceId
             .ForMember(dest => dest.RoleId, opt => opt.Ignore()) // We'll set this separately in the controller
             .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.ImageName))
             .ReverseMap();
            CreateMap<ApplicationUser, UserVM>();
            CreateMap<ApplicationUser, UserDetailsVM>()
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Name))
                    .ForMember(dest => dest.RoleName, opt => opt.Ignore()); // Handle RoleName separately
        }
    }
}
