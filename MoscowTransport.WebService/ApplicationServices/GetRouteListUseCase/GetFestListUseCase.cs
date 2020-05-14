using System.Threading.Tasks;
using System.Collections.Generic;
using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.DomainObjects.Ports;
using placesFestFlowerJam.ApplicationServices.Ports;

namespace placesFestFlowerJam.ApplicationServices.GetFestListUseCase
{
    public class GetFestListUseCase : IGetFestListUseCase
    {
        private readonly IReadOnlyFestRepository _readOnlyFestRepository;

        public GetFestListUseCase(IReadOnlyFestRepository readOnlyFestRepository) 
            => _readOnlyFestRepository = readOnlyFestRepository;

        public async Task<bool> Handle(GetFestListUseCaseRequest request, IOutputPort<GetFestListUseCaseResponse> outputPort)
        {
            IEnumerable<Fest> fests = null;
            if (request.FestId != null)
            {
                var fest = await _readOnlyFestRepository.GetFest(request.FestId.Value);
                fests = (fest != null) ? new List<Fest>() { fest } : new List<Fest>();
                
            }
            else if (request.OrganizationId != null)
            {
                fests = await _readOnlyFestRepository.QueryFests(new FestCriteria(request.OrganizationId.Value));
            }
            else
            {
                fests = await _readOnlyFestRepository.GetAllFests();
            }
            outputPort.Handle(new GetFestListUseCaseResponse(fests));
            return true;
        }
    }
}
