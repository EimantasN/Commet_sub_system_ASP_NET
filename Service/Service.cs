using Library;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T120B143.Models;

namespace Service
{
    public class Service : IDb
    {
        private readonly DbContextApi _ctx;

        public Service(DbContextApi ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Comment>> GetComments()
        {
            try
            {
                return await _ctx.Comments.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Like(int id)
        {
            try
            {
                var data = await _ctx.Comments.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    data.Likes++;
                    _ctx.Entry(data).State = EntityState.Modified;
                    await _ctx.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Dislike(int id)
        {
            try
            {
                var data = await _ctx.Comments.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    data.Dislikes++;
                    _ctx.Entry(data).State = EntityState.Modified;
                    await _ctx.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Add(CommentJson com)
        {
            try
            {
                var NewCom = new Comment
                {
                    Name = com.Name,
                    LastName = com.Lastname,
                    Banned = false,
                    CommentText = com.Message,
                    Company = com.Company,
                    Created = DateTime.Now,
                    Dislikes = 0,
                    Likes = 0,
                    Gender = com.Gender,
                    ImageUrl = com.Img
                };
                await _ctx.Comments.AddAsync(NewCom);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
