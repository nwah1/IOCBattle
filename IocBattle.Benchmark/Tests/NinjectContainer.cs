using IocBattle.Benchmark.Models;
using Ninject;
using Ninject.Planning.Bindings;

namespace IocBattle.Benchmark.Tests
{
	public class NinjectContainer : IContainer
	{
		private KernelConfiguration _config;
	    private IReadOnlyKernel _kernel;

	    public string Name
		{
			get { return "Ninject"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _kernel.Get<T>();
		}

		public void SetupForTransientTest()
		{
			_config = new KernelConfiguration();

            _config.Bind<IRepository>().To<Repository>().InTransientScope();
            _config.Bind<IAuthenticationService>().To<AuthenticationService>().InTransientScope();
            _config.Bind<UserController>().ToSelf().InTransientScope();

            _config.Bind<IWebService>().To<WebService>().InTransientScope();
            _config.Bind<IAuthenticator>().To<Authenticator>().InTransientScope();
            _config.Bind<IStockQuote>().To<StockQuote>().InTransientScope();
            _config.Bind<IDatabase>().To<Database>().InTransientScope();
            _config.Bind<IErrorHandler>().To<ErrorHandler>().InTransientScope();

            _config.Bind<IService1>().To<Service1>().InTransientScope();
            _config.Bind<IService2>().To<Service2>().InTransientScope();
            _config.Bind<IService3>().To<Service3>().InTransientScope();
            _config.Bind<IService4>().To<Service4>().InTransientScope();

            _config.Bind<ILogger>().To<Logger>().InTransientScope();

            _kernel?.Dispose();
            _kernel = _config.BuildReadonlyKernel();
		}

		public void SetupForSingletonTest()
		{
			_config = new KernelConfiguration();

            _config.Bind<IRepository>().To<Repository>().InSingletonScope();
            _config.Bind<IAuthenticationService>().To<AuthenticationService>().InSingletonScope();
            _config.Bind<UserController>().ToSelf().InSingletonScope();

            _config.Bind<IWebService>().To<WebService>().InSingletonScope();
            _config.Bind<IAuthenticator>().To<Authenticator>().InSingletonScope();
            _config.Bind<IStockQuote>().To<StockQuote>().InSingletonScope();
            _config.Bind<IDatabase>().To<Database>().InSingletonScope();
            _config.Bind<IErrorHandler>().To<ErrorHandler>().InSingletonScope();

            _config.Bind<IService1>().To<Service1>().InSingletonScope();
            _config.Bind<IService2>().To<Service2>().InSingletonScope();
            _config.Bind<IService3>().To<Service3>().InSingletonScope();
            _config.Bind<IService4>().To<Service4>().InSingletonScope();

            _config.Bind<ILogger>().To<Logger>().InSingletonScope();

            _kernel?.Dispose();
            _kernel = _config.BuildReadonlyKernel();
        }
	}
}