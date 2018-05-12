using NewsPush.DataAccess.Models;
using NewsPush.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsPush.DA.Business
{
    public interface IDaCategoriesC
    {
        ECategories Get(int id);
        List<ECategories> GetAll();
        int Create(ECategories e);
        bool Update(ECategories e);
        bool Delete(int id);
    }
    public class DaCategoriesC : IDaCategoriesC
    {
        private readonly NewsDBContext db;
        public DaCategoriesC(NewsDBContext dBContext)
        {
            db = dBContext;
        }
        
        public ECategories Get(int id)
        {
            ECategories res = new ECategories();
            try
            {
                var q = (from x in db.Categories select x).FirstOrDefault();
                res.Description = q.Description;
                res.Name = q.Name;
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public List<ECategories> GetAll()
        {
            List<ECategories> res = new List<ECategories>();
            try
            {
                var query = (from x in db.Categories select x).ToList();
                if (query.Any())
                {
                    foreach (var i in query)
                    {
                        ECategories e = new ECategories();
                        e.Name = i.Name;
                        e.Description = i.Description;
                        res.Add(e);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return res;
        }

        public int Create(ECategories e)
        {
            int res = 0;
            try
            {
                DataAccess.Models.Categories obj = new Categories();
                obj.Name = e.Name;
                obj.Description = e.Description;
                db.Categories.Add(obj);
                db.SaveChanges();
                res = obj.IdCategory;
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public bool Update(ECategories e)
        {
            bool res = false;
            try
            {
                var query = (from x in db.Categories where x.IdCategory == e.IdCategory select x).FirstOrDefault();
                query.Name = e.Name;
                query.Description = e.Description;
                db.Categories.Update(query);
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                throw;                
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res;
            try
            {
                var query = (from x in db.Categories where x.IdCategory == id select x).FirstOrDefault();
                db.Categories.Remove(query);
                res = true;
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }
    }
}
