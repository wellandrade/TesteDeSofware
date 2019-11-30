using FluentValidation;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Domain;
using System;

namespace NerdStore.Vendas.Application.Validacoes
{
    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public static string IdClienteErroMsg => "Id do cliente invalido";
        public static string IdProdutoErroMsg => "Id do produto invalido";
        public static string NomeErroMsg => "O nome do produto nao foi informado";
        public static string QtdMaxErroMsg => $"A quantidade maxima de um item { Pedido.MAX_UNIDADES_ITEM }"; 
        public static string QtdMinErroMsg => "A quantidade minima de um item é 1";
        public static string ValorErroMsg => "O valor precisa ser maior que 0";

        public AdicionarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage(IdClienteErroMsg);

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage(IdProdutoErroMsg);

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage(NomeErroMsg);

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage(QtdMinErroMsg)
                .LessThanOrEqualTo(Pedido.MAX_UNIDADES_ITEM)
                .WithMessage(QtdMaxErroMsg);

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0)
                .WithMessage(ValorErroMsg);
        }
    }
}
