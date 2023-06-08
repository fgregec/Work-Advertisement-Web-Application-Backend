using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using TrazimMestra.Dtos;

namespace TrazimMestra.Controllers
{
    public class AnalyticsController : BaseApiController
    {
        private readonly IAnalyticsRepository _analyticsRepository;
        private readonly IMapper _mapper;

        public AnalyticsController(IAnalyticsRepository analyticsRepository)
        {
            _analyticsRepository = analyticsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Analytics>>> MestarProfit(Guid mestarID, DateTime? dateFrom, DateTime? dateUntil)
        {
            var natjecajList = await _analyticsRepository.GetMestarProfit(mestarID, dateFrom, dateUntil);            
            var analyticsDtos = _mapper.Map<IReadOnlyList<Natjecaj>, IReadOnlyList<Analytics>>(natjecajList);

            return Ok(analyticsDtos);
        }
    }
}
