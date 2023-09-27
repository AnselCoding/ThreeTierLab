using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using System.Collections.Generic;
using ThreeTierLab.Common.Models;
using ThreeTierLab.DTOs;
using ThreeTierLab.Repository.Models;
using ThreeTierLab.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTierLab.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// 使用條件搜尋使用者。
        /// </summary>
        /// <param name="userSearchInfo">使用者搜尋條件</param>
        /// <returns>符合條件的使用者清單</returns>
        // GET: api/Users/GetAll(?Name=Fa&MobilePhone=3333&Role=User)
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserSearchInfo userSearchInfo)
        {
            var users = await _usersService.GetAll(userSearchInfo);
            if (users == null)
            {
                return NotFound("使用者不存在");
            }
            var results = users.Select(x => TinyMapper.Map<UserResultModel>(x));

            return Ok(results);
        }

        /// <summary>
        /// 使用 id 查詢使用者。
        /// </summary>
        /// <param name="id">使用者 id</param>
        /// <returns>該使用者資料</returns>
        // GET api/Users/Get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var user = await _usersService.Get(id);
            if (user == null)
            {
                return NotFound("使用者不存在");
            }
            var result = TinyMapper.Map<UserResultModel>(user);
            return Ok(result);
        }

        /// <summary>
        /// 新建使用者。
        /// </summary>
        /// <param name="userParameter">使用者資料</param>
        /// <returns></returns>
        // POST api/Users/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserParameter userParameter)
        {
            User user = TinyMapper.Map<User>(userParameter);
            await _usersService.Create(user);
            return Ok();
        }

        /// <summary>
        /// 更新使用者資訊。
        /// </summary>
        /// <param name="id">使用者 id</param>
        /// <param name="userParameter">使用者資料</param>
        /// <returns></returns>
        // PUT api/Users/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UserParameter userParameter)
        {
            var isItemExists = await _usersService.IsItemExists(id);
            if (isItemExists)
            {
                User user = TinyMapper.Map<User>(userParameter);
                user.Id = id;
                await _usersService.Update(user);
                return Ok();
            }
            return NotFound("使用者不存在");
        }

        /// <summary>
        /// 刪除使用者。
        /// </summary>
        /// <param name="id">使用者 id</param>
        /// <returns></returns>
        // DELETE api/Users/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var user = await _usersService.Get(id);
            if(user == null)
            {
                return NotFound("使用者不存在");
            }
            await _usersService.Delete(user);
            return Ok();
        }
    }
}
