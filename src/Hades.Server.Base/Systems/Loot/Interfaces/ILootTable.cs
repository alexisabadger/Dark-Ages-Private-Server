﻿#region

using System.Collections.Generic;

#endregion

namespace Darkages.Systems.Loot.Interfaces
{
    public interface ILootTable : ILootDefinition
    {
        IList<ILootDefinition> Children { get; }

        ILootTable Add(ILootDefinition item);

        ILootDefinition Get(string name);

        ILootTable Remove(ILootDefinition item);
    }
}