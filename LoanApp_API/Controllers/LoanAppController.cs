using LoanApp_API.Models.DTOs;
using LoanApp_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAppController : ControllerBase
    {
        private readonly ILoanService _loanApplicationService;

        public LoanAppController(ILoanService loanApplicationService)
        {
            _loanApplicationService = loanApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanAppDto>>> GetAll()
        {
            var loanApplications = await _loanApplicationService.GetAllAsync();
            return Ok(loanApplications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanAppDto>> GetById(int id)
        {
            var loanApplication = await _loanApplicationService.GetByIdAsync(id);
            if (loanApplication == null)
            {
                return NotFound();
            }
            return Ok(loanApplication);
        }

        [HttpPost]
        public async Task<ActionResult<LoanAppDto>> Create(CreateLoanAppDto createLoanApplicationDto)
        {
            var loanApplication = await _loanApplicationService.CreateAsync(createLoanApplicationDto);
            return CreatedAtAction(nameof(GetById), new { id = loanApplication.Id }, loanApplication);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateLoanAppDto updateLoanApplicationDto)
        {
            try
            {
                await _loanApplicationService.UpdateStatusAsync(id, updateLoanApplicationDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

