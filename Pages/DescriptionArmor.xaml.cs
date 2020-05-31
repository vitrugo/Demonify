using Demonify.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demonify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionArmor : ContentPage
    {
        public DescriptionArmor(Items items)
        {
            InitializeComponent();
            BindingContext = items;
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
    }
}