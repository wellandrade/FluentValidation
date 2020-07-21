using ConsoleValidacoes.Entidades;
using FluentValidation;

namespace ConsoleValidacoes.Validacao
{
    public class ItemVendaValidator : AbstractValidator<ItemVenda>
    {
        public ItemVendaValidator()
        {
            RuleFor(i => i.Descricao)
                .Length(3, 50).WithMessage("A descrição do item deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.Preco)
                .GreaterThan(0).WithMessage("O preço do item deve ser maior que {ComparisonValue}");

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade de item deve ser maioque que {ComparisonValue}");
        }
    }
}
