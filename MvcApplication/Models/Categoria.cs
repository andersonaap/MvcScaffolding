using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Categoria
    {
        public string Nome { get; set; }
        public int CategoriaId { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}