using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class PacienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public int Sexo { get; set; }
        public string Cpf { get; set; }
        public string TitularCpf { get; set; }
        public string IndicadoPor { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}
