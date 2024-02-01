using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.Product.Commands.UpdateProduct;

namespace Diplom.ASPNET.API.Models.Products;

public class UpdateProductDto : IMapWith<UpdateProductCommand>
{ 
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string Category { get; set; } 
    public string ImageUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
            .ForMember(ProductCommand => ProductCommand.Name, opt =>
                opt.MapFrom(ProductDto => ProductDto.Name))
            .ForMember(ProductCommand => ProductCommand.Description, opt =>
                opt.MapFrom(ProductDto => ProductDto.Description))
            .ForMember(ProductCommand => ProductCommand.Price, opt =>
                opt.MapFrom(ProductDto => ProductDto.Price))
            .ForMember(ProductCommand => ProductCommand.Quantity, opt =>
                opt.MapFrom(ProductDto => ProductDto.Quantity))
            .ForMember(ProductCommand => ProductCommand.Category, opt =>
                opt.MapFrom(ProductDto => ProductDto.Category))
            .ForMember(ProductCommand => ProductCommand.ImageUrl, opt =>
                opt.MapFrom(ProductDto => ProductDto.ImageUrl));
    }
}