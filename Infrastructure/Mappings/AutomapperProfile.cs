using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Producto, ProductoDto>();
        }
    }

}
