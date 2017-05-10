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

namespace Wizardi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        private IBus bus;
        private int minValue = -1;
        private int maxValue = -1;
        private int voltage = 0;

        public MainWindow()
        {
            InitializeComponent();
            bus = new Bus();
            bus.BusEvent += MessageReceived;
  
            Truck truck = new Wizardi.Truck(bus);
            truck.Show();
            
        }

        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            if (maxValue == -1)
            {
                bus.SetParameter("minValue", voltage);
            }
            else
            {
                if (maxValue <= voltage)
                    MessageBox.Show("Minimiarvon pitää olla pienempi kuin maksimiarvo.");
                else
                    bus.SetParameter("minValue", voltage);
            }
        }

        private void maxButton_Click(object sender, RoutedEventArgs e)
        {
            if (minValue == -1)
                bus.SetParameter("maxValue", voltage);
            else
            {
                if (minValue >= voltage)
                    MessageBox.Show("Maksimiarvon pitää olla suurempi kuin minimiarvo.");
                else
                    bus.SetParameter("maxValue", voltage);
            }
            
        }

        private void MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.ParamName == "voltage")
            {
                voltage = e.ParamValue;
                textBox.Text = voltage.ToString();
            }
            if (e.ParamName == "minValueACK")
            {
                minValue = e.ParamValue;
                minTextBox.Text = minValue.ToString();
            }
            if (e.ParamName == "maxValueACK")
            {
                maxValue = e.ParamValue;
                maxTextBox.Text = maxValue.ToString();
            }
            if (e.ParamName == "resetACK")
            {
                maxValue = -1;
                minValue = -1;
                minTextBox.Text = "";
                maxTextBox.Text = "";
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            bus.SetParameter("reset", -1);
        }
    }
}
