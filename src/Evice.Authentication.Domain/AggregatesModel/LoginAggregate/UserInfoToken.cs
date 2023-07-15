using Evice.Authentication.Domain.SeedWork;

namespace Evice.Authentication.Domain.AggregatesModel.LoginAggregate
{
    public class UserInfoToken : Entity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public bool IsAdmin { get; set; }
    }
}