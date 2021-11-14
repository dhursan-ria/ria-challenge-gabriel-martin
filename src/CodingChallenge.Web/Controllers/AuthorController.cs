using System;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Author;
using CodingChallenge.Application.Domain.Models;
using CodingChallenge.Application.Domain.Queries.Author;
using CodingChallenge.Application.Domain.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;
        
        public AuthorController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _mediator.Send(new GetAuthorListQuery());

            return Ok(authors);
        }
        
        [HttpGet("top-expensive")]
        public async Task<IActionResult> GetTopBooks([FromQuery] int? year, [FromQuery] int? top)
        {
            var books = await _mediator.Send(new GetAuthorTopExpensiveBookListQuery(year ?? DateTime.UtcNow.Year, top ?? 3));

            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));

            return author is null
                ? NotFound()
                : Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            var result = await _mediator.Send(new CreateAuthorCommand(author));

            return CreatedAtAction(nameof(GetAuthor), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] Author author)
        {
            await _mediator.Send(new UpdateAuthorCommand(author));

            return NoContent();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _mediator.Send(new DeleteAuthorCommand(id));

            return NoContent();
        }
    }
}