using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Validations;

namespace WebApi.Domain.Entities
{
    public sealed class Product
    {
        public Product(string name, string codeErp, decimal price)
        {
            Validation(name, codeErp, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string codeErp, decimal price)
        {
            DomainValidationException.When(id < 0, "O id é invalido");
            Id = id;

            Validation(name, codeErp, price);

            Purchases = new List<Purchase>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodeErp { get; private set; }
        public decimal Price { get; private set; }

        public ICollection<Purchase> Purchases { get; set; }


        private void Validation(string name, string codeErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(codeErp), "O codigo ERP deve ser informado!");
            DomainValidationException.When(price < 0, "O preço é invalido!");

            Name = name;
            CodeErp = codeErp;
            Price = price;
        }

    }
}
