using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Database;
using Microsoft.EntityFrameworkCore;
namespace Example.CORE.Abstract
{
    public interface IRepoStoryCore<T,Y> 
        where T : class,IEntity
        where Y : DbContext,new()   
    {
        public T Get(Expression<Func<T, bool>> expression);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        public T Add(T Model);
        public T Update(T Model);
        public bool Any(Expression<Func<T, bool>> expression);
        public IEnumerable<T> RemoveRange(Expression<Func<T, bool>> expression);
        public T Remove(Expression<Func<T, bool>> expression);



    }
}
