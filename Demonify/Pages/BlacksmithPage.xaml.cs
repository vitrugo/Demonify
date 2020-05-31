using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demonify.Classes;

namespace Demonify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlacksmithPage : ContentPage
    {
        DefaultChar player;
        Random rdn = new Random();
        public BlacksmithPage()
        {
            InitializeComponent();
            player = DefaultChar.DownloadDB();
            Title = player.Name + " Blacksmithing";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LvInventory.ItemsSource = Inventory.Inv;
            LblCurXP.Text = player.XP.ToString();
        }

        private async void UpgradeItem(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Items;
            bool ansr = await DisplayAlert("Upgrade", "Deseja mesmo tentar o upgrade?\nChance de Falha: " + item.LVL*2 + "%\n" +
                "Custo: " + item.Cost*2 + " XP", "Yes", "No");
            if (!ansr) return;
            if(player.XP < item.Cost * 2)
            {
                await DisplayAlert("ERROR", "Você não possui XP suficiente", "OK");
                return;
            }
            player.XP -= item.LVL * 2;
            LblCurXP.Text = player.XP.ToString();
            if (rdn.Next(101) <= item.LVL * 2)
            {
                await DisplayAlert("FALHA", "Upgrade do item não teve sucesso, item foi destruído", "OK");
                Inventory.Inv.Remove(item);
            }
            else
            {
                await DisplayAlert("SUCESSO", "Upgrade do item teve sucesso, item foi aprimorado", "OK");
                item.LVL++;
            }
            DefaultChar.UpdateDB(player);
        }
    }
}