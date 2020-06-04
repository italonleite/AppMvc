using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Paciente : Entity
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
        public string Cpf { get; set; }
        public string TitularCpf { get; set; }
        public string IndicadoPor { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
