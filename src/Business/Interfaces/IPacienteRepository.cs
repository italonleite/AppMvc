using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<Paciente> ObterPacienteEndereco(Guid id);
    }
}
