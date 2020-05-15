using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace placesFestFlowerJam.ApplicationServices.GetFestListUseCase
{
    public class GetFestListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Fest> Routes { get; }

        public GetFestListUseCaseResponse(IEnumerable<Fest> fests) => Routes = fests;
    }
}
