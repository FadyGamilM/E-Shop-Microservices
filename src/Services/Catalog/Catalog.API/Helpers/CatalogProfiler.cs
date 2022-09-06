using AutoMapper;
using Catalog.API.DTOs;
using Catalog.API.Entities;

namespace Catalog.API.Helpers
{
   public class CatalogProfiler : Profile
   {
      public CatalogProfiler()
      {
         CreateMap<CreateProductDto, Product>();
         CreateMap<Product, CreateProductDto>();
         CreateMap<UpdateProductDto, Product>();
         CreateMap<Product, UpdateProductDto>();
      }
   }
}