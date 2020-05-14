using placesFestFlowerJam.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace placesFestFlowerJam.ApplicationServices.GetFestListUseCase
{
    public class GetFestListUseCaseRequest : IUseCaseRequest<GetFestListUseCaseResponse>
    {
        public long? OrganizationId { get; private set; }
        public long? FestId { get; private set; }

        private GetFestListUseCaseRequest()
        { }

        public static GetFestListUseCaseRequest CreateAllFestsRequest()
        {
            return new GetFestListUseCaseRequest();
        }

        public static GetFestListUseCaseRequest CreateFestRequest(long festId)
        {
            return new GetFestListUseCaseRequest() { FestId = festId };
        }
        public static GetFestListUseCaseRequest CreateOrganizationFestsRequest(long organizationId)
        {
            return new GetFestListUseCaseRequest() { OrganizationId = organizationId };
        }
    }
}
