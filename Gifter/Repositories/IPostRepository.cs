using Gifter.Models;
using System;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        List<Post> GetAllWithComments();

        Post GetById(int id);
        void Update(Post post);
        List<Post> Search(string criterion, string two, bool sortDescending);
        List<Post> Hottest(DateTime criterion, bool sortDescending);
        //  void Search(Post post);
    }
}