using LoanApp_API.Models.DTOs;

namespace LoanApp_API.Services
{
    public interface ILoanService
    {
        Task<LoanAppDto> GetByIdAsync(int id);
        Task<IEnumerable<LoanAppDto>> GetAllAsync();
        Task<LoanAppDto> CreateAsync(CreateLoanAppDto createLoanApplicationDto);
        Task UpdateStatusAsync(int id, UpdateLoanAppDto updateLoanApplicationDto);
    }
}
