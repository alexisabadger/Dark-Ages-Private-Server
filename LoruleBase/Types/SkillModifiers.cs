﻿#region

using System;

#endregion

namespace Darkages.Types
{
    [Flags]
    public enum SkillModifiers
    {
        Default = 0,
        Fixed = 1,
        Custom = 2
    }
}