﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demonify.Classes;

namespace Demonify.SupportPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescribeArmor : ContentPage
    {
        public delegate bool PopDelegate(bool delete);
        public event PopDelegate Finished;
        private Items item;
        public DescribeArmor(Items items)
        {
            InitializeComponent();
            item = items;
            BindingContext = item;
            if (items is HeavyArmor)
            {
                LblDex.Text = LblWis.Text = "0";
            }
            else if (items is MediumArmor)
            {
                LblStr.Text = LblWis.Text = "0";
            }
            else
            {
                LblStr.Text = LblDex.Text = "0";
            } 
            LblEquip.Text = item.equipped.ToString();
        }

        private void BtnEquip(object sender, EventArgs e)
        {
            item.equipped = !item.equipped;
            LblEquip.Text = item.equipped.ToString();
            if (item.equipped) Inventory.slot2 = item;
            else Inventory.slot1 = null;
            if (item.equipped) DisplayAlert("Sucesso", "Item equipado com sucesso", "OK");
            else DisplayAlert("Sucesso", "Item desequipado com sucesso", "OK");
        }

        private async void BtnDelete(object sender, EventArgs e)
        {
            bool ansr = await DisplayAlert("CONFIRMAÇÃO", "Certeza de que deseja deletar este item de seu inventário? " +
                "(Caso equipado, será retirado de sua mão primeiro)", "SIM", "NÂO");
            if (ansr)
            {
                if (item.equipped)
                {
                    item.equipped = false;
                    Inventory.slot1 = null;
                }
                Inventory.Inv.Remove(item);
                Finished(true);
                await Navigation.PopAsync();
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