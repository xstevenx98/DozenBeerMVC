using AutoMapper;
using Dozen2MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Mapping
{
    public class AutoMapperProfile : Profile
    /*
     looks in the source and target..if the column name is the same then I auto know what your intentions are

     */
    {
        public AutoMapperProfile()
        {
            CreateMap<Dozen2Models.Customer, CustomerVM>();
            CreateMap<CustomerCreateVM, Dozen2Models.Customer>();
            CreateMap<Dozen2Models.Customer, CustomerEditVM>().ReverseMap();
            CreateMap<Dozen2Models.Customer, CustomerDeleteVM>();
            CreateMap<Dozen2Models.Customer, CustomerSearchVM>().ReverseMap();

        }
    }
}
