# Lanchonete

Este software é uma solução proposta para para uma startup de lanchonete. Para desenvolvê-las foram utilizadas as tecnoligias de .net core para o backend e angular 7 para o frontend.

## Intruções para rodar o sistema

O sistema foi desenvolvido utilizando containers no docker. Com o docker devidamenta instalado siga as seguintes instruções:

Para inciar o sistema bastar entra na patas Lanchone e executar o appstart.bat. Depois de iniciado todos os serviços do docker o sistema em angular vai responder em [http://localhost](http://localhost) (está utilizando a porta 80). O backend irá responder em [http://localhost:5000/api/values](http:localhost:5000/api/values).

Após terminado o teste o sistema pode ser desligado usando o appstop.bat.

## Problema proposto

Somos uma startup do ramo de alimentos e precisamos de uma aplicação web para gerir nosso negócio. Nossa especialidade é a venda de lanches, de modo que alguns lanches são opções de cardápio e outros podem conter ingredientes personalizados.

A seguir, apresentamos a lista de ingredientes disponíveis:

### INGREDIENTE VALOR
Alface R$ 0.40
Bacon R$ 2,00
Hambúrguer de carne R$ 3,00
Ovo R$ 0,80
Queijo R$ 1,50

Segue as opções de cardápio e seus respectivos ingredientes:

### LANCHE INGREDIENTES
X-Bacon Bacon, hambúrguer de carne e queijo
X-Burger Hambúrguer de carne e queijo
X-Egg Ovo, hambúrguer de carne e queijo
X-Egg Bacon Ovo, bacon, hambúrguer de carne e queijo

O valor de cada opção do cardápio é dado pela soma dos ingredientes que compõe o lanche. Além destas opções, o cliente pode personalizar seu lanche e escolher os ingredientes que desejar. Nesse caso, o preço do lanche também será calculado pela soma dos ingredientes.

Existe uma exceção à regra para o cálculo de preço, quando o lanche pertencer à uma promoção. A seguir, apresentamos a lista de promoções e suas respectivas regras de negócio:

### PROMOÇÃO REGRA DE NEGÓCIO
Light Se o lanche tem alface e não tem bacon, ganha 10% de desconto.
Muita carne A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...
Muito queijo A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...
Inflação Os valores dos ingredientes são alterados com frequência e não gastaríamos que isso influenciasse nos testes automatizados.

## Solução implementa

A solução implementa foi utilizando um Backend feito em dotnet core. O backend é uma API Rest que vai receber as solicitações da aplicação de Frontend, sua responsábilidade é realizar os calculos dos lanches e realizar a persistência das informações. Para desenvolvmento da api foi utilizado o Visual Studio 2017 Community.

A aplicação de Frontend feito em Angular, tem como responsabilidade exibir de forma intuitiva os lanches permitindo a customazação dos lanches e por fim fazer a comunicação com o backend para persistir os dados. Para desenvolvimento do frontend foi utilizado o Visual Studio Code

### Backend

O Backend foi desenvolvido pensando numa arquitetura o próxima o possível de microsirviços, devido a simplicida e por existir persistências o sistema foi separado em duas camadas: API e Domínio.

#### Camada API

A camada de API é utilizada principalmente para realizar a comunicação do mundo externo ao Domínio. Outra responsábilidade da camada é fazer a conversão dos tipos que são enviados pelo cliente para os tipos conhecidos pelo Domínio, as classes que fazem essa conversão ficam na pasta _Factory_. Os tipos que usados para comunicação com o mundo externo são chamados de _ViewModel_.

#### Camanda Domínio

A camada de Domínio foi projetada para seguir um modelo de domínio rico. Dentro desse projeto foram adicionados as classes de Domínio que são representações do objetos que encontramos no sistema que incluen: lanches, pedidos, ingredientes, etc.

Esse modelo de foi organizado na pasta Model. Abaixa uma lista das classes e suas funções:
* Inflacao - Classe que representa a a inflação do lanche. Ela possui internamente o valor da inflação e regra de cálculo
* Ingrediente - representa um ingrediente do lanche tendo um valor e nome.
* Lanche - Suas instâncias representam os lanches oferecidos pela pela statup Lanchonete.
* LancheItem - Cada lanche pode possuir ingrediente diferente e com quantidades diferentes. Esse classe ainda permite aumentar/dimunuir a quantidade de um ingrediente
* Pedido - O pedido é a classe responsável por agrupar todos os itens de um lanche, nele também são registradas as promoções válidas. Depois de todas as modificações feitas no lanches ele irá calcular o valor final do lanche.
* PromocaoItemLight, PromocaoItemMuitaCarne, PromocaoItemMuitoQueijo - Verifica se uma pedido pode receber o desconto da promoção e calcula o valor de desconto.

As classe de comunicação com a API são os _Services_. Essas classes tem como responsabilidade orquestrar o processo de negócio. Abaixo uma pequena descrição das classes principais:
* PerdidoService - essa classe tem como responsabilidade orquestrar a processo de negócio do pedido, aplicando as promoções validas, realizando a chamada do cálculo do pedido, sua ultima reponsábilidade é delegar a persistência do pedido
* PromocaoService - Funciona como espécie de _composite_ onde todas as promoções são listadas e aplicadas ao pedido

Para simular o banco de dados foram criadas _factories_. As _factories_ ficam nesse projeto na pasta _Factory_.

#### Projeto de teste

O projeto de teste foi criado para permitir o fácil _refactory_ do fonte e para trazer uma segurança no desenvolvimento. Foram criados teste paras as pricipais funcionalidades do sistema. Para desenvolvimento do teste foi usado o xUnit.

### Frontend

O sistema de _Frontend_ apresenta duas telas: Lanche e Pedido.

Na tela de Lanche são listados todos os lanches diponíveis pelo sistema, ao selecionar o lanche é listado abixo quais são os seus ingredientes. A quantidade de cada ingrediente pode ser modifica, então o cliente pode finalizar o pedido ou cancelar.

Também posível criar um lanche customiza. Nessa opção são exibidas todos os ingredientes ao cliente pode modificar a quantidade de cada um.

Se o cliente decidir fechar o pedido o sistema de frontend iria enviar o lanche criado pelo cliente para o backend que ficará resposável por realizar os calculos. Quando terminado os calculos o cliente será redirecionado para a tela de Pedido.

A tela Pedido lista todos os pedidos feitos pelos clientes.

## Implementações futuras

* Sistema para persistência dos lanches
* Utilização de Https no backend e frontend


