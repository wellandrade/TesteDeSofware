using FluentValidation;
using NerdStore.Vendas.Domain.Enum;
using System;

namespace NerdStore.Vendas.Domain.Validacoes
{
    public class VoucherAplicavelValidation : AbstractValidator<Voucher>
    {
        public VoucherAplicavelValidation()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty()
                .WithMessage(CodigoErroMsg);

            RuleFor(c => c.DataValidade)
                .Must(DataVencimentoSuperiorAtual)
                .WithMessage(DataValidadeErroMsg);

            RuleFor(c => c.Ativo)
                .Equal(true)
                .WithMessage(AtivoErroMsg);

            RuleFor(c => c.Utilizado)
                .Equal(false)
                .WithMessage(UtilizadoErroMsg);

            RuleFor(c => c.Quantidade)
              .GreaterThan(0)
              .WithMessage(QuantidadeErroMsg);

            When(f => f.TipoDescontoVoucher == TipoDescontoVoucher.Valor, () =>
            {
                RuleFor(f => f.ValorDesconto)
                .NotNull()
                .WithMessage(ValorDescontoErroMsg)
                .GreaterThan(0)
                .WithMessage(ValorDescontoErroMsg);
            });

            When(f => f.TipoDescontoVoucher == TipoDescontoVoucher.Porcentagem, () =>
            {
                RuleFor(f => f.PercentualDesconto)
                .NotNull()
                .WithMessage(PercentualErroMsg)
                .GreaterThan(0)
                .WithMessage(PercentualErroMsg);
            });

        }

        public static string CodigoErroMsg => "Voucher sem codigo valido";
        public static string DataValidadeErroMsg => "Esses voucher esta expirado";
        public static string AtivoErroMsg => "Esse voucher não é mais valido";
        public static string UtilizadoErroMsg => "Esse voucher ja foi utilizado";
        public static string QuantidadeErroMsg => "Esse voucher não está mais disponivel";
        public static string ValorDescontoErroMsg => "Valor de desconto precisa ser superior a 0";
        public static string PercentualErroMsg => "O valor do percentual precisa ser superior a 0";

        protected static bool DataVencimentoSuperiorAtual(DateTime dataValidade)
        {
            return dataValidade >= DateTime.Now;
        }
    }
}
