 using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DmxUserControlLib
{
    /// <summary>
    /// Logique d'interaction pour LaunchpadMap.xaml
    /// </summary>
    public partial class LaunchpadMap : UserControl
    {
        public event EventHandler BT_Click;
        public List<int> selectedBT = new List<int>();
        public List<int> selectedSystemBT = new List<int>();

        public LaunchpadMap()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button bt = sender as System.Windows.Controls.Button;
            int BT_ID;
            bool Is_BT_system;

            if (Grid.GetRow(bt) == 1)
            {
                BT_ID = Grid.GetColumn(bt);
                Is_BT_system = true;
                if(is_BT_selected(selectedSystemBT, BT_ID))
                {
                    bt.SetValue(BackgroundProperty, Brushes.Gray);
                    selectedSystemBT.Remove(BT_ID);
                }
                else
                {
                    bt.SetValue(BackgroundProperty, Brushes.LightBlue);
                    selectedSystemBT.Add(BT_ID);
                }
            }
            else
            {
                BT_ID = Grid.GetColumn(bt) + ((Grid.GetRow(bt) - 2) * 16);
                Is_BT_system = false;
                if (is_BT_selected(selectedBT, BT_ID))
                {
                    bt.SetValue(BackgroundProperty, Brushes.White);
                    selectedBT.Remove(BT_ID);
                }
                else
                {
                    bt.SetValue(BackgroundProperty, Brushes.LightBlue);
                    selectedBT.Add(BT_ID);
                }
            }

            if (this.BT_Click != null)
            {
                this.BT_Click(this, e);
            }
        }

        private Boolean is_BT_selected(List<int> sel, int BT_ID)
        {
            foreach(int ID in sel)
            {
                if(ID == BT_ID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
