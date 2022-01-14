using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail Inválido");

            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter pelo menos: 8 caracteres um número, uma letra maiúcula, uma letra minúscula e um caracter especial.");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Nome deve ser preenchido");
        }

        private bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}
