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

namespace DmxUserControlLib
{
    /// <summary>
    /// Logique d'interaction pour ChannelController.xaml
    /// </summary>
    public partial class ChannelController : UserControl
    {
        private int Pdmxvalue;
        private int Pchannel;

        public int dmxvalue
        {
            get
            {
                return Pdmxvalue;
            }
            set
            {
                if(value < 0 || value > 255)
                {
                    throw new ArgumentOutOfRangeException("dmx value must be between 0 and 255");
                }

                Pdmxvalue = value;         
            }
        }
        public int channel
        {
            get
            {
                return Pchannel;
            }
            set
            {
                {
                    if (value < 1 || value > 512)
                    {
                        throw new ArgumentOutOfRangeException("dmx value must be between 0 and 255");
                    }

                    Pchannel = value;
                    if(channelNumberLB != null)
                    {
                        channelNumberLB.Content = Pchannel.ToString();
                    }
                }
            }
        }

        public event EventHandler DmxValue_Changed;

        public ChannelController()
        {
            InitializeComponent();

            this.Pchannel = 0;
            this.Pdmxvalue = 0;
        }

        private void DimmerSB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            valueTB.Text =  Convert.ToInt32(255 - DimmerSB.Value).ToString();
        }

        private void valueTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dmxvalue = Convert.ToInt32(valueTB.Text);

            if (this.DmxValue_Changed != null)
            {
                this.DmxValue_Changed.Invoke(this, e);
            }
        }

        public void ChangeValue(int value)
        {
            DimmerSB.Value = 255 - value;
        }
    }
}
