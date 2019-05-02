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
using System.Text.RegularExpressions;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxZipcode.Text = string.Empty;
            uxSubmit.IsEnabled = false;
        }

        private void UxZipcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex usZipCodeOneSegment = new Regex(@"^[0-9][0-9][0-9][0-9][0-9]$");
            Regex usZipCodeTwoSegments = new Regex(@"^[0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$");
            Regex canadaZipCode = new Regex(@"^[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]$");
            string zipcode = uxZipcode.Text;

            if (usZipCodeOneSegment.Match(zipcode).ToString() != ""
                || usZipCodeTwoSegments.Match(zipcode).ToString() != ""
                || canadaZipCode.Match(zipcode).ToString() != "")
                
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                if (uxSubmit != null)
                {
                    uxSubmit.IsEnabled = false;
                }
            }
        }
    }
}
