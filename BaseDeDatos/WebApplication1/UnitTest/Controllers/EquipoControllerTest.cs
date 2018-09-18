using Base.Controllers;
using Core.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Controllers
{
    class EquipoControllerTest
    {

        private EquipoController _equipoController;
        private Mock<IEquipo> _equipoNegocio;

        [SetUp()]
        public void SetUp()
        {
            _equipoNegocio = new Mock<IEquipo>();
            _equipoController = new EquipoController(_equipoNegocio.Object)
            {
                _equipoManager = _equipoNegocio.Object
            };
        }


        #region Get
        [Test]
        public async Task GetById_CuandoIdNoSeEncuentraDevuelveNulo()
        {
            _equipoNegocio.Setup(x => x.GetAll()).Returns(new List<EquipoEntity>());
            var result = _equipoController.Details(999);
            var resultadoEsperado = result as NotFoundResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(resultadoEsperado);
            Assert.AreEqual(resultadoEsperado.StatusCode, StatusCodes.Status404NotFound);
        }

        [Test]
        public async Task GetById_CuandoEncuentroDevulevoLaVista()
        {
            _equipoNegocio.Setup(x => x.GetAll()).Returns(new List<EquipoEntity> { new EquipoEntity { EquipoId = 999 } });
            var result = _equipoController.Details(999);
            var resultadoEsperado = result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(resultadoEsperado);
            Assert.IsInstanceOf(typeof(EquipoEntity), resultadoEsperado.Model);
        }
        #endregion
    }
}
