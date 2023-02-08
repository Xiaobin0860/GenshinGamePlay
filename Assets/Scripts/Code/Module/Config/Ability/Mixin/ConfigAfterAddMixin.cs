﻿namespace TaoTie
{
    /// <summary>
    /// 监听添加后
    /// </summary>
    public class ConfigAfterAddMixin : ConfigAbilityMixin
    {
        public ConfigAbilityAction[] Actions;

        public override AbilityMixin CreateAbilityMixin(ActorAbility actorAbility, ActorModifier actorModifier)
        {
            var res = ObjectPool.Instance.Fetch(TypeInfo<AfterAddMixin>.Type) as AfterAddMixin;
            res.Init(actorAbility, actorModifier, this);
            return res;
        }
    }
}