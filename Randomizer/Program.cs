// See https://aka.ms/new-console-template for more information


using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryFormatDataStructure;

class Program
{
    static class MODULES
    {
        public static string INITIALIZE = "INITIALIZE";
        public static string EQUIP = "EQUIP";
        public static string ITEMS = "ITEMS";
        public static string TREASURE = "TREASURE";
        public static string LEVELUP = "LEVELUP";
    }
    static Dictionary<string, bool> modules = new Dictionary<string, bool>() {
        {MODULES.INITIALIZE,false },
        {MODULES.EQUIP,false },
        {MODULES.ITEMS,false },
        {MODULES.TREASURE,false },
        {MODULES.LEVELUP,false },
    };
    static string base_path = @"romfs\Data\StreamingAssets\data_tbl\";
    static string dest_path = @"outout\romfs\Data\StreamingAssets\data_tbl\";
    private static IEnumerable<int> all_items = new List<int>();
    private static List<int>[] all_equipable = new List<int>[6]
    {
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>()
    };
    public static void RandomizeCharacterInitialStats()
    {
        var file = "player_initialize";
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();

            if (modules[MODULES.INITIALIZE])
            {
                Console.WriteLine("Randomizing players initial stats");
                foreach (var item in result)
                {
                    item["_hp"] = (int)((int)item["_hp"] * (r.NextDouble() + 0.5));
                    item["_attack"] = (int)((int)item["_attack"] * (r.NextDouble() + 0.5));
                    item["_magic_attack"] = (int)((int)item["_magic_attack"] * (r.NextDouble() + 0.5));
                    item["_defence"] = (int)((int)item["_defence"] * (r.NextDouble() + 0.5));
                    item["_magic_defence"] = (int)((int)item["_magic_defence"] * (r.NextDouble() + 0.5));
                    item["_speeed"] = (int)((int)item["_speeed"] * (r.NextDouble() + 0.5));
                    var skills = (int[])item["_learned_skill_id"];

                    item["_armor"] = (int)(new int[] { 0, 0, 0, 0, 59 }.OrderBy(x => r.Next()).First());
                    item["_weapon"] = (int)(new int[] { 0, 0, 0, 0, 27 }.OrderBy(x => r.Next()).First());

                    var learnableSkills = new int[] { 0, 103, 109, 111, 115, 120, 124, 125 };
                    var new_skiils = learnableSkills.OrderBy(x => r.Next()).Take(2).ToList();
                    skills[0] = new_skiils[0];
                    skills[1] = new_skiils[1];
                }
            }

            System.IO.File.Delete(destination);
            using (var stream_o = File.OpenWrite(destination))
            {
                reader.WriteStream(stream_o);
            }
        };

    }
    public static void RandomizeCharacterLevelUp()
    {
        //levelup_mario.tbl
        var skills = new List<int>();
        ReadCharacterLevelUp("mario", skills);
        ReadCharacterLevelUp("mallow", skills);
        ReadCharacterLevelUp("geno", skills);
        ReadCharacterLevelUp("koopa", skills);
        ReadCharacterLevelUp("peach", skills);
        skills = skills.Distinct().ToList();
        for (var i = 0; i < 20; i++)
            skills.Add(0);
        RandomizeCharacterLevelUp("mario", skills);
        RandomizeCharacterLevelUp("mallow", skills);
        RandomizeCharacterLevelUp("geno", skills);
        RandomizeCharacterLevelUp("koopa", skills);
        RandomizeCharacterLevelUp("peach", skills);
    }
    public static void RandomizeCharacterLevelUp(string character, List<int> learnableSkill)
    {
        var file = "/levelup_" + character;
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();

            if (modules[MODULES.LEVELUP])
            {

                Console.WriteLine("Randomizing players level up for " + character);
                foreach (var item in result.Skip(1))
                {
                    item["_hp"] = (int)((int)item["_hp"] * (r.NextDouble() + 0.5));
                    item["_hp_bonus"] = (int)((int)item["_hp_bonus"] * (r.NextDouble() + 0.5));
                    item["_attack"] = (int)((int)item["_attack"] * (r.NextDouble() + 0.5));
                    item["_attack_bonus"] = (int)((int)item["_attack_bonus"] * (r.NextDouble() + 0.5));
                    item["_magic_attack"] = (int)((int)item["_magic_attack"] * (r.NextDouble() + 0.5));
                    item["_magic_attack_bonus"] = (int)((int)item["_magic_attack_bonus"] * (r.NextDouble() + 0.5));
                    item["_defence"] = (int)((int)item["_defence"] * (r.NextDouble() + 0.5));
                    item["_defence_bonus"] = (int)((int)item["_defence_bonus"] * (r.NextDouble() + 0.5));
                    item["_magic_defence"] = (int)((int)item["_magic_defence"] * (r.NextDouble() + 0.5));
                    item["_magic_defence_bonus"] = (int)((int)item["_magic_defence_bonus"] * (r.NextDouble() + 0.5));
                    //Crash the start menu if enabled? Will find a way one day...
                    //item["_learn_skill"] = learnableSkill.OrderBy(x => r.Next()).First();
                }
            }

            System.IO.File.Delete(destination);
            using (var stream_o = File.OpenWrite(destination))
            {
                reader.WriteStream(stream_o);
            }
        };

    }
    public static void ReadCharacterLevelUp(string character, List<int> learnableSkill)
    {
        var file = "/levelup_" + character;
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();

            if (modules[MODULES.LEVELUP])
            {

                Console.WriteLine("Randomizing players level up for " + character);
                foreach (var item in result.Skip(1))
                {
                    learnableSkill.Add((int)item["_learn_skill"]);
                }
            }
        };

    }
    public static void RandomizeItems()
    {
        var file = "stella_item_list";
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();
            var items = new List<int>();
            all_items = items;
            if (modules[MODULES.EQUIP])
            {
                Console.WriteLine("Randomizing who can equip items");
            }
            if (modules[MODULES.ITEMS])
            {
                Console.WriteLine("Randomizing items stats");
            }
            foreach (var item in result)
            {
                items.Add((int)item["_item_id"]);
                if (modules[MODULES.EQUIP])
                {
                    //_can_equip_mario,_can_equip_mallow,_can_equip_geno,_can_equip_kupper,_can_equip_peach
                    var _can_equip_mario = (bool)item["_can_equip_mario"];
                    var _can_equip_mallow = (bool)item["_can_equip_mallow"];
                    var _can_equip_geno = (bool)item["_can_equip_geno"];
                    var _can_equip_kupper = (bool)item["_can_equip_kupper"];
                    var _can_equip_peach = (bool)item["_can_equip_peach"];
                    var is_equipable = _can_equip_mario || _can_equip_mallow || _can_equip_geno || _can_equip_kupper || _can_equip_peach;
                    if (is_equipable)
                    {
                        var equipable = new bool[] { false, false, false, false, false };

                        while (!equipable.Any())
                            equipable = equipable.Select(x => r.NextDouble() > 0.5).ToArray();

                        item["_can_equip_mario"] = (bool)equipable[0];

                        item["_can_equip_mallow"] = (bool)equipable[1];

                        item["_can_equip_geno"] = (bool)equipable[2];

                        item["_can_equip_kupper"] = (bool)equipable[3];

                        item["_can_equip_peach"] = (bool)equipable[4];

                    }
                }
                if (modules[MODULES.ITEMS])
                {
                    item["_buy_price"] = (int)((int)item["_buy_price"] * (r.NextDouble() + 0.5));
                    item["_attack"] = (int)((int)item["_attack"] * (r.NextDouble() + 0.5));
                    item["_magic_attack"] = (int)((int)item["_magic_attack"] * (r.NextDouble() + 0.5));
                    item["_defense"] = (int)((int)item["_defense"] * (r.NextDouble() + 0.5));
                    item["_magic_defense"] = (int)((int)item["_magic_defense"] * (r.NextDouble() + 0.5));

                    item["_possession_limit_easy"] = Math.Max(2, (int)((int)item["_possession_limit_easy"] * (r.NextDouble() + 0.5)));
                    item["_possession_limit_normal"] = Math.Max(2, (int)((int)item["_possession_limit_normal"] * (r.NextDouble() + 0.5)));
                }
                if ((bool)item["_can_equip_mario"])
                    all_equipable[1].Add((int)item["_item_id"]);
                if ((bool)item["_can_equip_mario"])
                    all_equipable[2].Add((int)item["_item_id"]);
                if ((bool)item["_can_equip_mario"])
                    all_equipable[3].Add((int)item["_item_id"]);
                if ((bool)item["_can_equip_mario"])
                    all_equipable[4].Add((int)item["_item_id"]);
                if ((bool)item["_can_equip_mario"])
                    all_equipable[5].Add((int)item["_item_id"]);
            }

            System.IO.File.Delete(destination);
            using (var stream_o = File.OpenWrite(destination))
            {
                reader.WriteStream(stream_o);
            }
        };
    }
    public static void RandomizeTreasure()
    {
        var file = "treasure_box";
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();

            var possible_0_value = result.Where(x => (int)x["_treasure_type"] == 0).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_1_value = result.Where(x => (int)x["_treasure_type"] == 1).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_2_value = result.Where(x => (int)x["_treasure_type"] == 2).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_3_value = result.Where(x => (int)x["_treasure_type"] == 3).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_4_value = result.Where(x => (int)x["_treasure_type"] == 4).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_5_value = result.Where(x => (int)x["_treasure_type"] == 5).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_6_value = result.Where(x => (int)x["_treasure_type"] == 6).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_7_value = result.Where(x => (int)x["_treasure_type"] == 7).Select(x => (int)x["_treasure_value"]).Distinct();
            var possible_new_types = new int[] { 1, 2, 3, 7 };
            var possible_values = new[] { possible_0_value, all_items, possible_2_value, possible_3_value, possible_4_value, possible_5_value, possible_6_value, possible_7_value };
            if (modules[MODULES.TREASURE])
            {
                Console.WriteLine("Randomizing treasure boxes");
                foreach (var item in result)
                {
                    if (possible_new_types.Contains((int)item["_treasure_type"]))
                    {
                        //If is not a special chest, then randomize it
                        item["_treasure_type"] = (int)possible_new_types[r.Next(possible_new_types.Length)];
                        item["_treasure_value"] = (int)(possible_values[(int)item["_treasure_type"]].OrderBy(x => r.Next()).First());
                    }
                    //_treasure_type
                    //_treasure_value
                    //_type {[_treasure_type, 
                }
            }
            Console.WriteLine(string.Join(",", result.Select(x => x["_treasure_type"]).Distinct()));
            Console.WriteLine(string.Join(",", result.Select(x => x["_treasure_value"]).Distinct()));
            Console.WriteLine(string.Join(",", possible_0_value));
            //treasure_type 1 would be an item?C:\Users\moysk\Desktop\__\t\BinaryFormatDataStructure\README.md
            Console.WriteLine(string.Join(",", possible_1_value));
            //tresure_type 2 would be coins?
            Console.WriteLine(string.Join(",", possible_2_value));
            //tresure_type 3 would be frog coins?
            Console.WriteLine(string.Join(",", possible_3_value));
            Console.WriteLine(string.Join(",", possible_4_value));
            Console.WriteLine(string.Join(",", possible_5_value));
            Console.WriteLine(string.Join(",", possible_6_value));
            //tresure_type 7 would be another coins?
            Console.WriteLine(string.Join(",", possible_7_value));

            System.IO.File.Delete(destination);
            using (var stream_o = File.OpenWrite(destination))
            {
                reader.WriteStream(stream_o);
            }
        };
    }
    public static void ReadConfig(string[] args)
    {
        bool needManualConfirm = true;
        foreach (var key in modules.Keys)
        {
            if (args.Contains(key))
            {
                needManualConfirm = false;
                modules[key] = true;
            }
        }
        if (args.Contains("-a"))
        {
            needManualConfirm = false;
            foreach (var key in modules.Keys)
                modules[key] = true;
        }
        if (needManualConfirm)
        {
            int cursor = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Select the modules to randomize");
                int i = 0;
                foreach (var key in modules.Keys)
                {
                    Console.WriteLine((i == cursor ? ">" : " ") + " [" + (modules[key] ? "x" : " ") + "] " + key);
                    i++;
                }
                Console.WriteLine(" W : Go up       S : Go down     Space: select     Enter: confirm");
                var pressed = Console.ReadKey(true);
                if (pressed.Key == ConsoleKey.Spacebar)
                {
                    var key = modules.Keys.ElementAt(cursor);
                    modules[key] = !modules[key];
                }
                else if (pressed.Key == ConsoleKey.W)
                {
                    if (cursor > 0)
                        cursor--;
                }
                else if (pressed.Key == ConsoleKey.S)
                {
                    if (cursor < modules.Count - 1)
                        cursor++;
                }
                else if (pressed.Key == ConsoleKey.Enter)
                {
                    needManualConfirm = true;
                    foreach (var key in modules.Keys)
                    {
                        if (modules[key])
                        {
                            needManualConfirm = false;
                        }
                    }
                }
            } while (needManualConfirm);
        }
    }
    public static void Main(string[] args)
    {
        ReadConfig(args);
        if (!System.IO.Directory.Exists(base_path))
        {
            Console.WriteLine("Put the dumped romfs in the same folder as the .exe file");
            return;
        }
        System.IO.Directory.CreateDirectory(dest_path);

        RandomizeItems();
        RandomizeCharacterInitialStats();
        RandomizeTreasure();
        RandomizeCharacterLevelUp();
        //player_action
        //encounter
        //shop
        //level_up


        var file = "stella_item_list";
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();

            Console.WriteLine(result);
            System.IO.File.Delete(destination);
            using (var stream_o = File.OpenWrite(destination))
            {
                reader.WriteStream(stream_o);
            }
        };

        /*using (var stream = File.OpenRead(destination))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
        }*/

    }
}
