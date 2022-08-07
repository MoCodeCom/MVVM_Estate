using Estate.Interface;
using Estate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data
{
    public class DiryData : IDiryModel
    {
        public void AddDiry()
        {
            throw new NotImplementedException();
        }

        public void DeleteDiry(string date)
        {
            throw new NotImplementedException();
        }

        public List<DiryModel> GetDiry(string date)
        {
            throw new NotImplementedException();
        }

        public List<DiryModel> GetDiryList()
        {
            List<DiryModel> li = new List<DiryModel>();

            li.Add(new DiryModel() { id = 0, date = "22/06/2022", note = "test test test 1", title = "title 1" });
            li.Add(new DiryModel() { id = 1, date = "10/04/2022", note = "test test test 2", title = "title 2" });
            li.Add(new DiryModel() { id = 2, date = "11/20/2021", note = "test test test 3", title = "title 3" });
            li.Add(new DiryModel() { id = 3, date = "08/03/2020", note = "test test test 4", title = "title 4" });
            li.Add(new DiryModel() { id = 4, date = "01/04/2023", note = "test test test 5", title = "title 5" });

            return li;
        }
    }
}
