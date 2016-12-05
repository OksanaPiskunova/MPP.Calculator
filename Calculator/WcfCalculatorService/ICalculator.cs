﻿using System;
using System.ServiceModel;

namespace WcfCalculatorService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Add(double a, double b);

        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Substract(double a, double b);

        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Multiply(double a, double b);

        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        [FaultContract(typeof(DivideByZeroException))]
        double Divide(double a, double b);

        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Sqrt(double a);
    }
}
