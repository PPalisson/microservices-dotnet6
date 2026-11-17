# microservices-dotnet6

## Mapa do projeto para estudo

O projeto atual usa .NET 9 (net9.0), apesar do nome do repositorio mencionar .NET 6.

| Arquivo | Funcao |
| --- | --- |
| `RestWithASPNETUdemy/RestWithASPNETUdemy.sln` | Solucao que organiza o projeto no Visual Studio. |
| `RestWithASPNETUdemy/RestWithASPNETUdemy/RestWithASPNETUdemy.csproj` | Define o SDK Web, a versao do .NET e os pacotes NuGet. |
| `Program.cs` | Configura os servicos, o Swagger e as rotas; inicia o servidor. |
| `Controllers/PersonController.cs` | Recebe requisicoes sobre pessoas, chama o servico e monta respostas HTTP. |
| `Services/IPersonService.cs` | Contrato com as operacoes que o servico deve oferecer. |
| `Services/Implementations/PersonServiceImplementation.cs` | Implementacao atual do contrato, com dados ficticios e sem banco. |
| `Model/Person.cs` | Define os dados de uma pessoa usados no JSON de entrada e saida. |
| `Controllers/CalculatorController.cs` | Endpoints de calculos com valores recebidos pela URL. |
| `appsettings.json` | Configuracoes gerais, como niveis de log e hosts permitidos. |
| `appsettings.Development.json` | Configuracoes que complementam ou substituem as gerais no ambiente Development. |
| `Properties/launchSettings.json` (local, se existir) | Perfis de inicializacao, URLs e ambiente usados pelas ferramentas de desenvolvimento. |
| `RestWithASPNETUdemy.http` | Requisicoes que podem ser executadas pelo editor; ajuste a porta para a API em execucao. |
| `.gitignore` | Impede que cache e arquivos gerados, como .vs, bin e obj, sejam adicionados ao Git. |
| `LICENSE` | Termos de licenca do repositorio. |
| `README.md` | Este guia de leitura do projeto. |

Os caminhos curtos da tabela sao relativos a pasta que contem o .csproj.

## Um exemplo do caminho da requisicao

1. No Swagger, execute GET /Person (Try it out -> Execute).
2. O ASP.NET combina [Route("[controller]")] com [HttpGet] e chama Get().
3. O controller chama _personService.FindAll().
4. A implementacao registrada no Program.cs cria oito pessoas ficticias.
5. Ok(lista) retorna status 200 e os objetos sao serializados em um array JSON.

A interface define o contrato; o AddScoped escolhe a implementacao; o construtor recebe a dependencia.
HTTP e o protocolo. GET, POST, PUT e DELETE sao metodos HTTP; HTTPS e HTTP com transporte protegido.

## Rotas de pessoas

| Requisicao | Intencao | Comportamento atual |
| --- | --- | --- |
| GET /Person | Listar | Gera oito pessoas ficticias a cada chamada. |
| GET /Person/5 | Buscar pelo ID | Ignora o ID e devolve uma pessoa fixa com ID gerado. |
| POST /Person | Criar com JSON no corpo | Devolve o objeto recebido com 200; nao salva. |
| PUT /Person | Atualizar com JSON no corpo | Devolve o objeto recebido com 200; nao salva. |
| DELETE /Person/5 | Excluir pelo ID | Chama um metodo vazio e responde 204, sem corpo. |

Os dados nao sao persistidos. POST, PUT e DELETE ainda nao mudam o resultado da listagem.
O contador de IDs pertence ao servico Scoped e reinicia a cada requisicao.

## Pontos para estudar depois

- A rota Addition usa divisao, apesar de seu nome sugerir soma.
- A rota Percentage usa %, que calcula resto da divisao, nao porcentagem.
- Divisao e resto ainda precisam tratar o segundo numero igual a zero.
- A calculadora valida com double e cultura invariavel, mas converte com decimal e cultura local; uniformizar os dois evita resultados inesperados.
- PersonController ainda tem auxiliares numericos copiados da calculadora e sem uso.
- Persistencia, busca real por ID e validacao dos dados de pessoas ainda sao proximas etapas.
