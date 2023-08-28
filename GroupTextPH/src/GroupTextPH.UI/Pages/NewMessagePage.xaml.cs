using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupTextPH.Core.ViewModels.Message;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupTextPH.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMessagePage : MvxContentPage<MessageViewModel>
    {
        public NewMessagePage()
        {
            InitializeComponent();
        }
    }
}
