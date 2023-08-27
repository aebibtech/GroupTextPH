using GroupTextPH.Core.ViewModels.Home;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace GroupTextPH.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}
