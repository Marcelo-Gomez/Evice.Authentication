namespace Evice.Authentication.Domain.SeedWork
{
    public class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid().ToString("N");
            this.CreationDate = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}