using Company.MVC.DAL.Models;
using Company.MVC.DAL.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MVC.BLL.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
        Task<T> GetWithSpecAsync(ISpecifications<T> spec);


        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
