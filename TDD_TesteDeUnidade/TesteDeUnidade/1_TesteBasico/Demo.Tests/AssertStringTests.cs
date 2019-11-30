using Xunit;

namespace Demo.Tests
{
    public class AssertStringTests
    {
        [Fact]
        public void StringTools_UnirNomes_RetonarNomeCompleto()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Joao", "Silva");

            // Assert
            Assert.Equal("Joao Silva", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Joao", "Silva");

            // Assert
            Assert.Equal("JOAO SILVA", nomeCompleto, true);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveConterTrecho()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Joao", "Silva");

            // Assert
            Assert.Contains("ao", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComecarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Joao", "Silva");

            // Assert
            Assert.StartsWith("Joa", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveTerminarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Joao", "Silva");

            // Assert
            Assert.EndsWith("va", nomeCompleto);
        }
    }
}
