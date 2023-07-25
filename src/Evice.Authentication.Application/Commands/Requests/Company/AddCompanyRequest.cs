namespace Evice.Authentication.Application.Commands.Requests.Company
{
    public class AddCompanyRequest
    {
        public string Name { get; set; }

        public string Document { get; set; }

        //TODO: Pensar em como salvar a imagem do logo da empresa.
        //public string LogoImage { get; set; }
    }
}