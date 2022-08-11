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

namespace Estate.View.Pages.SubPages.Property
{
    /// <summary>
    /// Interaction logic for AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Page
    {
        public AddProperty()
        {
            InitializeComponent();
            cbCountries.ItemsSource = Enum.GetValues(typeof(contries)).Cast<contries>();
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


            bool fnInspactor = TestContent.IsValidName(tbfname.Text);
            bool phoneInspactor = TestContent.IsValidPhone(tbPhone.Text);


            if (!fnInspactor)
            {
                tbfname.Text = "";
                errFname.Visibility = Visibility.Visible;
            }
            else
            {
                errFname.Visibility = Visibility.Hidden;
            }


            if (errFname.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Please re-enter information with red star.");
            }
        }


        private void btnClear_Button_Click(object sender, RoutedEventArgs e)
        {
            tbfname.Text = "";
            tbLineOne.Text = "";
            tbLineTwo.Text = "";
            tbPostCode.Text = "";
            tbCity.Text = "";
            cbCountries.Text = "UnitedKingdom";
            tbPhone.Text = "";



            errFname.Visibility = Visibility.Hidden;
        }



    }
}
