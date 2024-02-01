using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Application.Lists.Queries.GetProductList;

public class ProductLookupDto : IMapWith<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string Category { get; set; } 
    public string ImageUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductLookupDto>()
            .ForMember(ProductDto => ProductDto.Id,
                opt => opt.MapFrom(Product => Product.Id))
            .ForMember(ProductDto => ProductDto.Name,
                opt => opt.MapFrom(Product => Product.Name))
            .ForMember(ProductDto => ProductDto.Category,
                opt => opt.MapFrom(Product => Product.Category))
            .ForMember(ProductDto => ProductDto.Description,
                opt => opt.MapFrom(Product => Product.Description))
            .ForMember(ProductDto => ProductDto.Price,
                opt => opt.MapFrom(Product => Product.Price))
            .ForMember(ProductDto => ProductDto.Quantity,
                opt => opt.MapFrom(Product => Product.Quantity))
            .ForMember(ProductDto => ProductDto.ImageUrl,
                opt => opt.MapFrom(Product => Product.ImageUrl))
            ;
    }
}