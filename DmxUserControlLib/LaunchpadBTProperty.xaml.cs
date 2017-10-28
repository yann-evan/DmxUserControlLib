using System;
using System.Windows;
using System.Windows.Controls;
using DmxControlLib.Utility;

namespace DmxUserControlLib
{
    /// <summary>
    /// Logique d'interaction pour LaunchpadBTProperty.xaml
    /// </summary>
    public partial class LaunchpadBTProperty : UserControl
    {
        public ButtonColor ONBTColor = ButtonColor.None;
        public ButtonColor OFFBTColor = ButtonColor.None;
        public buttonType BTType = buttonType.Momentary;
        public bool ONFlash = false;
        public bool OFFFlash = false;

        public event EventHandler BT_Valid_Click;


        public LaunchpadBTProperty()
        {
            InitializeComponent();

            foreach (buttonType item in Enum.GetValues(typeof(buttonType)))
            {
                BT_Type_CB.Items.Add(item.ToString());
            }

            foreach (ButtonColor item in Enum.GetValues(typeof(ButtonColor)))
            {
                ON_BT_Color_CB.Items.Add(item.ToString());
                OFF_BT_Color_CB.Items.Add(item.ToString());
            }

            ON_BT_Color_CB.SelectedItem = ButtonColor.None.ToString();
            OFF_BT_Color_CB.SelectedItem = ButtonColor.None.ToString();
            BT_Type_CB.SelectedItem = buttonType.Momentary.ToString();
        }

        private void Validation_BT_Click(object sender, RoutedEventArgs e)
        {
            switch (ON_BT_Color_CB.SelectedItem.ToString())
            {
                case "Green":
                    ONBTColor = ButtonColor.Green;
                    break;

                case "Red":
                    ONBTColor = ButtonColor.Red;
                    break;

                case "Ambre":
                    ONBTColor = ButtonColor.Ambre;
                    break;

                case "Yellow":
                    ONBTColor = ButtonColor.Yellow;
                    break;

                case "None":
                    ONBTColor = ButtonColor.None;
                    break;
            }

            switch (OFF_BT_Color_CB.SelectedItem.ToString())
            {
                case "Green":
                    OFFBTColor = ButtonColor.Green;
                    break;

                case "Red":
                    OFFBTColor = ButtonColor.Red;
                    break;

                case "Ambre":
                    OFFBTColor = ButtonColor.Ambre;
                    break;

                case "Yellow":
                    OFFBTColor = ButtonColor.Yellow;
                    break;

                case "None":
                    OFFBTColor = ButtonColor.None;
                    break;
            }

            switch (BT_Type_CB.SelectedItem.ToString())
            {
                case "Momentary":
                    BTType = buttonType.Momentary;
                    break;

                case "Toogle":
                    BTType = buttonType.Toogle;
                    break;
            }

            ONFlash = (bool)On_BT_Flash_Check.IsChecked;
            OFFFlash = (bool)Off_BT_Flash_Check.IsChecked;

            if(BT_Valid_Click != null)
            {
                this.BT_Valid_Click(this, e);
            }

        }
    }
}
