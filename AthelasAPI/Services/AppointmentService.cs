using AthelasAPI.Entites;
using AthelasAPI.Exceptions;
using AthelasAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AthelasAPI.Services
{
    public interface IAppointmentService
    {
        void Add(AppointmentAddAndUpdateDto addDto);
        void Delete(int id);
        IEnumerable<AppointmentDto> GetAll();
        AppointmentDto GetById(int id);
        void Update(int id, AppointmentAddAndUpdateDto updateModel);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly AthelasDbContext mAthelasDbContext;
        private readonly IMapper mMapper;

        public AppointmentService(AthelasDbContext athelasDbContext, IMapper mapper)
        {
            mAthelasDbContext = athelasDbContext;
            mMapper = mapper;
        }

        public void Add(AppointmentAddAndUpdateDto addDto)
        {
            var entity = mMapper.Map<Appointment>(addDto);
            mAthelasDbContext.Add(entity);
            mAthelasDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = mAthelasDbContext.Appointments.FirstOrDefault(a => a.Id == id);

            if (entity is null)
                throw new NotFoundException("Appointment with provided `id` does not exist!");

            mAthelasDbContext.Appointments.Remove(entity);
            mAthelasDbContext.SaveChanges();
        }

        public AppointmentDto GetById(int id)
        {
            var entity = mAthelasDbContext.Appointments.Include(a => a.Client).Include(a => a.Employee).Include(a => a.Service).FirstOrDefault(a => a.Id == id);

            if (entity is null)
                throw new NotFoundException("Appointment with provided `id` does not exist!");

            return mMapper.Map<AppointmentDto>(entity);
        }

        public IEnumerable<AppointmentDto> GetAll()
        {
            var entities = mAthelasDbContext.Appointments.Include(a => a.Client).Include(a => a.Employee).Include(a => a.Service).ToArray();
            return mMapper.Map<IEnumerable<AppointmentDto>>(entities);
        }

        public void Update(int id, AppointmentAddAndUpdateDto updateModel)
        {
            var entity = mAthelasDbContext.Appointments.FirstOrDefault(a => a.Id == id);

            if (entity is null)
                throw new NotFoundException("Appointment with provided `id` does not exist!");

            entity.ClientId     = updateModel.ClientId;
            entity.EmployeeId   = updateModel.EmployeeId;
            entity.ServiceId    = updateModel.ServiceId;
            entity.Start        = updateModel.Start;
            entity.End          = updateModel.End;

            mAthelasDbContext.SaveChanges();
        }
    }
}
