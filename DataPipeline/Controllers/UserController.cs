using DataPipeline.Dtos;
using DataPipeline.Dtos.Pagination;
using DataPipeline.Models;
using DataPipeline.Models.UnitOfWork;
using DataPipeline.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace DataPipeline.Controllers
{
    [Route("/users")]
    public class UserController : ControllerBase
    {
        private readonly DbAppContext _context;
        private readonly IUnitOfWork<DbAppContext> _uow;
        public UserController(DbAppContext context, IUnitOfWork<DbAppContext> uow)
        {
            _context = context;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<Dtos.Pagination.PagedResult<User>>> getUsers([FromQuery] PagedRequest req)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(req.Keyword))
            {
                query = query.Where(u => u.FullName.Contains(req.Keyword));
            }

            if (!string.IsNullOrEmpty(req.OrderBy))
            {
                var sort = req.SortDirection.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{req.OrderBy} {sort}");
            }

            var totalItems = await query.CountAsync();

            var items = await query.Skip((req.Page - 1) * req.PageSize)
                                    .Take(req.PageSize)
                                    .ToListAsync();

            return Ok(new Dtos.Pagination.PagedResult<User>(totalItems, req.Page, req.PageSize, items));
        }


        [HttpGet("/procedure")]
        public async Task<ActionResult<List<User>>> getUsersByCity([FromQuery] string city)
        {
            var users = _context.Users.FromSqlRaw("EXEC GetUsersByCity @City = {0}", city);
            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult> addUser([FromBody] CreateUserDTO req)
        {
            var newUser = new User(req.FullName, req.Email, req.Age, req.Country, req.City);
            _context.Users.Add(newUser);
            await _uow.CompleteAsync();

            return Ok("Add successfully");
        }
    }
}
