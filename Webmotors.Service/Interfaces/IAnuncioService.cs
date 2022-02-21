using System.Collections.Generic;
using Webmotors.Service.DTOs;
using Webmotors.Service.DTOs.Anuncio;

namespace Webmotors.Service.Interfaces
{
    public interface IAnuncioService
    {
        ResponseBase Create(AnuncioDTO anuncio);
        ResponseBase<IEnumerable<AnuncioDTO>> List(string marca, string modelo);
        ResponseBase<AnuncioDTO> Read(int id);
        ResponseBase Update(AnuncioDTO anuncio);
        ResponseBase Delete(int id);
    }
}
