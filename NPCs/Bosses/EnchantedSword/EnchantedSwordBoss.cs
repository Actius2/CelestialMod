using CelestialMod.Dusts;
using CelestialMod.Items;
using CelestialMod.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.NPCs.Bosses.EnchantedSword
{
	[AutoloadBossHead]
	public class EnchantedSwordBoss : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("NAMEHERE");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.EnchantedSword];
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 14;
			npc.defense = 6;
			npc.lifeMax = 200;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 23;
			aiType = NPCID.EnchantedSword;
			animationType = NPCID.EnchantedSword;
			music = MusicID.Title;
			musicPriority = MusicPriority.BossMedium; // By default, musicPriority is BossLow
			bossBag = ItemType<MysticGrassBlock>();
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.2f * bossLifeScale);
			npc.defense = 72;
		}
		
		
		
		
		
	}
}