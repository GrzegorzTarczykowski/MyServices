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

        private static ChannelFactory<ICalculator> CreateChannelFactoryUsingNetTcpBinding()
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            return new ChannelFactory<ICalculator>(netTcpBinding, "net.tcp://localhost:9000/MyService");
        }

        private static ChannelFactory<ICalculator> CreateChannelFactoryUsingNetHttpBinding()
        {
            NetHttpBinding netHttpBinding = new NetHttpBinding();
            return new ChannelFactory<ICalculator>(netHttpBinding, "http://localhost:8081/ServiceModelSamples/serviceNetHttp");
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
            Console.WriteLine("Connected to service by Channel Factory with NetTcpBinding");
            using (ChannelFactory<ICalculator> cf = CreateChannelFactoryUsingNetTcpBinding())
            {
                ICalculator o = cf.CreateChannel();
                Console.WriteLine(o.Add(4, 5));
            }
            /////////////////////////////////////////////////////////
            Console.WriteLine("Connected to service by Channel Factory with NetHttpBinding");
            using (ChannelFactory<ICalculator> cf = CreateChannelFactoryUsingNetHttpBinding())
            {
                ICalculator o = cf.CreateChannel();
                Console.WriteLine(o.Add(4, 5));
            }
            /////////////////////////////////////////////////////////
            Console.ReadKey();
        }
    }
}
