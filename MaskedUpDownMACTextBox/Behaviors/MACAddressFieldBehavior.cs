using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;
using MaskedUpDownMACTextBox;

namespace MaskedUpDownMACTextBox.Behaviors
{
    class MACAddressFieldBehavior : Behavior<MACAddressUpDown>
    {
        private readonly Int64 biggestMACInDecimal = 281474976710655;

        public static readonly DependencyProperty MacFieldBehaviorProperty =
                DependencyProperty.Register(
                "MacFieldBehavior",
                typeof(string),
                typeof(MACAddressFieldBehavior));

        public string MacFieldBehavior
        {
            get { return (string)GetValue(MacFieldBehaviorProperty); }
            set { SetValue(MacFieldBehaviorProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Initialized += AssociatedObject_Initialized;

        }

        private void AssociatedObject_Initialized(object sender, EventArgs e)
        {
            var AssociatedObject = sender as MACAddressUpDown;
            AssociatedObject.upBtn.Click += UpBtn_Click;
            AssociatedObject.downBtn.Click += DownBtn_Click;
            AssociatedObject.MacField.LostFocus += FillEmptySpaces;
        }

        private void UpBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var userControl = GetUserControl(btn);
            userControl.MacField.Text = PlusOneMac(userControl.MacField.Text);
        }


        private void DownBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var userControl = GetUserControl(btn);
            userControl.MacField.Text = MinusOneMac(userControl.MacField.Text);
        }

        private void FillEmptySpaces(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.Text = UnderscoresToZeroes(textbox.Text);
        }

        private static MACAddressUpDown GetUserControl(Button btn)
        {
            var parent = VisualTreeHelper.GetParent(btn);
            while (parent != null && parent.GetType() != typeof(MACAddressUpDown))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            var userControl = parent as MACAddressUpDown;
            return userControl;
        }
        private string PlusOneMac(string macField)
        {
            var newvalue = MACToDecimal(macField) + 1;
            if (newvalue > biggestMACInDecimal) newvalue = 0;
            return DecimalToMAC(newvalue);
        }

        private string MinusOneMac(string macField)
        {
            var newvalue = MACToDecimal(macField) - 1;
            if (newvalue < 0) newvalue = biggestMACInDecimal;
            return DecimalToMAC(newvalue);
        }

        private static string DecimalToMAC(Int64 newvalue)
        {
            var newMac = newvalue.ToString("X12");
            int totalLength = newMac.Length;
            for (int i = 2; i < totalLength; i += 2)
            {
                newMac = newMac.Insert(i, "-");
                i += 1;
                totalLength += 1;
            }
            return newMac;
        }

        private Int64 MACToDecimal(string macField)
        {
            var macNoStrokes = UnderscoresToZeroes(macField);
            macNoStrokes = macNoStrokes.Replace("-", "");
            var newvalue = Helpers.HexToUDecimal.ParseLong(macNoStrokes);
            return newvalue;
        }

        private string UnderscoresToZeroes(string text)
        {
            return text.Replace("_", "0");
        }

        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= FillEmptySpaces;
            base.OnDetaching();
        }

    }
}
