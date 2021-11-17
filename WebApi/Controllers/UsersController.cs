using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Helpers;
using Core.StorageManagers.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    /// <summary>
    /// Управление пользователями
    /// </summary>
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersStorageManager _usersSm;

        public UsersController(IUsersStorageManager usersSm)
        {
            _usersSm = usersSm;
        }

        /// <summary>
        /// Возвращает список всех пользователей
        /// </summary>
        /// <returns>IEnumerable{User}</returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
            => Ok(await _usersSm.GetAllAsync());

        /// <summary>
        /// Возвращает пользователя по его Id
        /// </summary>
        /// <returns>User</returns>
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long id)
            => Ok(await _usersSm.GetByIdAsync(id));

        /// <summary>
        /// Возвращает пользователей с указанными Ids
        /// </summary>
        /// <returns>User</returns>
        [HttpGet("get-by-ids")]
        public async Task<IActionResult> GetByIds([FromQuery] string ids)
            => Ok(await _usersSm.GetByIdsAsync(QueryParser.ParseIds(ids)));

        /// <summary>
        /// Создает нового пользователя
        /// </summary>
        /// <returns>Количество изменений</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] User entity)
            => Ok(await _usersSm.CreateAsync(entity));

        /// <summary>
        /// Обновляет данные пользователя
        /// </summary>
        /// <returns>Количество изменений</returns>
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] User entity)
            => Ok(await _usersSm.UpdateAsync(entity));

        /// <summary>
        /// Удаляет пользователя с заданным Id
        /// </summary>
        /// <returns>
        /// Количество изменений
        /// </returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromQuery] long id)
            => Ok(await _usersSm.DeleteAsync(id));
    }
}
