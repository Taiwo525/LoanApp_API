using AutoMapper;
using LoanApp_API.Models;
using LoanApp_API.Models.DTOs;
using LoanApp_API.Repositories;

namespace LoanApp_API.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoanAppDto> GetByIdAsync(int id)
        {
            var loanApplication = await _repository.GetByIdAsync(id);
            return _mapper.Map<LoanAppDto>(loanApplication);
        }

        public async Task<IEnumerable<LoanAppDto>> GetAllAsync()
        {
            var loanApplications = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanAppDto>>(loanApplications);
        }

        public async Task<LoanAppDto> CreateAsync(CreateLoanAppDto createLoanApplicationDto)
        {
            var loanApplication = _mapper.Map<LoanApp>(createLoanApplicationDto);
            loanApplication.ApplicationDate = DateTime.UtcNow;
            loanApplication.Status = LoanStatus.Pending;

            var createdLoanApplication = await _repository.CreateAsync(loanApplication);
            return _mapper.Map<LoanAppDto>(createdLoanApplication);
        }

        public async Task UpdateStatusAsync(int id, UpdateLoanAppDto updateLoanApplicationDto)
        {
            var loanApplication = await _repository.GetByIdAsync(id);
            if (loanApplication == null)
            {
                throw new KeyNotFoundException($"Loan application with id {id} not found.");
            }

            if (Enum.TryParse<LoanStatus>(updateLoanApplicationDto.Status, out var newStatus))
            {
                loanApplication.Status = newStatus;
                await _repository.UpdateAsync(loanApplication);
            }
            else
            {
                throw new ArgumentException("Invalid loan status.");
            }
        }
    }
}
