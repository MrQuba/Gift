using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Gift.Changes;

namespace Gift.Changes.NPCs
{
    public class ModifiedDryad : GlobalNPC
    {
        public int happiness_level = 1;
        GetHappinessPoints get;
        public override bool InstancePerEntity => true;

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            Player player = Main.LocalPlayer;

            if (npc.type == NPCID.Dryad)
            {
                if (!firstButton)
                {
                    if (happiness_level >= 100)
                    {
                        player.AddBuff(BuffID.DryadsWard, 54000);
                        happiness_level = 100;

                    }
                    if (happiness_level >= 25)
                    {
                        // grants buff happy
                        player.AddBuff(146, 54000);
                    }
                    // 3467 - Luminite Bars
                    happiness_level += get.Happiness(player, ItemID.Sunflower, 3467);
                }
            }
        }
        public override void SaveData(NPC npc, TagCompound tag)
        {
            tag.Add("DryadHappiness", happiness_level);
        }
        public override void LoadData(NPC npc, TagCompound tag)
        {
            happiness_level = tag.GetAsInt("DryadHappiness");
        }

    }
}