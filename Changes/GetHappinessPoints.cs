using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;

namespace Gift.Changes
{
    internal class GetHappinessPoints
    {
        public int Happiness(Player player, int likedItem, int lovedItem)
        {
            int happiness_level = 0;
            if (player.HasItemInInventoryOrOpenVoidBag(likedItem))
            {
                happiness_level += (5 * GetAmountOfItems(player, likedItem));
                int li_index = Main.LocalPlayer.FindItem(likedItem);
                Main.LocalPlayer.inventory[li_index].TurnToAir();

            }
            else if (player.HasItemInInventoryOrOpenVoidBag(lovedItem))
            {
                happiness_level += GetAmountOfItems(player, lovedItem);
                int lv_index = Main.LocalPlayer.FindItem(lovedItem);
                Main.LocalPlayer.inventory[lv_index].TurnToAir();
            }
            return happiness_level;
        }
        public int GetAmountOfItems(Player player, int ItemType)
        {
            int amount = 0;
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == ItemType)
                {
                    amount += player.inventory[i].stack;
                }
            }

            return amount;
        }
    }
}
