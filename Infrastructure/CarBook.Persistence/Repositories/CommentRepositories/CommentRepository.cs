using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            var values = _context.Comments.Select(x=> new Comment
            {
                BlogID = x.BlogID,
                Description = x.Description,
                CommentID = x.CommentID,
                CreatedDate = x.CreatedDate,
                Name = x.Name,
            }).ToList();
            return values;
        }

        public Comment GetById(int id)
        {
            var value = _context.Comments.Find(id);
            return value;
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return  _context.Set<Comment>().Where(x => x.BlogID == id).ToList();
        }

        public void Remove(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentID);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
        }

        public int GetCountCommentByBlog(int id)
        {
            return _context.Comments.Where(x=>x.BlogID== id).Count();
        }
    }
}
