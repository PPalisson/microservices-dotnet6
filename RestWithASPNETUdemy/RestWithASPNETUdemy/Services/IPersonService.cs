// IPersonService.cs: contrato que declara as operacoes de pessoas.
// Nao executa a logica: define o que a implementacao deve oferecer ao controller.
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services {
    public interface IPersonService {

        // Recebe uma pessoa e devolve o resultado da criacao.
        Person Create (Person person);
        // Consulta uma pessoa pelo identificador numerico.
        Person FindByID (long id);
        // Devolve uma lista de pessoas (List<Person>).
        List<Person> FindAll ();
        // Recebe a pessoa com os dados que se deseja atualizar.
        Person Update (Person person);
        // Recebe somente o ID. void significa que nao devolve um valor ao chamador.
        void Delete(long id);
    }
}
