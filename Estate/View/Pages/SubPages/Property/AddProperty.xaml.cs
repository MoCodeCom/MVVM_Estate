using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView;
using Estate.ModelView.Classes;
using Estate.View.Pages.Classes;
using Estate.View.Pages.SubPages.Landlord;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Drawing.Image;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace Estate.View.Pages.SubPages.Property
{
    /// <summary>
    /// Interaction logic for AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Page
    {
        public List<byte[]> ImagesByte = new List<byte[]>() 
        {
            new byte[]{ 0},
            new byte[]{ 0},
            new byte[]{ 0},
            new byte[]{ 0}
        };
        GetLandlordsInfo lli = new GetLandlordsInfo();
        PropertyModelView<PropertyData> ppd = new PropertyModelView<PropertyData>();
        PropertyModelView<PropertyData> pmv = new PropertyModelView<PropertyData>();
        DefaultImage di = new DefaultImage();
        public AddProperty()
        {
            InitializeComponent();
            cbCountries.ItemsSource = Enum.GetValues(typeof(contries)).Cast<contries>();
            cbfname.ItemsSource = lli.GetLandlordsName();
            checkOwner();
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
            if (cbfname.Text == "" || tbPostCode.Text == "")
            {
                reject();
            }
            else
            {

                for (int i=0;i<4 ;i++)
                {
                    if (ImagesByte[i] == null || ImagesByte[i].Length<5)
                    {
                        ImagesByte[i] = di.GetDefaultImageBytes("property_Default_Image");
                    }
                }
                


                PropertyData ppd = new PropertyData()
                {
                    OwnerName = cbfname.Text,
                    Phone = tbPhone.Text,
                    Image_1 = ImagesByte[0],
                    Image_2 = ImagesByte[1],
                    Image_3 = ImagesByte[2],
                    Image_4 = ImagesByte[3],
                    Address = new AddressData()
                    {
                        LineOne = tbLineOne.Text,
                        LineTwo = tbLineTwo.Text,
                        PostCode = tbPostCode.Text,
                        City = tbCity.Text,
                        Country = cbCountries.Text
                    }
                };
                pmv.Add(ppd);
                
                MessageBox.Show("The new property is added.");
                clear();
            }

        }

        private void btnClear_Button_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void checkOwner()
        {
            if (cbfname.Text != "" )
            {
                btnSave.IsEnabled = true;
            }
        }
        private void reject()
        {
            if (cbfname.Text == "" && tbPostCode.Text == "")
            {
                errFname.Visibility = Visibility.Visible;
                errPostCode.Visibility = Visibility.Visible;
            }
            else if (cbfname.Text == "")
            {
                errFname.Visibility = Visibility.Visible;
            }
            else if (tbPostCode.Text == "")
            {
                errPostCode.Visibility = Visibility.Visible;
            }
            else
            {
                errFname.Visibility = Visibility.Hidden;

            }
            if (errFname.Visibility == Visibility.Visible || errPostCode.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Please re-enter information with red star.");
            }
        }
        public void clear()
        {
            cbfname.Text = "";
            tbLineOne.Text = "";
            tbLineTwo.Text = "";
            tbPostCode.Text = "";
            tbCity.Text = "";
            cbCountries.Text = "UnitedKingdom";
            tbPhone.Text = "";
            ImagesByte = new List<byte[]>()
            { 
                new byte[] { 0 },
                new byte[] { 0 },
                new byte[] { 0 }, 
                new byte[] { 0 } 
            };


            errFname.Visibility = Visibility.Hidden;
            errPostCode.Visibility = Visibility.Hidden;
        }
        private void btnImage1_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[0] = imageAsByte;
            MessageBox.Show("Upload is done! " + ImagesByte.Count);
        }

        private void btnImage2_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[1] = imageAsByte;
            MessageBox.Show("Upload is done! " + ImagesByte.Count);
        }

        private void btnImage3_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[2] = imageAsByte;
            MessageBox.Show("Upload is done! " + ImagesByte.Count);
        }

        private void btnImage4_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[3] = imageAsByte;
            MessageBox.Show("Upload is done! " + ImagesByte.Count);
        }
    }
}
