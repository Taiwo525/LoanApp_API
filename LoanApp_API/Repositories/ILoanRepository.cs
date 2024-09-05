using LoanApp_API.Models;

namespace LoanApp_API.Repositories
{
    public interface ILoanRepository
    {
        Task<LoanApp> GetByIdAsync(int id);
        Task<IEnumerable<LoanApp>> GetAllAsync();
        Task<LoanApp> CreateAsync(LoanApp loanApp);
        Task UpdateAsync(LoanApp loanApp);
        Task DeleteAsync(int id);
    }
}
