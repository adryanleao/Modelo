using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Interfaces;
using Modelo.Domain.Models;
using Modelo.Infra.Data.Oracle.Context;
using System.Linq;

namespace Modelo.Infra.Data.Oracle.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ModeloContext context)
            : base(context)
        {

        }

        public Funcionario GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
