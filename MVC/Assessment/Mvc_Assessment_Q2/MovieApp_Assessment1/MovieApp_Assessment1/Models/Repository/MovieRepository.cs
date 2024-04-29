﻿using MVC_Movie_Assessment1;
using MVC_Movie_Assessment1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieApp_Assessment1.Models.Repository
{
    public class MovieRepository<T> : IMovieRepository<T> where T : class
    {
        MovieDBContext db = new MovieDBContext();

        public DbSet<T> DbSet { get; }

        DbSet<T> dbSet;

        public MovieRepository()
        {
            db = new MovieDBContext();
            DbSet = db.Set<T>();
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}