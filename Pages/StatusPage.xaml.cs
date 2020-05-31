using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demonify.Classes;
using Newtonsoft.Json;

namespace Demonify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusPage : ContentPage
    {
        DefaultChar player;
        public StatusPage()
        {
            InitializeComponent();
            player = JsonConvert.DeserializeObject<DefaultChar>(App.Current.Properties["Player"].ToString());
            BindingContext = player;
            Title = player.Name + " Status";
        }
    }
}