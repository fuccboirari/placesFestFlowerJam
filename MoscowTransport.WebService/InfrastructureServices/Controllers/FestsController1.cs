using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.ApplicationServices.GetRouteListUseCase;
using placesFestFlowerJam.InfrastructureServices.Presenters;

namespace placesFestFlowerJam.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FestsController : ControllerBase
    {
        private readonly ILogger<FestsController> _logger;
        private readonly IGetFestListUseCase _getRouteListUseCase;

        public FestsController(ILogger<FestsController> logger,
                                IGetFestListUseCase getFestListUseCase)
        {
            _logger = logger;
            _getFestListUseCase = getFestListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFests()
        {
            var presenter = new FestListPresenter();
            await _getFestListUseCase.Handle(GetFestListUseCaseRequest.CreateAllRoutesRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetFest(long festId)
        {
            var presenter = new FestListPresenter();
            await _getRouteListUseCase.Handle(GetFestListUseCaseRequest.CreateFestRequest(festId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult> GetOrganizationFests(long organizationId)
        {
            var presenter = new FestListPresenter();
            await _getRouteListUseCase.Handle(GetFestListUseCaseRequest.CreateOrganizationFestsRequest(organizationId), presenter);
            return presenter.ContentResult;
        }
    }
}
