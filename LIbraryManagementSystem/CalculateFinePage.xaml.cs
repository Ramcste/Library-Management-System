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

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for CalculateFinePage.xaml
    /// </summary>
    public partial class CalculateFinePage
    {
        public CalculateFinePage()
        {
            InitializeComponent();

            TodaysDatePicker.Text = (DateTime.Today.Day+"/"+DateTime.Today.Month+"/"+DateTime.Today.Year).ToString();
        }

        private void FineButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
