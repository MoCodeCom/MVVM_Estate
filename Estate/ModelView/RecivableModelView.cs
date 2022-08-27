using Estate.Model.Data;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView
{
    public class RecivableModelView<T>:IModelView<RecivableData>
    {
        private List<RecivableData> _GetAllData;

        public RecivableModelView()
        {
            _GetAllData = GetAll();
        }

        public List<RecivableData> GetAllData
        {
            get { return _GetAllData; }
            set
            {
                if (_GetAllData != value)
                {
                    _GetAllData = value;
                }
            }
        }

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

        public List<RecivableData> GetAll()
        {
            List<RecivableData> li = new List<RecivableData>();
            li.Add(new RecivableData()
            {
                id = 0,
                tansaction = "company 1",
                date = "01/01/2022",
                issued = "01/01/2022",
                amount = "1500",
                paymentMethod = "card",
                state = "Recived",
            });
            li.Add(new RecivableData()
            {
                id = 1,
                tansaction = "company 2",
                date = "20/04/2022",
                issued = "20/04/2022",
                amount = "3000",
                paymentMethod = "cash",
                state = "Recived",
            });
            li.Add(new RecivableData()
            {
                id = 2,
                tansaction = "company 3",
                date = "10/03/2022",
                issued = "10/03/2022",
                amount = "1100",
                paymentMethod = "card",
                state = "Recived",
            });
            li.Add(new RecivableData()
            {
                id = 3,
                tansaction = "company 4",
                date = "22/02/2022",
                issued = "22/02/2022",
                amount = "2000",
                paymentMethod = "card",
                state = "Recived",
            });
            li.Add(new RecivableData()
            {
                id = 4,
                tansaction = "company 5",
                date = "30/07/2022",
                issued = "30/07/2022",
                amount = "200",
                paymentMethod = "cash",
                state = "Recived",
            });
            return li;
        }

        public RecivableData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
