using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace RPN_Calculator_UI;
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
            TextBox1 = this.FindControl<TextBox>("TextBox1");
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
        }

        public void ButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text += "7";
        }

        public void ButtonEight_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "8";
        }

        public void ButtonNine_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "9";
        }

        public void ButtonFour_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "4";
        }

        public void ButtonFive_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "5";
        }

        public void ButtonSix_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "6";
        }

        public void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "1";
        }

        public void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "2";
        }

        public void ButtonThree_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "3";
        }

        public void ButtonZero_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "0";
        }

        public void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text.Length != 0)
            {
                TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
            }
            else
            {
                TextBox1.Text = "";
            }
            
        }

        public void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
        }

        public void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "/";
        }

        public void ButtonModule_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "%";
        }

        public void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "*";
        }

        public void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "-";
        }

        public void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "+";
            Console.WriteLine(TextBox1.Text);
        }

        public void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + ",";
        }

        public void ButtonPow_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "^";
        }

        public void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "sqrt";
        }

        public void SpaceButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + " ";
        }
        
        public void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Func<double, double, double>> 
                operations = new Dictionary<string, Func<double, double, double>>();
            if (operations == null) throw new ArgumentNullException(nameof(operations));
            
            operations.Add("+", (a, b) => a + b);
            operations.Add("-", (a, b) => a - b);
            operations.Add("*", (a, b) => a * b);
            operations.Add("/", (a, b) => a / b);
            operations.Add("^", Math.Pow);
            operations.Add("%", (a, b) => a % b);
            operations.Add("sqrt", (a, _) => Math.Sqrt(a+_));
            
            var data = new Stack<double>();
            
            foreach (var part in TextBox1.Text.Split(' '))
            {
                if (double.TryParse(part, out var n))
                {
                    data.Push(n);
                }
                else
                {
                    var b = data.Pop();
                    var a = data.Pop();
                    data.Push(operations[part](a,b));
                }
            }
            TextBox1.Text = TextBox1.Text + "  =  " + Convert.ToString(data.Pop(), CultureInfo.CurrentCulture);
        }
    }



