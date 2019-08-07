using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Data { get; set; }

        [Required(ErrorMessage = "O RA é de preenchimento obrigatório")]
        public int? RegistroAcademico { get; set; }
    }
}