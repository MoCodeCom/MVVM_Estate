using Estate.Model.Data;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView
{
    public class PaymentModelView<T> : IModelView<PaymentData>
    {
        private List<PaymentData> _GetAllData;

        public PaymentModelView()
        {
            _GetAllData = GetAll();
        }
        
        public List<PaymentData> GetAllData 
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

        public void Add(PaymentData item)
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

        public List<PaymentData> GetAll()
        {
            List<PaymentData> li = new List<PaymentData>();
            li.Add(new PaymentData() 
            {
                id = 0,
                tansaction = "company 1",
                date = "01/08/2022",
                issued = "01/08/2022",
                amount = "-1500",
                paymentMethod = "card",
                state = "Paid",
            });
            li.Add(new PaymentData()
            {
                id = 1,
                tansaction = "company 2",
                date = "01/04/2022",
                issued = "01/04/2022",
                amount = "-3000",
                paymentMethod = "cash",
                state = "paid",
            });
            li.Add(new PaymentData()
            {
                id = 2,
                tansaction = "company 3",
                date = "01/05/2022",
                issued = "01/05/2022",
                amount = "-1100",
                paymentMethod = "card",
                state = "Paid",
            });
            li.Add(new PaymentData()
            {
                id = 3,
                tansaction = "company 4",
                date = "12/03/2022",
                issued = "12/03/2022",
                amount = "-2000",
                paymentMethod = "card",
                state = "Paid",
            });
            li.Add(new PaymentData()
            {
                id = 4,
                tansaction = "company 5",
                date = "09/07/2022",
                issued = "09/07/2022",
                amount = "-200",
                paymentMethod = "cash",
                state = "Paid",
            });
            return li;
        }

        public PaymentData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(PaymentData item)
        {
            throw new NotImplementedException();
        }

   
    }
}
