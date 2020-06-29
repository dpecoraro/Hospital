using BUSINESSLOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Repository.Context;
using WebAPI.Repository.Interface;
using WebAPI.Repository.Model;

namespace WebAPI.Repository
{
    public class HospitalRepository : GenericRepository<TB_ATENDIMENTO>, IHospitalRepository
    {
        public HospitalRepository(string connection)
        {
            _context = new HospitalContext(connection);
        }

        public HospitalRepository(ConnectionDetail connection)
        {
            _context = new HospitalContext(connection);
        }

        public async Task<IList<TB_ATENDIMENTO>> ListarAtendimentosAsync()
        {
            return await _context.Set<TB_ATENDIMENTO>().ToListAsync();
        }

        public IQueryable<TB_ATENDIMENTO> ListarAtendimentos()
        {
            return _context.Set<TB_ATENDIMENTO>().AsQueryable();
        }

        public async Task<IList<TB_FUNCIONARIO>> ListarFuncionariosAsync()
        {
            return await _context.Set<TB_FUNCIONARIO>().ToListAsync();
        }

        public IQueryable<TB_FUNCIONARIO> ListarFuncionarios()
        {
            return _context.Set<TB_FUNCIONARIO>().AsQueryable();
        }

        public async Task<TB_ATENDIMENTO> ObterAtendimentoAsync(long id)
        {
            return await _context.Set<TB_ATENDIMENTO>().FindAsync(id);
        }

        public TB_ATENDIMENTO ObterAtendimento(long id)
        {
            return _context.Set<TB_ATENDIMENTO>().Where(a => a.Id == id).FirstOrDefault();
        }

        public TB_MEDICAMENTO ObterMedicamento(long id)
        {
            return _context.Set<TB_MEDICAMENTO>().Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
