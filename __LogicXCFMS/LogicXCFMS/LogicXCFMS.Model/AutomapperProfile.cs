using AutoMapper;
using LogicXCFMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Model
{
    public class AutomapperProfile:AutoMapper.Profile
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Role, RoleModel>().ReverseMap();
                config.CreateMap<Company, CompanyModel>().ReverseMap();
                config.CreateMap<Users, UserModel>().ReverseMap();
                config.CreateMap<Customers, CustomerModel>().ReverseMap();
                config.CreateMap<CustomerModel, Customers>().ReverseMap();
            });
        }
    }//end class
}
