using Evice.Authentication.Domain.SeedWork;

namespace Evice.Authentication.Domain.AggregatesModel.CompanyAggregate
{
    public class Company : Entity
    {
        public string DisplayName { get; set; }

        public string FantasyName { get; set; }

        public string Document { get; set; }

        //TODO: Pensar em como salvar a imagem do logo da empresa.
    }
}