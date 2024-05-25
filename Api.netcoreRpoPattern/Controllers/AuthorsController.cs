using Api.netcoreRpoPattern.core.Data;
using Api.netcoreRpoPattern.core.Interfaces;
using Api.netcoreRpoPattern.ef.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.netcoreRpoPattern.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IBaseGenericRepo<Author> _authorsRepo;
        public AuthorsController(IBaseGenericRepo<Author> authorsRepo)
        {
			_authorsRepo = authorsRepo;
        }
		[HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
		{
			var author= await _authorsRepo.GetById(id);
			if (author == null) return BadRequest("Not author found!!");
			return Ok(author);
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _authorsRepo.GetAll());
		}
		[HttpGet("{name}/Author")]
		public IActionResult GetByName(string name)
		{
			var isValid = _authorsRepo.Find(b => b.Name ==name);
			if (isValid == null) return BadRequest("Not Found");
			return Ok(isValid);
		}
	}
}
 