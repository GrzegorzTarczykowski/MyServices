using Microsoft.ServiceModel.Samples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ServiceModel.Samples
{
    public class CalculatorWindowsService : ServiceBase
    {
        private Thread _thread;
        public ServiceHost serviceHost = null;
        public CalculatorWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFWindowsServiceSample";
        }

        public static void Main()
        {
#if DEBUG
            CalculatorWindowsService serviceBase = new CalculatorWindowsService();
            serviceBase.OnStart(null);
#else
            ServiceBase.Run(new CalculatorWindowsService());
#endif
        }
        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            try
            {
                // Uncomment this line to debug...
                //System.Diagnostics.Debugger.Break();

                // Create the thread object that will do the service's work.
                _thread = new System.Threading.Thread(DoWork);

                // Start the thread.
                _thread.Start();

                // Log an event to indicate successful start.
                EventLog.WriteEntry("Successful start.", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                // Log the exception.
                EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

        private void DoWork()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(CalculatorService));
            var x = serviceHost.BaseAddresses;
            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }
    }
}
