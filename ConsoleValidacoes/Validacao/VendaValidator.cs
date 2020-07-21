using ConsoleValidacoes.Entidades;
using ConsoleValidacoes.Enum;
using FluentValidation;
using System;

namespace ConsoleValidacoes.Validacao
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(v => v.Data)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data da venda deve ser menor ou igual a data atual")
                .NotNull().WithMessage("A data da venda nao pode ser nula");

            RuleFor(v => v.Total)
                .GreaterThan(0).When(v => v.Tipo == ETipoVenda.Padrao).WithMessage("O total da venda nao pode ser zero");

            RuleForEach(v => v.Itens)
                .NotNull().WithMessage("A propriedade Itens da venda nao pode ser nula")
                .Must(i => i != null ? i.Quantidade > 0 : false).WithMessage("A venda deve possuir pelo menos um item")
                .SetValidator(new ItemVendaValidator());

            When(v => v.Tipo == ETipoVenda.Brinde, () =>
            {
                RuleFor(v => v.Total)
                    .Equal(0).WithMessage("O total de venda deve ser {ComparisonValue} para as vendas do tipo brinde");

                RuleFor(v => v.Itens.Count)
                    .Equal(1).WithMessage("Vendas do tipo brinde devem conter apenas {ComparisonValue} item");
            });
        }
    }
}
