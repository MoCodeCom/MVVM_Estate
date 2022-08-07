using Estate.Data;
using Estate.Windows.MassageBoxWin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace Estate.Pages
{
    /// <summary>
    /// Interaction logic for DiryPage.xaml
    /// </summary>
    public partial class DiryPage : Page
    {

        public List<string> monthList = new List<string> { "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUN",
            "JULY","AUGUST","SEPTEMBER","OCTOBER","NOVEMBER","DECEMBER"};
        public DateTime dt = DateTime.Now;
        public DiryPage()
        {
            
            InitializeComponent();
            /////////////////////-- Data Grid Diry --//////////////////////
            DataGridDiry.ItemsSource = new DiryData().GetDiryList();
            /////////////////////-- Combo List --//////////////////////////
            //Combo Years
            ComboDiryYears.SelectedItem = dt.Year;
            //ComboDiryYears.DataContextChanged += changeYear;
            int currentyear = dt.Year;
            currentyear = currentyear - 5;
            for (int year = 0; year<11 ;year++)
            {
                ComboDiryYears.Items.Add(currentyear + year);
            }
            //Combo months
            for (int month=0; month<monthList.Count ;month++)
            {
                string m = monthList[month];
                ComboDiryMonths.Items.Add(m);
            }
            ComboDiryMonths.SelectedItem = dt.ToString("MMMM").ToUpper();

            //////////////////-- Data in Grid --//////////////////////////

            int days = 0;
            
            
            // To distribute date on the grid
            int currntlyMonthDays = DateTime.DaysInMonth(dt.Year,dt.Month);


            for (int row=0;row<DiryGrid.RowDefinitions.Count ;row++)
            {

                for (int col=0;col<DiryGrid.ColumnDefinitions.Count ;col++)
                {
                    days++;
                    TextBlock TextDayDate = new TextBlock();
                    Button btnDairy = new Button();
                    Frame FrameDayDate = new Frame();

                    btnDairy.Background = new SolidColorBrush(Colors.White);
                    if (days == dt.Day)
                    {
                        btnDairy.Background = new SolidColorBrush(Colors.LemonChiffon);
                        FrameDayDate.BorderThickness = new Thickness(2, 2, 2, 2);
                        FrameDayDate.BorderBrush = new SolidColorBrush(Colors.Red);
                    }

                    if (days > currntlyMonthDays)
                    {
                        TextDayDate.Text = "";
                        Grid.SetRow(TextDayDate, row);
                        Grid.SetColumn(TextDayDate, col);

                        DiryGrid.Children.Add(TextDayDate);
                    }
                    else
                    {

                        TextDayDate.Text = days.ToString();
                        TextDayDate.HorizontalAlignment = HorizontalAlignment.Center;
                        TextDayDate.FontWeight = FontWeights.Bold;
                        TextDayDate.FontSize = 20;

                        

                        btnDairy.Content = TextDayDate;
                        btnDairy.Click += Diry_Click_Button;

                        FrameDayDate.Content = btnDairy;



                        Grid.SetRow(FrameDayDate, row);
                        Grid.SetColumn(FrameDayDate, col);

                        DiryGrid.Children.Add(FrameDayDate);

                    }
                }   
            }
        }

        private void Diry_Click_Button(object sender, RoutedEventArgs e )
        {
            // To get day date

            var content = (e.Source as Button).ToString();
            string n = content.Substring(content.Length - 2);
            //MessageBox.Show(n);
            DiryMessageBoxWin dmbw = new DiryMessageBoxWin();
            dmbw.Show();

           
        }

        public int MonthCount = 0;

        private void ComboDiryYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string? month = ComboDiryMonths.SelectedItem?.ToString();
            string year = ComboDiryYears.SelectedItem.ToString()!;

            int IntYear = int.Parse(year);
            int IntMonth = StringToIntMonth(month!);

            ComboChangesDates(IntYear, IntMonth);
        }
            

        private void ComboDiryMonths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string? month = ComboDiryMonths.SelectedItem?.ToString();
            string year = ComboDiryYears.SelectedItem.ToString()!;

            int IntYear = int.Parse(year);
            int IntMonth = StringToIntMonth(month!);

            ComboChangesDates(IntYear, IntMonth);

            

        }

        public void ComboChangesDates(int SelectedYear, int SelectedMonth)
        {
            int days = 0;

            if(SelectedMonth == null || SelectedMonth == 0)
            {
                SelectedMonth = 1;
            }
            // To distribute date on the grid
            int currntlyMonthDays = DateTime.DaysInMonth(SelectedYear, SelectedMonth);

            DiryGrid.Children.Clear();
            for (int row = 0; row < DiryGrid.RowDefinitions.Count; row++)
            {

                for (int col = 0; col < DiryGrid.ColumnDefinitions.Count; col++)
                {

                    //Day date in grid style...
                    days++;
                    TextBlock TextDayDate = new TextBlock();
                    Button btnDairy = new Button();
                    Frame FrameDayDate = new Frame();

                    btnDairy.Background = new SolidColorBrush(Colors.White);

                    //selection nothing for no date grid.
                    if (days > currntlyMonthDays)
                    {
                        TextDayDate.Text = "";
                        Grid.SetRow(TextDayDate, row);
                        Grid.SetColumn(TextDayDate, col);
                        DiryGrid.Children.Add(TextDayDate);
                    }
                    else
                    {

                        TextDayDate.Text = days.ToString();
                        TextDayDate.HorizontalAlignment = HorizontalAlignment.Center;
                        TextDayDate.FontWeight = FontWeights.Bold;
                        TextDayDate.FontSize = 20;



                        btnDairy.Content = TextDayDate;
                        btnDairy.Click += Diry_Click_Button;

                        FrameDayDate.Content = btnDairy;



                        Grid.SetRow(FrameDayDate, row);
                        Grid.SetColumn(FrameDayDate, col);

                        DiryGrid.Children.Add(FrameDayDate);

                    }
                }
            }
        }

        public int StringToIntMonth(string month)
        {
            int result=0;
            for (int c=0;c<monthList.Count ;c++)
            {
                if (monthList[c] == month)
                {
                    result = c + 1;
                    break;
                }
            }
            return result;
        }

        public void MouseDoubleClick(object sender, EventHandler e)
        {
            MessageBox.Show("test");
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("test ...");
        }
    }
   
}

/*
 
 <!--<Style TargetType="Button">
                                <Style.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="Background">
                                            <Setter.Value>
                                                <ImageBrush ImageSource="C:\Users\PC Mohammed\Desktop\VS\Projects\Estate\Estate\Images\Search.png"/>
                                            </Setter.Value>
                                        </Setter>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>-->
 
 */
