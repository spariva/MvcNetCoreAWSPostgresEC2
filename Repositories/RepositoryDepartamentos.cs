using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private HospitalContext context;

        public RepositoryDepartamentos(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            return await context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamento(int id)
        {
            return await context.Departamentos.FindAsync(id);
            //return await context.Departamentos.FirstOrDefaultAsync(d => d.IdDepartamento == id);
        }

        public async Task<Departamento> AddDepartamento(Departamento departamento)
        {
            context.Departamentos.Add(departamento);
            await context.SaveChangesAsync();
            return departamento;
        }


    }
}
