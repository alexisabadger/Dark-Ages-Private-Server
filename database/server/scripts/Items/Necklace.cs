﻿#region

using Darkages.Scripting;
using Darkages.Types;

#endregion

namespace Darkages.Storage.locales.Scripts.Items
{
    [Script("Necklace", "Dean")]
    public class Necklace : ItemScript
    {
        public Necklace(Item item) : base(item)
        {
        }

        public override void Equipped(Sprite sprite, byte displayslot)
        {
            if (Item.Template.Flags.HasFlag(ItemFlags.Elemental))
                if (Item.OffenseElement != ElementManager.Element.None)
                    while (sprite.OffenseElement == ElementManager.Element.Random)
                        sprite.OffenseElement = Sprite.CheckRandomElement(Item.Template.OffenseElement);

            Item.ApplyModifers((sprite as Aisling).Client);
            (sprite as Aisling).Client.SendStats(StatusFlags.StructD);
        }

        public override void OnUse(Sprite sprite, byte slot)
        {
            if (sprite == null)
                return;
            if (Item == null)
                return;
            if (Item.Template == null)
                return;

            if (sprite is Aisling)
            {
                var client = (sprite as Aisling).Client;

                if (Item.Template.Flags.HasFlag(ItemFlags.Equipable))
                    if (client.CheckReqs(client, Item))
                        client.Aisling.EquipmentManager.Add(Item.Template.EquipmentSlot, Item);
            }
        }

        public override void UnEquipped(Sprite sprite, byte displayslot)
        {
            if (Item.Template.Flags.HasFlag(ItemFlags.Elemental))
                sprite.OffenseElement = ElementManager.Element.None;

            Item.RemoveModifiers((sprite as Aisling).Client);
            (sprite as Aisling).Client.SendStats(StatusFlags.StructD);
        }
    }
}