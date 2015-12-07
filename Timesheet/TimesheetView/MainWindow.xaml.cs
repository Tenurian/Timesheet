using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TimesheetView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void D1_Checked(object sender, RoutedEventArgs e)
        {
            HD1.Text = "8";
        }

        private void D2_Checked(object sender, RoutedEventArgs e)
        {
            HD2.Text = "8";
        }

        private void D3_Checked(object sender, RoutedEventArgs e)
        {
            HD3.Text = "8";
        }

        private void D4_Checked(object sender, RoutedEventArgs e)
        {
            HD4.Text = "8";
        }

        private void D5_Checked(object sender, RoutedEventArgs e)
        {
            HD5.Text = "8";
        }

        private void D6_Checked(object sender, RoutedEventArgs e)
        {
            HD6.Text = "8";
        }

        private void D7_Checked(object sender, RoutedEventArgs e)
        {
            HD7.Text = "8";
        }

        private void D8_Checked(object sender, RoutedEventArgs e)
        {
            HD8.Text = "8";
        }

        private void D9_Checked(object sender, RoutedEventArgs e)
        {
            HD9.Text = "8";
        }

        private void D10_Checked(object sender, RoutedEventArgs e)
        {
            HD10.Text = "8";
        }

        private void D11_Checked(object sender, RoutedEventArgs e)
        {
            HD11.Text = "8";
        }

        private void D12_Checked(object sender, RoutedEventArgs e)
        {
            HD12.Text = "8";
        }

        private void D13_Checked(object sender, RoutedEventArgs e)
        {
            HD13.Text = "8";
        }

        private void D14_Checked(object sender, RoutedEventArgs e)
        {
            HD14.Text = "8";
        }
    }

    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int hold;
            Boolean test = Int32.TryParse(value.ToString(), out hold);

            if (test)
            {
                if (hold > 24)
                {
                    return "Input too high";
                }
                else if (hold < 0)
                {
                    return "Input too low";
                }
                else
                {
                    return hold.ToString();
                }
            }
            else
            {
                return "N/A";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TotalTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int holder, hold = 0;
            for(int i = 0; i < values.Length; i++) {
                if (Int32.TryParse(values[i].ToString(), out holder))
                {
                    hold += holder;
                }
            }

            return String.Format("Total Time worked: \t {0}", hold.ToString());

            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class OverTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int holder, hold = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (Int32.TryParse(values[i].ToString(), out holder))
                {
                    hold += holder;
                }
            }

            if(hold > 80)
            {
                hold -= 80;
            }
            else
            {
                hold = 0;
            }

            return String.Format("OverTime worked: \t {0}", hold.ToString());

            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
