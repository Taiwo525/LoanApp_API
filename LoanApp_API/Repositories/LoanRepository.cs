using LoanApp_API.Data;
using LoanApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApp_API.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _context;

        public LoanRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<LoanApp> GetByIdAsync(int id)
        {
            return await _context.LoanApps
                .Include(la => la.Documents)
                .FirstOrDefaultAsync(la => la.Id == id);
        }

        public async Task<IEnumerable<LoanApp>> GetAllAsync()
        {
            return await _context.LoanApps
                .Include(la => la.Documents)
                .ToListAsync();
        }

        public async Task<LoanApp> CreateAsync(LoanApp loanApplication)
        {
            _context.LoanApps.Add(loanApplication);
            await _context.SaveChangesAsync();
            return loanApplication;
        }

        public async Task UpdateAsync(LoanApp loanApplication)
        {
            _context.Entry(loanApplication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var loanApplication = await _context.LoanApps.FindAsync(id);
            if (loanApplication != null)
            {
                _context.LoanApps.Remove(loanApplication);
                await _context.SaveChangesAsync();
            }
        }
    }
}

