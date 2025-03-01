﻿using CarBook.Application.Features.Mediator.Commands.CommentCommand;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Repositories.CommentRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
       private readonly IGenericRepository<Comment> _commentRepository;
       private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comment = _commentRepository.GetById(id);
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {
            _commentRepository.create(comment);
            return Ok(comment);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = _commentRepository.GetById(id);
            _commentRepository.Remove(comment);
            return Ok();
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _commentRepository.GetCommentsByBlogId(id);
            return Ok(value);
        }

        [HttpGet("GetCountCommentByBlog")]
        public IActionResult GetCountCommentByBlog(int id)
        {
            var value = _commentRepository.GetCountCommentByBlog(id);
            return Ok(value);
        }

        [HttpPost("CreateCommentWithMediator")]

        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand createCommentCommand)
        {
            await _mediator.Send(createCommentCommand);
            return Ok("eklendi");
    }
}
}
