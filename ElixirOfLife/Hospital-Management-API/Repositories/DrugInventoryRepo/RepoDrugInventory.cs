using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_API.Repositories.DrugInventoryRepo
{
    public class RepoDrugInventory : IRepoDrugInventory
    {
        private readonly Random random = new();
        private readonly HospitalDbContext _context;
        public RepoDrugInventory(HospitalDbContext context)
        {
            _context = context;
        }
        List<DrugInventory> drugs = new List<DrugInventory>();
        DrugInventory drug = new DrugInventory();
        DrugInventoryResponse drugInventoryResponse = new DrugInventoryResponse();
        public async Task<DrugInventoryResponse> DeleteDrug(string id)
        {
            try
            {
                drug = await _context.DrugInventory.FindAsync(id);
                drugs.Add(drug);
                if (drugs.Count <= 0)
                {
                    AddResponse(false, $"Drug {id} Not available", drugs);
                    return drugInventoryResponse;
                }
                await _context.DrugInventory.Where(x => x.DrugId.Equals(id)).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                AddResponse(true, $"{drugs.Count} record deleted", drugs);
                return drugInventoryResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, drugs);
                return drugInventoryResponse;
            }
        }

        public async Task<DrugInventoryResponse> GetDrugById(string id)
        {
            try
            {
                drug = await _context.DrugInventory.FindAsync(id);
                drugs.Add(drug);
                if (drugs.Count <= 0)
                {
                    AddResponse(false, "No Drugs Available to Display", drugs);
                    return drugInventoryResponse;
                }
                AddResponse(true, $"{drugs.Count} record found", drugs);
                return drugInventoryResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, drugs);
                return drugInventoryResponse;
            }
        }

        public async Task<DrugInventoryResponse> GetDrugs()
        {
            try
            {
                drugs = await _context.DrugInventory.ToListAsync();
                if (drugs.Count <= 0)
                {
                    AddResponse(false, "No Drugs Available to Display", drugs);
                    return drugInventoryResponse;
                }
                AddResponse(true, $"{drugs.Count} records found", drugs);
                return drugInventoryResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, drugs);
                return drugInventoryResponse;
            }
        }

        public async Task<DrugInventoryResponse> PostDrug(DrugInventoryDTO drugData)
        {
            try
            {
                AddDrug($"DRUGID{random.Next(100, 999)}", drugData);
                _context.DrugInventory.AddAsync(drug);
                await _context.SaveChangesAsync();
                AddResponse(true, $"1 record Inserted", drugs);
                return drugInventoryResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, drugs);
                return drugInventoryResponse;
            }
        }

        public async Task<DrugInventoryResponse> PutDrug(string id, DrugInventoryDTO drugData)
        {
            try
            {
                AddDrug(id, drugData);
                _context.Entry(drug).State = EntityState.Detached;
                _context.Entry(drug).State = EntityState.Modified;
                _context.DrugInventory.Update(drug);
                await _context.SaveChangesAsync();
                AddResponse(true, $"1 record Updated", drugs);
                return drugInventoryResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, drugs);
                return drugInventoryResponse;
            }
        }

        public void AddDrug(string id, DrugInventoryDTO drugData)
        {
            drug = new DrugInventory()
            {
                DrugId = id,
                DrugName = drugData.DrugName,
                DrugDescription = drugData.DrugDescription,
                DrugImgURL = drugData.DrugImgURL,
                DrugType = drugData.DrugType,
                DrugPrice = drugData.DrugPrice,
            };
        }
        public void AddResponse(bool status, string Message, List<DrugInventory> drugs)
        {
            drugInventoryResponse = new DrugInventoryResponse()
            {
                Status = status,
                Message = Message,
                Drugs = drugs
            };
        }
    }
}
