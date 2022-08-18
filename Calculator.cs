using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyCalculator
{
    public class Calculator: INotifyPropertyChanged 
    {
      //  readonly int _result;
        private int firstNumber;
        public int FirstNumber
        {
            get { return firstNumber; }
            set
            {
                firstNumber = value;
                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs("FirstNumber"));
                //}
            }
        }

        private int secondNumber;
        //public int SecondNumber { get; set; }
        public int SecondNumber
        {
            get { return secondNumber; }
            set
            {
                secondNumber = value;
                
            }
        }

        private int _result;

        public int Result
        {
            get { return _result; }

            set
            {
                _result = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void Add(Object obj)
        {
             Result = FirstNumber + SecondNumber;
        }
        private void Substract(Object obj)
        {
            Result = FirstNumber - SecondNumber;
        }

        private void Multiplication(Object obj)
        {
            Result = FirstNumber * SecondNumber;
        }

        private void Division(Object obj)
        {
            Result = FirstNumber / SecondNumber;
        }

        public bool CanExecute(object parameter) //when to execute 
        {
            if (FirstNumber > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
          //  return true;
        }

        public bool CanExecuteMulDiv(object parameter) //when to execute 
        {
            if (SecondNumber > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //  return true;
        }








        private ICommand addCommand;
         public ICommand AddCommand
         {
            get { return addCommand; }
         }

        private ICommand subCommand;
        public ICommand SubCommand
        {
            get { return subCommand; }
        }

        private ICommand mulCommand;
        public ICommand MulCommand
        {
            get { return mulCommand; }
        }

        private ICommand divCommand;
        public ICommand DivCommand
        {
            get { return divCommand; }
        }



        public Calculator() 
        {

            addCommand = new RelayCommandCalc(Add, CanExecute);
            subCommand = new RelayCommandCalc(Substract, CanExecute);
            mulCommand = new RelayCommandCalc(Multiplication, CanExecuteMulDiv);
            divCommand = new RelayCommandCalc(Division, CanExecuteMulDiv);
        }
    }
}
