using Estate.Model.Data;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView
{
    public class TenantModelView<T> : IModelView<TenantData>
    {
        private IList<TenantData> _GetAll;
        public TenantModelView()
        {
            _GetAll = GetAll();
        }
        public IList<TenantData> GetAllData { get { return _GetAll; } 
            set { _GetAll = value; } }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TenantData> GetAll()
        {
            List<TenantData> li = new List<TenantData>()
            {
                new TenantData(){ FirstName = "Ali", LastName ="Hussain" , 
                PostCode = "B28 0AJ", Email = "ali@gmail.com", Phone = "07455552540",
                Address = new Model.Interface.AddressData(){ PostCode = "B28 0AJ", 
                    Country = "Iraq", LineOne ="Basra", LineTwo="Ashar"}
                },

                new TenantData(){ FirstName = "Sara", LastName ="John" ,
                PostCode = "B27 0SJ", Email = "Sara@gmail.com", Phone = "07465652540",
                Address = new Model.Interface.AddressData(){ PostCode = "B28 0AJ",
                    Country = "Germany", LineOne ="Basra", LineTwo="Ashar"}
                },

                new TenantData(){ FirstName = "Mechil", LastName ="Jorden" ,
                PostCode = "B1 0SS", Email = "mechil@gmail.com", Phone = "07488882540",
                Address = new Model.Interface.AddressData(){ PostCode = "B28 0AJ",
                    Country = "France", LineOne ="Basra", LineTwo="Ashar"}
                }
            };

            return li;

        }

        public TenantData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
