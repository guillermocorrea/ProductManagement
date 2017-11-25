using AutoMapper;
using ProductManagement.Domain;
using ProductManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.UI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Repository.EF.DataModel.Product, Product>();
            CreateMap<Product, Repository.EF.DataModel.Product>();
        }
    }
}
