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

namespace Calculator
{

	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void calcButton_Click(object sender, RoutedEventArgs e)
		{
			double principal, years, months, annualRate;
			try
			{
				principal = double.Parse(principalTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please enter a valid principal amount",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				principalTextBox.Focus(FocusState.Programmatic);
				return;
			}
			try
			{
				years = double.Parse(yearsTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please enter a valid number of years",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				return;
			}
			try
			{
				months = double.Parse(monthsTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please enter a valid number of months",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				return;
			}
			try
			{
				annualRate = double.Parse(annualInterestTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please enter a valid interest rate",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				annualInterestTextBox.Focus(FocusState.Programmatic);
				return;
			}

			double monthlyRate = annualRate / 100 / 12;
			double numberOfPayments = (years * 12) + months;

			double monthlyPayment = principal * (monthlyRate * Math.Pow(1 + monthlyRate, numberOfPayments))
				/ (Math.Pow(1 + monthlyRate, numberOfPayments) - 1);

			monthlyInterestTextBox.Text = monthlyRate.ToString("P2");
			monthlyPaymentTextBox.Text = monthlyPayment.ToString("C2");
        }

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}
    }
}
