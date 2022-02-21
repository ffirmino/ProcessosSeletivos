using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Webmotors.Domain.Entities;
using Webmotors.Domain.Repositories;
using Webmotors.Infra.DBContext;

namespace Webmotors.Infra.Repositories.AnuncioRepository
{
    public class AnuncioRepository : BaseRepository, IAnuncioRepository
    {
        private readonly IMapper _mapper;

        public AnuncioRepository(DbContextWebmotors dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var anuncio = _dbContext.TbAnuncioWebmotors.Single(a => a.Id == id);

            _dbContext.Remove(anuncio);
        }

        public Anuncio Get(IDictionary<string, object> keys)
        {
            return _dbContext.TbAnuncioWebmotors
                             .Where(a => a.Id == Convert.ToInt32(keys["ID"].ToString()))
                             .Select(a => _mapper.Map<Anuncio>(a))
                             .FirstOrDefault();
        }

        public void Insert(Anuncio entity)
        {
            var anuncio = _mapper.Map<TbAnuncioWebmotors>(entity);

            _dbContext.TbAnuncioWebmotors.Add(anuncio);
        }

        public IEnumerable<Anuncio> List(IDictionary<string, object> keys)
        {
            return _dbContext.TbAnuncioWebmotors
                             .Where(a => a.Marca.Contains(keys["marca"].ToString()) &&
                                         a.Modelo.Contains(keys["modelo"].ToString()))
                             .Select(a => _mapper.Map<Anuncio>(a))
                             .ToList();
        }

        public void Update(Anuncio entity)
        {
            var anuncio = _dbContext
                .TbAnuncioWebmotors
                .FirstOrDefault(a => a.Id == entity.ID);

            _mapper.Map(entity, anuncio);

            _dbContext.Entry(anuncio).State = EntityState.Modified;
        }
    }
}
