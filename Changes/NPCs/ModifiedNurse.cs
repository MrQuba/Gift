using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Gift.Changes.NPCs
{
    public class ModifiedNurse : GlobalNPC
    {
        public int happiness_level = 1;
        GetHappinessPoints get;
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
                        player.AddBuff(BuffID.Lifeforce, 54000);
                        happiness_level = 100;

                   }
                   if (happiness_level >= 25)
                   {
                        player.AddBuff(BuffID.Regeneration, 54000);
                    }
                    happiness_level += get.Happiness(player, ItemID.LifeCrystal, ItemID.LifeFruit);
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
    }
}