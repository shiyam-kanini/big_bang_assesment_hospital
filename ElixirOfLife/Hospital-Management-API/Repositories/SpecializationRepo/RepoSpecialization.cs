using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital_Management_API.Repositories.SpecializationRepo
{
    public class RepoSpecialization : IRepoSpecialization
    {
        private readonly Random random= new Random();
        private readonly HospitalDbContext _context;
        public RepoSpecialization(HospitalDbContext context) 
        {
            _context = context;
        }
        public Specialization specialization = new Specialization();
        public List<Specialization> specializations = new List<Specialization>();
        public SpecializationResponse specializationResponse = new SpecializationResponse();
        public Role role = new Role();
        public async Task<SpecializationResponse> DeleteSpecialization(string specializationId)
        {
            try
            {
                specialization = await _context.Specializations.FindAsync(specializationId);
                specializations.Add(specialization);
                if(specialization == null)
                {
                    AddSpecializationResponse(false, $"Specialization {specializationId} Not found", specializations);
                    return specializationResponse;
                }
                await _context.Specializations.Where(x => x.SpecializationId.Equals(specializationId)).ExecuteDeleteAsync();
                await _context.SaveChangesAsync(); 
                AddSpecializationResponse(true, $"1 record deleted", specializations.ToList());
                return specializationResponse;
            }
            catch (Exception ex)
            {
                AddSpecializationResponse(false, ex.Message, specializations.ToList());
                return specializationResponse;
            }
        }

        public async Task<SpecializationResponse> GetSpecializations()
        {
            try
            {
                specializations = await _context.Specializations.ToListAsync();
                if(specializations.Count <= 0)
                {
                    AddSpecializationResponse(false, "0 Records Found", specializations);
                    return specializationResponse;
                }
                AddSpecializationResponse(true, $"{specializations.Count} records found", specializations);
                return specializationResponse;
            }
            catch(Exception ex)
            {
                AddSpecializationResponse(false, ex.Message, specializations);
                return specializationResponse;
            }
        }

        public async Task<SpecializationResponse> GetSpecializationById(string id)
        {
            try
            {
                specialization = await _context.Specializations.FindAsync(id);
                specializations.Add(specialization);
                if (specialization == null)
                {
                    AddSpecializationResponse(false, "0 Records Found", specializations);
                    return specializationResponse;
                }
                AddSpecializationResponse(true, $"{specializations.Count} records found", specializations);
                return specializationResponse;
            }
            catch (Exception ex)
            {
                AddSpecializationResponse(false, ex.Message, specializations);
                return specializationResponse;
            }
        }

        public async Task<SpecializationResponse> InsertSpecialization(SpecializationDTO specializationData)
        {
            try
            {
                role = await _context.Roles.FindAsync(specializationData.Role);
                AddSpecialization($"SPID{random.Next(100, 999)}", specializationData, role);
                specializations.Add(specialization);
                await _context.Specializations.AddAsync(specialization);
                await _context.SaveChangesAsync();
                AddSpecializationResponse(true, $"1 record Added", specializations);
                return specializationResponse;
            }
            catch (Exception ex)
            {
                AddSpecializationResponse(false, ex.StackTrace, specializations);
                return specializationResponse;
            }
        }

        public async Task<SpecializationResponse> UpdateSpecialization(string specializationId, SpecializationDTO specializationData)
        {
            try
            {
                role = await _context.Roles.FindAsync(specializationData.Role);
                AddSpecialization(specializationId, specializationData, role);
                specializations.Add(specialization);
                _context.Specializations.Update(specialization);
                await _context.SaveChangesAsync();
                AddSpecializationResponse(true, $"1 record Updated", specializations.ToList());
                return specializationResponse;
            }
            catch (Exception ex)
            {
                AddSpecializationResponse(false, ex.Message, specializations.ToList());
                return specializationResponse;
            }
        }
        public void AddSpecialization(string id, SpecializationDTO specializationData, Role role) 
        {
            specialization = new Specialization
            {
                SpecializationId = id,
                SpecializationName = specializationData.SpecializationName,
                SpecializationDescription = specializationData.SpecializationDescription,
                Role = role
            };
        }
        public void AddSpecializationResponse(bool status, string message, List<Specialization> specializations) 
        {
            specializationResponse = new SpecializationResponse()
            {
                Status = status,
                Message = message,
                Specializations = specializations
            };
        }
    }
}
