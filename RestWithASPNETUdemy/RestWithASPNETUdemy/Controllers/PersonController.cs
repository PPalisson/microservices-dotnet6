// PersonController.cs: recebe requisicoes HTTP sobre pessoas e chama IPersonService.
// Fluxo: Swagger/cliente -> controller -> servico -> resposta HTTP em JSON.
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers {

    // [controller] vira Person: a rota base deste controller e /Person.
    [Route("[controller]")]
    // Ativa comportamentos de API, incluindo respostas 400 para erros de validacao.
    [ApiController]
    public class PersonController : ControllerBase {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;


        // Injecao de dependencia: o ASP.NET fornece o logger e o servico registrado no Program.cs.
        // ILogger registra mensagens; IPersonService oferece as operacoes sobre pessoas.
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
           _logger = logger;
            _personService = personService;
        }

        // GET /Person: consulta todas as pessoas, sem parametro e sem corpo JSON.
        // FindAll gera a lista; Ok(lista) responde status 200 e serializa a lista em JSON.
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());

        }

        // GET /Person/5: o valor 5 da URL e convertido para o parametro long id.
        // Get() e Get(long) podem coexistir porque recebem parametros diferentes.
        // NotFound() = 404; Ok(person) = 200 com a pessoa no corpo da resposta.
        // O servico atual ainda simula a busca: ignora o ID e sempre devolve uma pessoa.
        [HttpGet("{id}")]
        public IActionResult Get(long id )
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);

        }

        // POST /Person: solicita criacao com os dados enviados no corpo JSON.
        // [FromBody] converte o JSON em um objeto Person. Exemplo de corpo:
        // { "id": 1, "firstName": "Ana", "lastName": "Silva", "address": "Recife", "gender": "Female" }
        // BadRequest() = 400. Neste codigo, o sucesso e 200 com a pessoa retornada.
        // Create ainda so devolve o objeto; nao salva em banco nem o adiciona a lista.
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {

            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        // PUT /Person: solicita atualizacao com um objeto Person no corpo JSON.
        // Aqui o ID vem na propriedade id do JSON, e nao em /Person/{id}.
        // Update ainda so devolve os dados recebidos, sem alterar registros armazenados.
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        // DELETE /Person/5: recebe o ID na URL e chama Delete(id) no servico.
        // NoContent() = status 204, sem corpo de resposta.
        // O Delete do servico ainda esta vazio: nenhuma pessoa e removida de verdade.
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
            {
            _personService.Delete(id);
            return NoContent();

        }


    }
}
