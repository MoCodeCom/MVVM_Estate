using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView.Interface
{
    public interface IModelView<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void DeleteById(int id);
        void DeleteAll();
        void UpdateById(T item);


    }
}
