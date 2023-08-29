using GroupTextPH.Core.Services;
using GroupTextPH.Core.ViewModels.Home;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace GroupTextPH.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<ISmsServiceA, SmsServiceA>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IDatabaseServiceA, DatabaseServiceA>();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
