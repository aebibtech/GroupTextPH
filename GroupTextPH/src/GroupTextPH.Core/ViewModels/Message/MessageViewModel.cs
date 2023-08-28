using System;
using System.Collections.Generic;
using System.Text;
using GroupTextPH.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace GroupTextPH.Core.ViewModels.Message
{
    public class MessageViewModel : MvxViewModel
    {
        private readonly ISmsServiceA _smsService;

        public MessageViewModel(ISmsServiceA smsService)
        {
            _smsService = smsService;
            Initialize();
            
        }

        public IMvxAsyncCommand SendMessage { get; private set; }

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
