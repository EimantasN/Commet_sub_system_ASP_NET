using Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using T120B143.Models;

namespace Library
{
    public interface IDb
    {
        Task<List<Comment>> GetComments();
        Task<bool> Like(int id);
        Task<bool> Dislike(int id);
        Task<bool> Add(CommentJson com);
    }
}
