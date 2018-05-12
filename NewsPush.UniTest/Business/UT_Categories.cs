using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPush.UniTest.Business
{
    [TestClass]
    public class UT_Categories
    {
        //private readonly IDaCategories _daCategories;
        //public UT_Categories(IDaCategories daCategories)
        //{
        //    _daCategories = daCategories;
        //}

        //public readonly DA.Business.DaCategories _daCountries;

        //public UT_Categories()
        //{
        //    _daCountries = new DA.Business.DaCategories();
        //}

        [TestMethod]
        public void Get()
        {
            DA.Business.DaCategories _da = new DA.Business.DaCategories();
            var res = _da.GetAll();
            Assert.IsNotNull(res);
        }

    }
}
