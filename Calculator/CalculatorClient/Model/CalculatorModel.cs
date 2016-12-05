using System;
using System.Globalization;

namespace CalculatorClient.Model
{
    public class CalculatorModel
    {
        private readonly CalculatorServiceReference.CalculatorClient _client;
        
        public CalculatorModel()
        {
            _client = new CalculatorServiceReference.CalculatorClient();
        }

        public string Add(double firstNumber, double secondNumber)
        {
            string result;

            try
            {
                result = _client.Add(firstNumber, secondNumber).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                result = GetErrorMessage(e);
            }

            return result;
        }

        public string Substract(double firstNumber, double secondNumber)
        {
            string result;

            try
            {
                result = _client.Substract(firstNumber, secondNumber).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                result = GetErrorMessage(e);
            }

            return result;
        }

        public string Multiply(double firstNumber, double secondNumber)
        {
            string result;

            try
            {
                result = _client.Multiply(firstNumber, secondNumber).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                result = GetErrorMessage(e);
            }

            return result;
        }

        public string Divide(double firstNumber, double secondNumber)
        {
            string result;

            try
            {
                result = _client.Divide(firstNumber, secondNumber).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                result = GetErrorMessage(e);
            }

            return result;
        }

        public string Sqrt(double number)
        {
            string result;

            try
            {
                result = _client.Sqrt(number).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                result = GetErrorMessage(e);
            }

            return result;
        }

        private string GetErrorMessage(Exception e)
        {
            return "Error: " + e.Message;
        }
    }
}