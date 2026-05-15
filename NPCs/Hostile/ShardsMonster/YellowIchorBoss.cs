using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
    public class YellowIchorBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/YellowIchorBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/YellowIchorBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.IchorSticker);
            NPC.aiStyle = -1; 
            NPC.lifeMax = 2200; 
            NPC.damage = 5; 
            NPC.defense = 5; 
            NPC.scale = 2f;
            NPC.value = 5000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.YellowIchorBossBag>()));
        }
        

        public override void AI()
        {
            Target();
            DespawnHandler();

            bool secondPhase = NPC.life < NPC.lifeMax / 2;
            NPC.ai[0]++;

            Vector2 hoverOffset = new Vector2((float)Math.Sin(NPC.ai[0] / 20f) * 280f, -170f + (float)Math.Cos(NPC.ai[0] / 16f) * 45f);
            Move(hoverOffset);

            if (NPC.ai[0] % (secondPhase ? 65f : 95f) == 0f)
            {
                Shoot(secondPhase ? 2 : 1, secondPhase ? 8f : 5.75f);
            }

            if (secondPhase && NPC.ai[0] % 150f == 0f)
            {
                IchorRain();
            }

            if (NPC.ai[0] > 360f)
            {
                NPC.ai[0] = 0f;
            }
        }

        private void Target()
        {
            player = Main.player[NPC.target]; // This will get the player target.
        }

        private void Move(Vector2 offset)
        {
            speed = NPC.life < NPC.lifeMax / 2 ? 10f : 7f; // Sets the max speed of the NPC.
            Vector2 moveTo = player.Center + offset; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude; 
            }
            float turnResistance = 25f; // The larget the number the slower the npc will turn.
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
        }

        private void DespawnHandler()// Handles if the NPC should despawn.
        {
            if(!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                player = Main.player[NPC.target];
                if(!player.active || player.dead)
                {
                    NPC.velocity = new Vector2(0f, -10f);
                    if(NPC.timeLeft > 10)
                    {
                        NPC.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private void Shoot(int spread, float projectileSpeed)
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.YellowIchorBossProjectile>();
            Vector2 velocity = player.Center - NPC.Center; // Get the distance between target and NPC.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= projectileSpeed / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            for (int i = -spread; i <= spread; i++)
            {
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity.RotatedBy(MathHelper.ToRadians(i * 10f)), type, NPC.damage, 2f);
            }
        }

        private void IchorRain()
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.YellowIchorBossProjectile>();
            for (int i = -3; i <= 3; i++)
            {
                Vector2 position = player.Center + new Vector2(i * 80f, -500f);
                Vector2 velocity = new Vector2(i * 0.25f, 7f);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), position, velocity, type, (int)(NPC.damage * 0.75f), 1f);
            }
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1;
            NPC.frameCounter %= 20;
            int frame = (int)(NPC.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[Type]) frame = 0;
            NPC.frame.Y = frame * frameHeight;

        }


        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.BallisticStaff>(), 1);
                        break;
                    case 1:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.DualUse.GoldenGunBlade>(), 1);
                        break;
                    case 2:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.Shield.ShieldOfFlag>(), 1);
                        break;
                    case 3:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.PizzaBadge>(), 1);
                        break;
                }

                if (Main.rand.Next(10) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.AmberMosquito, 1);

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Amber, Main.rand.Next(2, 5));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Topaz, Main.rand.Next(1, 4));
            }

            // For settings if the boss has been downed
            VinesWorld.downedYellowIchorBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
