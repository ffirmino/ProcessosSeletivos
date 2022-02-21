using AutoMapper;
using System;
using System.Collections.Generic;
using Webmotors.Domain.Entities;
using Webmotors.Domain.Repositories;
using Webmotors.Service.DTOs;
using Webmotors.Service.DTOs.Anuncio;
using Webmotors.Service.Interfaces;

namespace Webmotors.Service.Services
{
    public class AnuncioService : BaseService, IAnuncioService
    {
        protected override Type ConcreteType => typeof(AnuncioService);

        private readonly IMapper _mapper;

        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioService(IMapper mapper, IAnuncioRepository anuncioRepository)
        {
            _mapper = mapper;

            _anuncioRepository = anuncioRepository;
        }

        public ResponseBase Create(AnuncioDTO anuncio)
        {
            var response = new ResponseBase();

            try
            {
                var entity = _mapper.Map<Anuncio>(anuncio);

                _anuncioRepository.Insert(entity);
                _anuncioRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message}";
                response.Exception = ex;
            }

            return response;
        }

        public ResponseBase Delete(int id)
        {
            var response = new ResponseBase();

            try
            {
                _anuncioRepository.Delete(id);
                _anuncioRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message}";
                response.Exception = ex;
            }

            return response;
        }

        public ResponseBase<IEnumerable<AnuncioDTO>> List(string marca, string modelo)
        {
            var response = new ResponseBase<IEnumerable<AnuncioDTO>>();

            try
            {
                var keys = new Dictionary<string, object>();
                keys.Add("marca", marca);
                keys.Add("modelo", modelo);

                var anuncios = _anuncioRepository.List(keys);

                response.Data = _mapper.Map(anuncios, new List<AnuncioDTO>());
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message}";
                response.Exception = ex;
            }

            return response;
        }

        public ResponseBase<AnuncioDTO> Read(int id)
        {
            var response = new ResponseBase<AnuncioDTO>();

            try
            {
                var keys = new Dictionary<string, object>();
                keys.Add("ID", id);

                var anuncio = _anuncioRepository.Get(keys);

                response.Data = _mapper.Map(anuncio, new AnuncioDTO());
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message}";
                response.Exception = ex;
            }

            return response;
        }

        public ResponseBase Update(AnuncioDTO anuncio)
        {
            var response = new ResponseBase();

            try
            {
                var entity = _mapper.Map<Anuncio>(anuncio);

                _anuncioRepository.Update(entity);
                _anuncioRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message}";
                response.Exception = ex;
            }

            return response;
        }
    }
}
