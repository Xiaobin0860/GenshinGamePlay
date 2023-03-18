﻿using System;
using Nino.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TaoTie
{
    [LabelText("通过ActorId创建实体")]
    [NinoSerialize]
    public partial class ConfigSceneGroupCreateEntityByActorIdAction : ConfigSceneGroupAction
    {
        [NinoMember(10)]
        [ValueDropdown("@OdinDropdownHelper.GetSceneGroupActorIds()")]
        public int actorId;
        
        protected override void Execute(IEventBase evt, SceneGroup aimSceneGroup, SceneGroup fromSceneGroup)
        {
            aimSceneGroup.CreateActor(actorId);
        }
    }
}