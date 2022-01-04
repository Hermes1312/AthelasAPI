using AthelasAPI.Entites;
using AthelasAPI.Exceptions;
using AthelasAPI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AthelasAPI.Services
{
    public interface IServiceService
    {
        int Add(ServiceAddAndUpdateDto addDto);
        void Delete(int id);
        ServiceDto GetById(int id);
        void Update(int id, ServiceAddAndUpdateDto updateDto);
        IEnumerable<ServiceDto> GetAll();
    }

    public class ServiceService : IServiceService
    {
        private readonly AthelasDbContext   mAthelasDbContext;
        private readonly IMapper            mMapper;

        public ServiceService(AthelasDbContext athelasDbContext, IMapper mapper)
        {
            mAthelasDbContext   = athelasDbContext;
            mMapper             = mapper;
        }

        public int Add(ServiceAddAndUpdateDto addDto)
        {
            var service = mMapper.Map<Service>(addDto);
            mAthelasDbContext.Services.Add(service);
            mAthelasDbContext.SaveChanges();

            return service.Id;
        }

        public void Delete(int id)
        {
            var service = mAthelasDbContext.Services.FirstOrDefault(c => c.Id == id);

            if (service is null)
                throw new NotFoundException("Service with provided `id` does not exist!");

            mAthelasDbContext.Services.Remove(service);
            mAthelasDbContext.SaveChanges();
        }

        public ServiceDto GetById(int id)
        {
            var service = mAthelasDbContext.Services.FirstOrDefault(c => c.Id == id);

            if (service is null)
                throw new NotFoundException("Service with provided `id` does not exist!");

            return mMapper.Map<ServiceDto>(service);
        }

        public IEnumerable<ServiceDto> GetAll()
        {
            return mMapper.Map<IEnumerable<ServiceDto>>(mAthelasDbContext.Services.ToArray());
        }

        public void Update(int id, ServiceAddAndUpdateDto updateDto)
        {
            var service = mAthelasDbContext.Services.FirstOrDefault(c => c.Id == id);

            if (service is null)
                throw new NotFoundException("Service with provided `id` does not exist!");

            service.Name = updateDto.Name;

            mAthelasDbContext.SaveChanges();
        }
    }
}
