using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroupTextPH.Core.Services;
using GroupTextPH.Core.ViewModels.Home;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GroupTextPH.Core.ViewModels.Message
{
    public class MessageViewModel : MvxViewModel
    {
        private readonly ISmsServiceA _smsService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IDatabaseServiceA _dbService;

        public MessageViewModel(ISmsServiceA smsService, IMvxNavigationService navigationService, IDatabaseServiceA dbService)
        {
            _smsService = smsService;
            _navigationService = navigationService;
            _dbService = dbService;
            Initialize();
            SendMessage = new MvxAsyncCommand(SendMsgAsync);
            Notification = "";
        }

        public async Task SendMsgAsync()
        {
            var message = new Models.Message
            {
                Content = Message,
                Recipients = Recipients,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            Console.WriteLine(message.Content);

            IsSending = true;
            await RaisePropertyChanged(nameof(IsSending));

            Notification = "Sending message";
            await RaisePropertyChanged(nameof(Notification));

            var sendResult = await _smsService.SendSms(Message, Recipients);

            message.Status = sendResult ? "Sent" : "Failed";

            await _dbService.SaveMessageAsync(message);

            IsSending = false;
            await RaisePropertyChanged(nameof(IsSending));

            Notification = sendResult ? "Message sent successfully!" : "Failed to send message";
            await RaisePropertyChanged(nameof(Notification));

            await Task.Delay(1500);

            Notification = "";
            await RaisePropertyChanged(nameof(Notification));

            if (sendResult)
            {
                //await _navigationService.Close(this);
                await _navigationService.Navigate<HomeViewModel>();
            }
        }

        public IMvxAsyncCommand SendMessage { get; private set; }

        private string _notification;
        public string Notification {
            get => _notification ?? "";
            set {
                _notification = value;
                RaisePropertyChanged(nameof(Notification));
            }
        }

        public bool IsSending { get; set; } = false;

        public int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string _msg;
        public string Message
        {
            get => _msg ?? "";
            set
            {
                _msg = value;
                UpdatedAt = DateTime.Now;
                RaisePropertyChanged(() => Message);
            }
        }

        public string _recipients;
        public string Recipients
        {
            get => _recipients ?? "";
            set
            {
                _recipients = value;
                UpdatedAt = DateTime.Now;
                RaisePropertyChanged(() => Recipients);
            }
        }

        public string _status;
        public string Status
        {
            get => _status ?? "Pending";
            set
            {
                _status = value;
                UpdatedAt = DateTime.Now;
                RaisePropertyChanged(() => Status);
            }
        }

        public DateTime _createdAt = DateTime.Now;
        public DateTime CreatedAt => _createdAt;

        public DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get
            {
                if(_updatedAt == null)
                {
                    return CreatedAt;
                }

                return _updatedAt;
            }
            private set
            {
                _updatedAt = value;
                RaisePropertyChanged(() => UpdatedAt);
            }
        }
    }
}
