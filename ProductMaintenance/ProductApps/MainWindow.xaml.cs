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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;
        decimal deliveryCharge = 25.00M;  // Existing Delivery charge
        decimal wrappingCharge = 5.00M;   // Existing Wrapping charge
        decimal gstRate = 1.1M;           // New: GST rate

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                // Calculate and display Total Charge after adding the delivery charge
                decimal totalCharge = cProduct.TotalPayment + deliveryCharge;
                totalChargeTextBlock.Text = Convert.ToString(totalCharge);

                // Calculate and display Total Charge after adding the wrapping charge
                decimal totalChargeWithWrap = cProduct.TotalPayment + deliveryCharge + wrappingCharge;
                totalChargeWithWrapTextBlock.Text = Convert.ToString(totalChargeWithWrap);

                // New: Calculate and display Total Charge after GST
                decimal totalChargeWithGST = totalChargeWithWrap * gstRate;
                totalChargeWithGSTTextBlock.Text = Convert.ToString(totalChargeWithGST);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";
            totalChargeWithWrapTextBlock.Text = "";
            totalChargeWithGSTTextBlock.Text = ""; // New: Clear the GST TextBlock as well
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
