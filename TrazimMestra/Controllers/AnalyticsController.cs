using Core.Entities;
using Core.interfaces;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class AnalyticsController : BaseApiController
    {
        private readonly IAnalyticsRepository _analyticsRepository;
        private readonly IGenericRepository<MestarProfit> _repository;

        public AnalyticsController(IGenericRepository<MestarProfit> repository, IAnalyticsRepository analyticsRepository)
        {
            _repository = repository;
            _analyticsRepository = analyticsRepository;
        }

        [HttpPost("profit")]
        public async Task<IActionResult> AddMestarProfit(MestarProfit mestarProfit)
        {
            _repository.Add(mestarProfit);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mestarProfit= await _repository.GetByIdAsync(id);

            if (mestarProfit == null)
                return NotFound();            

            _repository.Delete(mestarProfit);
            return Ok();
        }

        [HttpGet("mestar-profit")]
        public async Task<ActionResult<MestarProfitModel>> MestarProfit(MestarProfitModel profitModel)
        {
            var mestarProfit = await _analyticsRepository.GetMestarProfit(profitModel);
            return Ok(mestarProfit);
        }
    }
}
