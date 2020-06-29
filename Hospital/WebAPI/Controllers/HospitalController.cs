using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ApiServices;
using WebAPI.ApiServices.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [Route("listarfuncionarios")]
        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ListarFuncionarios()
        {
            var funcionarios = _hospitalService.ListarFuncionarios();
            if (!funcionarios.Any())
            {
                return await Task.FromResult(StatusCode(400, "Não há funcionarios"));
            }

            return await Task.FromResult(StatusCode(200, funcionarios));
        }

    }
}
