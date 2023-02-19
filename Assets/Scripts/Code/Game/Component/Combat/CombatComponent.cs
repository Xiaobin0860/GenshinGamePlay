﻿using System;
using UnityEngine;

namespace TaoTie
{
    public class CombatComponent : Component, IComponent
    {
        private FsmComponent fsm => Parent.GetComponent<FsmComponent>();
        protected AttackTarget attackTarget;
        public virtual void Init()
        {
            attackTarget = new AttackTarget();
        }

        public virtual void Destroy()
        {
            beforeAttack = null;
            beforeBeAttack = null;
            afterAttack = null;
            afterBeAttack = null;
        }

        /// <summary>
        /// 造成伤害前
        /// </summary>
        public event Action<AttackResult, CombatComponent> beforeAttack;

        /// <summary>
        /// 受到伤害前
        /// </summary>
        public event Action<AttackResult, CombatComponent> beforeBeAttack;

        /// <summary>
        /// 造成伤害后
        /// </summary>
        public event Action<AttackResult, CombatComponent> afterAttack;

        /// <summary>
        /// 造成伤害后
        /// </summary>
        public event Action<AttackResult, CombatComponent> afterBeAttack;

        /// <summary>
        /// 造成伤害前
        /// </summary>
        public void BeforeAttack(AttackResult result, CombatComponent other)
        {
            beforeAttack?.Invoke(result, other);
        }

        /// <summary>
        /// 受到伤害前
        /// </summary>
        public void BeforeBeAttack(AttackResult result, CombatComponent other)
        {
            beforeBeAttack?.Invoke(result, other);
        }

        /// <summary>
        /// 造成伤害后
        /// </summary>
        public void AfterAttack(AttackResult result, CombatComponent other)
        {
            afterAttack?.Invoke(result, other);
        }

        /// <summary>
        /// 受到伤害后
        /// </summary>
        public void AfterBeAttack(AttackResult result, CombatComponent other)
        {
            afterBeAttack?.Invoke(result, other);
        }

        /// <summary>
        /// 立刻使用技能
        /// </summary>
        /// <param name="skillId"></param>
        public void UseSkillImmediately(int skillId)
        {
            fsm.SetData(FSMConst.UseSkill, true);
            fsm.SetData(FSMConst.SkillId, skillId);
        }

        /// <summary>
        /// 开启或关闭hitBox
        /// </summary>
        /// <param name="hitBox"></param>
        /// <param name="enable"></param>
        public async ETTask EnableHitBox(string hitBox, bool enable)
        {
            GameObjectHolderComponent ghc = Parent.GetComponent<GameObjectHolderComponent>();
            await ghc.WaitLoadGameObjectOver();
            ghc.GetCollectorObj<GameObject>(hitBox)?.SetActive(enable);
        }
    }
}