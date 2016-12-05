namespace CalculatorClient.Model
{
    public class CalculatorModel
    {
        private readonly CalculatorServiceReference.CalculatorClient _client;

        public CalculatorModel()
        {
            _client = new CalculatorServiceReference.CalculatorClient();
        }

        public double Add(double firstNumber, double secondNumber)
        {
            return _client.Add(firstNumber, secondNumber);
        }

        public double Substract(double firstNumber, double secondNumber)
        {
            return _client.Substract(firstNumber, secondNumber);
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            return _client.Multiply(firstNumber, secondNumber);
        }

        public double Divide(double firstNumber, double secondNumber)
        {
            return _client.Divide(firstNumber, secondNumber);
        }

        public double Sqrt(double number)
        {
            return _client.Sqrt(number);
        }
    }
}