using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class AdvancedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
             switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected virtual void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            Item gatherItem = null;
            string gatherItemName = commandWords[2];
            var gatherLocation = actor.Location as IGatheringLocation;

            if (gatherLocation != null &&
                actor.ListInventory().Any(item => item.ItemType == gatherLocation.RequiredItem))
            {
                gatherItem = gatherLocation.ProduceItem(gatherItemName);
                this.AddToPerson(actor, gatherItem);
                gatherItem.UpdateWithInteraction("gather");
            }
        }
        protected virtual void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            switch (commandWords[2])
            {
                case "weapon":
                    CraftWeapon(commandWords, actor);
                    break;
                case "armor":
                    CraftArmor(commandWords, actor);
                    break;
                default:
                    break;
            }
        }

        protected void CraftWeapon(string[] commandWords, Person actor)
        {
            Item craftedItem = null;
            string craftItemName = commandWords[3];
            if (actor.ListInventory().Any(item => Weapon.GetComposingItems()[0] == item.ItemType) && actor.ListInventory().Any(item => Weapon.GetComposingItems()[1] == item.ItemType))
            {
                craftedItem = new Weapon(craftItemName);
                this.AddToPerson(actor, craftedItem);
                craftedItem.UpdateWithInteraction("craft");
            }
        }

        protected void CraftArmor(string[] commandWords, Person actor)
        {
            Item craftedItem = null;
            string craftItemName = commandWords[3];
            if (actor.ListInventory().Any(item => Armor.GetComposingItems()[0] == item.ItemType))
            {
                craftedItem = new Armor(craftItemName);
                this.AddToPerson(actor, craftedItem);
                craftedItem.UpdateWithInteraction("craft");
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }
    }
}
