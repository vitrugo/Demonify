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
    public partial class PrimaryPage : ContentPage
    {
        DefaultChar player;
        public PrimaryPage()
        {
            InitializeComponent();
            var json = App.Current.Properties["Player"];
            player = JsonConvert.DeserializeObject<DefaultChar>(json.ToString());
            Title = player.Name + " Estate";
            LblTest.Text = json.ToString();
        }

        private void BtnDeleteChar(object sender, EventArgs args)
        {
            if (App.Current.Properties.ContainsKey("Player")) App.Current.Properties.Remove("Player");
            App.Current.MainPage = new Creation();
        }

        private void BtnStatus(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StatusPage());
        }

        private void BtnMarket(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Market());
        }

        private void BtnTraining(object sender, EventArgs e)
        {
            var page = new TrainingPage();
            page.Finished += (param) =>
            {
                if (param == 0)
                {
                    int timemultiplier = player.Str / 10;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    fttimer.StartingSecond = timer.Seconds;
                    fttimer.IsEnabled = true;
                    fttimer.Start();
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Str += 5;
                            string json = JsonConvert.SerializeObject(player);
                            App.Current.Properties["Player"] = json;
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                if(param == 1)
                {
                    int timemultiplier = player.Def / 10;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Def += 5;
                            string json = JsonConvert.SerializeObject(player);
                            App.Current.Properties["Player"] = json;
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                if(param == 2)
                {
                    int timemultiplier = player.Dex / 10;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Dex += 5;
                            string json = JsonConvert.SerializeObject(player);
                            App.Current.Properties["Player"] = json;
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                if(param == 3)
                {
                    int timemultiplier = player.Wis / 10;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Wis += 5;
                            string json = JsonConvert.SerializeObject(player);
                            App.Current.Properties["Player"] = json;
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                return 0;
            };
            Navigation.PushAsync(page);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            player = JsonConvert.DeserializeObject<DefaultChar>(App.Current.Properties["Player"].ToString());
        }
    }
}