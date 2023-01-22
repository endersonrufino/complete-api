﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApi.Domain.Validations;

namespace WebApi.Domain.Entities
{
    public class Purchase
    {
        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);            
        }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "O id da compra é invalido!");
            Id = id;

            Validation(productId, personId);
        }

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }

        public Person Person { get; set; }
        public Product Product { get; set; }

        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId < 0, "O id do produto é invalido!");
            DomainValidationException.When(personId < 0, "O id da pessoa é invalido!");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
