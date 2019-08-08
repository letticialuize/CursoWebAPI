using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Domain
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Nome tem no mínimo 2 caracteres e no máximo 50", MinimumLength = 2)]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        [RegularExpression(@"[0-9]{4}\-[0-9]{2}", ErrorMessage = "A data está fora do formato YYYYY-MM" )]
        public string Data { get; set; }

        [Required(ErrorMessage = "O RA é de preenchimento obrigatório")]
        [Range(1,9099, ErrorMessage = "O intervalo para cadastro de RA está entre 1 e 9099")]
        public int? RegistroAcademico { get; set; }
    }
}