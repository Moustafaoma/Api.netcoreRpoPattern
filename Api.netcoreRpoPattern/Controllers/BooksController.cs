using Api.netcoreRpoPattern.core.Data;
using Api.netcoreRpoPattern.core.DTOs;
using Api.netcoreRpoPattern.core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.netcoreRpoPattern.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBaseGenericRepo<Book> _bookRepo;
		private readonly IMapper _mapper;
		public BooksController(IBaseGenericRepo<Book> bookRepo, IMapper mapper)
		{
			_bookRepo = bookRepo;
			_mapper = mapper;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var book = await _bookRepo.GetById(id);
			if (book == null) return BadRequest("Not book found!!");
			var dto = _mapper.Map<BookDetailsDTO>(book);
			return Ok(dto);
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var books = await _bookRepo.GetAll(new[] {"Author"});
			var dto = _mapper.Map<IEnumerable<BookDetailsDTO>>(books);
			return Ok(dto);

		}
		[HttpGet("{title}/Book")]
		public IActionResult GetByName( string title)
		{
			var isValid= _bookRepo.Find(b => b.Title == title, new[] { "Author"});
			if (isValid == null) return BadRequest("Not Found");
			return Ok(isValid);
		}
		

	}
}
