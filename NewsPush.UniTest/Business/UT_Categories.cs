﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPush.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPush.UniTest.Business
{
    [TestClass]
    public class UT_Categories
    {


        [TestMethod]
        public void Get()
        {
            DA.Business.DaCategories _da = new DA.Business.DaCategories();
            var res = _da.GetAll();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetAll()
        {
            DA.Business.DaCategories _da = new DA.Business.DaCategories();
            int id = 1;
            var res = _da.Get(id);
            Assert.IsTrue(res.IdCategory > 0);
        }

        [TestMethod]
        public void Create()
        {
            DA.Business.DaCategories _da = new DA.Business.DaCategories();
            ECategories e = new ECategories();
            e.Name = "Categoria Prueba";
            e.Description = "Descri Prueba";
            var res = _da.Create(e);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void Update()
        {
            DA.Business.DaCategories _da = new DA.Business.DaCategories();
            ECategories e = new ECategories();
            e.Name = "Categoria Prueba";
            e.Description = "Descri Prueba";
            e.IdCategory = 1;
            var res = _da.Update(e);
            Assert.IsNotNull(res);
        }


    }
}
