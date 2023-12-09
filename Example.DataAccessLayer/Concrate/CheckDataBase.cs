using Example.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccessLayer.Concrate
{
    public class CheckDataBase : ICheckDataBase
    {
        public void CheckDb()
        {
            using (var Context = new DataContext())
            {
                if(!Context.Database.CanConnect())
                Context.Database.EnsureCreated();
             




            }
        }
 
    }
}
