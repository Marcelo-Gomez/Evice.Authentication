namespace Evice.Authentication.Application.Commands.Requests.Company
{
    public class UpdateCompanyRequest
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string FantasyName { get; set; }

        public string Document { get; set; }
    }
}