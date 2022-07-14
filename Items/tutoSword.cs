using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace tuto.Items
{
	public class tutoSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("tutoSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.ArmorPenetration = 10;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Fireball>();
			Item.shootSpeed = 3f;
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			
			int dustQuantity = 5; // How many particles do you want ?
			for (int i = 0; i < dustQuantity; i++)
			{
				int dust = Dust.NewDust(player.position, Item.width, Item.height, 6); // Create the dust, "6" is the dust type (fire, in that case).

				Main.dust[dust].noGravity = true; // Is the dust affected by gravity ?
				Main.dust[dust].velocity *= 1f;    // Change the dust velocity.
				Main.dust[dust].scale = 1.5f;    // Change the dust size.
			}
			return true;
        }

    }
}