using CashFlowManagement.Domain.Entities;
using FluentValidation;
using System;

namespace CashFlowManagement.Domain.Validations
{
    public class CashFlowValidation : AbstractValidator<CashFlow>
    {
        public CashFlowValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Identificador tem que ser gerado");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Descrição tem que ser preenchida")
                .Length(0, 100)
                .WithMessage("Tamanho do campo descrição excedido");

            RuleFor(c => c.Value)
                .NotEqual(decimal.Zero)
                .WithMessage("Valor do fluxo de caixa não pode ser igual a zero");

            RuleFor(c => c.CashFlowTypeId)
                .NotEqual(Guid.Empty)
                .WithMessage("Tipo do fluxo de caixa tem que ser preenchido");
        }
    }
}
