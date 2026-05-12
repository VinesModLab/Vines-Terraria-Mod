# tModLoader 1.4 Migration TODO

This branch is `codex/tmodloader-1-4-migration`. It contains a broad first-pass migration from old tModLoader 1.3-era APIs toward current tModLoader 1.4 standards.

## Current Status

- **Build Environment:** Successfully linked mod to tModLoader `ModSources/` and confirmed `VinesMod.csproj` compiles.
- **Recipe Migration:** Main compiler-blocking recipe migration is complete, including the current `AddConsumeIngredientCallback` signature in `Wisp.cs`.
- **General APIs:** Major mechanical replacements (Item/Projectile casing, DamageClasses, ModContent calls) are done.
- **Namespace Ambiguity:** Fixed `CS0426` errors by adding `global::` to `VinesMod` type references in generic arguments.
- **Projectile Hooks:** Old projectile `Kill(int timeLeft)` overrides have been moved to `OnKill(int timeLeft)`.
- **Boss Music:** Custom bosses now assign vanilla boss music with the 1.4 `Music` property on clients.

## Immediate Compiler Blockers

The following errors still prevent a successful build:

- [x] **Melee Speed:** `player.meleeSpeed` was removed. Replace with `player.GetAttackSpeed(DamageClass.Melee) += Xf;`.
- [x] **Recipe Callback:** `AddOnCraftCallback` in `Wisp.cs` has an incorrect signature. Fixed to `(Item item, Recipe recipe, List<Item> consumedItems, Item destinationStack)`.
- [x] **NPC Scaling:** `ScaleExpertStats` was removed. Re-implemented using `public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)`.
- [x] **Tile Smart Cursor:** Fixed to `TileID.Sets.DisableSmartCursor[Type] = true;` in `StarForge.cs`.
- [x] **Projectile Sets:** `ProjectileID.Sets.Homing` is removed; deleted.
- [x] **AIType/aiStyle:** Corrected ambiguous assignments where Projectile IDs were being assigned to `aiStyle`.

## Post-Compilation Cleanup

1. **Restore Localization (DONE / REVIEW):**
   - The old `DisplayName.SetDefault` etc. calls were removed.
   - Text has been recovered into `Localization/en-US.hjson`.
   - Follow-up: review empty tooltip/description entries and fill only where the original content actually had text.

2. **Refactor Loot to 1.4 Systems (PARTIAL):**
   - Common global shard drops have been moved to `ModifyNPCLoot` using `ItemDropRule`.
   - Some boss-specific random drops remain in `OnKill` because they encode behavior-specific runtime logic and still use `NPC.GetSource_Loot()`.
   - Boss bags still use `RightClick` with `player.GetSource_OpenItem(Type)`, which is valid and preserves current behavior. Optional follow-up: convert fixed boss bag tables to `ModifyItemLoot` after in-game drop review.

3. **Restore Boss Music (DONE):**
   - Re-enabled vanilla boss music IDs for custom bosses.
   - Use `SceneEffect` later only if the mod needs custom biome/scene music behavior.

4. **Verify Sound Assets (DONE / IN-GAME CHECK REMAINS):**
   - `ModSound` was removed. Ensure all sounds are triggered via `SoundStyle` and that paths like `VinesMod/Sounds/Item/Wooo` are correct.
   - Static asset check confirms `Sounds/Item/Wooo.wav` exists. In-game smoke test should still confirm the sound actually triggers.

5. **Entity Source Audit (DONE / REVIEW):**
   - Ensure all `NewProjectile` and `NewItem` calls use the most specific `IEntitySource` available.
   - Static scan found no `NewItem(null)`, `NewProjectile(null)`, or `QuickSpawnItem(null)` calls.

6. **Thrown Damage Class (DECIDED FOR NOW):**
   - Confirm if `DamageClass.Ranged` is the permanent home for old thrown items, or if a custom `ThrownDamageClass` should be added.
   - Current migration keeps old thrown weapons on `DamageClass.Ranged`, matching vanilla 1.4's removal of the thrown class. Revisit only if the mod wants separate thrown scaling.

## Smoke Test Checklist

- [ ] Mod loads without errors in tModLoader.
- [ ] Star Forge can be crafted and placed.
- [ ] Bosses spawn via summon items and have correct names.
- [ ] Boss bags drop and can be opened.
- [ ] Wisp projectile homing behavior works (if applicable).
- [ ] All weapons render their custom textures and fire projectiles.
- [ ] Custom sounds (Wooo!) trigger correctly.

## Caution Notes

- Do not assume the current branch is complete. It is a migration baseline.
- Do not remove user assets or old content files.
- Prefer `ExampleMod` patterns as the source of truth.
- Keep behavior changes explicit, especially around recipes, drops, and damage classes.
