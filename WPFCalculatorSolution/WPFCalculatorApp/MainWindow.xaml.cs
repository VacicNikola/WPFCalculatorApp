using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CalculatorLibrary;

namespace WPFCalculatorApp
{
    /// <summary>
    /// Interaction NumberLogic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        // Promenljive

        private bool OperandClicked;
        
        private bool firstIteration;

        private bool equalsClicked;

        
        
        public string Operator { get; set; }

        private string _currentValue;
        public string CurrentValue
        {
            get { return _currentValue; }

            set {
                if (string.Equals(value, _currentValue))
                    return;
                _currentValue = value;
                onPropertyChanged("CurrentValue");
            }
        
        }

        public string SecondValue { get; set; }

        public string EqualsAnswer { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        // metode

        public MainWindow()
        {
            InitializeComponent();

            CurrentValue = "0";
            SecondValue = null;
            OperandClicked = false;
            equalsClicked = false;
            firstIteration = true;
            Operator = null;

            this.DataContext = CurrentValue;
        
        }
        protected virtual void onPropertyChanged(string propertyName) {

            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Number1_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("1");
        }

        private void Number2_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("2");
        }

        private void Number3_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("3");
        }

        private void Number4_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("4");
        }

        private void Number5_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("5");
        }

        private void Number6_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("6");
        }

        private void Number7_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("7");
        }

        private void Number8_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("8");
        }

        private void Number9_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("9");
        }

        private void Number0_Click(object sender, RoutedEventArgs e)
        {
            NumberLogic("0");
        }

        private void NumberLogic(string v)
        {
            if (CurrentValue == "0")
                CurrentValue = string.Empty;

            if (OperandClicked)
            {
                if (CurrentValue == "")
                    SecondValue = "0";
                else
                {
                    SecondValue = CurrentValue;
                }
                CurrentValue = "";
            }

            if (equalsClicked) {
                CurrentValue = "";
                SecondValue = null;
            
            }

            CurrentValue = $"{CurrentValue}{v}";

            OperandClicked = false;
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentValue.Contains(".") == false)
                CurrentValue = $"{CurrentValue}.";

        }       // mozda ima sredjivanja

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentValue != "0")
                CurrentValue = CurrentValue.Substring(0, CurrentValue.Length - 1);

            if (CurrentValue == "")
                CurrentValue = "0";

        }       // Treba da se sredi malo

        private void res_Click(object sender, RoutedEventArgs e)
        {
            CurrentValue = "0";
            SecondValue = null;
            OperandClicked = false;
            equalsClicked = false;
            firstIteration = true;
        }   

        private void multiplication_Click(object sender, RoutedEventArgs e)
        {

            OperandClicked = true;

            equalsClicked = false;

            OperandsLogic(Operator);
            
            Operator = "*";

            
        }
            

        private void division_Click(object sender, RoutedEventArgs e)
        {

            OperandClicked = true;

            equalsClicked = false;

            OperandsLogic(Operator);

            Operator = "/";

        }

        private void addition_Click(object sender, RoutedEventArgs e)
        {
            OperandClicked = true;

            equalsClicked = false;

            OperandsLogic(Operator);

            Operator = "+";
        }

        private void substraction_Click(object sender, RoutedEventArgs e)
        {
            OperandClicked = true;

            equalsClicked = false;

            OperandsLogic(Operator);

            Operator = "-";


        }

        private void OperandsLogic(string Operator)
        {
            
            if (SecondValue != null)
            {
                string value = Calculator.Arithmetic(SecondValue, CurrentValue, Operator);
                CurrentValue = value;
                SecondValue = null;
            }

        }


        private void equals_Click(object sender, RoutedEventArgs e)
        {

            OperandClicked = false;

            equalsClicked = true;



            string value;

            if (SecondValue != null)
            {
                value = Calculator.Arithmetic(SecondValue, CurrentValue, Operator);
                CurrentValue = value;
                SecondValue = null;
                EqualsAnswer = value;
            }



        }

        

        private void answer_Click(object sender, RoutedEventArgs e)
        {
            CurrentValue = EqualsAnswer;
        }
    }
}
