using System;
using System.Collections.Generic;
using System.Text;
using GroupTextPH.Core.ViewModels.Message;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GroupTextPH.Core.ViewModels.Home
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new MvxAsyncCommand(() => _navigationService.Navigate<MessageViewModel>());
        }

        public IMvxAsyncCommand NavigateCommand { get; private set; }
    }
}
