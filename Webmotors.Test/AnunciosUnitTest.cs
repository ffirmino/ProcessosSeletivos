using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Webmotors.API.Controllers;
using Webmotors.Service.DTOs;
using Webmotors.Service.DTOs.Anuncio;
using Webmotors.Service.Interfaces;

namespace Webmotors.Test
{
    public class Tests
    {
        private Mock<IAnuncioService> anuncioServiceMock;

        private AnunciosController anunciosController;
        private InfosController infosController;

        [SetUp]
        public void Setup()
        {
            anuncioServiceMock = new Mock<IAnuncioService>();

            anunciosController = new AnunciosController(anuncioServiceMock.Object);
            infosController = new InfosController();
        }

        [Test]
        public void CreateAnuncio()
        {
            var anuncio = new AnuncioDTO
            {
                Marca = "Chevrolet",
                Modelo = "Agile",
                Versao = "1.5 DX 16V FLEX 4P AUTOMÁTICO",
                Ano = 2018,
                Quilometragem = 25000,
                Observacao = "Carro com único dono e o IPVA de 2020 pago."
            };

            var data = new ResponseBase
            {
                Success = true,
                Message = null,
                Exception = null
            };

            anuncioServiceMock.Setup(a => a.Create(anuncio)).Returns(data);

            var result = anunciosController.Post(anuncio);

            Assert.AreEqual(true, GetVal<bool>(result, "Success"));
            Assert.AreEqual(null, GetVal<string>(result, "Message"));
        }

        [Test]
        public void DeleteAnuncio()
        {
            int id = 1;

            var data = new ResponseBase
            {
                Success = true,
                Message = null,
                Exception = null
            };

            anuncioServiceMock.Setup(a => a.Delete(id)).Returns(data);

            var result = anunciosController.Delete(id);

            Assert.AreEqual(true, GetVal<bool>(result, "Success"));
            Assert.AreEqual(null, GetVal<string>(result, "Message"));
        }

        [Test]
        public void GetInfos()
        {
            var result = infosController.Get();

            Assert.IsNotNull(result.Value);
            Assert.AreEqual("Webmotors", GetVal<string>(result, "Company"));
            Assert.AreEqual("API", GetVal<string>(result, "Type"));
            Assert.AreEqual("v1.0", GetVal<string>(result, "Version"));
        }

        [Test]
        public void ListAnuncios()
        {
            string marca = "Chevrolet";

            string modelo = "Agile";

            var anuncio = new AnuncioDTO
            {
                Marca = "Chevrolet",
                Modelo = "Agile",
                Versao = "1.5 DX 16V FLEX 4P AUTOMÁTICO",
                Ano = 2018,
                Quilometragem = 25000,
                Observacao = "Carro com único dono e o IPVA de 2020 pago."
            };

            var anuncios = new List<AnuncioDTO>();
            anuncios.Add(anuncio);

            var data = new ResponseBase<IEnumerable<AnuncioDTO>>()
            {
                Success = true,
                Data = anuncios,
                Message = null,
                Exception = null
            };

            anuncioServiceMock.Setup(a => a.List(marca, modelo)).Returns(data);

            var result = anunciosController.List(marca, modelo);

            Assert.AreEqual(true, GetVal<bool>(result, "Success"));
            Assert.AreEqual(1, GetVal<List<AnuncioDTO>>(result, "Data").Count);
        }

        [Test]
        public void ReadAnuncio()
        {
            int id = 1;

            var anuncio = new AnuncioDTO
            {
                Marca = "Chevrolet",
                Modelo = "Agile",
                Versao = "1.5 DX 16V FLEX 4P AUTOMÁTICO",
                Ano = 2018,
                Quilometragem = 25000,
                Observacao = "Carro com único dono e o IPVA de 2020 pago."
            };

            var data = new ResponseBase<AnuncioDTO>()
            {
                Success = true,
                Data = anuncio,
                Message = null,
                Exception = null
            };

            anuncioServiceMock.Setup(a => a.Read(id)).Returns(data);

            var result = anunciosController.Get(id);

            var dataValue = GetVal<AnuncioDTO>(result, "Data");

            Assert.AreEqual(true, GetVal<bool>(result, "Success"));
            Assert.AreEqual("Chevrolet", dataValue.Marca);
            Assert.AreEqual("Agile", dataValue.Modelo);
            Assert.AreEqual("1.5 DX 16V FLEX 4P AUTOMÁTICO", dataValue.Versao);
            Assert.AreEqual(2018, dataValue.Ano);
            Assert.AreEqual(25000, dataValue.Quilometragem);
            Assert.AreEqual("Carro com único dono e o IPVA de 2020 pago.", dataValue.Observacao);
        }

        [Test]
        public void UpdateAnuncio()
        {
            var anuncio = new AnuncioDTO
            {
                Id = 1,
                Marca = "Chevrolet 1",
                Modelo = "Agile 1",
                Versao = "1.5 DX 16V FLEX 4P AUTOMÁTICO 1",
                Ano = 2019,
                Quilometragem = 1000,
                Observacao = "Carro com único dono, pouca quilometragem e o IPVA de 2020 pago."
            };

            var data = new ResponseBase
            {
                Success = true,
                Message = null,
                Exception = null
            };

            anuncioServiceMock.Setup(a => a.Update(anuncio)).Returns(data);

            var result = anunciosController.Put(anuncio);

            Assert.AreEqual(true, GetVal<bool>(result, "Success"));
            Assert.AreEqual(null, GetVal<string>(result, "Message"));
        }

        private T GetVal<T>(JsonResult jsonResult, string propertyName)
        {
            var property = jsonResult.Value.GetType().GetProperties()
                    .Where(p => string.Compare(p.Name, propertyName) == 0)
                    .FirstOrDefault();

            if (null == property)
                throw new ArgumentException("propertyName not found", "propertyName");

            return (T)property.GetValue(jsonResult.Value, null);
        }
    }
}
