using System;
using Nino.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TaoTie
{
    [TriggerType(typeof(ConfigPlatformReachPointEvtTrigger))]
    [NinoSerialize]
    public partial class ConfigPlatformReachPointEvtPointIndexCondition : ConfigSceneGroupCondition<PlatformReachPointEvt>
    {
        [Tooltip(SceneGroupTooltips.CompareMode)] [OnValueChanged("@CheckModeType(value,mode)")] 
        [NinoMember(1)]
        public CompareMode mode;
        [NinoMember(2)]
        public Int32 value;

        public override bool IsMatch(PlatformReachPointEvt obj, SceneGroup sceneGroup)
        {
            return IsMatch(value, obj.pointIndex, mode);
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
