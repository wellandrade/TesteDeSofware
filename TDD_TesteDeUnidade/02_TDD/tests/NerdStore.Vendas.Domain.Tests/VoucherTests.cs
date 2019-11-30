using NerdStore.Vendas.Domain.Enum;
using NerdStore.Vendas.Domain.Validacoes;
using System;
using Xunit;
using System.Linq;

namespace NerdStore.Vendas.Domain.Tests
{
    public class VoucherTests
    {
        [Fact(DisplayName = "Validar Voucher Tipo Valor Valido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarVoucherTipoValor_DeveEstarValido()
        { 
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, 1, TipoDescontoVoucher.Valor, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = voucher.ValidarSeAplicavel();  

            // Assert;
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validar Voucher Tipo Valor  Invalido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarVoucherTipoValor_DeveEstarInValido()
        {
            // Arrange
            var voucher = new Voucher("", null, 0, 0, TipoDescontoVoucher.Valor, DateTime.Now.AddDays(-1), false, true);

            // Act
            var result = voucher.ValidarSeAplicavel();

            // Assert;
            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count); // Esperar que tenha encontrado 6 erros

            // Verificar se existe as mensagens de erro
            Assert.Contains(VoucherAplicavelValidation.AtivoErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.CodigoErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.DataValidadeErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.QuantidadeErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.UtilizadoErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.ValorDescontoErroMsg, result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Validar Voucher Tipo Porcentagem Valido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarVoucherPorcentagel_DeveEstarValido()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", 15, 0, 1, TipoDescontoVoucher.Porcentagem, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = voucher.ValidarSeAplicavel();

            // Assert;
            Assert.True(result.IsValid);
        }
    }
}
