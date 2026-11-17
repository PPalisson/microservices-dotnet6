// Person.cs: modelo com os dados de uma pessoa; nao define endpoints nem salva em banco.
// As propriedades publicas viram campos JSON (Id -> id, FirstName -> firstName...).
// get permite ler a propriedade; set permite atribuir seu valor.
namespace RestWithASPNETUdemy.Model {
    public class Person {
        // Identificador inteiro; os campos FirstName, LastName, Address e Gender sao textos.
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }


    }
}
