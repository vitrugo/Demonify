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
    public partial class Creation : ContentPage
    {
        private int Str = 0, Def = 0, Dex = 0, Wis = 0, PointBuy = 44;
        private DefaultChar player;

        public Creation()
        {
            InitializeComponent();
            LblPointsLeft.Text = "Skill Points Left: " + PointBuy;
        }

        private void BtnMinusDef(object sender, EventArgs e)
        {
            if (Def == 1) btnMinusDef.IsEnabled = false;
            Def--;
            PointBuy++;
            LblDef.Text = Def.ToString();
            btnMoreDef.IsEnabled = true;
            CheckPoint();
        }

        private void BtnMoreDef(object sender, EventArgs e)
        {
            Def++;
            PointBuy--;
            LblDef.Text = Def.ToString();
            btnMinusDef.IsEnabled = true;
            CheckPoint();
            if (Def == 20) btnMoreDef.IsEnabled = false;
        }

        private void BtnMinusDex(object sender, EventArgs e)
        {
            if (Dex == 1) btnMinusDex.IsEnabled = false;
            Dex--;
            PointBuy++;
            LblDex.Text = Dex.ToString();
            btnMoreDex.IsEnabled = true;
            CheckPoint();
        }

        private void BtnMoreDex(object sender, EventArgs e)
        {
            Dex++;
            PointBuy--;
            LblDex.Text = Dex.ToString();
            btnMinusDex.IsEnabled = true;
            CheckPoint();
            if (Dex == 20) btnMoreDex.IsEnabled = false;
        }

        private void BtnMinusStr(object sender, EventArgs e)
        {
            if (Str == 1) btnMinusStr.IsEnabled = false;
            Str--;
            PointBuy++;
            LblStr.Text = Str.ToString();
            btnMoreStr.IsEnabled = true;
            CheckPoint();
        }

        private void BtnMoreStr(object sender, EventArgs e)
        {
            Str++;
            PointBuy--;
            LblStr.Text = Str.ToString();
            btnMinusStr.IsEnabled = true;
            CheckPoint();
            if (Str == 20) btnMoreStr.IsEnabled = false;
        }

        private void BtnMinusWis(object sender, EventArgs e)
        {
            if (Wis == 1) btnMinusWis.IsEnabled = false;
            Wis--;
            PointBuy++;
            LblWis.Text = Wis.ToString();
            btnMoreWis.IsEnabled = true;
            CheckPoint();
        }

        private void BtnMoreWis(object sender, EventArgs e)
        {
            Wis++;
            PointBuy--;
            LblWis.Text = Wis.ToString();
            btnMinusWis.IsEnabled = true;
            CheckPoint();
            if (Wis == 20) btnMoreWis.IsEnabled = false;
        }

        private async void BtnStartGame(object sender, EventArgs e)
        {
            if (PointBuy == 0)
            {
                if (entryName.Text.Length > 0 && entryName.Text != null) player = new DefaultChar(Str, Def, Dex, Wis, entryName.Text);
                else
                {
                    await DisplayAlert("Error", "Please, give your char a name", "OK");
                    return;
                }
                string json = JsonConvert.SerializeObject(player);
                if (App.Current.Properties.ContainsKey("Player")) App.Current.Properties.Remove("Player");
                App.Current.Properties.Add("Player", json);
                if(Device.RuntimePlatform == Device.Android) DependencyService.Get<Imessage>().ShortAlert("Char created succesfully");
                App.Current.MainPage = new NavigationPage(new PrimaryPage());
            }
            else
            {
                await DisplayAlert("Error", "Please, spend all your points before continuing", "OK");
            }
        }

        private void CheckPoint()
        {
            if (PointBuy == 0)
            {
                if (!(Str > 20)) btnMoreStr.IsEnabled = false;
                if (!(Def > 20)) btnMoreDef.IsEnabled = false;
                if (!(Dex > 20)) btnMoreDex.IsEnabled = false;
                if (!(Wis > 20)) btnMoreWis.IsEnabled = false;
            }
            else
            {
                if (Str != 20) btnMoreStr.IsEnabled = true;
                if (Def != 20) btnMoreDef.IsEnabled = true;
                if (Dex != 20) btnMoreDex.IsEnabled = true;
                if (Wis != 20) btnMoreWis.IsEnabled = true;
            }

            LblPointsLeft.Text = "Skill Points Left: " + PointBuy;
        }
    }
}