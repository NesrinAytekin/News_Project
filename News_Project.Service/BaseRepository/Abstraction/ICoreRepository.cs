using News_Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News_Project.Service.BaseRepository.Abstraction
{
    public interface ICoreRepository <T>  where T : BaseEntity //Where T:BaseEntity dememin sebebi ileride T'nin yerine koyacağım şey BaseEntity clasından kalıtım alan herhangi  bir üyesi yani class'ı tipinde olacak 
    {
        void Add(T item); //T Tipinde birşey alacak diyoruz.
        void Add(List<T> items);
        void Update(T item);
        void Remove(T item);
        void Remove(int id);
        void RemoveAll(Expression<Func<T, bool>> exp);
        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
