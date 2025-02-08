using ApiPizzaria.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ApiPizzaria.Tests
{
    [TestClass]
    public class PedidoServiceTests
    {
        [TestMethod]
        public void CalcularTempoEntrega_DeveRetornarTempoCorreto()
        {
            // Arrange
            var service = new PedidoService();
            int distancia = 5;
            int tempoEsperado = 50; 

            // Act
            int resultado = service.CalcularTempoEntrega(distancia);

            // Assert
            Assert.AreEqual(tempoEsperado, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalcularTempoEntrega_DistanciaInvalida_DeveLancarExcecao()
        {
            // Arrange
            var service = new PedidoService();

            // Act
            service.CalcularTempoEntrega(0);
        }
    }
}
