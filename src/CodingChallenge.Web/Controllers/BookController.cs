using System;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Book;
using CodingChallenge.Application.Domain.Models;
using CodingChallenge.Application.Domain.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        
        public BookController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _mediator.Send(new GetBookListQuery());

            return Ok(books);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            return book is null
                ? NotFound()
                : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            var result = await _mediator.Send(new CreateBookCommand(book));

            return CreatedAtAction(nameof(GetAuthor), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] Book book)
        {
            await _mediator.Send(new UpdateBookCommand(book));

            return NoContent();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _mediator.Send(new DeleteBookCommand(id));

            return NoContent();
        }
    }
}