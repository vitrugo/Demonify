using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Demonify.Classes;
using Newtonsoft.Json;

namespace Demonify.Models
{
    public class ItemsMVVM
    {
        DefaultChar player;
        private ObservableCollection<Items> List;
        public ObservableCollection<Items> items
        {
            get { return List; }
            set
            {
                List = value;
            }
        }

        public ItemsMVVM()
        {
            player = player = JsonConvert.DeserializeObject<DefaultChar>(App.Current.Properties["Player"].ToString());
            Random rdn = new Random();
            string[] names = { "Golden", "Darkness", "Holy", "Iron", "Steel", "Void", "Obsidian" };
            List = new ObservableCollection<Items>();
            for (int x = 0; x < 5; x++)
            {
                List.Add(new HeavyArmor { Name = names[rdn.Next(6)] + " Breastplate", LVL = rdn.Next(player.LVL * 2) + 1});
                List.Add(new HeavyWeapon { Name = names[rdn.Next(6)] + " Sword", LVL = rdn.Next(player.LVL * 2)+1});
                List.Add(new MediumArmor { Name = names[rdn.Next(6)] + " Cuirass", LVL = rdn.Next(player.LVL * 2)+1});
                List.Add(new MediumWeapon { Name = names[rdn.Next(6)] + " Dagger", LVL = rdn.Next(player.LVL * 2)+1});
                List.Add(new LightArmor { Name = names[rdn.Next(6)] + " Robe", LVL = rdn.Next(player.LVL * 2)+1});
                List.Add(new LightWeapon { Name = names[rdn.Next(6)] + " Wand", LVL = rdn.Next(player.LVL * 2)+1});
            }
            //TODO - implement cost = 25/100 * (this.LVL*100)
        }
    }
}
