using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPush.Entities;
namespace NewsPush.UniTest.Business
{
    [TestClass]
    public class UT_News
    {


        [TestMethod]
        public void Get()
        {
            DA.Business.DaNews _da = new DA.Business.DaNews();
            var res = _da.GetAll();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetAll()
        {
            DA.Business.DaNews _da = new DA.Business.DaNews();
            int id = 1;
            var res = _da.Get(id);
            Assert.IsTrue(res.IdCategory > 0);
        }

        [TestMethod]
        public void Create()
        {
            DA.Business.DaNews _da = new DA.Business.DaNews();
            Enews e = new Enews();
            e.Tittle = "Categoria Prueba";
            e.Description = "Descri Prueba";
            var res = _da.Create(e);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void Update()
        {
            DA.Business.DaNews _da = new DA.Business.DaNews();
            Enews e = new Enews();
            e.Tittle = "Categoria Prueba";
            e.Description = "Descri Prueba";
            e.IdCategory = 1;
            var res = _da.Update(e);
            Assert.IsNotNull(res);
        }


    }
}
