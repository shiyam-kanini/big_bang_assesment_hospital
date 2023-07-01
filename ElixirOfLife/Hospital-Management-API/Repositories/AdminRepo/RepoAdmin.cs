using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.AdminDto;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Models_Response_.AdminResponses;
using Hospital_Management_API.Repositories.SpecializationRepo;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Hospital_Management_API.Repositories.AdminRepo
{
    public class RepoAdmin : IRepoAdmin
    {
        private readonly Random random= new Random();
        private readonly HospitalDbContext _context;
        public RepoAdmin(HospitalDbContext context)
        {
            _context = context;
        }
        public EnableEmployeeResponse enabled = new EnableEmployeeResponse();
        Employee disabledEmployee = new Employee();
        public AddSpecializationResponse addSpecializationResponse = new AddSpecializationResponse();
        public EmployeeSpecialization employeeSpecialization= new EmployeeSpecialization();
        public async Task<EnableEmployeeResponse> EnableEmployee( EnableEmployeeDto enableEmployee)
        {
            try
            {
                disabledEmployee = await _context.Employees.FindAsync(enableEmployee.EmployeeId);
                if (disabledEmployee == null)
                {
                    AddEnableResponseResponse(false, $"Employee Id {enableEmployee.EmployeeId} Not found", disabledEmployee);
                    return enabled;
                }
                disabledEmployee.isActive = true;disabledEmployee.Role = await _context.Roles.FindAsync(enableEmployee.Role);
                _context.Employees.Update(disabledEmployee);
                await _context.SaveChangesAsync();
                AddEnableResponseResponse(true, $"Employee {disabledEmployee.EmployeeFirstName} {disabledEmployee.EmployeeLastName} is activated", disabledEmployee);
                return enabled;
            }
            catch (Exception ex)
            {
                AddEnableResponseResponse(false, ex.Message, disabledEmployee);
                return enabled;
            }
        }
        public async Task<AddSpecializationResponse> AddSpecialization(AddSpecializationDto addSpecialization)
        {
            try
            {
                Employee employee = await _context.Employees.FindAsync(addSpecialization.EmployeeId);
                Specialization specialization = await _context.Specializations.FindAsync(addSpecialization.SpecializationId);
                if(employee == null)
                {
                    AddSpecializationResponseAdd(false, $"Employee Id {addSpecialization.EmployeeId} Not found", employeeSpecialization);
                    return addSpecializationResponse;
                }
                if(specialization == null)
                {
                    AddSpecializationResponseAdd(false, $"Specialization Id {addSpecialization.SpecializationId} Not found", employeeSpecialization);
                    return addSpecializationResponse;
                }
                var s = await _context.EmployeeSpecialization.Where(x => x.Specialization.SpecializationId.Equals(addSpecialization.SpecializationId) && x.Doctor.EmployeeId.Equals(addSpecialization.EmployeeId)).Select(x => x.Specialization).ToListAsync();
                if(s.Count > 1)
                {
                    AddSpecializationResponseAdd(false, "Employee cannot have the same specialization twice", employeeSpecialization);
                    return addSpecializationResponse;
                }
                AddSpecializationData($"ESID{random.Next(100, 999)}", specialization, employee);
                await _context.EmployeeSpecialization.AddAsync(employeeSpecialization);
                await _context.SaveChangesAsync();
                AddSpecializationResponseAdd(true, $"Specialization {s.Count} has been added to {addSpecialization.EmployeeId}", employeeSpecialization);
                return addSpecializationResponse;
            }
            catch(Exception ex)
            {
                AddSpecializationResponseAdd(false, ex.Message, employeeSpecialization);
                return addSpecializationResponse;
            }
        }
        public void AddSpecializationData(string esId, Specialization specialization, Employee employee)
        {
            employeeSpecialization = new EmployeeSpecialization()
            {
                DSID= esId,
                Doctor = employee,
                Specialization= specialization
            };
        }
        public void AddSpecializationResponseAdd(bool status, string message, EmployeeSpecialization employeeSpec)
        {
            addSpecializationResponse = new AddSpecializationResponse()
            {
                Status = status,
                Message = message,
                EmployeeSpecialization = employeeSpec
            };
        }
        public void AddEnableResponseResponse(bool status, string message, Employee employee)
        {
            enabled = new EnableEmployeeResponse()
            {
                Status = status,
                Message = message,
                UpdatedEmployee= employee
            };
        }
    }
}
