using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPush.DA.Business;
using NewsPush.Entities;

namespace NewsPush.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories/{IdCategories}/News")]
    public class NewsController : Controller
    {
        private readonly IDaNews daNews;
        public NewsController(IDaNews daNews)
        {
            this.daNews = daNews;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var res = daNews.GetAll();
            if (res.Count > 0)
            {
                return Ok(res);
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllByCompanies(int IdCategories)
        {
            var res = daNews.GetAllByCategories(IdCategories);
            if (res.Count > 0)
            {
                return Ok(res);
            }
            return NoContent();
        }

        [HttpGet("{id}", Name = "CreateNews")]
        public IActionResult Get(int id)
        {
            var res = daNews.Get(id);
            if (res.IdNews > 0)
            {
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Enews e, int IdCategories)
        {
            e.IdCategory = IdCategories;
            var res = daNews.Create(e);
            if (res > 0)
            {
                return new CreatedAtRouteResult("CreateNews", new { id = res }, e);
            }
            return BadRequest();

        }

        [HttpPut]
        public IActionResult Update([FromBody] Enews e)
        {
            var res = daNews.Update(e);
            if (res)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var res = daNews.Delete(id);
            if (res)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}