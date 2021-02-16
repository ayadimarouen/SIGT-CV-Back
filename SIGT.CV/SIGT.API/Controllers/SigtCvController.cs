using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGT.DTO;
using SIGT.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class SigtCvController : ControllerBase
    {
        private readonly ICvService<CvDTO> _cvService;

        public SigtCvController(ICvService<CvDTO> cvService)
        {
            _cvService = cvService;
        }

        /// <summary>
        /// Web API to return a structured object of CV
        /// </summary>
        /// <param nname=""></param>
        /// <returns></returns>
        [HttpGet("/CV")]
        [ProducesResponseType(typeof(CvDTO),200)]
        public async Task<IActionResult> ReadCV()
        {
            var result = await _cvService.ReadCV();
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
