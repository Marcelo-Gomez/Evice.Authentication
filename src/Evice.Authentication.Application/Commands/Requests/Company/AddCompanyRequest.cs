﻿namespace Evice.Authentication.Application.Commands.Requests.Company
{
    public class AddCompanyRequest
    {
        public string DisplayName { get; set; }

        public string FantasyName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        //TODO: Pensar em como salvar a imagem do logo da empresa.
    }
}