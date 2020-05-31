using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demonify.Classes;
using Demonify.SupportPages;

namespace Demonify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryPage : ContentPage
    {
        DefaultChar player;
        public InventoryPage()
        {
            InitializeComponent();
            player = DefaultChar.DownloadDB();
            Title = player.Name + " Inventory";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LvInventory.ItemsSource = Inventory.Inv;
        }

        private void LvDescribe(object sender, ItemTappedEventArgs e)
        {
            //TODO - won't update list with pop async | not recognizing "missing link"
            var items = e.Item as Items;
            if(items is HeavyWeapon || items is MediumWeapon || items is LightWeapon)
            {
                var page = new DescribeWeapon(items);
                page.Finished += (param) =>
                {
                    if (param == true)
                    {
                        //Inventory.Inv.Remove(items);
                        return true;
                    }
                    else return false;
                };
                Navigation.PushAsync(page);
            }
            if (items is HeavyArmor || items is MediumArmor || items is LightArmor)
            {
                var page = new DescribeArmor(items);
                page.Finished += (param) =>
                {
                    if (param == true)
                    {
                        //Inventory.Inv.Remove(items);
                        return true;
                    }
                    else return false;
                };
                Navigation.PushAsync(page);
            }
        }
    }
}