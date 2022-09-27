using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WpfServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode =ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class SService : IService
    {
        public int i;

        public void Call()
        {
            // increment instance counts
            i++;

            // display client name, instance number , thread number and time when 
            // the method was called

            Console.WriteLine("Client name :" + " Instance:" +
              i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() +
              " Time:" + DateTime.Now.ToString() + "\n\n");

            // Wait for 5 seconds
            Thread.Sleep(2000);
        }

        public CData DoWork()
        {
            // increment instance counts
            i++;
            
            // display client name, instance number , thread number and time when 
            // the method was called
            
            Console.WriteLine("Client name :" + " Instance:" +
              i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() +
              " Time:" + DateTime.Now.ToString() + "\n\n");
            
            // Wait for 5 seconds
            Thread.Sleep(2000);
            return new CData() { Data = DateTime.Now.ToString() }; 
        }
    }
}
