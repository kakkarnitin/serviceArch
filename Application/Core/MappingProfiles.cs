using System;
using API.Models.ProductOptions;
using Application.Models.Product;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ViewProduct>();
            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateProduct, Product>();

            CreateMap<ProductOptions, ViewProductOption>();
            CreateMap<CreateProductOption, ProductOptions>();
            CreateMap<UpdateProductOption, ProductOptions>();
        }
    }
}
