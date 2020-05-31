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
    public partial class TrainingPage : ContentPage
    {
        public delegate int PopDelegate(int index);
        public event PopDelegate Finished;
        DefaultChar player;
        public TrainingPage()
        {
            InitializeComponent();
            List<string> attributes = new List<string> { "Strenght", "Defense", "Dexterity", "Wisdom" };
            pkrAttribute.ItemsSource = attributes;
            var json = App.Current.Properties["Player"];
            player = JsonConvert.DeserializeObject<DefaultChar>(json.ToString());
            LblXPLeft.Text = "Current XP: " + player.XP;
            Title = player.Name + " training area";
        }

        private async void BtnTrain(object sender, EventArgs e)
        {
            if(pkrAttribute.SelectedIndex == 0)
            {
                bool ansr = await answer();
                if (ansr)
                {
                    await Navigation.PopAsync();
                    Finished(0);
                }
                else return;
            }
            else if(pkrAttribute.SelectedIndex == 1)
            {
                bool ansr = await answer();
                if (ansr)
                {
                    await Navigation.PopAsync();
                    Finished(1);
                }
                else return;
            }
            else if(pkrAttribute.SelectedIndex == 2)
            {
                bool ansr = await answer();
                if (ansr)
                {
                    await Navigation.PopAsync();
                    Finished(2);
                }
                else return;
            }
            else if(pkrAttribute.SelectedIndex == 3)
            {
                bool ansr = await answer();
                if (ansr)
                {
                    await Navigation.PopAsync();
                    Finished(3);
                }
                else return;
            }
            else
            {
                if (Device.RuntimePlatform == Device.Android) DependencyService.Get<Imessage>().ShortAlert("Please, select an Attribute");
                else await DisplayAlert("ERROR", "Select an Attribute to train", "OK");
                return;
            }
        }

        private async Task<bool> answer()
        {
            bool ansr = await DisplayAlert("Warning", "Training will disable adventure and other trainings for the duration. Proceed?", "YES", "NO");
            return ansr;
        }
    }
}