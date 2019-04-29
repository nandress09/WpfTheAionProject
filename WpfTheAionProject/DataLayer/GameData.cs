using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;

namespace WpfTheAionProject.DataLayer
{
    /// <summary>
    /// static class to store the game data set
    /// </summary>
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Jared",
                Age = 12,
                JobTitle = Player.JobTitleName.Wolf,
                Race = Character.RaceType.Dad,
                Health = 100,
                Lives = 5,
                ExperiencePoints = 20,
                SkillLevel = 5,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(2001), 5),
                }
            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 4;

            Map gameMap = new Map(rows, columns);

            gameMap.StandardGameItems = StandardGameItems();

            //
            // row 1
            //
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Town Hall",
                Description = "Town Hall sits in the middle of town. " +
                "This is where all the celebrations are held, where people come to trade and sell goods " +
                "This is the best place to start, to find your son ",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\t while you were napping in the woods, you woke up to find someone had taken your pup " +
                "You don't know much about the humans, but this might be the best place to start to find him " +
                "Make some friends, dont bite anyone, and maybe they can be bribed for information and clues " 
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "The bakery",
                Description = "Everything here smells wonderful.The baker seems like a regular person " +
                "This might be a great place to grab a bite to eat " + "" +
                "The humans keep talking about the bakers boy stealing something from the queens quarter, maybe we can find clues here ",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(4002), 1)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1001),
                }
            };

            //
            // row 2
            //
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 3,
                Name = "The Knights keep",
                Description = "Located about a mile from Town Hall, in the woods, in a stand alone castle  " +
                "It reeks of death here. Watch your tail, boy. ",
                Accessible = true,
                ModifiyExperiencePoints = 20,
              
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(4001), 1)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1002),
                    NpcById(2001)
                }
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 4,
                Name = "The Queens keep ",
                Description = "The Queens keep is a two mile walk into the woods, surrounded by knights that dont seem to mind you  " +
                "The Castle is white, decorated with Rose Quartz stone. When the king died, the Queen went out of her way to pretty the place up" +
                "On the ground, there are flowers and roses of all colors " +
                "You walk through the flowers, and the smell of the flowers weaken you *yikes* why are there so many?!",
                Accessible = false,
                RequiredRelicId = 2030,
                ModifiyExperiencePoints = 50,
                ModifyLives = -1,
                RequiredExperiencePoints = 40,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001), 10),
                    new GameItemQuantity(GameItemById(1002), 10),
                    new GameItemQuantity(GameItemById(3001), 10)
                },
                  Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1002),
                    NpcById(1001)
                }
            };

            //
            // row 3
            //
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 5,
                Name = "Gang alley",
                Description = "Not the best place to be, but your notice the Bakers boy go down this way " +
                "You see the boy carrying a large bag of stuff, and can smell some painful smells of purfume" +
                "Maybe he has the'queen trinket' go sniff his bag! ",
                Accessible = false,
                ModifiyExperiencePoints = 20,
                ModifyHealth = 50,
                Message = "I see you have some interest in my merchandise, how can I help you? ",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2030), 10),
                    new GameItemQuantity(GameItemById(4002), 10),
                    new GameItemQuantity(GameItemById(3001), 10)
                }
                 
            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 6,
                Name = "The General store",
                Description = "Welcome to the general store, where we have all the goods of life! " +
                "Quit looking so lost, stranger. Come on in and get your food, weapons, and all other things " +
                "Don't touch the chickens..",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001), 10),
                    new GameItemQuantity(GameItemById(4002), 10),
                    new GameItemQuantity(GameItemById(3001), 10)
                },
                 Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1002),
                    NpcById(1001)
                }
            };
            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Longsword", 75, 1, 4, "Sharp enough to chop off your head, be careful not to run into one", 10),
                new Weapon(1002, "Musket", 250, 1, 9, "you aren't sure what to think of this shiny thing, but people do seem afraid of it", 10),
                new Treasure(2001, "Coin", 10, Treasure.TreasureType.Coin, "Very must does not have any taste to it, but the humans love it", 1),
                new Treasure(2020, "Sparkle Rock", 50, Treasure.TreasureType.Jewel, "alot of the women have these on their finger. Weird", 1),
                new Treasure(2030, "'Queens' Necklace ", 10, Treasure.TreasureType.Jewel, "This has the Royal emblem carved into it, but something looks off.", 5),
                new Potion(3001, "Bakers Best Bread", 5, 40, 1, "The smell alone fills your spirit, you heal 40 points", 5),
                new Relic(4001, "Queens Necklace", 5, "The beautiful engraving is perfect to the royal emblem", 5, "Theres a large crystal infused with ashes of the king in the middle", Relic.UseActionType.OPENLOCATION),
                new Relic(4002, "Dark Chocolate", 5, "It smells so good, shaped into a heart.", 5, "You cronch down on the delicious candy, it fills your stomach, and you suffocate as you vomit to death", Relic.UseActionType.KILLPLAYER)
            };
        }

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Military()
                {
                    Id = 2001,
                    Name = "Kings Guard Steve",
                    Race = Character.RaceType.Dad,
                    Description = "A smiley knight, dressed in all gold.",
                    Messages = new List<string>()
                    {
                        "hello! My name is Steve",
                        "Dont you be biting any children now! I will have to get you!",
                        "If you're hungry, check out the bakery!",
                        "Be careful around these parts, not many people feel comfortable around animals"
                    },
                   SkillLevel = 3,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Citizen()
                {
                    Id = 1001,
                    Name = "Gina Providence",
                    Race = Character.RaceType.Grandma,
                    Description = "A kind, very old looking woman, surrounded by 5 kids",
                    Messages = new List<string>()
                    {
                        "Hello, my name is Gine. If you bite my grand kids, I'll whip you into next week.",
                        "Come here sweet animal, what's your name.",
                        "I've lived here all of my life! I have twelve children, and twenty grandbabies.",
                        "Where's your home, little one?"
                    }
                },

                new Citizen()
                {
                    Id = 1002,
                    Name = "Maggie Cress",
                    Race = Character.RaceType.Grandpa,
                    Description = "Another old lady, shes got a knife though..so",
                    Messages = new List<string>()
                    {
                        "Hey there! You look lost.",
                        "Dont mind me! Just looking for some dinner.",
                        "Ever heard of the Queen? Poor thing lost her husband to an enemy attack a few years back..",
                        "Some say the Queen had her husbands ashes stored in a necklace that she refuses to be without"

                    }
                },
            };
        }
    }
}