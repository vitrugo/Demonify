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
using Demonify.SupportPages;

namespace Demonify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Market : ContentPage
    {
        DefaultChar player;
        int LvlUpCost;
        public Market()
        {
            InitializeComponent();
            player = DefaultChar.DownloadDB();
            BindingContext = new ItemsMVVM();
            LblCurXP.Text = player.XP.ToString();
            UpdateLvlItem();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DefaultChar.UpdateDB(player);
        }

        private void LvTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Items;
            if(item is HeavyArmor || item is MediumArmor || item is LightArmor)
            {
                var page = new DescriptionArmor(item, player.XP);
                page.Finished += (param) =>
                {
                    if (param == true)
                    {
                        bool buy = UpdateInventory(item).GetAwaiter().GetResult();
                        if (!buy) return false;
                        player.XP -= item.Cost;
                        LblCurXP.Text = player.XP.ToString();
                        DefaultChar.UpdateDB(player);
                        return true;
                    }
                    else return false;
                };
                Navigation.PushAsync(page);
            }
            else if(item is HeavyWeapon || item is MediumWeapon || item is LightWeapon)
            {
                var page = new DescriptionWeapon(item, player.XP);
                page.Finished += (param) =>
                {
                    if (param == true)
                    {
                        bool buy = UpdateInventory(item).GetAwaiter().GetResult();
                        if (!buy) return false;
                        player.XP -= item.Cost;
                        LblCurXP.Text = player.XP.ToString();
                        DefaultChar.UpdateDB(player);
                        return true;
                    }
                    else return false;
                };
                Navigation.PushAsync(page);
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

        private void BtnLvlUp(object sender, EventArgs e)
        {
            if (player.XP >= LvlUpCost)
            {
                player.XP -= LvlUpCost;
                LblCurXP.Text = player.XP.ToString();
                player.LVL += 1;
                DefaultChar.UpdateDB(player);
                UpdateLvlItem();
            }
            else DisplayAlert("ERROR", "XP insuficiente.\nNecessários " + LvlUpCost + "XP para realizar a compra.", "OK");
        }

        private void UpdateLvlItem()
        {
            LvlUpCost = player.LVL * 100;
            LblNextLvl.Text = (player.LVL + 1).ToString();
            LblXpCost.Text = LvlUpCost.ToString();
        }

        private async Task<bool> UpdateInventory(Items item)
        {
            if (Inventory.Inv.Count == DefaultChar.InventorySize)
            {
                await DisplayAlert("ERROR", "Inventário Lotado", "OK");
                return false;
            }
            Inventory.Inv.Add(item);
            return true;
            //TODO - Remove Item from Market (remove at receiving index)
        }
    }
}