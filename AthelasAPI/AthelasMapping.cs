using AthelasAPI.Entites;
using AthelasAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI
{
    public class AthelasMapping : Profile
    {
        public AthelasMapping()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(x => x.ClientFullName,   y => y.MapFrom(z => $"{z.Client.FirstName} {z.Client.LastName}"))
                .ForMember(x => x.EmployeeFullName, y => y.MapFrom(z => $"{z.Employee.FirstName} {z.Employee.LastName}"))
                .ForMember(x => x.ServiceName,      y => y.MapFrom(z => $"{z.Service.Name}"));

            CreateMap<AppointmentAddAndUpdateDto, Appointment>();

            CreateMap<Client, ClientDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => $"{z.FirstName} {z.LastName}"));

            
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => $"{z.FirstName} {z.LastName}"));

            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceAddAndUpdateDto, Service>();
            
            //Adds
            CreateMap<ClientAddDto, Client>().ReverseMap();
            CreateMap<EmployeeAddDto, Employee>().ReverseMap();
        }
    }
}
