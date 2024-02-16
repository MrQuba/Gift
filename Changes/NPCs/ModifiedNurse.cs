using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Gift.Changes.NPCs
{
    public class ModifiedNurse : GlobalNPC
    {
        public int happiness_level = 1;
        public override bool InstancePerEntity => true;

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            Player player = Main.LocalPlayer;

            if (npc.type == NPCID.Nurse)
            {
                if (!firstButton)
                {
                   if (happiness_level >= 100)
                    {
                        player.AddBuff(BuffID.Ironskin, 54000);
                        happiness_level = 100;

                   }
                   if (happiness_level >= 25)
                   {
                        player.AddBuff(BuffID.Regeneration, 54000);
                    }
                    if (player.HasItemInInventoryOrOpenVoidBag(ItemID.LifeFruit))
                    {
                        happiness_level += (5 * GetAmountOfItems(player, ItemID.LifeFruit));
                        int lifeFruit_index = Main.LocalPlayer.FindItem(ItemID.LifeFruit);
                        Main.LocalPlayer.inventory[lifeFruit_index].TurnToAir();                        

                    }
                    else  if (player.HasItemInInventoryOrOpenVoidBag(ItemID.LifeCrystal))
                    {
                        happiness_level += GetAmountOfItems(player, ItemID.LifeCrystal);
                        int lifeCrystal_Index = Main.LocalPlayer.FindItem(ItemID.LifeCrystal);
                        Main.LocalPlayer.inventory[lifeCrystal_Index].TurnToAir();
                    }
                }
            }
        }
        public override void SaveData(NPC npc, TagCompound tag)
        {
                tag.Add("NurseHappiness", happiness_level);
        }
        public override void LoadData(NPC npc, TagCompound tag)
        {
            happiness_level = tag.GetAsInt("NurseHappiness");
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