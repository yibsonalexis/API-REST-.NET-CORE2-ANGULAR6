using Microsoft.AspNetCore.Mvc;
using NewsPush.DA.Business;
using NewsPush.Entities;

namespace NewsPush.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly IDaCategories daCategories;
        public CategoriesController(IDaCategories daCategories)
        {
            this.daCategories = daCategories;
        }

        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] ECategories e)
        {
            if (ModelState.IsValid)
            {
                var res = daCategories.Create(e);
                if (res != 0)
                {
                    return new CreatedAtRouteResult("CreatedCategory", new { id = res }, e );
                }
                return BadRequest("Error en la creacion");
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var res = daCategories.Delete(id);
                if (res)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// returns all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = daCategories.GetAll();
            if (res.Count > 0)
            {
                return Ok(res);
            }
            return NoContent();            
        }

        /// <summary>
        /// returns a category by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "CreatedCategory")]
        public IActionResult Get(int id)
        {
            var res = daCategories.Get(id);
            if (res.IdCategory != 0)
            {
                return Ok(res);
            }
            return NotFound();
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] ECategories e)
        {
            var res = daCategories.Update(e);
            if (res)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}