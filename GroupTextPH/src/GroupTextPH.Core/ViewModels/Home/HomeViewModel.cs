using System;
using System.Collections.Generic;
using System.Text;
using GroupTextPH.Core.Services;
using GroupTextPH.Core.ViewModels.Message;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GroupTextPH.Core.ViewModels.Home
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IDatabaseServiceA _dbService;
        public HomeViewModel(IMvxNavigationService navigationService, IDatabaseServiceA dbService)
        {
            _navigationService = navigationService;
            _dbService = dbService;
            NavigateCommand = new MvxAsyncCommand(() => _navigationService.Navigate<MessageViewModel>(), null, true);
            GetMessages();
        }

        public IMvxAsyncCommand NavigateCommand { get; private set; }

        private async void GetMessages()
        {
            Messages = await _dbService.GetMessagesAsync();
        }

        private List<Models.Message> _messages;
        public List<Models.Message> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                RaisePropertyChanged(nameof(Messages));
                IsEmptyMessageVisible = Messages.Count == 0;
            }
        }

        public bool _emptyMsgVisible;
        public bool IsEmptyMessageVisible
        {
            get => _emptyMsgVisible;
            set
            {
                _emptyMsgVisible = value;
                RaisePropertyChanged(nameof(IsEmptyMessageVisible));
            }
        }
    }
}
