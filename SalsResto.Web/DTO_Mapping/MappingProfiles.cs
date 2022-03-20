using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SalsResto.Data.Models;
using SalsResto.Data.ViewModel_DTO;

namespace SalsResto.Web.DTO_Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDTOView>()
                .ForMember(c => c.fullname,
                    opt => opt.MapFrom(x => string.Format($"{x.lastname} ,{x.firstname} { (x.middle.Length>0?x.middle.Substring(0,1).ToUpper().TrimEnd() +".":"")} ")));


            CreateMap<CustomerForCreationViewModel, Customer>();
            CreateMap<CustomerForUpdateViewModel, Customer>();
            CreateMap<CustomerForUpdateViewModel, Customer>().ReverseMap();
        }
    }
}
