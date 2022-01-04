using AthelasAPI.Entites;
using AthelasAPI.Exceptions;
using AthelasAPI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AthelasAPI.Services
{
    public interface IEmployeeService
    {
        int Add(EmployeeAddDto addDto);
        void Delete(int employee);
        EmployeeDto GetById(int employeeId);
        void Update(int id, EmployeeUpdateDto updateDto);
        IEnumerable<EmployeeDto> GetAll();
        IEnumerable<AppointmentDto> GetAppointments(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly AthelasDbContext   mAthelasDbContext;
        private readonly IMapper            mMapper;

        public EmployeeService(AthelasDbContext athelasDbContext, IMapper mapper)
        {
            mAthelasDbContext   = athelasDbContext;
            mMapper             = mapper;
        }

        public int Add(EmployeeAddDto addDto)
        {
            var employee = mMapper.Map<Employee>(addDto);
            mAthelasDbContext.Employees.Add(employee);
            mAthelasDbContext.SaveChanges();

            return employee.Id;
        }

        public void Delete(int id)
        {
            var employee = mAthelasDbContext.Employees.FirstOrDefault(c => c.Id == id);

            if (employee is null)
                throw new NotFoundException("Employee with provided `id` does not exist!");

            mAthelasDbContext.Employees.Remove(employee);
            mAthelasDbContext.SaveChanges();
        }

        public EmployeeDto GetById(int id)
        {
            var employee = mAthelasDbContext.Employees.FirstOrDefault(c => c.Id == id);

            if (employee is null)
                throw new NotFoundException("Employee with provided `id` does not exist!");

            return mMapper.Map<EmployeeDto>(employee);
        }

        
        public IEnumerable<EmployeeDto> GetAll()
        {
            return mMapper.Map<IEnumerable<EmployeeDto>>(mAthelasDbContext.Employees.ToArray());
        } 
        
        public IEnumerable<AppointmentDto> GetAppointments(int id)
        {
            return mMapper.Map<IEnumerable<AppointmentDto>>(mAthelasDbContext.Appointments.Where(a => a.EmployeeId == id).ToArray());
        }

        public void Update(int id, EmployeeUpdateDto updateDto)
        {
            var employee = mAthelasDbContext.Employees.FirstOrDefault(c => c.Id == id);


            if (employee is null)
                throw new NotFoundException("Employee with provided `id` does not exist!");


            employee.FirstName    = updateDto.FirstName;
            employee.LastName     = updateDto.LastName;

            mAthelasDbContext.SaveChanges();
        }
    }
}
