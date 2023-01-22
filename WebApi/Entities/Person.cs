using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Validations;

namespace WebApi.Domain.Entities
{
    public sealed class Person
    {
        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
            Purchases = new List<Purchase>();
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id invalido!");
            Id = id;

            Validation(name, document, phone);

            Purchases = new List<Purchase>();
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public ICollection<Purchase> Purchases { get; set; }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O Telefone deve ser informado!");

            Name= name;
            Document= document;
            Phone= phone;
        }
    }
}
