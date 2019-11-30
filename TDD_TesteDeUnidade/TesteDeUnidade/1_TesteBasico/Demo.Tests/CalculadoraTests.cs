using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }

        [Theory] // Teoria - Para testar seu metodo com varios cenarios
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 4, 7)]
        [InlineData(1, 7, 8)]
        [InlineData(8, 1, 9)]
        public void Calculadora_Somar_RetornarValoresSomaCorretos(double n1, double n2, double total)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(n1, n2);

            // Assert
            Assert.Equal(total, resultado);
        }
    }
}
