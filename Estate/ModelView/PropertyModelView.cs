using Estate.Model.Data;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView
{
    public class PropertyModelView<T> : IModelView<PropertyData>
    {

        private IList<PropertyData> _GetAll;
        public PropertyModelView()
        {
            _GetAll = GetAll();
        }

        public IList<PropertyData> GetAllData
        {
            get { return _GetAll; }
            set { _GetAll = value; }
        }

        public void Add(PropertyData item)
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
        public List<PropertyData> GetAll()
        {
            List<PropertyData> li = new List<PropertyData>();
            li.Add( new PropertyData() { 
                City = "Birmingham", 
                Country = "UnitedKingdom", 
                FullName = "Mohammed Alfadhel",
                PostCode = "B12 0YL",
                LineOne = "73 Conybere", 
                LineTwo = "Highgate", 
                Phone = "020110024524"
            });
            li.Add(new PropertyData()
            {
                City = "York",
                Country = "UnitedKingdom",
                FullName = "Mohammed Alfadhel",
                PostCode = "Y60 3SH",
                LineOne = "187 North city",
                LineTwo = "Main city",
                Phone = "020113030524"
            });
            li.Add(new PropertyData()
            {
                City = "London",
                Country = "UnitedKingdom",
                FullName = "Rasha Almohy",
                PostCode = "B44 0BB",
                LineOne = "people high street",
                LineTwo = "102 skysail St",
                Phone = "020114242524"
            });
            li.Add(new PropertyData()
            {
                City = "Birmingham",
                Country = "UnitedKingdom",
                FullName = "Hasan Alfadhel",
                PostCode = "B28 0AJ",
                LineOne = "stratford Rd",
                LineTwo = "",
                Phone = "020155554524"
            });
            li.Add(new PropertyData()
            {
                City = "Newcastle",
                Country = "UnitedKingdom",
                FullName = "Mohammed Alfadhel",
                PostCode = "NE10 3SC",
                LineOne = "Wallsend",
                LineTwo = "Northshield",
                Phone = "0201133334"
            });
            li.Add(new PropertyData()
            {
                City = "Liverpool",
                Country = "UnitedKingdom",
                FullName = "Ahmed Alfadhel",
                PostCode = "L44 2LU",
                LineOne = "108 Cherch st",
                LineTwo = "Mery road",
                Phone = "0201180804"
            });

            return li;
        }
        public PropertyData GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateById(PropertyData item)
        {
            throw new NotImplementedException();
        }


    }
}
