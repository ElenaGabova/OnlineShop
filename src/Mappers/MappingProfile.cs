using AutoMapper;
using Domain;
using Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShopWebApp.Areas.Autorization.Models;
using ViewModels;

namespace Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StorageItem, StorageItemViewModel>().ReverseMap();
            CreateMap<Storage, StorageViewModel>().ReverseMap();
            CreateMap<TextPage, TextPageViewModel>().ReverseMap();
            CreateMap<UserDeliveryInfo, UserDeliveryInfoViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<User, RegisterViewModel>().ForMember(x => x.UserName, k => k.MapFrom(u => u.Email)).ReverseMap();
            CreateMap<Product, ProductViewModel>().ForMember(x => x.UploadedFile, k => k.Ignore());
            CreateMap<ProductViewModel, Product>().ForMember(x => x.StorageItems, k => k.Ignore());
            CreateMap<User, IdentityUser>().ForMember(x => x.UserName, k => k.MapFrom(u => u.Email)).ReverseMap();
            CreateMap<UserEntity, IdentityUser>().ReverseMap();
            CreateMap<DanceDirectionUser, DanceDirectionUserViewModel>().ReverseMap();
            CreateMap<DanceDirectionRegistration, DanceDirectionRegistrationViewModel>().ReverseMap();
            CreateMap<DanceDirection, DanceDirectionViewModel>().ReverseMap();
            CreateMap<DanceDirection, DanceDirectionViewModel>().ForMember(x => x.OtherPhotos, k => k.MapFrom(u => u.OtherPhotos.ToList()));
            CreateMap<DanceDirection, DanceDirectionViewModel>().ForMember(x => x.VideoLinks, k => k.MapFrom(u => u.VideoLinks.ToList()));
            CreateMap<DanceDirectionViewModel, DanceDirection>().ForMember(x => x.OtherPhotos, k => k.MapFrom(u => u.OtherPhotos.ToArray()));
            CreateMap<DanceDirectionViewModel, DanceDirection>().ForMember(x => x.VideoLinks, k => k.MapFrom(u => u.VideoLinks.ToArray()));

            CreateMap<StorageItem, StorageItemEntity>().ReverseMap();
            CreateMap<Storage, StorageEntity>().ReverseMap();
            CreateMap<TextPage, TextPageEntity>().ReverseMap();
            CreateMap<UserDeliveryInfo, UserDeliveryInfoEntity>().ReverseMap();
            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Product, ProductEntity>()/*.ForMember(x => x.UploadedFile, k => k.Ignore())*/.ReverseMap();
            CreateMap<DanceDirectionUser, DanceDirectionUserEntity>().ReverseMap();

            CreateMap<DanceDirection, DanceDirectionEntity>()
                .ForMember(x => x.OtherPhotos, k => k.MapFrom(u => u.OtherPhotos))
                .ForMember(x => x.VideoLinks, k => k.MapFrom(u => u.VideoLinks.ToList()));

            CreateMap<DanceDirectionEntity, DanceDirection>()
                .ForMember(x => x.OtherPhotos, k => k.MapFrom(u => u.OtherPhotos.ToArray()))
                .ForMember(x => x.VideoLinks, k => k.MapFrom(u => u.VideoLinks.ToArray())); 

            CreateMap<DanceDirectionRegistration, DanceDirectionRegistrationEntity>()
                .ForMember(x => x.DanceDirectionEntity, k => k.MapFrom(u => u.DanceDirection))
                .ForMember(x => x.DanceDirectionUserEntity, k => k.MapFrom(u => u.DanceDirectionUser));

            CreateMap<DanceDirectionRegistrationEntity, DanceDirectionRegistration>()
                .ForMember(x => x.DanceDirection, k => k.MapFrom(u => u.DanceDirectionEntity))
                .ForMember(x => x.DanceDirectionUser, k => k.MapFrom(u => u.DanceDirectionUserEntity));

        }
    }
}
