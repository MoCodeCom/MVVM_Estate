using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace Estate.View.Pages.SubPages.Landlord
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
            cbCountries.ItemsSource = Enum.GetValues(typeof(contries)).Cast<contries>();
            
        }

        public enum contries
        {
            UnitedKingdom,Afghanistan, Albania, Algeria, Andorra, Angola, AntiguaandBarbuda, Argentina,
            Armenia, Australia, Austria, Azerbaijan, TheBahamas,Bahrain,Bangladesh,Barbados,
            Belarus,Belgium,Belize,Benin,Bhutan,Bolivia,BosniaandHerzegovina,Botswana,
            Brazil,Brunei,Bulgaria,BurkinaFaso,Burundi,CaboVerde,Cambodia,Cameroon,Canada,CentralAfricanRepublic,
            Chad,Chile,China,Colombia,Comoros,Congo,DemocraticRepublicoftheCongo,
            RepublicoftheCostaRica,CôtedIvoire,Croatia,Cuba,Cyprus,CzechRepublic,
            Denmark,Djibouti,Dominica,Dominican_Republic,
            EastTimorTimorLeste,Ecuador,Egypt,ElSalvador,EquatorialGuinea,Eritrea,Estonia,
            Eswatini,Ethiopia,Fiji,Finland,France,Gabon,TheGambia,Georgia,Germany,Ghana,Greece,
            Grenada,Guatemala,Guinea,GuineaBissau,Guyana,Haiti,Honduras,Hungary,Iceland,India,
            Indonesia,Iran,Iraq,Ireland,Israel,Italy,Jamaica,Japan,Jordan,Kazakhstan,Kenya,Kiribati,
            Korea_North,Korea_South,Kosovo,Kuwait,Kyrgyzstan,Laos,Latvia,Lebanon,Lesotho,Liberia,Libya,
            Liechtenstein,Lithuania,Luxembourg,Madagascar,Malawi,Malaysia,Maldives,Mali,Malta,
            MarshallIslands,Mauritania,Mauritius,Mexico,Micronesia_Federated_States_of,Moldova,
            Monaco,Mongolia,Montenegro,Morocco,Mozambique,MyanmarBurma,
            Namibia, Nauru, Nepal, Netherlands, NewZealand, Nicaragua, Niger,
            Nigeria, NorthMacedonia, Norway, Oman, Pakistan, Palau, Panama,
            PapuaNewGuinea, Paraguay, Peru, Philippines, Poland, Portugal,Qatar, Romania, Russia, Rwanda,
            SaintKittsandNevis, SaintLucia, SaintVincentandtheGrenadines,Samoa,SanMarino,
            SaoTomeandPrincipe, SaudiArabia, Senegal, Serbia, Seychelles, Sierra, LeoneSingapore,
            Slovenia,SolomonIslands, Somalia, SouthAfrica, Spain, SriLanka,
            Sudan, SouthSudan, Suriname, Sweden, Switzerland, Syria,
            Taiwan, Tajikistan, Tanzania, Thailand, Togo, Tonga, TrinidadandTobago,
            Tunisia, Turkey, Turkmenistan, Tuvalu, Uganda,
            Ukraine, UnitedArabEmirates, UnitedStates, Uruguay, Uzbekistan,
            Vanuatu, VaticanCity, Venezuela, Vietnam, Yemen, Zambia, Zimbabwe
        }

        private void btnSave_Button_Click(object sender, RoutedEventArgs e)
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
                errFname.Visibility= Visibility.Hidden;
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
                MessageBox.Show("Please re-enter information with red star.");
            }
        }

        private void btnClear_Button_Click(object sender, RoutedEventArgs e)
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

