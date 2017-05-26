using Oma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Oma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public NavMaster()
        {
            InitializeComponent();
            BindingContext = new NavMasterViewModel();
        }



        class NavMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavMenuItem> MenuItems { get; }
            public NavMasterViewModel()
            {
                MenuItems = new ObservableCollection<NavMenuItem>(new[]
                { new NavMenuItem { Id = 0, Title = "Home", Icon="home", TargetType = typeof(Home) },
                    new NavMenuItem { Id = 1, Title = "MyLibrary", Icon = "playlist", TargetType = typeof(Library) },
                    new NavMenuItem { Id = 2, Title = "Ministers", Icon = "cat", TargetType = typeof(Ministers) },
                    new NavMenuItem { Id = 3, Title = "Latest Messages",TargetType = typeof(New) },
                    new NavMenuItem { Id = 4, Title = "FAQs", Icon = "FAQ", TargetType = typeof(FAQs) },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
