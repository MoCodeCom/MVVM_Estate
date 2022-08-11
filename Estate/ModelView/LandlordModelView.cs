using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView
{


    public class LandlordModelView<T> : IModelView<LandlordData>
    {
        private IList<LandlordData> _GetAll;

        public LandlordModelView()
        {
            _GetAll = GetAll();

        }

        public IList<LandlordData> GetAllData { 
            get { return _GetAll; } 
            set { _GetAll = value; }
        }



        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<LandlordData> GetAll()
        {
            List<LandlordData> li = new List<LandlordData>();
            li.Add(new LandlordData()
            {
                FirstName = "Mohammed",
                LastName = "Alfadhel",

                Address = new AddressData()
                {
                    LineOne = "73 conybere",
                    LineTwo = "Higate",
                    PostCode = "B12 0YL",
                    City = "Birmingham",
                    Country = "UnitedKingdom"
                },
                PostCode = "B12 0YL",
                Email = "mjmdell@gmial.com",
                Phone = "07460726920"
            });

            li.Add(new LandlordData()
            {
                FirstName = "Hasan",
                LastName = "Alfadhel",
                Address = new AddressData()
                {
                    LineOne = "73 conybere",
                    LineTwo = "Higate",
                    PostCode = "B18 0YL",
                    Country = "UnitedKingdom"
                },
                PostCode = "B18 0YL",
                Email = "hasandell@gmial.com",
                Phone = "07460726930"
            });

            li.Add(new LandlordData()
            {
                FirstName = "Ahmed",
                LastName = "Alfadhel",
                Address = new AddressData()
                {
                    LineOne = "73 conybere",
                    LineTwo = "Higate",
                    PostCode = "B32 0YL",
                    Country = "UnitedKingdom"
                },
                PostCode = "B32 0YL",
                Email = "ahmeddell@gmial.com",
                Phone = "07460782920"
            });

            li.Add(new LandlordData()
            {
                FirstName = "Rasha",
                LastName = "Almohy",
                Address = new AddressData()
                {
                    LineOne = "73 conybere",
                    LineTwo = "Higate",
                    PostCode = "B1 0YL",
                    Country = "UnitedKingdom"
                },
                PostCode = "B1 0YL",
                Email = "rashaell@gmial.com",
                Phone = "07460726925"
            });

            li.Add(new LandlordData()
            {
                FirstName = "Mohammed",
                LastName = "Alfadhel",

                Address = new AddressData()
                {
                    LineOne = "100 conybere",
                    LineTwo = "Higates",
                    PostCode = "B80 0YL",
                    Country = "UnitedKingdom"
                },
                PostCode = "B12 0YL",
                Email = "mjmdell@gmial.com",
                Phone = "07460326920"
            });


            return li;
        }

        public LandlordData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }












    /*
    public class LandlordModelView<T> : IModelView<LandlordData>
    {
        private ObservableCollection<LandlordData> _GetAll;

        public LandlordModelView()
        {

        }




        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public  ObservableCollection<LandlordData> GetAll()
        {
            ObservableCollection<LandlordData> li = new ObservableCollection<LandlordData>();
            li.Add(new LandlordData()
            {
                FirstName = "Mohammed",
                LastName = "Alfadhel",
                
                Address = new AddressData()
                    { LineOne = "73 conybere", LineTwo = "Higate",
                        PostCode = "B12 0YL", Country = "UnitedKingdom" },
                PostCode = "B12 0YL",
                Email = "mjmdell@gmial.com",
                Phone = "07460726920"
            }) ;

            li.Add(new LandlordData()
                {
                    FirstName = "Hasan",
                    LastName = "Alfadhel",
                    Address = new AddressData()
                    { LineOne = "73 conybere", LineTwo = "Higate", 
                        PostCode = "B18 0YL", Country = "UnitedKingdom" },
                    PostCode = "B18 0YL",
                    Email = "hasandell@gmial.com",
                    Phone = "07460726930"
                });

            li.Add(new LandlordData()
                    {
                        FirstName = "Ahmed",
                        LastName = "Alfadhel",
                        Address = new AddressData()
                        { LineOne = "73 conybere", LineTwo = "Higate", 
                            PostCode = "B32 0YL", Country = "UnitedKingdom" },
                        PostCode = "B32 0YL",
                        Email = "ahmeddell@gmial.com",
                        Phone = "07460782920"
                    });

            li.Add(new LandlordData()
                    {
                        FirstName = "Rasha",
                        LastName = "Almohy",
                        Address = new AddressData()
                        { LineOne = "73 conybere", LineTwo = "Higate", 
                            PostCode = "B1 0YL", Country = "UnitedKingdom" },
                        PostCode = "B1 0YL",
                        Email = "rashaell@gmial.com",
                        Phone = "07460726925"
                    });


            return li;
        }

        public LandlordData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
    */


}
