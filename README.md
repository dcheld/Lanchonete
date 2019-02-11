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


