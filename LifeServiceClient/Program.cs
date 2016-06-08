using System;
using LifeServiceLib;

namespace MyLifeServiceClient
{
	class Program
	{
		static void Main(string[] args)
		{
            var client = new LifeServiceClient("NetTcpBinding_ILifeService");

  //          client.AddStudent(new StudentDto
  //          {
  //              Name = string.Format("User_{0}", Guid.NewGuid())
  //          });

  //          foreach (var item in client.GetAll())
  //          {
  //              Console.WriteLine(item.Name);
  //          }

  //          Console.ReadKey();
        }
	}
}
