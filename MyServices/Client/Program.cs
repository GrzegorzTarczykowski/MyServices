using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static ChannelFactory<ICalculator> CreateChannelFactoryUsingWSHttpBinding()
        {
            WSHttpBinding wsHttpBinding = new WSHttpBinding();
            return new ChannelFactory<ICalculator>(wsHttpBinding, "http://localhost:8080/ServiceModelSamples/service");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Connected to service by reference to the service added to project");
            CalculatorS.CalculatorClient calculatorClient = new CalculatorS.CalculatorClient();
            Console.WriteLine(calculatorClient.Add(4, 5).ToString());
            /////////////////////////////////////////////////////////
            Console.WriteLine("Connected to service by Channel Factory with WSHttpBinding using (Soup 1.2)" + Environment.NewLine +
                "Using svcutil.exe http://localhost:8080/ServiceModelSamples/service?wsdl " + Environment.NewLine +
                "The ServiceModel Metadata Utility tool is used to generate service model code from metadata documents," + Environment.NewLine +
                "and metadata documents from service model code.");
            using (ChannelFactory<ICalculator> cf = CreateChannelFactoryUsingWSHttpBinding())
            {
                ICalculator o = cf.CreateChannel();
                Console.WriteLine(o.Add(4, 5));
            }
            /////////////////////////////////////////////////////////
            Console.ReadKey();
        }
    }
}
