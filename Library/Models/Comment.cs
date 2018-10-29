using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string CommentText { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; }
        public bool Banned { get; set; }
        public bool Gender { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
