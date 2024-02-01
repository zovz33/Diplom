using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;

namespace Diplom.ASPNET.Application.Items.Product.Queries.GetProductById;

public class GetProductByIdQueryResult : IMapWith<Domain.Entities.Product>
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
        profile.CreateMap<Domain.Entities.Product, GetProductByIdQueryResult>()
            .ForMember(GetProductByIdQueryResult => GetProductByIdQueryResult.Name,
                opt => opt.MapFrom(Product => Product.Name))
            .ForMember(GetProductByIdQueryResult => GetProductByIdQueryResult.Description,
                opt => opt.MapFrom(Product => Product.Description))
            .ForMember(GetProductByIdQueryResult => GetProductByIdQueryResult.Quantity,
                opt => opt.MapFrom(Product => Product.Quantity))
            .ForMember(GetProductByIdQueryResult => GetProductByIdQueryResult.Price,
                opt => opt.MapFrom(Product => Product.Price))
            .ForMember(GetProductByIdQueryResult => GetProductByIdQueryResult.Category,
                opt => opt.MapFrom(Product => Product.Category))
            .ForMember(GetProductByIdQueryResult => GetProductByIdQueryResult.ImageUrl,
                opt => opt.MapFrom(Product => Product.ImageUrl));
    }
}