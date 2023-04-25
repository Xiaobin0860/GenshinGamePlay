﻿namespace TaoTie
{
    public class DoActionBeforeBeAttackMixin: AbilityMixin
    {
        public ConfigDoActionBeforeBeAttackMixin ConfigDoAction => baseConfig as ConfigDoActionBeforeBeAttackMixin;

        private CombatComponent combatComponent;
        public override void Init(ActorAbility actorAbility, ActorModifier actorModifier, ConfigAbilityMixin config)
        {
            base.Init(actorAbility, actorModifier, config);
            combatComponent = actorAbility.Parent.GetParent<Entity>().GetComponent<CombatComponent>();
            if (combatComponent != null)
            {
                combatComponent.beforeBeAttack += Execute;
            }

        }

        private void Execute(AttackResult result, CombatComponent other)
        {
            if (ConfigDoAction.Actions != null)
            {
                for (int i = 0; i < ConfigDoAction.Actions.Length; i++)
                {
                    ConfigDoAction.Actions[i].DoExecute(actorAbility.Parent.GetParent<Entity>(), actorAbility, actorModifier, other.GetParent<Entity>());
                }
            }
        }

        public override void Dispose()
        {
            if (combatComponent != null)
            {
                combatComponent.beforeBeAttack -= Execute;
                combatComponent = null;
            }
            base.Dispose();
        }
    }
}