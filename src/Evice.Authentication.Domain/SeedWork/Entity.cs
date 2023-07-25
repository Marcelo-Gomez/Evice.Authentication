namespace Evice.Authentication.Domain.SeedWork
{
    public class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid().ToString("N");
            this.Active = true;
            this.CreationDate = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }
    }
}