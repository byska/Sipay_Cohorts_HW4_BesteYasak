using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohorts_HW4.Api.BookOperations;
using Sipay_Cohorts_HW4.Api.Validator;
using Sipay_Cohorts_HW4.DataAccess.Context;
using Sipay_Cohorts_HW4.Entities.DbSets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Sipay_Cohorts_HW4.Api.BookOperations.GetByIdQuery;
using static Sipay_Cohorts_HW4.Api.BookOperations.UpdateBookCommand;

namespace Sipay_Cohorts_HW4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            GetByIdQuery query = new GetByIdQuery(_dbContext, _mapper);
            BooksViewModel result = new BooksViewModel();
            try
            {
                query.Id = id;
                GetByIdQueryValidator validator = new GetByIdQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            try
            {
                command.Model = updatedBook;
                command.Id = id;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return RedirectToAction("GetByID", new { id = id });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            try
            {
                command.Id = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
