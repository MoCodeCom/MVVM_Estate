using Estate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Interface
{
    public interface IDiryModel
    {
        List<DiryModel> GetDiryList();
        List<DiryModel> GetDiry(string date);
        void DeleteDiry(string date);
        void AddDiry();

    }
}
