using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModel;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));

            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));


            this.CreateMap<Product, ListAllProductsByProductTypeService>();

            this.CreateMap<Product, ListAllModelServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
              .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
        }
    }
}
