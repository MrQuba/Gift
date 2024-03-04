using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Gift.Changes.NPCs
{
    public class ModifiedZoologist : GlobalNPC
    {
        public int happiness_level = 1;
        GetHappinessPoints get;
        public override bool InstancePerEntity => true;

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            Player player = Main.LocalPlayer;

            if (npc.type == NPCID.BestiaryGirl)
            {
                if (!firstButton)
                {
                    if (happiness_level >= 100)
                    {
                        player.AddBuff(BuffID.Panic, 54000);
                        happiness_level = 100;

                    }
                    if (happiness_level >= 25)
                    {
                        // grants buff durendal's blessing
                        player.AddBuff(308, 54000);
                    }
                    happiness_level += get.Happiness(player, ItemID.Bunny, ItemID.TigerSkin);
                }
            }
        }
        public override void SaveData(NPC npc, TagCompound tag)
        {
            tag.Add("ZoologistHappiness", happiness_level);
        }
        public override void LoadData(NPC npc, TagCompound tag)
        {
            happiness_level = tag.GetAsInt("ZoologistHappiness");
        }

    }
}