**INSTITUTO FEDERAL DE EDUCAÇÃO, CIÊNCIA E TECNOLOGIA DE SÃO PAULO – CAMPUS CUBATÃO**  
**TECNOLOGIA EM ANÁLISE E DESENVOLVIMENTO DE SISTEMAS**

KAIK PERSIKE MAIORQUINO  
LUIZ GUSTAVO VERISSIMO MONTEIRO

**TRABALHO PRÁTICO 04:**   
**DESENVOLVIMENTO DE WEB API COM ASP.NET CORE E CRUD EM PÁGINA WEB**

**SUMÁRIO**

[**1\. INTRODUÇÃO	4**](#introdução)

[**2\. TECNOLOGIAS UTILIZADAS	4**](#tecnologias-utilizadas)

[**3\. ESTRUTURA DA SOLUÇÃO	5**](#estrutura-da-solução)

[3.1. CBTSWE2\_TP04	5](#cbtswe2_tp04)

[3.2. Livraria.API	5](#livraria.api)

[3.3. Livraria.Core	5](#livraria.core)

[**4\. DESENVOLVIMENTO DA DLL E SUA INTEGRAÇÃO	6**](#desenvolvimento-da-dll-e-sua-integração)

[**5\. CONFIGURAÇÃO E CONEXÃO COM O BANCO DE DADOS	9**](#configuração-e-conexão-com-o-banco-de-dados)

[**6\. DESENVOLVIMENTO DA WEB API	10**](#desenvolvimento-da-web-api)

[**7\. DESENVOLVIMENTO DA PÁGINA WEB	11**](#desenvolvimento-da-página-web)

[7.1. Cadastro de livros	11](#cadastro-de-livros)

[7.2. Consulta de livros	11](#consulta-de-livros)

[7.3. Atualização de livros	11](#atualização-de-livros)

[7.4. Exclusão de livros	11](#exclusão-de-livros)

[**8\. VALIDAÇÕES E TESTES REALIZADOS	13**](#validações-e-testes-realizados)

[**9\. CONSIDERAÇÕES FINAIS	15**](#considerações-finais)

[**10\. REFERÊNCIAS E RECURSOS	16**](#referências-e-recursos)

**LISTA DE ILUSTRAÇÕES**

[Figura 1 Estrutura da solução no Visual Studio, mostrando os três projetos.](#bookmark=id.h6dwldsp21h0)	

[Figura 2 Dependências do projeto Livraria.API mostrando a referência Livraria.Core.](#bookmark=id.ilb3p5fj448c)	

[Figura 3 Código da classe Livro e do atributo AnoPublicacaoValidoAttribute.](#bookmark=id.2ecucyny8tbu)	

[Figura 4 Banco CBTSWE2\_Livraria e tabela dbo.Livros no SQL Server Object Explorer.](#bookmark=id.lov4i57q0evb)	

[Figura 5 Swagger exibindo os quatro endpoints da API.](#bookmark=id.l1w84en0romk)	

[Figura 6 Tela inicial mostrando a lista dos livros.](#bookmark=id.dhmrzkidfe4v)	

[Figura 7 Formulário de cadastro de livros.](#bookmark=id.r7zqiz35gy97)	

[Figura 8 Formulário de edição de um livro.](#bookmark=id.scj510yndbm1)	

[Figura 9 Exemplo de validação de dados retornando HTTP 400 no Swagger.](#bookmark=id.iahpmeu09znl)	

[Figura 10 Exemplo de atualização ou exclusão com ID inexistente retornando HTTP 404\.](#bookmark=id.67g1ua21xh1s)	

1. # **INTRODUÇÃO** {#introdução}

   Este trabalho tem como objetivo desenvolver uma aplicação web utilizando ASP.NET Core, contemplando a criação de uma Web API, integração com banco de dados local, utilização de uma biblioteca de classes (DLL) e desenvolvimento de uma interface web para realizar operações de cadastro, consulta, atualização e exclusão de registros.  
   Para a aplicação, foi desenvolvido um sistema de gerenciamento de livros denominado Minha Livraria, permitindo cadastrar livros, consultar os registros existentes, atualizar suas informações e removê-los.  
   O projeto foi estruturado de maneira modular, separando a interface web, a Web API e a biblioteca de classes, buscando facilitar a organização e a manutenção do código.  
   

2. # **TECNOLOGIAS UTILIZADAS** {#tecnologias-utilizadas}

   Para o desenvolvimento da aplicação, foram utilizadas as seguintes tecnologias:  
* C\#: linguagem de programação utilizada na implementação da aplicação.  
* ASP.NET Core: framework utilizado para desenvolver a Web API e a aplicação web.  
* Entity Framework Core: ORM utilizado para realizar o mapeamento entre as classes da aplicação e as tabelas do banco de dados.  
* SQL Server LocalDB: banco de dados local utilizado para armazenar os registros dos livros.  
* Swagger: ferramenta utilizada para visualizar e testar os endpoints da Web API.  
* Visual Studio 2022: ambiente de desenvolvimento utilizado na implementação do projeto.

3. # **ESTRUTURA DA SOLUÇÃO** {#estrutura-da-solução}

   A solução foi organizada em três projetos principais:

   1. ## **CBTSWE2\_TP04** {#cbtswe2_tp04}

      Projeto responsável pela interface web, desenvolvida com Razor Pages. Por meio dessa interface, o usuário pode cadastrar, visualizar, atualizar e excluir livros.

   2. ## **Livraria.API** {#livraria.api}

      Projeto responsável pela Web API, contendo os endpoints que recebem as requisições HTTP, processam as operações solicitadas e realizam a comunicação com o banco de dados.

   3. ## **Livraria.Core** {#livraria.core}

      Projeto do tipo Class Library, responsável por disponibilizar as classes e funcionalidades compartilhadas pela aplicação.  
      A biblioteca contém:  
* Livro.cs: representa a entidade Livro e suas propriedades.  
* StatusLeitura.cs: define os possíveis estados de leitura de um livro.  
* AnoPublicacaoValidoAttribute.cs: implementa uma validação personalizada para o ano de publicação.

A biblioteca é integrada à Web API por meio de uma referência de projeto, permitindo que suas classes e funcionalidades sejam utilizadas diretamente pela API.  
Figura  Estrutura da solução no Visual Studio, mostrando os três projetos.  
![][image1]  
Fonte: Elaborado pelos autores (2026)

4. # **DESENVOLVIMENTO DA DLL E SUA INTEGRAÇÃO** {#desenvolvimento-da-dll-e-sua-integração}

   Para atender ao requisito de desenvolvimento e integração de DLLs, foi criado o projeto Livraria.Core, utilizando o modelo Class Library do .NET. Esse projeto gera a biblioteca Livraria.Core.dll durante a compilação.  
   A biblioteca concentra elementos relacionados ao domínio da aplicação, permitindo o compartilhamento de estruturas e regras entre os projetos. A classe Livro representa os dados de cada livro, incluindo identificador, título, autor, ISBN, ano de publicação e status de leitura.  
     
   O enum StatusLeitura define três opções:  
* ParaLer;  
* Lendo;  
* Lido.

  Também foi desenvolvido o atributo personalizado AnoPublicacaoValidoAttribute, responsável por verificar se o ano informado está entre 1450 e o ano atual.

  A integração foi realizada adicionando uma referência ao projeto Livraria.Core nas dependências de Livraria.API.

  Dessa maneira, a Web API utiliza diretamente as classes e validações disponibilizadas pela biblioteca.

Figura  Dependências do projeto Livraria.API mostrando a referência Livraria.Core.  
![][image2]  
Fonte: Elaborado pelos autores (2026)  
Figura  Código da classe Livro e do atributo AnoPublicacaoValidoAttribute.  
![][image3]  
Fonte: Elaborado pelos autores (2026)

5. # **CONFIGURAÇÃO E CONEXÃO COM O BANCO DE DADOS** {#configuração-e-conexão-com-o-banco-de-dados}

   Foi utilizado o SQL Server LocalDB como banco de dados local da aplicação.  
   O banco de dados criado recebeu o nome CBTSWE2\_Livraria.  
   Para realizar a comunicação entre a Web API e o banco de dados, foi utilizado o Entity Framework Core, responsável pelo mapeamento objeto-relacional.  
   Foi criada a classe LivrariaContext, responsável por representar o contexto de acesso aos dados e disponibilizar a coleção de livros por meio de DbSet\<Livro\>.  
   A conexão foi configurada no arquivo appsettings.json, utilizando a instância local (localdb)\\MSSQLLocalDB.  
   Também foram utilizadas migrations do Entity Framework Core para criar e aplicar a estrutura inicial do banco de dados.  
   A tabela Livros armazena as informações cadastradas pela aplicação.

Figura  Banco CBTSWE2\_Livraria e tabela dbo.Livros no SQL Server Object Explorer.  
![][image4]  
Fonte: Elaborado pelos autores (2026)

6. # **DESENVOLVIMENTO DA WEB API** {#desenvolvimento-da-web-api}

   A Web API foi desenvolvida no projeto Livraria.API, utilizando o ASP.NET Core.  
   Foi criado o controller LivrosController, responsável por disponibilizar os endpoints relacionados à entidade Livro.  
     
   Foram implementadas as seguintes operações:

**Tabela 1 – Endpoints da Web API**

| Método HTTP | Endpoint | Funcionalidade |
| :---: | :---: | :---: |
| GET | /api/Livros | Consulta todos os livros cadastrados. |
| POST | /api/Livros | Cadastra um novo livro. |
| PUT | /api/Livros/{id} | Atualiza um livro existente. |
| DELETE | /api/Livros/{id} | Exclui um livro existente. |

Fonte: Elaborado pelos autores (2026)

As operações utilizam o Entity Framework Core para consultar, inserir, atualizar e remover registros no banco de dados.  
Para facilitar a visualização e os testes dos endpoints, foi configurado o Swagger.

Figura  Swagger exibindo os quatro endpoints da API.  
![][image5]  
Fonte: Elaborado pelos autores (2026)

7. # **DESENVOLVIMENTO DA PÁGINA WEB** {#desenvolvimento-da-página-web}

   A interface web foi desenvolvida utilizando Razor Pages, no projeto CBTSWE2\_TP04.  
   A página principal recebeu o título Minha Livraria e permite ao usuário interagir com a Web API por meio de formulários e componentes visuais.  
   A comunicação entre a interface e a API é realizada utilizando HttpClient, com requisições HTTP e transferência de dados no formato JSON.  
     
   As funcionalidades disponíveis são:

   1. ## **Cadastro de livros** {#cadastro-de-livros}

      Permite informar os dados de um livro e enviá-los à API para armazenamento no banco de dados.

   2. ## **Consulta de livros** {#consulta-de-livros}

      Exibe os livros cadastrados em uma tabela na página principal.

   3. ## **Atualização de livros** {#atualização-de-livros}

      Permite selecionar um livro existente, alterar suas informações e enviar a atualização à API.

   4. ## **Exclusão de livros** {#exclusão-de-livros}

      Permite remover um livro cadastrado, enviando uma requisição DELETE à API.

Figura  Tela inicial mostrando a lista dos livros.  
![][image6]  
Fonte: Elaborado pelos autores  (2026)  
Figura  Formulário de cadastro de livros.  
![][image7]  
Fonte: Elaborado pelos autores (2026)

Figura  Formulário de edição de um livro.  
![][image8]  
Fonte: Elaborado pelos autores (2026)

8. # **VALIDAÇÕES E TESTES REALIZADOS** {#validações-e-testes-realizados}

Durante o desenvolvimento, foram realizados testes manuais utilizando o Swagger e a própria interface web, verificando o funcionamento das operações e o tratamento de dados inválidos.

Entre as validações implementadas, destacam-se:

* Obrigatoriedade dos campos título e autor.  
* Limite máximo de 150 caracteres para o título.  
* Limite máximo de 100 caracteres para o autor.  
* Validação do ano de publicação, permitindo valores entre 1450 e o ano atual.  
* Possibilidade de não informar o ano de publicação.  
* Validação do status de leitura, aceitando apenas as opções definidas no enum.

  Também foram testadas situações de erro relacionadas às operações CRUD:

* Tentativa de atualizar um livro inexistente.  
* Tentativa de excluir um livro inexistente.  
* Envio de IDs diferentes entre a URL e o corpo da requisição PUT.  
    
  Os testes demonstraram o funcionamento das validações e o retorno de códigos HTTP apropriados, como 400 (Bad Request), 404 (Not Found), 201 (Created) e 204 (No Content).

Figura  Exemplo de validação de dados retornando HTTP 400 no Swagger.  
![][image9]  
Fonte: Elaborado pelos autores. (2026)

Figura  Exemplo de atualização ou exclusão com ID inexistente retornando HTTP 404\.  
![][image10]  
Fonte: Elaborado pelos autores (2026)

9. # **CONSIDERAÇÕES FINAIS** {#considerações-finais}

   O desenvolvimento da aplicação permitiu colocar em prática conceitos relacionados à construção de aplicações web utilizando o ASP.NET Core.

   

   Foram implementadas uma Web API com operações CRUD, uma interface web para interação com os dados, a integração com o banco de dados SQL Server LocalDB por meio do Entity Framework Core e uma biblioteca de classes própria, compartilhada entre os projetos.

   

   Os testes realizados permitiram verificar o funcionamento das operações e das validações implementadas, contribuindo para identificar e corrigir problemas durante o desenvolvimento.

   

   Dessa forma, a aplicação Minha Livraria contempla os principais requisitos técnicos propostos no Trabalho Prático 04\.

   

   

   

10. # **REFERÊNCIAS E RECURSOS** {#referências-e-recursos}

MICROSOFT. **Documentação do ASP.NET Core**. Microsoft Learn, \[s. d.\]. Disponível em: [https\://learn.microsoft.com/pt-br/aspnet/core/](https://learn.microsoft.com/pt-br/aspnet/core/). Acesso em: 6 nov. 2026\.

MICROSOFT. **Documentação do Entity Framework Core**. Microsoft Learn, \[s. d.\]. Disponível em: [https\://learn.microsoft.com/pt-br/ef/core/](https://learn.microsoft.com/pt-br/ef/core/). Acesso em: 6 nov. 2026\.

MICROSOFT. **Razor Pages no ASP.NET Core**. Microsoft Learn, \[s. d.\]. Disponível em: [https\://learn.microsoft.com/pt-br/aspnet/core/razor-pages/](https://learn.microsoft.com/pt-br/aspnet/core/razor-pages/). Acesso em: 6 nov. 2026\.

MICROSOFT. **SQL Server Express LocalDB**. Microsoft Learn, \[s. d.\]. Disponível em: [https\://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb). Acesso em: 7 nov. 2026\.

[image1]: imagens/image1.png
[image2]: imagens/image2.png
[image3]: imagens/image3.png
[image4]: imagens/image4.png
[image5]: imagens/image5.png
[image6]: imagens/image6.png
[image7]: imagens/image7.png
[image8]: imagens/image8.png
[image9]: imagens/image9.png
[image10]: imagens/image10.png
