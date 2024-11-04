using Calculator7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;



namespace Calculator7.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Calculator calc;

        public string Result
        {
            get => calc.Result.ToString();
            set
            {
                calc.Result = value;

                OnPropertyChanged(nameof(Result));
            }
        }

        public string Save
        {
            get => calc.Save;
            set
            {
                OnPropertyChanged(nameof(Save));
            }
        }

        public string Equation
        {
            get => calc.equation;
            set
            {
                OnPropertyChanged(nameof(Equation));
            }
        }

        public ObservableCollection<string> Equations { get; set; }
        


        public ICommand ClickCommand { get; set; }
        public ICommand ClickOpCommand { get; set; }
        public ICommand EqualCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand DotCommand { get; set; }
        public ICommand CECommand { get; set; }
        public ICommand PERCommand { get; set; }
        //public ICommand ReverseCommand { get; set; }
        //public ICommand SqrCommand { get; set; }
        //public ICommand SqrtCommand { get; set; }
        //public ICommand PlusMinusCommand { get; set; }      

        public ICommand CopyCommand { get; set; }
        public ICommand PasteCommand { get; set; }

        public IValueConverter Converter { get; set; }
        public bool? IsChecked { get; set; }

        public ICommand ExitCommand { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            calc = new Calculator();
            Equations = new ObservableCollection<string>();
            

            ClickCommand = new RelayCommand(Btn_Click);
            ClickOpCommand = new RelayCommand(BtnOp_Click);
            EqualCommand = new RelayCommand(Equal_Click);
            ClearCommand = new RelayCommand(Clear_Click);
            BackCommand = new RelayCommand(Back_Click);
            DotCommand = new RelayCommand(Dot_Click);
            CECommand = new RelayCommand(CE_Click);
            PERCommand = new RelayCommand(Per_Click);
            //ReverseCommand = new RelayCommand(Reverse_Click);
            //SqrCommand = new RelayCommand(Sqr_Click);
            //SqrtCommand = new RelayCommand(Sqrt_Click);
            //PlusMinusCommand = new RelayCommand(PlusMinus_Click);

            CopyCommand = new RelayCommand(CopyText);
            PasteCommand = new RelayCommand(PasteText);

            ExitCommand = new RelayCommand(Exitbtn_Click);

        }

        public void CopyText(object obj)
        {
            if (Result.Length > 0)
            {
                Clipboard.SetText(Result);
            }
        }

        public void PasteText(object obj)
        {
            if (Clipboard.ContainsText())
            {
                Result = Clipboard.GetText();
                calc.Input = Result;
                calc.ResultTF = false;
            }
        }

        public void Exitbtn_Click(object parameter)
        {            
            Application.Current.Shutdown();
        }

        public void Btn_Click(object number)
        {
            string input = number.ToString();
            calc.Append(input);
            OnPropertyChanged(nameof(Result));
        }

        public void BtnOp_Click(object operation)
        {
            string op = operation.ToString();
            string result = calc.UseOperator(op);
            if (result != "")
            {
                Equations.Add(result);
            }            
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        public void Equal_Click(object parameter)
        {
            Equations.Add(calc.Equal());
            // calc.Save = Result;
            // calc.Save = calc.Equal();
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        public void Clear_Click(object parameter)
        {
            calc.Clear();
            Equations.Clear();
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        public void Back_Click(object parameter)
        {
            calc.Back();
            OnPropertyChanged(nameof(Result));
        }

        public void Dot_Click(object parameter)
        {
            calc.Dot();
            OnPropertyChanged(nameof(Result));
        }

        public void CE_Click(object parameter)
        {
            calc.ClearEntry();
            OnPropertyChanged(nameof(Result));
        }

        public void Per_Click(object parameter)
        {
            calc.Percent();
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        /* public void Reverse_Click(object parameter)
        {
            calc.Reverse();
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        public void Sqr_Click(object parameter)
        {
            calc.Square();
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        public void Sqrt_Click(object parameter)
        {
            calc.SquareRoot();
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(Save));
        }

        public void PlusMinus_Click(object parameter)
        {
            calc.PlusMinus();
            OnPropertyChanged(nameof(Result));
        }
        */
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
    }
}
