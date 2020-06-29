using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ApiServices.Interface;
using WebAPI.Repository.Interface;
using WebAPI.Repository.Model;

namespace WebAPI.ApiServices
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalService(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public IList<TB_FUNCIONARIO> ListarFuncionarios()
        {
            try
            {
                var aux = _hospitalRepository.ListarFuncionarios().ToList();

                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
