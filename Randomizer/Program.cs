// See https://aka.ms/new-console-template for more information


using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryFormatDataStructure;

class Program
{
    [Serializable]
    class Validator
    {
        public Validator()
        {
            a = "A";
            b = new V2[] {
                new V2(){ /*d="bob"*/ }
            };
        }
        public string a { get; set; }

        public V2[] b { get; set; }
    }
    [Serializable]
    class V2
    {
        public int a { get; set; } = int.MaxValue;
        public int b { get; set; } = int.MaxValue;
        public int c { get; set; } = int.MaxValue;
        //public string d { get; set; }
        public int e { get; set; } = int.MaxValue;
        public int f { get; set; } = int.MaxValue;
    }

    static class MODULES
    {
        public static string INITIALIZE = "INITIALIZE";
        public static string SPECIALS = "SPECIALS";
        public static string EQUIP = "EQUIP";
        public static string ITEMS = "ITEMS";
        public static string ITEMS_PRICE = "ITEMS_PRICE";
        public static string TREASURE = "TREASURE";
        public static string LEVELUP = "LEVELUP";
        public static string ENCOUNTER = "ENCOUNTER";
        public static string SHOP = "SHOP";
        public static string CUTSCENES_R = "CUTSCENES_R";
        public static string CUTSCENES_S = "CUTSCENES_S";
    }
    static Dictionary<string, bool> modules = new Dictionary<string, bool>() {
        {MODULES.INITIALIZE,false },
        {MODULES.SPECIALS,false },
        {MODULES.EQUIP,false },
        {MODULES.ITEMS,false },
        {MODULES.ITEMS_PRICE,false },
        {MODULES.TREASURE,false },
        {MODULES.LEVELUP,false },
        {MODULES.ENCOUNTER,false },
        {MODULES.SHOP,false },
        {MODULES.CUTSCENES_R,false },
        {MODULES.CUTSCENES_S,false },
    };
    static string base_path = @"romfs\Data\StreamingAssets\data_tbl\";
    static string dest_path = @"outout\romfs\Data\StreamingAssets\data_tbl\";
    private static IEnumerable<int> all_items = new List<int>();
    private static List<int> shop_items = new List<int>();
    private static List<int>[] all_equipable = new List<int>[6]
    {
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>()
    };
    public static void RandomizeEncounter()
    {
        var file3 = "encounter";
        var file2 = "encounter_pattern";
        var file = "monster";
        var path = base_path + file + ".tbl";
        var path2 = base_path + file2 + ".tbl";
        var path3 = base_path + file3 + ".tbl";
        var destination = dest_path + file + ".tbl";
        var destination2 = dest_path + file2 + ".tbl";
        var destination3 = dest_path + file3 + ".tbl";

        NRBFReader reader1, reader2, reader3;
        BinaryObject[] monsters, encounters, monsters_ori, encounters_meta;

        using (var stream = File.OpenRead(path))
        {
            reader1 = new NRBFReader(stream);
            monsters_ori = ((Object[])reader1.Parse()).Select(x => (BinaryObject)x).ToArray();
        }
        using (var stream = File.OpenRead(path))
        {
            reader1 = new NRBFReader(stream);
            monsters = ((Object[])reader1.Parse()).Select(x => (BinaryObject)x).ToArray();
        }
        using (var stream = File.OpenRead(path2))
        {
            reader2 = new NRBFReader(stream);
            encounters = ((Object[])reader2.Parse()).Select(x => (BinaryObject)x).ToArray();
        }
        using (var stream = File.OpenRead(path3))
        {
            reader3 = new NRBFReader(stream);
            encounters_meta = ((Object[])reader3.Parse()).Select(x => (BinaryObject)x).ToArray();
        }
        Random r = new Random();

        var event_battles = encounters_meta.Where(x => (bool)x["_is_event_battle"]).ToList();
        var non_randomizable_battles = event_battles.SelectMany(x => ((int[])x["_encount_ptn_id"])).Distinct().ToList();
        var randomizable_montsters = encounters.Where(item => !non_randomizable_battles.Contains((int)item["_encount_pattern_id"]))
                                           .SelectMany(item => (int[])(int[])item["_monster_id"]).Distinct().ToList();

        if (modules[MODULES.ENCOUNTER])
        {
            Console.WriteLine("Randomizing encounters");
            var all_ids = monsters.Select(x => ((int)x["_character_id"])).Where(x => x > 1 && randomizable_montsters.Contains(x)).ToList();
            var shuffled_ids = all_ids.OrderBy(x => r.Next()).ToList();

            //for (var i = 0; i < all_ids.Count; i++)
            //{
            //    var dest_monster = monsters.First(x => (int)x["_character_id"] == shuffled_ids[i]);
            //    var source_monster = monsters_ori.First(x => (int)x["_character_id"] == all_ids[i]);

            //    foreach (var stat in new string[]
            //       {
            //           "_hp", "_fp", "_attack","_defense", "_magic_attack","_magic_defense"
            //       })
            //    {
            //        dest_monster[stat] = Math.Max(1, (int)source_monster[stat]);
            //    }
            //}
            foreach (var item in monsters)
            {
                item["_is_drop_100per"] = true;
                item["_drop_item_id_1"] = all_items.OrderBy(x => r.Next()).First();
                item["_drop_item_id_2"] = all_items.OrderBy(x => r.Next()).First();
                item["_coin"] = r.Next(10, 20);

                /*_monster_id,_character_id,
                 * _hp,_fp,_attack,_defense,_magic_attack,_magic_defense,_speed,_avoid,
                 * 
                 * _resist_jump,_resist_fire,_resist_thunder,_resist_ice,
                 * _invalid_fear,_invalid_poison,_invalid_sleep,_invalid_silent,_resist_sheep,_invalid_geno_cutter,_invalid_holy_water,
                 * _invalid_yoshi_cookie,_start_state,_exp,_coin,_is_drop_100per,_drop_item_id_1,_drop_item_id_2,
                 * _drop_item_by_yoshi_cookie,_bonus_flower_id,_bonus_flower_persent,_appear_ptn_id,_escape_ptn_id,
                 * _collision_size_x,_collision_size_y,_collision_size_z,_collision_offset_x,_collision_offset_y,
                 * _collision_offset_z,_scale,_nanikangaeteruno_id,_nanikangaeteruno_mess_num,_ryuuyou_chara_id,
                 * _cookie_hit_percent,_monster_book_sort_order,_monster_book_msg_id,_monster_book_area_id,
                 * _monster_book_fixed_position,_monster_book_encounter_id,_monster_book_encount_pattern_id,
                 * _monster_book_multiple_display,_monster_book_camera_pattern,_monster_book_pos_move_x,
                 * _monster_book_pos_move_z,_dying_disp*/
                var stats = new string[] { "_hp","_fp","_attack","_defense","_magic_attack","_magic_defense","_speed","_exp"
                    };
                foreach (var stat in stats)
                {
                    item[stat] = Math.Max(1, (int)((int)item[stat] * (r.NextDouble() + 0.5)));
                }

                //item["_can_escape"] = true;
            }
            var d = encounters_meta.Select(c => c["_can_escape"]).ToList();
            foreach (var item in encounters_meta)
            {
                item["_can_escape"] = true;
            }
            foreach (var item in encounters)
            {
                if (non_randomizable_battles.Contains((int)item["_encount_pattern_id"])) continue;
                var lst = (int[])item["_monster_id"];
                for (var i = 0; i < lst.Length; i++)
                {
                    if (lst[i] > 1001)
                    {
                        var mon_id = lst[i];
                        //var idx = all_ids.IndexOf(mon_id);
                        //if (idx != -1)
                        //{
                        //    var new_id = shuffled_ids[idx];
                        //    lst[i] = new_id;
                        //}
                        while (lst[i] == mon_id)
                            lst[i] = all_ids.Where(x => x >= lst[i] - 40 && x <= lst[i] + 40).OrderBy(x => r.Next()).First();
                    }
                }
            }
        }

        System.IO.File.Delete(destination);
        using (var stream_o = File.OpenWrite(destination))
        {
            reader1.WriteStream(stream_o);
        }
        System.IO.File.Delete(destination2);
        using (var stream_o = File.OpenWrite(destination2))
        {
            reader2.WriteStream(stream_o);
        }
        System.IO.File.Delete(destination3);
        using (var stream_o = File.OpenWrite(destination3))
        {
            reader3.WriteStream(stream_o);
        }
    }
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
                    item["_weapon"] = (int)(new int[] { 27 }.OrderBy(x => r.Next()).First());

                    if (modules[MODULES.SPECIALS])
                    {
                        var learnableSkills = new int[] { /*0, 103, 109, 111, 115, 120,*/
                124, 125 };
                        var new_skiils = learnableSkills.OrderBy(x => r.Next()).Take(2).ToList();
                        skills[0] = new_skiils[0];
                        skills[1] = new_skiils[1];
                    }
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
                BinaryObject previous = null;
                Console.WriteLine("Randomizing players level up for " + character);
                foreach (var item in result.Skip(1))
                {
                    var stats = new string[] { "_hp", "_hp_bonus", "_attack", "_attack_bonus",
                        "_magic_attack","_magic_attack_bonus","_defence",
                        "_defence_bonus","_magic_defence","_magic_defence_bonus"
                    };
                    foreach (var stat in stats)
                    {
                        item[stat] = (int)((int)item[stat] * (r.NextDouble() + 0.5));
                        if (previous != null)
                        {
                            //Prevent too big of debuff
                            item[stat] = Math.Max((int)previous[stat] - 10, (int)item[stat]);
                        }
                    }

                    previous = item;
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
                if (modules[MODULES.ITEMS_PRICE])
                {
                    item["_buy_price"] = (int)((int)item["_buy_price"] * (r.NextDouble() + 0.5));
                    //item["_buy_price"] = 1;
                    item["_buy_price_alto"] = (int)((int)item["_buy_price_alto"] * (r.NextDouble() + 0.5));
                    item["_buy_price_tenor"] = (int)((int)item["_buy_price_tenor"] * (r.NextDouble() + 0.5));
                    item["_buy_price_soprano"] = (int)((int)item["_buy_price_soprano"] * (r.NextDouble() + 0.5));
                    item["_sell_price"] = (int)((int)item["_sell_price"] * (r.NextDouble() + 0.5));
                    //item["_sell_price"] = 100;
                    item["_kaeru_coin_price"] = (int)((int)item["_kaeru_coin_price"] * (r.NextDouble() + 0.5));
                    item["_point_buy_price"] = (int)((int)item["_point_buy_price"] * (r.NextDouble() + 0.5));
                    item["_point_sell_price"] = (int)((int)item["_point_sell_price"] * (r.NextDouble() + 0.5));
                }
                if ((int)item["_explain_id"] > 0 && (int)item["_buy_price"] > 0)
                {
                    shop_items.Add((int)item["_item_id"]);
                }
                if (modules[MODULES.ITEMS])
                {
                    item["_speed"] = (int)((int)item["_speed"] * (r.NextDouble() + 0.5));
                    item["_attack"] = (int)((int)item["_attack"] * (r.NextDouble() + 0.5));
                    item["_magic_attack"] = (int)((int)item["_magic_attack"] * (r.NextDouble() + 0.5));
                    item["_defense"] = (int)((int)item["_defense"] * (r.NextDouble() + 0.5));
                    item["_magic_defense"] = (int)((int)item["_magic_defense"] * (r.NextDouble() + 0.5));

                    item["_possession_limit_easy"] = 100;// Math.Max(2, (int)((int)item["_possession_limit_easy"] * (r.NextDouble() + 0.5)));
                    item["_possession_limit_normal"] = 100;// Math.Max(2, (int)((int)item["_possession_limit_normal"] * (r.NextDouble() + 0.5)));
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
    public static void RandomizeShop(string shop = null)
    {
        if (shop == null)
        {
            RandomizeShop("shop");
            RandomizeShop("frog_shop");
            RandomizeShop("pickup_shop");
            return;
        }
        var file = shop;
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();
            if (modules[MODULES.SHOP])
            {
                Console.WriteLine("Randomizing shops");
            }

            foreach (var item in result)
            {
                int[] items_for_sale = (int[])item["_item_id"];
                for (int i = 0; i < items_for_sale.Length; i++)
                {
                    items_for_sale[i] = shop_items.OrderBy(x => r.Next()).First();
                }
            }

            System.IO.File.Delete(destination);
            using (var stream_o = File.OpenWrite(destination))
            {
                reader.WriteStream(stream_o);
            }
        };
    }

    public static void RandomizeUnlocks()
    {
        var file = "event_status";
        var path = base_path + file + ".tbl";
        var destination = dest_path + file + ".tbl";

        using (var stream = File.OpenRead(path))
        {
            var reader = new NRBFReader(stream);
            var result = ((Object[])reader.Parse()).Select(x => (BinaryObject)x).ToArray();
            Random r = new Random();

            var unlocks = result.Where(x => (int)x["_party_num"] > 0).Distinct().ToArray();
            foreach (var item in result)
            {
                //_bounus_hp
                var bonus_hp = (bool[])item["_bounus_hp"];
                for (var i = 0; i < bonus_hp.Length; i++) bonus_hp[i] = true;
                var bonus_pow = (bool[])item["_bounus_pow"];
                for (var i = 0; i < bonus_pow.Length; i++) bonus_pow[i] = true;
                var bonus_s = (bool[])item["_bounus_s"];
                for (var i = 0; i < bonus_s.Length; i++) bonus_s[i] = true;

                //_coin
                //_frog_coin
                item["_coin"] = r.Next(1, 50);
                item["_frog_coin"] = r.Next(1, 50);
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
            var resetTypes = result.Select(x => x["_reset_type"]).Distinct().ToList();
            if (modules[MODULES.TREASURE])
            {
                Console.WriteLine("Randomizing treasure boxes");
                foreach (var item in result)
                {
                    if (possible_new_types.Contains((int)item["_treasure_type"]))
                    {
                        //If is not a special chest, then randomize it
                        item["_reset_type"] = 1;
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
    public static void RandomizeCutscenes()
    {
        if (modules[MODULES.CUTSCENES_R] || modules[MODULES.CUTSCENES_S])
        {
            var path = base_path + "..\\movies\\";
            var destination = dest_path + "..\\movies\\";
            var r = new Random();
            var ori_file_name = System.IO.Directory.GetFiles(path).Select(x => (new System.IO.FileInfo(x)).Name).ToList();
            var shuffled = ori_file_name.OrderBy(x => r.Next()).ToList();
            for (var i = 0; i < shuffled.Count; i++)
            {
                if (modules[MODULES.CUTSCENES_R])
                    System.IO.File.Copy(path + ori_file_name[i], destination + shuffled[i], true);
                if (modules[MODULES.CUTSCENES_S])
                    System.IO.File.Copy(path + "movie_009.usm", destination + shuffled[i], true);
            }
        }
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
        System.IO.Directory.CreateDirectory(dest_path + "\\..\\movies\\");

        RandomizeItems();
        RandomizeCharacterInitialStats();
        RandomizeTreasure();
        RandomizeCharacterLevelUp();
        RandomizeEncounter();
        RandomizeShop();
        RandomizeUnlocks();
        RandomizeCutscenes();
        //player_action
        //encounter
        //shop
        //level_up

        //BinaryFormatter bf = new BinaryFormatter();
        //System.IO.File.Delete("demo.bin");
        //using (var stream = File.OpenWrite("demo.bin"))
        //{
        //    var arr = new Validator[] { new Validator() { a = "blob" }, new Validator() { a = "blob" }, null };
        //    arr[2] = arr[1];
        //    bf.Serialize(stream, arr);
        //}

        //using (var stream = File.OpenRead("demo.bin"))
        //{
        //    var reader = new NRBFReader(stream);
        //    var result = (reader.Parse());
        //    Console.WriteLine(result);
        //    System.IO.File.Delete("demo_o.bin");
        //    using (var stream_o = File.OpenWrite("demo_o.bin"))
        //    {
        //        reader.WriteStream(stream_o);
        //    }
        //};

        //using (var stream = File.OpenRead("demo_o.bin"))
        //{
        //    var reader = new NRBFReader(stream);
        //    var result = (reader.Parse());
        //}

        //var file = "encounter";
        //var path = base_path + file + ".tbl";
        //var destination = dest_path + file + ".tbl";

        //using (var stream = File.OpenRead(path))
        //{
        //    var reader = new NRBFReader(stream);
        //    var result = (reader.Parse());
        //    Console.WriteLine(result);
        //    System.IO.File.Delete(destination);
        //    using (var stream_o = File.OpenWrite(destination))
        //    {
        //        reader.WriteStream(stream_o);
        //    }
        //};

        //using (var stream = File.OpenRead(destination))
        //{
        //    var reader = new NRBFReader(stream);
        //    var result = (reader.Parse());
        //}

    }
}
