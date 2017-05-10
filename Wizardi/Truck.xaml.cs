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
using System.Windows.Shapes;

namespace Wizardi
{
    /// <summary>
    /// Interaction logic for Gas.xaml
    /// </summary>
    public partial class Truck : Window
    {
        private IBus bus;
        private int minValue = -1;
        private int maxValue = -1;

        public Truck(IBus bus)
        {
            InitializeComponent();
            this.bus = bus;
            bus.BusEvent += MessageReceived;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bus.SetParameter("voltage", (int) (slider.Value * 1000));
        }

        private void MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.ParamName == "minValue")
            {
                minValue = e.ParamValue;
                bus.SetParameter("minValueACK", minValue);
            }
            if (e.ParamName == "maxValue")
            {
                maxValue = e.ParamValue;
                bus.SetParameter("maxValueACK", maxValue);
            }
            if (e.ParamName == "reset")
            {
                maxValue = -1;
                minValue = -1;
                bus.SetParameter("resetACK", -1);
            }
        }
    }
}
