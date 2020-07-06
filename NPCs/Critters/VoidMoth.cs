using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CelestialMod.NPCs.Critters
{
	public class VoidMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Moth");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 20;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.dontCountMe = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("VoidMothItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 64;
			npc.rarity = 3;
			npc.npcSlots = 0;
			npc.noGravity = true;
			aiType = NPCID.Butterfly;
			Main.npcFrameCount[npc.type] = 3;
		}
		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
 		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth2"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.GetModPlayer<CelestialModPlayer>().ZoneVoid ? 1f : 0f;
				
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
	}
}
