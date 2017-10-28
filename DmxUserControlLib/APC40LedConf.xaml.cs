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
using DmxControlLib.Utility;

namespace DmxUserControlLib
{
    /// <summary>
    /// Logique d'interaction pour APC40LedConf.xaml
    /// </summary>
    public partial class APC40LedConf : UserControl
    {
        public int ONRGBPrimaryColor = 0;
        public int ONRGBSecondaryColor = 0;
        public BlinkingType ONBlinkingType = BlinkingType.OneShot;
        public BlinkingSpeed ONBlinkingSpeed = BlinkingSpeed._1_2;

        public int OFFRGBPrimaryColor = 0;
        public int OFFRGBSecondaryColor = 0;
        public BlinkingType OFFBlinkingType = BlinkingType.OneShot;
        public BlinkingSpeed OFFBlinkingSpeed = BlinkingSpeed._1_2;

        public buttonType BTType = buttonType.Momentary;
        public int Groupe = -1;

        public event EventHandler BT_Valid_Click;

        public APC40LedConf()
        {
            InitializeComponent();

            foreach (buttonType item in Enum.GetValues(typeof(buttonType)))
            {
                BT_Type_CB.Items.Add(item);
            }

            foreach (BlinkingType item in Enum.GetValues(typeof(BlinkingType)))
            {
                ON_Flashing_Type_CB.Items.Add(item);
                OFF_Flashing_Type_CB.Items.Add(item);
            }

            foreach (BlinkingSpeed item in Enum.GetValues(typeof(BlinkingSpeed)))
            {
                ON_Flashing_Speed_CB.Items.Add(item);
                OFF_Flashing_Speed_CB.Items.Add(item);
            }

            for (int i = 0; i < 130; i++)
            {
                ON_Primary_Color_CB.Items.Add(i);
                OFF_Primary_Color_CB.Items.Add(i);
                ON_Secondary_Color_CB.Items.Add(i);
                OFF_Secondary_Color_CB.Items.Add(i);
            }

            Groupe_Selection.Items.Add("None");
            for (int i = 0; i < 10; i++)
            {
                Groupe_Selection.Items.Add(i);
            }

            ON_Primary_Color_CB.SelectedItem = 0;
            OFF_Primary_Color_CB.SelectedItem = 0;
            ON_Secondary_Color_CB.SelectedItem = 0;
            OFF_Secondary_Color_CB.SelectedItem = 0;
            ON_Flashing_Type_CB.SelectedItem = BlinkingType.OneShot;
            OFF_Flashing_Type_CB.SelectedItem = BlinkingType.OneShot;
            ON_Flashing_Speed_CB.SelectedItem = BlinkingSpeed._1_2;
            OFF_Flashing_Speed_CB.SelectedItem = BlinkingSpeed._1_2;
            BT_Type_CB.SelectedItem = buttonType.Momentary;
            Groupe_Selection.SelectedItem = "None";
        }

        private void Validation_BT_Click(object sender, RoutedEventArgs e)
        {
            ONRGBPrimaryColor = (int)ON_Primary_Color_CB.SelectedItem;
            ONRGBSecondaryColor = (int)ON_Secondary_Color_CB.SelectedItem;
            ONBlinkingType = (BlinkingType)ON_Flashing_Type_CB.SelectedItem;
            ONBlinkingSpeed = (BlinkingSpeed)ON_Flashing_Speed_CB.SelectedItem;

            OFFRGBPrimaryColor = (int)OFF_Primary_Color_CB.SelectedItem;
            OFFRGBSecondaryColor = (int)OFF_Secondary_Color_CB.SelectedItem;
            OFFBlinkingType = (BlinkingType)OFF_Flashing_Type_CB.SelectedItem;
            OFFBlinkingSpeed = (BlinkingSpeed)OFF_Flashing_Speed_CB.SelectedItem;

            BTType = (buttonType)BT_Type_CB.SelectedItem;

            try
            {
                if ((string)Groupe_Selection.SelectedItem == "None")
                {
                    Groupe = -1;
                }
            }
            catch
            {
                Groupe = (int)Groupe_Selection.SelectedItem;
            }



            if (BT_Valid_Click != null)
            {
                this.BT_Valid_Click(this, e);
            }
        }
    }
}
