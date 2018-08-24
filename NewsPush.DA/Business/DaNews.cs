using NewsPush.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using NewsPush.DataAccess.Models;
using System.Linq;

namespace NewsPush.DA.Business
{
    public interface IDaNews
    {
        Enews Get(int id);
        List<Enews> GetAll();
        List<Enews> GetAllByCategories(int id);
        int Create(Enews e);
        bool Update(Enews e);
        bool Delete(int id);
    }
    public class DaNews : IDaNews
    {
        /// <summary>
        /// Create a News 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int Create(Enews e)
        {
            var res = 0;
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var obj = new DataAccess.Models.News();
                    obj.Title = e.Tittle;
                    obj.Description = e.Description;

                    db.News.Add(obj);
                    db.SaveChanges();
                    res = obj.IdNews;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        /// <summary>
        /// Detele a news by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var res = false;
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var q = (from x in db.News where x.IdCategory == id select x).FirstOrDefault();
                    if (q != null)
                    {
                        db.News.Remove(q);
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

        /// <summary>
        /// Get a New by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Enews Get(int id)
        {
            Enews res = new Enews();
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var q = (from x in db.News where x.IdCategory == id select x).FirstOrDefault();
                    if (q != null)
                    {
                        res.IdCategory = q.IdCategory;
                        res.Tittle = q.Title;
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
        /// Get all News
        /// </summary>
        /// <returns></returns>
        public List<Enews> GetAll()
        {
            List<Enews> res = new List<Enews>();
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var query = (from x in db.News select x).ToList();
                    if (query.Any())
                    {
                        foreach (var i in query)
                        {
                            Enews e = new Enews();
                            e.Tittle = i.Title;
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
        /// Get by IdCategory
        /// </summary>
        /// <returns></returns>
        public List<Enews> GetAllByCategories(int id)
        {
            List<Enews> res = new List<Enews>();
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var query = (from x in db.News where x.IdCategory == id select x).ToList();
                    if (query.Any())
                    {
                        foreach (var i in query)
                        {
                            Enews e = new Enews();
                            e.Tittle = i.Title;
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
        /// Update a New
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Update(Enews e)
        {
            bool res = false;
            try
            {
                using (var db = new DataAccess.Models.NewsDBContext())
                {
                    var query = (from x in db.News where x.IdNews == e.IdNews select x).FirstOrDefault();
                    if (query != null)
                    {
                        query.Title = e.Tittle;
                        query.Description = e.Description;
                        db.News.Update(query);
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
