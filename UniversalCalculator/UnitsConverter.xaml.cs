using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class UnitsConverter : Page
	{

		private readonly Func<double, double>[] _converters =
		{
			c => (c * 9 / 5) + 32 ,
			f => (f - 32) * 5 / 9 ,
			k => k * 2.20462,
			p => p / 2.20462,
			m => m * 3.28084,
			ft => ft / 3.28084,
		};
		public UnitsConverter()
		{
			InitializeComponent();
		}

		private void returnToMenuButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private void CalculateOptions()
		{
			try
			{
				Func<double, double> conversionFunc = _converters[conversionTypeComboBox.SelectedIndex];
				double input = double.Parse(inputOneTextBox.Text);

				outputTextBox.Text = conversionFunc(input).ToString();
			}
			catch
			{
				outputTextBox.Text = "NAN";
			}
		}

		private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			CalculateOptions();
		}

		private void conversionTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CalculateOptions();
		}
	}
}
