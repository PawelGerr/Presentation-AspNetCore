using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Singletons
{
	public class Startup
	{
		private readonly MySingleton _mySingletonFromHostingServiceProvider;

		public Startup(MySingleton mySingletonFromHostingServiceProvider)
		{
			_mySingletonFromHostingServiceProvider = mySingletonFromHostingServiceProvider;
		}

		public void Configure(IApplicationBuilder app)
		{
			app.Use(async (ctx, next) =>
						{
							var mySingleton = ctx.RequestServices.GetRequiredService<MySingleton>();

							// the comparison of 2 instances yields "false"
							var areEqual = _mySingletonFromHostingServiceProvider == mySingleton;
							var message = $"==> {nameof(_mySingletonFromHostingServiceProvider)} == {nameof(mySingleton)}: {areEqual}";

							Console.WriteLine(message);
							await ctx.Response.WriteAsync(message).ConfigureAwait(false);
						});
		}
	}
}
