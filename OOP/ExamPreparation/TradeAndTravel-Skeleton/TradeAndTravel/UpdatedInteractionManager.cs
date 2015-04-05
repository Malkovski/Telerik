namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UpdatedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
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
                    return base.CreateLocation(locationTypeString, locationName);
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

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            if (actor.ListInventory().Exists(x => (x.ItemType == ItemType.Iron)))
            {
                if (commandWords[2] == "armor")
                {
                    actor.AddToInventory(new Armor(commandWords[3]));
                }
                else if (commandWords[2] == "weapon" && actor.ListInventory().Exists(x => (x.ItemType == ItemType.Wood)))
                {
                    actor.AddToInventory(new Weapon(commandWords[3]));
                }
            }          
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor.Location.GetType().Name == "Mine" && actor.ListInventory().Exists(x => (x.ItemType == ItemType.Armor)))
            {
                actor.AddToInventory(new Iron(commandWords[2]));
            }

            if (actor.Location.GetType().Name == "Forest" && actor.ListInventory().Exists(x => (x.ItemType == ItemType.Weapon)))
            {
                actor.AddToInventory(new Wood(commandWords[2]));
            }
        }
    }
}
