using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Model;

namespace WebAPI.Repository.Interface
{
    public interface IHospitalRepository
    {
        IQueryable<TB_ATENDIMENTO> ListarAtendimentos();
        Task<IList<TB_ATENDIMENTO>> ListarAtendimentosAsync();
        IQueryable<TB_FUNCIONARIO> ListarFuncionarios();
        Task<IList<TB_FUNCIONARIO>> ListarFuncionariosAsync();
        TB_ATENDIMENTO ObterAtendimento(long id);
        Task<TB_ATENDIMENTO> ObterAtendimentoAsync(long id);
        TB_MEDICAMENTO ObterMedicamento(long id);
    }
}