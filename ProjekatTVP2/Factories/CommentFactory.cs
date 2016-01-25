using ProjekatTVP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTVP2.Factories
{
    public class CommentFactory
    {
        private FileFactory _factory;
        private int brojac;

        public CommentFactory()
        {
            brojac = 0;
            _factory = new FileFactory();
        }

        public async Task<List<Comment>> LoadAllComments()
        {
            List<Comment> comments = new List<Comment>();
            Comment comment = new Comment();
            while((comment = await _factory.Read<Comment>("Comment-" + (brojac++) + ".xml")) != null)
            {
                comments.Add(comment);
            }
            return comments;
        }

        public async void WriteComment(Comment comment)
        {
            await _factory.Write(comment);
        }

        public int Brojac { get { return brojac; } }
    }
}
