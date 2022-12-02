using ForumAPI.Entities;

namespace ForumAPI.Services
{
    public class ThreadServices : IThreadServices
    {
        public string programmingPostsId = "0";
        public string FilmPostsId = "1";
        public List<Entities.Thread> GenerateThreads()
        {
            var programmingPosts = new List<Post>
            {
                new Post(){Id = Guid.NewGuid(), Username="Diogo", Title="Here's how to create a forum using .Net and React", Body="Just try to do it and google search your way in, Just try to do it and google search your way in, Just try to do it and google search your way in.", Category = Enums.CategoryEnum.Clarification, ImageURL="..."},
                new Post(){Id = Guid.NewGuid(), Username="Marwan", Title="For programmers who stress alot", Body="Calm down you should enjoy programming and building stuff don't stress it. Calm down you should enjoy programming and building stuff don't stress it. ", Category = Enums.CategoryEnum.Suggestion, ImageURL="..."},
                new Post(){Id = Guid.NewGuid(), Username="Marwan", Title="How to center a div", Body="You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.", Category = Enums.CategoryEnum.Question, ImageURL="..."},
            };

            var filmPosts = new List<Post>
            {
                new Post(){Id = Guid.NewGuid(), Username="Diogo", Title="For those who say Andrei Tarkovsky's films are boring, here's what you want to do", Body="Don't watch his movies. Don't watch his movies. Don't watch his movies", Category = Enums.CategoryEnum.Suggestion, ImageURL="..."},
                new Post(){Id = Guid.NewGuid(), Username="Marwan", Title="What are the best Christmas films ever", Body="Christmas is coming and I want to know. Christmas is coming and I want to know. Christmas is coming and I want to know. ", Category = Enums.CategoryEnum.Question, ImageURL="..."},
              
            };

            return new List<Entities.Thread>
            {
                new Entities.Thread(){Id = programmingPostsId, Title="Programming", Posts = programmingPosts},
                new Entities.Thread(){Id = FilmPostsId, Title="Films", Posts = filmPosts},
            };
            
        }

        public List<Entities.Thread> GetAllThreads()
        {
            return GenerateThreads();
        }

        public Entities.Thread GetThreadById(string id)
        {
            var threads = GenerateThreads();
            var thread = new Entities.Thread();
            threads.ForEach(t => {
                if (t.Id == id) thread = t;
            });
            return thread;
        }
    }
}
