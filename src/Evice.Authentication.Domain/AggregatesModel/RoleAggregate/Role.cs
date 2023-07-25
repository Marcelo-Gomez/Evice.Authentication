using Evice.Authentication.Domain.SeedWork;

namespace Evice.Authentication.Domain.AggregatesModel.RoleAggregate
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }
    }
}