## WPF Masked UpDown MAC TextBox UserControl

My take on reinventing the sqare wheel in WPF using MVVM pattern and attached behavior.

It looks kinda like this: ![alt text](https://raw.githubusercontent.com/tsurrdurr/MaskedUpDownMACTextBox/master/MaskedUpDownMACTextBox/howitlooks.png)
## Functionality
Up and down buttons select next and previous MAC address respectively. With up arrow you can go from FF-FF-FF-FF-FF-FF to 00-00-00-00-00-00 and vice versa with down arrow.

When entering any value from keyboard, the resulting line is compared with regex and if it does not fit the MAC format, the change is not applied to the line. E.g. trying to type "Z" in the field results into nothing.

When removing the values an underscore is left in empty space. When the field loses focus or up or down button is pressed, underscores are replaced with zeroes.

## Installation and running

Open .sln file in Visual Studio and run it. Dependencies are:
- System.Windows.Interactivity (install Blend SDK)
- Extended.Wpf.Toolkit by Xceed (included in lib folder)
- C# 7.0
