using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string storedInput = "";        
        private string selectedOperation = "";  

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            string inputText = texbBoxInput.Text;

            try
            {
               
                double inputValue = double.Parse(texbBoxInput.Text); 
                double result = 0;

                switch (selectedOperation)
                {
                    case "+":
                        result = double.Parse(storedInput) + inputValue;
                        break;
                    case "-":
                        result = double.Parse(storedInput) - inputValue;
                        break;
                    case "*":
                        result = double.Parse(storedInput) * inputValue;
                        break;
                    case "/":
                        if (inputValue != 0)
                        {
                            result = double.Parse(storedInput) / inputValue;
                        }
                        else
                        {
                            texbBoxInput.Text = "Error: Division by zero";
                            return;
                        }
                        break;
                    default:
                        result = inputValue;
                        break;
                }

                
                texbBoxInput.Text = result.ToString();
                storedInput = ""; 
                selectedOperation = ""; 
            }
            catch (Exception ex)
            {
               
                texbBoxInput.Text = "Error: " + ex.Message;
            }
        }

        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = ((Button)sender).Content.ToString();
            texbBoxInput.Text += buttonContent;
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            string operation = ((Button)sender).Content.ToString();

            if (!string.IsNullOrEmpty(texbBoxInput.Text))
            {
                storedInput = texbBoxInput.Text;
                selectedOperation = operation;
                texbBoxInput.Clear();
            }
            else
            {
                
            }
        }
    }
}
