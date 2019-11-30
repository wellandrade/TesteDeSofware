using Xunit;

namespace Demo.Tests
{
    public class AssertNumberTests
    {
        [Fact]
        public void Calculadora_Somar_SomaDeveSerIgual()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Calculadora_Somar_SomaNaoDeveSerIgual()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(1.13123123123, 2.2312313123);

            // Assert
            Assert.NotEqual(3.3, resultado, 1);
        }
    }
}
