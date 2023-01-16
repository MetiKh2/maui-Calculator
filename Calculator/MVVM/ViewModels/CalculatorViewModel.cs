using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel
    {
        public string Formula { get; set; }
        public double Result { get; set; } = 0;

        public ICommand OperationCommand => new Command((number) =>
        {
            Formula += number;
        });
        public ICommand ResetCommand => new Command(() =>
        {
            Formula = "";
            Result = 0;
        });
        public ICommand RemoveCommand => new Command(() =>
        {
            if (Formula.Length>0)
            Formula=Formula.Remove(Formula.Length-1);
        });
        public ICommand CalculateCommand => new Command(() =>
        {
            if (Formula.Length == 0) return;
            var calculate=Dangl.Calculator.Calculator.Calculate(Formula);
            Result = calculate.Result;
        });
    }
}
