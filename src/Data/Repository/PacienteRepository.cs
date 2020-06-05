using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Paciente> ObterPacienteEndereco(Guid id)
        {
            return await Db.Pacientes.AsNoTracking().Include(e => e.Endereco)
                .FirstOrDefaultAsync(e => e.Id == id);
        }


    }
}
