using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demonify.Classes;
using Newtonsoft.Json;
using Demonify.Models;

namespace Demonify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Market : ContentPage
    {
        DefaultChar player;
        public Market()
        {
            InitializeComponent();
            player = player = JsonConvert.DeserializeObject<DefaultChar>(App.Current.Properties["Player"].ToString());
            BindingContext = new ItemsMVVM();
            StkCurrentXP.BindingContext = player;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            string json = JsonConvert.SerializeObject(player);
            App.Current.Properties["Player"] = json;
        }

        private void LvTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Items;
            if(item is HeavyArmor || item is MediumArmor || item is LightArmor)
            {
                Navigation.PushModalAsync(new DescriptionArmor(item));
            }
            else if(item is HeavyWeapon || item is MediumWeapon || item is LightWeapon)
            {

            }
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<Imessage>().ShortAlert("Item não classificado!");
                }
                else DisplayAlert("ENTRY ERROR", "Item was not identified on the market", "OK");
            }
        }
    }
}