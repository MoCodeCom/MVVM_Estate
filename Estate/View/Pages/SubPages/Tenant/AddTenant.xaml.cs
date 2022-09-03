using Estate.Model.Data;
using Estate.ModelView.Classes;
using Estate.ModelView;
using Estate.View.Pages.SubPages.Landlord;
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
using static Estate.View.Pages.SubPages.Landlord.Add;
using System.Text.RegularExpressions;
using Estate.Model.Interface;

namespace Estate.View.Pages.SubPages.Tenant
{
    /// <summary>
    /// Interaction logic for AddTenant.xaml
    /// </summary>
    public partial class AddTenant : Page
    {
        TenantModelView<TenantData> llMV = new TenantModelView<TenantData>();
        CheckPhone<TenantData> checkPhone = new CheckPhone<TenantData>();
        public AddTenant()
        {
            InitializeComponent();
            cbCountries.ItemsSource = Enum.GetValues(typeof(contries)).Cast<contries>();
            Clear();
        }

        public enum contries
        {
            UnitedKingdom, Afghanistan, Albania, Algeria, Andorra, Angola, AntiguaandBarbuda, Argentina,
            Armenia, Australia, Austria, Azerbaijan, TheBahamas, Bahrain, Bangladesh, Barbados,
            Belarus, Belgium, Belize, Benin, Bhutan, Bolivia, BosniaandHerzegovina, Botswana,
            Brazil, Brunei, Bulgaria, BurkinaFaso, Burundi, CaboVerde, Cambodia, Cameroon, Canada, CentralAfricanRepublic,
            Chad, Chile, China, Colombia, Comoros, Congo, DemocraticRepublicoftheCongo,
            RepublicoftheCostaRica, CôtedIvoire, Croatia, Cuba, Cyprus, CzechRepublic,
            Denmark, Djibouti, Dominica, Dominican_Republic,
            EastTimorTimorLeste, Ecuador, Egypt, ElSalvador, EquatorialGuinea, Eritrea, Estonia,
            Eswatini, Ethiopia, Fiji, Finland, France, Gabon, TheGambia, Georgia, Germany, Ghana, Greece,
            Grenada, Guatemala, Guinea, GuineaBissau, Guyana, Haiti, Honduras, Hungary, Iceland, India,
            Indonesia, Iran, Iraq, Ireland, Israel, Italy, Jamaica, Japan, Jordan, Kazakhstan, Kenya, Kiribati,
            Korea_North, Korea_South, Kosovo, Kuwait, Kyrgyzstan, Laos, Latvia, Lebanon, Lesotho, Liberia, Libya,
            Liechtenstein, Lithuania, Luxembourg, Madagascar, Malawi, Malaysia, Maldives, Mali, Malta,
            MarshallIslands, Mauritania, Mauritius, Mexico, Micronesia_Federated_States_of, Moldova,
            Monaco, Mongolia, Montenegro, Morocco, Mozambique, MyanmarBurma,
            Namibia, Nauru, Nepal, Netherlands, NewZealand, Nicaragua, Niger,
            Nigeria, NorthMacedonia, Norway, Oman, Pakistan, Palau, Panama,
            PapuaNewGuinea, Paraguay, Peru, Philippines, Poland, Portugal, Qatar, Romania, Russia, Rwanda,
            SaintKittsandNevis, SaintLucia, SaintVincentandtheGrenadines, Samoa, SanMarino,
            SaoTomeandPrincipe, SaudiArabia, Senegal, Serbia, Seychelles, Sierra, LeoneSingapore,
            Slovenia, SolomonIslands, Somalia, SouthAfrica, Spain, SriLanka,
            Sudan, SouthSudan, Suriname, Sweden, Switzerland, Syria,
            Taiwan, Tajikistan, Tanzania, Thailand, Togo, Tonga, TrinidadandTobago,
            Tunisia, Turkey, Turkmenistan, Tuvalu, Uganda,
            Ukraine, UnitedArabEmirates, UnitedStates, Uruguay, Uzbekistan,
            Vanuatu, VaticanCity, Venezuela, Vietnam, Yemen, Zambia, Zimbabwe
        }

        private void btnSave_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (tbfname.Text == "" && tblname.Text == "" && tbPhone.Text == "" && tbEmail.Text == "")
                {
                    Reject();
                }
                else
                {
                    if (tbfname.Text != "" && tblname.Text != "" && tbPhone.Text != "" && tbEmail.Text != "")
                    {

                        TenantData ttd = new TenantData()
                        {
                            FirstName = tbfname.Text,
                            LastName = tblname.Text,
                            Phone = tbPhone.Text,
                            Email = tbEmail.Text,
                            Address = new AddressData()
                            {
                                LineOne = tbLineOne.Text,
                                LineTwo = tbLineTwo.Text,
                                PostCode = tbPostCode.Text,
                                City = tbCity.Text,
                                Country = cbCountries.Text
                            }
                        };

                        //if (!llMV.checkPhoneExists(lld))
                        if (!checkPhone.checkPhoneExists(ttd, "TenantTable"))
                        {
                            llMV.Add(ttd);
                            MessageBox.Show("The adding is done successfully.", "Add");
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("The phone number is exist already!", "Error");
                        }
                    }
                    Reject();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            tbfname.Text = "";
            tblname.Text = "";
            tbLineOne.Text = "";
            tbLineTwo.Text = "";
            tbPostCode.Text = "";
            tbCity.Text = "";
            cbCountries.Text = "UnitedKingdom";
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbfname.Focus();
        }
        public void Reject()
        {
            bool emailInspactor = TestContent.IsValidEmailAddress(tbEmail.Text);
            bool fnInspactor = TestContent.IsValidName(tbfname.Text);
            bool lnInspactor = TestContent.IsValidName(tblname.Text);
            bool phoneInspactor = TestContent.IsValidPhone(tbPhone.Text);

            if (!emailInspactor)
            {
                tbEmail.Text = "";
                errEmail.Visibility = Visibility.Visible;
            }
            else
            {
                errEmail.Visibility = Visibility.Hidden;
            }

            if (!fnInspactor)
            {
                tbfname.Text = "";
                errFname.Visibility = Visibility.Visible;
            }
            else
            {
                errFname.Visibility = Visibility.Hidden;
            }

            if (!lnInspactor)
            {
                tblname.Text = "";
                errLname.Visibility = Visibility.Visible;
            }
            else
            {
                errLname.Visibility = Visibility.Hidden;
            }

            if (!phoneInspactor)
            {
                tbPhone.Text = "";
                errPhone.Visibility = Visibility.Visible;
            }
            else
            {
                errPhone.Visibility = Visibility.Hidden;
            }

            if (errEmail.Visibility == Visibility.Visible ||
                errFname.Visibility == Visibility.Visible ||
                errLname.Visibility == Visibility.Visible ||
                errPhone.Visibility == Visibility.Visible
                )
            {
                MessageBox.Show("Please re-enter information with red star.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }


    public static class TestContent
    {
        public static bool IsValidEmailAddress(string emailStr)
        {
            Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return r.IsMatch(emailStr);
        }

        public static bool IsValidName(string name)
        {
            Regex n = new Regex("^[A-Za-z]{1,20}$");
            return n.IsMatch(name);
        }

        public static bool IsValidPhone(string phone)
        {
            Regex n = new Regex("^[0-9]{11}$");
            return n.IsMatch(phone);
        }
    }
}
