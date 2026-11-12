using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reporting.Application.Funds;

namespace Reporting.Api.Controllers;

[ApiController]
[Route("api/funds")]
[Authorize]
public class FundsController : ControllerBase
{
    private readonly IFundService _fundService;

    public FundsController(IFundService fundService)
    {
        _fundService = fundService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FundDto>>> GetAll()
    {
        var funds = await _fundService.GetAllAsync();
        return Ok(funds);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FundDto>> GetById(int id)
    {
        var fund = await _fundService.GetByIdAsync(id);

        if (fund is null)
        {
            return NotFound();
        }

        return Ok(fund);
    }
}
