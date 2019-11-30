Funcionalidade: Pedido - Adicionar item ao carrinho
	Como um usuário
	Eu desejo colocar um item no carrinho
	Para que eu possa compra-lo posteriormente

Cenário: Adicionar item com sucesso a um novo pedido
Dado um produto que esteja na vitrine
E Esteja disponivel
E O usuario esteja logado
Quando O usuario adicionar uma unidade ao carrinho
Então  O usuario sera redirecionado ao resumo da compra
E O valor total do pedido sera exatamente o valor do item adicionado

Cenário: Adicionar itens acima do limite
Dado Que um produto esteja na vitrine
E Esteja disponivel no estoque
E O usuario esteja logado
Quando O usuario adicionar um item acima da quantidade maxima permitidade
Entao Recebera uma mensagem de erro mencionando que foi ultrapassada a quantidade limite

Cenario:  Adicionar item ja existente no carrinho
Dado Que um produto esteja na vitrine
E Esteja disponivel no estoque
E O usuario esteja logado
E O mesmo produto ja tenha sido adicionado ao carrinho posteriormente
Quando O usuario adicionar uma unidade ao carrinho
Entao O usuario sera redirecionado ao resumo da compra
E A quantidade de itens daquele produto tera sido acrescida em uma unidade a mais
E O valor total do pedido sera a multiplicacao da quantidade de itens pelo valor unitario

Cenario:  Adicionar item ja existente onde soma ultrapassa limite maximo
Dado Que um produto esteja na vitrine
E Esteja disponivel no estoque
E O usuario esteja logado
E O mesmo produto ja tenha sido adicionado ao carrinho posteriormente
Quando O usuario adicionar uma unidade ao carrinho
Entao O usuario sera redirecionado ao resumo da compra
E Recebera uma mensagem de erro mencionando que foi ultrapassada a quantidade limite

