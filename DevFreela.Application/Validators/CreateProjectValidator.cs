using DevFreela.Application.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(200)
                .WithMessage("O campo deve possuir no máximo 200 caracteres. ");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("O Tamanho máximo do titulo deve possuir 30 caracteres");
         
        }
    }
}
