using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertingExceptionsTests
    {
        [Fact]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act e Assert
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
        }

        [Fact]
        public void Calculadora_Dividir_DeveRetornarErroSalarioInferiorPermitido()
        {
            // Arrange - Act - Assert
            //var excetion = Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Joao", 350));

            //Assert.Equal("Salario inferior ao permitido", excetion);
        }
    }
}
