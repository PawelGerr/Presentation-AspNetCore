using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Singletons
{
	class Program
	{
		static void Main(string[] args)
		{
			WebHost
				.CreateDefaultBuilder()
				.UseStartup<Startup>()
				.ConfigureServices(services => services.AddSingleton<MySingleton>())
				.Build()
				.Run();
		}
	}
}
