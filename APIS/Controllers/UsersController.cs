using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersAPIDbContext dbContext;

        public UsersController(UsersAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task< ActionResult> GetUsers()
        {
            return Ok(await dbContext.User.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetUserById([FromRoute] Guid id)
        {
            var us = await dbContext.User.FindAsync(id);

            if (us == null)
                return NotFound();

            return Ok(us);

        }

        [HttpPost]
        public async Task<ActionResult> AddUser ([FromBody]AddUser user)
        {
            var us = new Users()
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone
            };

            await dbContext.User.AddAsync(us);
            await dbContext.SaveChangesAsync();

            return Ok(us);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<ActionResult> UpdateUser([FromRoute] Guid id, AddUser user)
        {
            var us = await dbContext.User.FindAsync(id);

            if (us == null)
                return NotFound();

            us.FirstName = user.FirstName;
            us.LastName = user.LastName;
            us.Email = user.Email;
            us.Phone = user.Phone;

            await dbContext.SaveChangesAsync();

            return Ok(us);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid id)
        {
            var us = await dbContext.User.FindAsync(id);

            if (us == null)
                return NotFound();

             dbContext.Remove(us);
            await dbContext.SaveChangesAsync();

            return Ok(us);

        }




    }
}
