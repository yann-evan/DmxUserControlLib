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
using System.Diagnostics;

namespace DmxUserControlLib
{
    /// <summary>
    /// Logique d'interaction pour MatriceLedAPC40.xaml
    /// </summary>
    public partial class MatriceLedAPC40 : UserControl
    {
        public event EventHandler<BTClickEventArgs> BT_click;
        public List<int> SelectedBT = new List<int>();

        public MatriceLedAPC40()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            int BT_ID = -1;
            System.Windows.Controls.Button bt = null;


            if (sender is System.Windows.Controls.Button)
            {
                bt = sender as System.Windows.Controls.Button;
                

                if(Grid.GetColumn(bt) == 8) //Si Scene Launch
                {
                     BT_ID = Grid.GetRow(bt) + 81;
                }
                else //si Matrice RGB
                {
                    BT_ID = 39 - ((7 - Grid.GetColumn(bt)) + ((Grid.GetRow(bt) - 1) * 8));
                }
            }

            Debug.WriteLine("BT ID -> " + BT_ID);
            if (is_BT_selected(BT_ID))
            {
                bt.SetValue(BackgroundProperty, Brushes.White);
                SelectedBT.Remove(BT_ID);
            }
            else
            {
                bt.SetValue(BackgroundProperty, Brushes.LightBlue);
                SelectedBT.Add(BT_ID);
            }

            if (BT_click != null)
            {
                this.BT_click(this, new BTClickEventArgs { BT_ID = BT_ID, IS_Selected = is_BT_selected(BT_ID) });
            }
        }

        private Boolean is_BT_selected(int BT_ID)
        {
            foreach (int ID in SelectedBT)
            {
                if (ID == BT_ID)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class BTClickEventArgs : EventArgs
    {
        public int BT_ID { get; set; }
        public bool IS_Selected { get; set; }
    }
}
