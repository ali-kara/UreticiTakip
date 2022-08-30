using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEntity<T>
    {

        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        List<T> GetAll();
        IEnumerable<T> GetIEnum(Expression<Func<T, bool>> filter = null);
        int Update(T entity);
        int Insert(T entity);
        int Delete(T entity);
    }
}
