using placesFestFlowerJam.ApplicationServices.GetRouteListUseCase;
using System.Net;
using Newtonsoft.Json;
using placesFestFlowerJam.ApplicationServices.Ports;

namespace placesFestFlowerJam.InfrastructureServices.Presenters
{
    public class FestListPresenter : IOutputPort<GetRouteListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public FestListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetRouteListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Routes) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
