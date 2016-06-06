using System;
using System.ServiceModel;

namespace LifeServiceHost
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost svcHost = null;
			try
			{
				svcHost = new ServiceHost(typeof(LifeServiceLib.LifeService));
				svcHost.Open(); Console.WriteLine("\n\nService is Running  at following address");
				Console.WriteLine("\nhttp://localhost:9001/LifeService");
				Console.WriteLine("\nnet.tcp://localhost:9002/LifeService");
			}
			catch (Exception ex)
			{
				svcHost = null;
				Console.WriteLine("Service can not be started \n\nError Message [" + ex.Message + "]");
				Console.ReadKey();
			}
			if (svcHost != null)
			{
				Console.WriteLine("\nPress any key to close the Service");
				Console.ReadKey();
				svcHost.Close();
				svcHost = null;
			}
		}
	}
}
