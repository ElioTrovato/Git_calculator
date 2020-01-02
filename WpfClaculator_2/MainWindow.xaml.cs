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

namespace WpfClaculator_2
{
   
    public partial class MainWindow : Window
    {
        bool screen_vuoto = false;
        
        double operatore1=0;
        double operatore2=0;
        string operatore="";
        double operationResult = 0;
        bool operation_pressed = false;


        public MainWindow()
        {
            InitializeComponent();
            screen.Text = "0";
        }

        private void Calcolator_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string chiave = e.Text;
            switch (chiave)
            {
                case "1": One.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // a sort of PerformClick()
                    break;
                case "2": two.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "3": three.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "4": four.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "5": five.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "6": six.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "7": seven.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "8": eight.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "9": nine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "0": zero.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case ",": dot.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "-": minus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "+": plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "*": per.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "/": div.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "c": clear.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case ".": dot.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "=": result.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                default: return;
            }
        }
        private void Calcolator_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
                result.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {



            if ((screen.Text == "0") || (operation_pressed))
                screen.Text="";

            operation_pressed = false;
            Button b = (Button)e.OriginalSource;
            if (b.Tag.ToString() == ".")
            {
                if (!screen.Text.Contains("."))
                    screen.Text = screen.Text + b.Tag.ToString();
            }
            else if (b.Tag.ToString() == "C")
               {
                   operationResult = 0;
                   operatore1 = 0;
                   operatore2 = 0;
                   operatore = "";
                   screen.Text = "0";
                equation.Text = "";
               }
            else
                screen.Text = screen.Text + b.Tag.ToString();


            //if (e.OriginalSource is Button)
            //{
                

            //   // operation_pressed = false;
            //    Button b = (Button)e.OriginalSource;

            //    int i;
            //    bool isDigit = false;
            //    isDigit = int.TryParse(b.Tag.ToString(), out i);
            //    if (isDigit)
            //    {
            //        if (screen_vuoto)
            //        {
            //            screen.Text = "";
            //            screen_vuoto = false;
            //        }
            //        screen.Text = screen.Text + b.Tag.ToString();
            //    }
            //    else if (b.Tag.ToString() == ",")
            //    {
            //      if (!screen.Text.Contains(","))
            //          screen.Text = screen.Text + b.Content.ToString();
            //    }
            //    else if (b.Tag.ToString() == "C")
            //    {
            //        operationResult = 0;
            //        operatore1 = 0;
            //        operatore2 = 0;
            //        operatore = "";
            //        screen.Text = "0";
            //    }

            //}
        }


        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button)
            {
                Button op = (Button)e.OriginalSource;

                if (op.Tag.ToString() != "=")
                {
                    
                        operatore1 = double.Parse(screen.Text);
                        operatore = op.Tag.ToString();
                        //screen_vuoto = true;
                        operation_pressed = true;
                        equation.Text = operatore1 + " " + operatore;
                    
                }
                //else if(operatore1 != 0){

                //    result.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                //    operation_pressed = true;
                //    operatore = op.Tag.ToString();
                //        equation.Text = operatore1 + " " + operatore;
                    
                //}
                else
                {
                    try
                    {
                        //operatore2 = double.Parse(screen.Text);
                        equation.Text = "";
                        switch (operatore)
                        {
                            case "+": operationResult = operatore1 + double.Parse(screen.Text);
                                break;
                            case "-": operationResult = operatore1 - double.Parse(screen.Text);
                                break;
                            case "*": operationResult = operatore1 * double.Parse(screen.Text);
                                break;
                            case "/":// if (operatore2 != 0)
                                    operationResult = operatore1 / double.Parse(screen.Text);
                             //   else if (operatore2 == 0) {
                                   // clear.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                     //   screen.Text = "inf"; }

                                break;
                        }
                        screen.Text = operationResult.ToString();
                        operatore = "";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        screen_vuoto = true;
                    }
                }

            }
        }

        private void Operator1_Click(object sender, RoutedEventArgs e)
        {
            double reverse = Convert.ToDouble(screen.Text);
            double result_reverse = 1 / reverse;
            screen.Text = result_reverse.ToString();
        } //   1/x
        private void Operator2_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(screen.Text);
            number = -number;
            screen.Text = number.ToString();
        } //   +-
    }
}
