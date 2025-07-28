using AutoMapper;
using Renty.Application.DTOs;
using Renty.Domain.Entities;

namespace Renty.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            #region UserMapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDetailDto>()
                  .ForMember(des => des.FullName, 
                  opt => opt.MapFrom(src => src.FirstName+" "+src.LastName))
                  //Email!.Substring(0,src.Email.IndexOf("@"))
                  .ReverseMap();
            #endregion

            #region ProductMapping
             // Map Product to ProductDto (basic info for listing)
            CreateMap<Product, ProductDto>()
            .ForMember(des => des.InterfaceImageUrl, opt => opt.MapFrom(src => src.Images.FirstOrDefault()!.Url))
            .ForMember(des => des.ClientsCount, opt => opt.MapFrom(src => src.Ratings.Count))
            
            .ForMember(des => des.OverallRating,  opt => {
        opt.PreCondition(src => src.Ratings!=null&&src.Ratings.Count!=0);
        opt.MapFrom(src => src.Ratings.Select(r=>r.Value).Average());
    })
            .ReverseMap();

            // Map Product to ProductDetailDto (detailed info)
            CreateMap<Product, ProductDetailDto>().ReverseMap();

            // Map ProductAddDto to Product (used for creation)
            CreateMap<ProductAddDto, Product>()
       .ForMember(des=>des.AddingDate, opt => opt.MapFrom(src => DateTime.Now))
       .ForMember(des=>des.Status, opt => opt.MapFrom(src => "Wating for approval"))
       .ReverseMap();
            // Map ProductUpdateDto to Product (used for updating)
            CreateMap<ProductUpdateDto, Product>()
            .ForMember(des => des.Status, opt => opt.MapFrom(src => "Wating for approval"))
            .ReverseMap();
            
            #endregion


            #region CategoryMapping
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<CategoryAddDto, Category>().ReverseMap();

            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            #endregion


            #region ImageMapping
            CreateMap<Image, ImageDto>().ReverseMap();

            CreateMap<ImageAddDto, Image>().ReverseMap();

            CreateMap<ImageUpdateDto, Image>().ReverseMap();
            #endregion


            #region CountryMapping
            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<CountryAddDto, Country>().ReverseMap();

            CreateMap<CountryUpdateDto, Country>().ReverseMap();
            #endregion


            #region CityMapping
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<CityAddDto, City>().ReverseMap();

            CreateMap<CityUpdateDto, City>().ReverseMap();
            #endregion


            #region AreaMapping
            CreateMap<Area, AreaDto>().ReverseMap();

            CreateMap<AreaAddDto, Area>().ReverseMap();

            CreateMap<AreaUpdateDto, Area>().ReverseMap();
            #endregion


            #region RatingMapping
            CreateMap<Rating, RatingDto>()
            .ForMember(des => des.FullName, 
             opt => opt.MapFrom(src => src.User!.FirstName+" "+src.User!.LastName))
            .ReverseMap();

            CreateMap<RatingAddDto, Rating>()
              .ForMember(des=>des.Datetime, opt => opt.MapFrom(src => DateTime.Now))
              .ReverseMap();

            CreateMap<RatingUpdateDto, Rating>().ReverseMap();
            #endregion
            

            #region RatingMapping
            CreateMap<WishlistUpdateOrCreateDto, Wishlist>().ReverseMap();
            #endregion


    
        }
    }
}
