using System;
using TechTalk.SpecFlow;

namespace Nerd.BDD.Tests
{
    [Binding]
    public class Pedido_AdicionarItemAoCarrinhoSteps
    {
        [Given(@"um produto que esteja na vitrine")]
        public void DadoUmProdutoQueEstejaNaVitrine()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Esteja disponivel")]
        public void DadoEstejaDisponivel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"O usuario esteja logado")]
        public void DadoOUsuarioEstejaLogado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Que um produto esteja na vitrine")]
        public void DadoQueUmProdutoEstejaNaVitrine()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Esteja disponivel no estoque")]
        public void DadoEstejaDisponivelNoEstoque()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"O mesmo produto ja tenha sido adicionado ao carrinho posteriormente")]
        public void DadoOMesmoProdutoJaTenhaSidoAdicionadoAoCarrinhoPosteriormente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"O usuario adicionar uma unidade ao carrinho")]
        public void QuandoOUsuarioAdicionarUmaUnidadeAoCarrinho()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"O usuario adicionar um item acima da quantidade maxima permitidade")]
        public void QuandoOUsuarioAdicionarUmItemAcimaDaQuantidadeMaximaPermitidade()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"O usuario sera redirecionado ao resumo da compra")]
        public void EntaoOUsuarioSeraRedirecionadoAoResumoDaCompra()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"O valor total do pedido sera exatamente o valor do item adicionado")]
        public void EntaoOValorTotalDoPedidoSeraExatamenteOValorDoItemAdicionado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Recebera uma mensagem de erro mencionando que foi ultrapassada a quantidade limite")]
        public void EntaoReceberaUmaMensagemDeErroMencionandoQueFoiUltrapassadaAQuantidadeLimite()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"A quantidade de itens daquele produto tera sido acrescida em uma unidade a mais")]
        public void EntaoAQuantidadeDeItensDaqueleProdutoTeraSidoAcrescidaEmUmaUnidadeAMais()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"O valor total do pedido sera a multiplicacao da quantidade de itens pelo valor unitario")]
        public void EntaoOValorTotalDoPedidoSeraAMultiplicacaoDaQuantidadeDeItensPeloValorUnitario()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
