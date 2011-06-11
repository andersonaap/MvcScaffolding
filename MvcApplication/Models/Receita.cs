using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Receita
    {
        public string Nome { get; set; }
        public int TempoPreparo { get; set; }
        public int ReceitaId { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}