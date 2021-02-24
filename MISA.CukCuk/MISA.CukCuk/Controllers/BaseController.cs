using MISA.CukCuk.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseService">Base service</param>
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        // GET: api/v1/<Controller>
        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        /// <returns>Tất cả các bản ghi và status code tương ứng</returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            var res = _baseService.GetEntities();
            return StatusCode(res.StatusCode, res.Data);
        }

        // GET: api/v1/<Controller>/5
        /// <summary>
        /// Lấy về bản ghi theo id truyền vào
        /// </summary>
        /// <param name="id">id của bản ghi cần lấy</param>
        /// <returns>Bản ghi phù hợp với id và status code tương ứng</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = _baseService.GetEntity(id);
            return StatusCode(res.StatusCode, res.Data);
        }

        // POST: api/v1/<Controller>
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm mới</param>
        /// <returns>Số dòng của db bị ảnh hưởng và status code</returns>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var res = _baseService.InsertEntity(entity);
            return StatusCode(res.StatusCode, res.Data);
        }

        // PUT: api/v1/<Controller>/5
        /// <summary>
        /// Cập nhật thông tin một bản ghi
        /// </summary>
        /// <param name="id">id của bản ghi cần cập nhật</param>
        /// <param name="entity">Bản ghi thay thế</param>
        /// <returns>số dòng bị ảnh hưởng và status code tương ứng</returns>
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] T entity)
        {
            var res = _baseService.UpdateEntity(id, entity);
            return StatusCode(res.StatusCode, res.Data);
        }

        // DELETE: api/v1/<Controller>/5
        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="id">id của bản ghi cần xóa</param>
        /// <returns>số dòng bị ảnh hưởng và status code tương ứng</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _baseService.DeleteEntity(id);
            return StatusCode(res.StatusCode, res.Data);
        }
        #endregion

    }
}
