﻿using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObject;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig:Profile
    {
        public MappingConfig() { 
            CreateMap<Product,ProductVO>().ReverseMap();
        
        }

    }
}
