using System;
using System.ComponentModel.DataAnnotations;

namespace AppLembrarData.Entity
{
    public class Compromisso
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Display(Description ="Tipo do Compromisso")]
        public int TipoCompromisso { get; set; }

        [Display(Description = "Data do Compromisso")]
        public DateTime DataCompromisso { get; set; }

        public int Status { get; set; }


        //Add new comentario para NovaBranch
        public string NewBranch { get; set; }
    }
}
