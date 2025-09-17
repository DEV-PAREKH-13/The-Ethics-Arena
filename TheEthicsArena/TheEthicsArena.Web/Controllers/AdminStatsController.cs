using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEthicsArena.Web.Services;

namespace TheEthicsArena.Web.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    [Route("api/admin/stats")]
    public class AdminStatsController : ControllerBase
    {
        private readonly DilemmaService _dilemmaService;

        public AdminStatsController(DilemmaService dilemmaService)
        {
            _dilemmaService = dilemmaService;
        }
        
        [HttpGet]
public async Task<IActionResult> GetAllDilemmaStats()
{
    var dilemmas = _dilemmaService.GetAllDilemmas();

    var statsList = new List<object>();

    foreach (var d in dilemmas)
    {
        var stats = await _dilemmaService.GetResponseStatsAsync(d.Id);

        statsList.Add(new
        {
            DilemmaId = d.Id,
            Title = d.Title,
            ResponsesA = stats.ContainsKey("A") ? stats["A"] : 0,
            ResponsesB = stats.ContainsKey("B") ? stats["B"] : 0,
            TotalResponses = (stats.ContainsKey("A") ? stats["A"] : 0) + (stats.ContainsKey("B") ? stats["B"] : 0)
        });
    }

    return Ok(statsList);
}


    }
}
