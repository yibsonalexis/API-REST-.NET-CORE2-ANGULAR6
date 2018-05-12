using NewsPush.DataAccess.Models;
using NewsPush.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsPush.DA.Business
{
    public interface IDaCategories
    {
        ECategories Get(int id);
        List<ECategories> GetAll();
        int Create(ECategories e);
        bool Update(ECategories e);
        bool Delete(int id);
    }
    public class DaCategories : IDaCategories
    {
        /// <summary>
        /// Retornar una categoria por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ECategories Get(int id)
        {
            ECategories res = new ECategories();            
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var q = (from x in db.Categories where x.IdCategory == id select x).FirstOrDefault();
                    if (q != null)
                    {
                        res.IdCategory = q.IdCategory;
                        res.Name = q.Name;
                        res.Description = q.Description;
                    }                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        /// <summary>
        /// Devuelve todas las categorias
        /// </summary>
        /// <returns></returns>
        public List<ECategories> GetAll()
        {
            List<ECategories> res = new List<ECategories>();
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var query = (from x in db.Categories select x).ToList();
                    if (query.Any())
                    {
                        foreach (var i in query)
                        {
                            ECategories e = new ECategories();
                            e.IdCategory = i.IdCategory;
                            e.Name = i.Name;
                            e.Description = i.Description;
                            res.Add(e);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int Create(ECategories e)
        {
            int res = 0;
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    DataAccess.Models.Categories obj = new Categories();
                    obj.Name = e.Name;
                    obj.Description = e.Description;
                    db.Categories.Add(obj);
                    db.SaveChanges();
                    res = obj.IdCategory;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        /// <summary>
        /// update a category created
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Update(ECategories e)
        {
            bool res = false;
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var query = (from x in db.Categories where x.IdCategory == e.IdCategory select x).FirstOrDefault();
                    query.Name = e.Name;
                    query.Description = e.Description;
                    db.Categories.Update(query);
                    db.SaveChanges();
                    res = true;

                }
            }
            catch (Exception)
            {
                throw;                
            }
            return res;
        }

        /// <summary>
        /// Delete a category by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            bool res = false;
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var query = (from x in db.Categories where x.IdCategory == id select x).FirstOrDefault();
                    if (query != null)
                    {
                        db.Categories.Remove(query);
                        db.SaveChanges();
                        res = true;
                    }                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }
    }
}
