// PersonServiceImplementation.cs: implementa as operacoes de IPersonService.
// Esta etapa usa dados ficticios (mock): ainda nao existe banco nem persistencia.
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations {
    public class PersonServiceImplementation : IPersonService {

        // Contador desta instancia. O registro Scoped cria outra instancia a cada requisicao.
        private volatile int count;

        // Simulacao: apenas devolve o objeto recebido; nao o armazena.
        public Person Create(Person person) {
            return person;
        }

        // Ainda vazio: nao exclui nenhum registro.
        public void Delete(long id ) {
            
        }

        // Gera uma NOVA lista de oito pessoas ficticias a cada chamada.
        // Um POST anterior nao aparece aqui, pois nao existe armazenamento dos dados.
        public List<Person> FindAll() {
            List<Person> Persons = new List<Person>();
            for (int i = 0; i < 8; i++) 
                {

                Person person = MockPerson(i);
                Persons.Add(person);            
            }
            return Persons;
        }

        

        // Simulacao: ignora o id recebido e cria uma pessoa com dados fixos.
        // Sempre retorna um objeto; por isso o NotFound do controller nao acontece aqui.
        public Person FindByID(long id) {
            return new Person {

                Id = IncrementAndGet(),
                FirstName = "Nedilma",
                LastName = "Soarez",
                Address = "curado 2 - Jaboatão dos Guararapes",
                Gender = "Female"

            };
        }


        // Simulacao: devolve o objeto sem procurar ou alterar uma pessoa armazenada.
        public Person Update(Person person) {
            return person;
        }

        // Monta uma pessoa ficticia; o indice i diferencia nome e endereco.
        private Person MockPerson(int i) {
            return new Person {

                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Some Address" + i,
                Gender = "Female"

            };
        }

        // Interlocked incrementa o contador de forma atomica e retorna o novo valor.
        // Este contador nao e um ID global: reinicia com cada nova instancia do servico.
        private long IncrementAndGet() 
            {

            return Interlocked.Increment(ref count);
        }
    }
}
