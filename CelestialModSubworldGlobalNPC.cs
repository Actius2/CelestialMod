using System.Collections.Generic;
using Terraria.ModLoader;

namespace CelestialMod
{
	public class CelestialModSubworldGlobalNPC : GlobalNPC
	{
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			//If any subworld from our mod is loaded, disable spawns
			if (CelestialModSubworldManager.AnyActive(mod) ?? false)
			{
				pool.Clear();
			}
		}
	}
}
