using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess //Core katmanı, diğer katmanları referans almaz
{
    public interface IEntityRepository<T> where T:class,IEntity //Hem ICategoryDal, hem de IProductDal'da aynı kodları kullanmamak için bunu oluşturduk.
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}











