using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Abstract;
using Example.CORE.Database;
using Microsoft.EntityFrameworkCore;

namespace Example.CORE.Concrate
{
    public class RepoStoryManager<T, Y> : IRepoStoryCore<T, Y>
       where T : class, IEntity
       where Y : DbContext, new()
    {
        public T Add(T Model)
        {
            using (var Context = new Y())
            {

                Context.Add<T>(Model);
                Context.SaveChanges();
                return Model;

            }
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            using (var Context = new Y())
            {

                return Context.Set<T>().FirstOrDefault(expression);

            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            using (var Context = new Y())
            {

                return Context.Set<T>().Where(expression).ToList();

            }

        }

        public IEnumerable<T> RemoveRange(Expression<Func<T, bool>> expression)
        {
            using (var context = new Y())
            {
                var RemoveList = context.Set<T>().Where(expression);
                context.Set<T>().RemoveRange(RemoveList);
                context.SaveChanges();
                return RemoveList;

            }
        }


        public T Remove(Expression<Func<T, bool>> expression)
        {
            using (var context = new Y())
            {
                var Entry = context.Set<T>().FirstOrDefault();
                context.Set<T>().Remove(Entry);
                context.SaveChanges();
                return Entry;

            }

        }
        public T Update(T Model)
        {
            using (var context = new Y())
            {
                var Entry = context.Entry<T>(Model);
                Entry.State = EntityState.Modified;
                context.SaveChanges();
                return Model;
            }
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            using (var context = new Y())
            { 
                return context.Set<T>().Any(expression);
            }
        }
    }
}
