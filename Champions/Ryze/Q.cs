using LeagueSandbox.GameServer.Logic.GameObjects;
using LeagueSandbox.GameServer.Logic.API;
using LeagueSandbox.GameServer.Logic.GameObjects.AttackableUnits;
using LeagueSandbox.GameServer.Logic.Scripting.CSharp;

namespace Spells
{
    public class Overload : GameScript
    {
        public void OnActivate(Champion owner)
        {
        }

        public void OnDeactivate(Champion owner)
        {
        }

        public void OnStartCasting(Champion owner, Spell spell, AttackableUnit target)
        {
            spell.spellAnimation("SPELL1", owner);
        }

        public void OnFinishCasting(Champion owner, Spell spell, AttackableUnit target)
        {
            spell.AddProjectileTarget("Overload", target);
        }

        public void ApplyEffects(Champion owner, AttackableUnit target, Spell spell, Projectile projectile)
        {
            //TODO ADD Overload Passive: CDR per lvl

            var baseDamage = new[] { 40f, 60f, 80f, 100f, 120f }[spell.Level - 1];
            var ap = owner.GetStats().AbilityPower.Total * 0.4f;
            var mana = owner.GetStats().ManaPoints.Total * 0.065f;
            var damage = baseDamage + ap + mana;
            
            if (target != null && !ApiFunctionManager.IsDead(target))
            {

                target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            }
            projectile.setToRemove();

        }

        public void OnUpdate(double diff)
        {


        }
    }
}
