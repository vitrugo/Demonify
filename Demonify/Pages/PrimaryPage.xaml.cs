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
            //fttimer.Stopped += Fttimer_StoppedSTR;
            player = DefaultChar.DownloadDB();
            Title = player.Name + " Estate";
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

        private void BtnInventory(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InventoryPage());
        }

        private void BtnBlackSmith(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BlacksmithPage());
        }

        private void BtnTraining(object sender, EventArgs e)
        {
            var page = new TrainingPage();
            page.Finished += (param) =>
            {
                if (param == 0)
                {
                    int timemultiplier = player.Str / 5;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    //fttimer.StartingSecond = timer.Subtract(TimeSpan.FromSeconds(1)).Seconds;
                    //fttimer.IsEnabled = true;
                    //fttimer.Start();
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        float cost = 10 * (player.Str / 5);
                        player.XP -= (int)cost;
                        DefaultChar.UpdateDB(player);
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Str += 5;
                            DefaultChar.UpdateDB(player);
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                if(param == 1)
                {
                    float cost = 10 * (player.Def / 5);
                    player.XP -= (int)cost;
                    DefaultChar.UpdateDB(player);
                    int timemultiplier = player.Def / 5;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Def += 5;
                            DefaultChar.UpdateDB(player);
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                if(param == 2)
                {
                    float cost = 10 * (player.Dex / 5);
                    player.XP -= (int)cost;
                    DefaultChar.UpdateDB(player);
                    int timemultiplier = player.Dex / 5;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Dex += 5;
                            DefaultChar.UpdateDB(player);
                            btnTraining.IsEnabled = true;
                            return false;
                        }
                        return true;
                    });
                }
                if(param == 3)
                {
                    float cost = 10 * (player.Wis / 5);
                    player.XP -= (int)cost;
                    DefaultChar.UpdateDB(player);
                    int timemultiplier = player.Wis / 5;
                    btnTraining.IsEnabled = false;
                    TimeSpan timer = TimeSpan.FromSeconds(10 * timemultiplier);
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timer = timer.Subtract(TimeSpan.FromSeconds(1));
                        if (timer.TotalSeconds <= 1)
                        {
                            player.Wis += 5;
                            DefaultChar.UpdateDB(player);
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

        private void Fttimer_StoppedSTR(object sender, FrameTimerX.FrameTimerEventArgs args)
        {
            player.Str += 5;
            DefaultChar.UpdateDB(player);
            btnTraining.IsEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            player = DefaultChar.DownloadDB();
        }

        private void BtnADDXp(object sender, EventArgs e)
        {
            player.XP += 100;
            DefaultChar.UpdateDB(player);
        }
    }
}