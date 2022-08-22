using Estate.Model.Data;
using Estate.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Estate.View.Pages.Classes;

namespace Estate.View.Pages.SubPages.Money
{

    public partial class Money : Page
    {

        PaymentModelView<PaymentData> paymentlist = new PaymentModelView<PaymentData>();
        RecivableModelView<RecivableData> recivablelist = new RecivableModelView<RecivableData>();


        public Money()
        {
            InitializeComponent();
            DataGridMoney.ItemsSource = null;
            DataGridMoney.ItemsSource = bothList();


        }

        public List<MoneyListData> bothList()
        {
            var li = new List<MoneyListData>();
            List<RecivableData> rec = recivablelist.GetAllData;
            List<PaymentData> pay = paymentlist.GetAllData;


            // unified both lists that has different generic in one list with new generic...
            List<MoneyListData> lirec = rec.Select(a => new MoneyListData 
            { 
                id = a.id,
                tansaction = a.tansaction,
                date = a.date,
                amount = a.amount,
                paymentMethod = a.paymentMethod,
                issued = a.issued,
                state = a.state
            }).ToList();
            List<MoneyListData> lipay = pay.Select(a => new MoneyListData
            {
                id = a.id,
                tansaction = a.tansaction,
                date = a.date,
                amount = a.amount,
                paymentMethod = a.paymentMethod,
                issued = a.issued,
                state = a.state
            }).ToList();

            
            li.AddRange(lirec);
            li.AddRange(lipay);
            

            return li.OrderBy(x => Convert.ToDateTime(x.date).ToString("MM/yyyy")).ToList(); ;
        }

        public List<PaymentData> payli { get; set; }
        public List<RecivableData> reciveli { get; set; }



        private void Filter(TextBox tb)
        {
            DataGridMoney.ItemsSource = null;
            var li = bothList();

            if (tb.Text != "")
            {
                var filterLandlord = li.Where(x =>
                x.tansaction.ToLower().Contains(tb.Text.ToLower()) ||
                x.date.ToLower().Contains(tb.Text.ToLower()) ||
                x.amount.ToLower().Contains(tb.Text.ToLower()) ||
                x.paymentMethod.ToLower().Contains(tb.Text.ToLower()) ||
                x.state.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridMoney.ItemsSource = null;
                DataGridMoney.ItemsSource = filterLandlord;
            }
            else
            {

                // solve dublicate data in the Money list when sorting doing
                DataGridMoney.ItemsSource = li;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        public void Dsort()
        {
            var DESCsortGrid = bothList().OrderByDescending(x => x.tansaction.ToLower());
            DataGridMoney.ItemsSource = null;
            DataGridMoney.ItemsSource = DESCsortGrid;
        }

        public void Asort()
        {
            var ASCsort = bothList().OrderBy(x => x.tansaction.ToLower());
            DataGridMoney.ItemsSource = null;
            DataGridMoney.ItemsSource = ASCsort;
        }


    }
}


/*
public List<MoneyListData> bothList()
{
            public List<MoneyListData> li = null; 
    }

        //var li = paymentlist.GetAllData.Concat(recivablelist.GetAllData).ToList();
        //PaymentModelView<PaymentData> li = new PaymentModelView<PaymentData>();
        //paymentlist.GetAllData.AddRange(recivablelist.GetAllData);
            //li = paymentlist;

            // to sort data accourding to the transaction date. 
            //return li.GetAllData.OrderBy(x => Convert.ToDateTime(x.date).ToString("MM/yyyy")).ToList();
            //return li.OrderBy(x => Convert.ToDateTime(x.date).ToString("MM/yyyy")).ToList();
*/
