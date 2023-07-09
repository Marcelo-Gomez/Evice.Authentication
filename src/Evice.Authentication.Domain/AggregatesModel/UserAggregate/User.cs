using Evice.Authentication.Domain.SeedWork;

namespace Evice.Authentication.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string EncryptedPassword { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}