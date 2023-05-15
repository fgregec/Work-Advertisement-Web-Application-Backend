using AutoMapper;
using Core.Entities;
using Core.interfaces;
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
        public async Task<ActionResult<IReadOnlyList<AnalyticsDto>>> MestarProfit(Guid mestarID, DateTime? from, DateTime? until)
        {
            var natjecajList = await _analyticsRepository.GetMestarProfit(mestarID, from, until);            
            var analyticsDtos = _mapper.Map<IReadOnlyList<Natjecaj>, IReadOnlyList<AnalyticsDto>>(natjecajList);

            return Ok(analyticsDtos);
        }
    }
}
