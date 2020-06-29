using System.Collections.Generic;
using WebAPI.Repository.Model;

namespace WebAPI.ApiServices.Interface
{
    public interface IHospitalService
    {
        IList<TB_FUNCIONARIO> ListarFuncionarios();
    }
}