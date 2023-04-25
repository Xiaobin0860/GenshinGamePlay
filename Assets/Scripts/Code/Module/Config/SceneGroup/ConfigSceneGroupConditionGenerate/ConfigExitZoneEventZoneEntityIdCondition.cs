using System;
using Nino.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TaoTie
{
    [TriggerType(typeof(ConfigExitZoneEventTrigger))]
    [NinoSerialize]
    public partial class ConfigExitZoneEventZoneEntityIdCondition : ConfigSceneGroupCondition<ExitZoneEvent>
    {
        [Tooltip(SceneGroupTooltips.CompareMode)] [OnValueChanged("@CheckModeType(value,mode)")] 
        [NinoMember(1)]
        public CompareMode mode;
        [NinoMember(2)]
        public Int64 value;

        public override bool IsMatch(ExitZoneEvent obj, SceneGroup sceneGroup)
        {
            return IsMatch(value, obj.ZoneEntityId, mode);
        }
#if UNITY_EDITOR
        protected override bool CheckModeType<T>(T t, CompareMode mode)
        {
            if (!base.CheckModeType(t, mode))
            {
                mode = CompareMode.Equal;
                return false;
            }

            return true;
        }
#endif
    }
}