using AutoMapper;
using Company.DAL.Entities;
using Company.PL.Models;

namespace Company.PL.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile(){
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }
    }
}
