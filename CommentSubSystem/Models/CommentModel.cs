using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T120B143.Models
{
    public class CommentModel
    {
        private Regex ValidImage = new Regex(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)");


        public List<Comment> Comments { get; set; }
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

        public CommentModel()
        { }

        public string GetName(Comment com)
        {
            return com.Name + " " + com.LastName;
        }

        public List<Comment> Order(string order)
        {
            if (order == "asc")
            {
                return Comments.OrderBy(x => x.Created).ToList();
            }
            return Comments;
        }

        public string GetImg(Comment com)
        {
            if (!string.IsNullOrEmpty(com.ImageUrl) && ValidImage.IsMatch(com.ImageUrl))
                return com.ImageUrl;

            return !com.Gender ? 
                "https://cdn1.iconfinder.com/data/icons/hipster-4/512/hipster-fashion-style-beard-man-glasses-512.png" //Male img
                : 
                "https://melbournechapter.net/images/short-hair-girl-clipart.png";  //Female img

        }
    }
}
