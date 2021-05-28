using System;
using System.ComponentModel.DataAnnotations;

namespace AppLembrarData.Entity
{
    public class Compromisso
    {
        public Compromisso()
        {

        }

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int TipoCompromisso { get; set; }
        public DateTime DataCompromisso { get; set; }

        public int Status { get; set; }

        public Compromisso(DateTime dataCompromisso)
        {
            dataCompromisso = DateTime.Now;
        }

    }


}
