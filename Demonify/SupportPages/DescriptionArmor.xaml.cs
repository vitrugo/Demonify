using Demonify.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demonify.SupportPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionArmor : ContentPage
    {
        public delegate bool PopDelegate(bool bought);
        public event PopDelegate Finished;
        private int XP, Cost;
        public DescriptionArmor(Items items, int xp)
        {
            InitializeComponent();
            BindingContext = items;
            XP = xp;
            Cost = items.Cost;
            if (items is HeavyArmor)
            {
                LblDex.Text = LblWis.Text = "0";
            }
            else if (items is MediumArmor)
            {
                LblStr.Text = LblWis.Text = "0";
            }
            else LblStr.Text = LblDex.Text = "0";
        }

        private async void BtnBuy(object sender, EventArgs e)
        {
            bool ansr = await DisplayAlert("Buy Action", "Certeza de que deseja realizar esta compra?", "SIM", "NÃO");
            if (ansr)
            {
                if(XP < Cost)
                {
                    await DisplayAlert("ERROR", "XP insuficiente.\nNecessários " + Cost + "XP para realizar a compra.", "OK");
                    return;
                }
                await Navigation.PopAsync();
                Finished(true);
            }
            else return;
        }
        protected override bool OnBackButtonPressed()
        {
            Finished(false);
            return base.OnBackButtonPressed();
        }
    }
}