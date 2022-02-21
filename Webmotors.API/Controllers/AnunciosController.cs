using Microsoft.AspNetCore.Mvc;
using Webmotors.Service.DTOs.Anuncio;
using Webmotors.Service.Interfaces;

namespace Webmotors.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnunciosController : ControllerBase
    {
        IAnuncioService _anuncioService;

        public AnunciosController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _anuncioService.Delete(id);

            return new JsonResult(new { result.Success, result.Message });
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _anuncioService.Read(id);

            return new JsonResult(new { result.Success, result.Data, result.Message });
        }

        [HttpGet]
        [Route("List")]
        public JsonResult List([FromQuery] string marca, string modelo)
        {
            var result = _anuncioService.List(marca, modelo);

            return new JsonResult(new { result.Success, result.Data, result.Message });
        }

        [HttpPost]
        public JsonResult Post([FromBody] AnuncioDTO anuncio)
        {
            var result = _anuncioService.Create(anuncio);

            return new JsonResult(new { result.Success, result.Message });
        }

        [HttpPut]
        public JsonResult Put([FromBody] AnuncioDTO anuncio)
        {
            var result = _anuncioService.Update(anuncio);

            return new JsonResult(new { result.Success, result.Message });
        }
    }
}
