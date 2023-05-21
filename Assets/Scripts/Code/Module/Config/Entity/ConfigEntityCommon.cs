﻿using Nino.Serialization;
using UnityEngine;

namespace TaoTie
{
    [NinoSerialize]
    public partial class ConfigEntityCommon
    {
        [NinoMember(1)][Tooltip("会影响相机机位")]
        public float Height = 1.5f;
        [NinoMember(2)]
        public float ModelHeight;
        [NinoMember(3)]
        public float Scale;
        
    }
}