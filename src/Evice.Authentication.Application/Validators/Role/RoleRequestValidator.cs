using Evice.Authentication.Application.Commands.Requests.Role;
using FluentValidation;

namespace Evice.Authentication.Application.Validators.Role
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(r => r.Description)
                .MaximumLength(250);

            RuleFor(r => r.CompanyId)
                .NotNull()
                .NotEmpty();

            //TODO: Pesquisar se tem alguma forma de fazer a validação async funcionar via pipeline.
            //RuleFor(r => new { r.Name, r.CompanyId })
            //    .MustAsync(async (m, _) => await this._companyQuery.CompanyExists(m.CompanyId))
            //    .MustAsync(async (m, _) => await this._roleQuery.CheckNameExists(m.CompanyId, m.Name));
        }
    }
}