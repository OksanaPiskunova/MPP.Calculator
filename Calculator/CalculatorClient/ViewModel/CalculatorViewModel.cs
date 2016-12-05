﻿using System;
using System.ComponentModel;
using CalculatorClient.Model;

namespace CalculatorClient.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CalculationCommand AddCommand { get; private set; }
        public CalculationCommand SubstractCommand { get; private set; }
        public CalculationCommand MultiplyCommand { get; private set; }
        public CalculationCommand DivideCommand { get; private set; }
        public CalculationCommand SqrtCommand { get; private set; }

        private readonly CalculatorModel _calculatorModel;

        private double _firstNumber;
        private double _secondNumber;
        private string _result;

        public double FirstNumber
        {
            get { return _firstNumber; }
            set
            {
                if (!_firstNumber.Equals(value))
                {
                    _firstNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public double SecondNumber
        {
            get { return _secondNumber; }
            set
            {
                if (!_secondNumber.Equals(value))
                {
                    _secondNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddCommand = InitializeCommand(Add);
            SubstractCommand = InitializeCommand(Substract);
            MultiplyCommand = InitializeCommand(Multiply);
            DivideCommand = InitializeCommand(Divide);
            SqrtCommand = InitializeCommand(Sqrt);
        }

        private CalculationCommand InitializeCommand(Func<string> method)
        {
            return new CalculationCommand(
                () =>
                {
                    if (AddCommand.CanExecute)
                    {
                        AddCommand.CanExecute = false;
                        Result = method();
                        AddCommand.CanExecute = true;
                    }
                });
        }

        private string Add()
        {
            return _calculatorModel.Add(_firstNumber, _secondNumber);
        }

        private string Substract()
        {
            return _calculatorModel.Substract(_firstNumber, _secondNumber);
        }

        private string Multiply()
        {
            return _calculatorModel.Multiply(_firstNumber, _secondNumber);
        }

        private string Divide()
        {
            return _calculatorModel.Divide(_firstNumber, _secondNumber);
        }

        private string Sqrt()
        {
            return _calculatorModel.Sqrt(_firstNumber);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}