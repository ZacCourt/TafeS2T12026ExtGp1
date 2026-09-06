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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		private void menuExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private void convertButton_Click(object sender, RoutedEventArgs e)
		{
			string amount = amountTextBox.Text;
			string fromCurrency = fromCurrencyComboBox.SelectedValue.ToString();
			string toCurrency = toCurrencyComboBox.SelectedValue.ToString();
			double fromAmount;
			double conRateTwo;
			double toAmount;

			if (double.TryParse(amount, out fromAmount))
			{
				amountIn.Text = fromAmount.ToString();
			}
			else
			{
				amountIn.Text = "Error, Please enter a double";
			}

			if (fromCurrency == "USD1")
			{
				switch (toCurrency)
				{
					case "USD2":
						conRateTwo = 1.0;
						break;
					case "EUR2":
						conRateTwo = 0.85189982;
						break;
					case "GBP2":
						conRateTwo = 0.72872436;
						break;
					case "INR2":
						conRateTwo = 74.257327;
						break;
					default:
						amountIn.Text = "Please choose a Currency";
						return;
				}
			}
			else if (fromCurrency == "EUR1")
			{
				switch (toCurrency)
				{
					case "USD2":
						conRateTwo = 1.1739732;
						break;
					case "EUR2":
						conRateTwo = 1.0;
						break;
					case "GBP2":
						conRateTwo = 0.8556672;
						break;
					case "INR2":
						conRateTwo = 87.00755;
						break;
					default:
						amountIn.Text = "Please choose a Currency";
						return;
				}
			}
			else if (fromCurrency == "GBP1")
			{
				switch (toCurrency)
				{
					case "USD2":
						conRateTwo = 1.371907;
						break;
					case "EUR2":
						conRateTwo = 1.1686692;
						break;
					case "GBP2":
						conRateTwo = 1.0;
						break;
					case "INR2":
						conRateTwo = 101.68635;
						break;
					default:
						amountIn.Text = "Please choose a Currency";
						return;
				}
			}
			else if (fromCurrency == "INR1")
			{
				switch (toCurrency)
				{
					case "USD2":
						conRateTwo = 0.011492628;
						break;
					case "EUR2":
						conRateTwo = 0.013492774;
						break;
					case "GBP2":
						conRateTwo = 0.0098339397;
						break;
					case "INR2":
						conRateTwo = 1.0;
						break;
					default:
						amountIn.Text = "Please choose a Currency";
						return;
				}
			}
			else
			{
				amountIn.Text = "Please choose a Currency";
				return;
			}

			toAmount = fromAmount * conRateTwo;
			amountIn.Text = string.Format("{0:F2} {1} =", fromAmount, fromCurrency.Substring(0,3));
			amountOut.Text = string.Format("{0:F2} {1}", toAmount, toCurrency.Substring(0, 3));
			conversionRateOne.Text = string.Format("1 {0}", fromCurrency.Substring(0, 3));
			conversionRateTwo.Text = string.Format("= {0} {1}", conRateTwo, toCurrency.Substring(0, 3));

		}
	}
}
