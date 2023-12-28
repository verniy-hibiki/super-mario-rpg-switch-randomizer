// See https://aka.ms/new-console-template for more information


using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryFormatDataStructure;

namespace Randomizer
{
    class Program
    {
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
            public static string SHORT_TEXT = "SHORT_TEXT";
            public static string MONSTER_SKILL = "MONSTER_SKILL";
            public static string ZONES = "ZONES";
            public static string SURPRISE = "SURPRISE";
            public static string MONSTER_XP = "MONSTER_XP";
        }
        static readonly Dictionary<string, bool> modules = new()
        {
            { MODULES.INITIALIZE, false },
            { MODULES.SPECIALS, false },
            { MODULES.EQUIP, false },
            { MODULES.ITEMS, false },
            { MODULES.ITEMS_PRICE, false },
            { MODULES.TREASURE, false },
            { MODULES.LEVELUP, false },
            { MODULES.ENCOUNTER, false },
            { MODULES.SHOP, false },
            { MODULES.CUTSCENES_R, false },
            { MODULES.CUTSCENES_S, false },
            { MODULES.SHORT_TEXT, false },
            { MODULES.MONSTER_SKILL, false },
            { MODULES.ZONES, false },
            { MODULES.SURPRISE, false },
            { MODULES.MONSTER_XP, false },
        };
        static readonly Dictionary<string, TBLFile> files = new();
        static readonly Random r = new();
        static double danger = 1;
        static double danger_offset = +0.5;
        static readonly string base_path = @"romfs\Data\StreamingAssets\data_tbl\";
        static readonly string dest_path = @"outout\romfs\Data\StreamingAssets\data_tbl\";
        private static IEnumerable<int> all_items = new List<int>();
        private static readonly List<int> shop_items = new();
        private static readonly List<int> shop_weapons = new();
        private static readonly List<int>[] all_equipable = new List<int>[6]
        {
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>()
        };
        private static readonly List<int>[] all_skills = new List<int>[6]
       {
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>(),
        new List<int>()
       };
        private static readonly Dictionary<int, double> character_bonus =
        new Dictionary<int, double>(){
            { PLAYER.MARIO, 1 },
            { PLAYER.MALLOW, 2 },
            { PLAYER.BOWSER, 0.8 },
            { PLAYER.GENO, 1.5 },
            { PLAYER.PEACH, 2.5 }
        };
        public static double Random()
        {
            return r.NextDouble() * danger + danger_offset;
        }
        public static TBLFile RequestFile(string name)
        {
            if (files.ContainsKey(name))
            {
                return files[name];
            }
            var path = base_path + name + ".tbl";
            var destination = dest_path + name + ".tbl";
            using (var stream = File.OpenRead(path))
            {
                var reader = new NRBFReader(stream);
                var messages = ((Object[])reader.Parse());
                files[name] = new TBLFile()
                {
                    Content = messages,
                    Reader = reader,
                    Destination = destination
                };
            }
            return files[name];
        }
        public static void Watermark(string? language = null)
        {
            if (language == null)
            {
                Watermark("lang/menu_text_eng");
                Watermark("lang/menu_text_eng_us");
                Watermark("lang/menu_text_esp");
                return;
            }
            var file = RequestFile(language);

            foreach (var menu in file.Wrap<MenuTextData>())
            {
                var items = menu.m_data;
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        if ((item.m_id == 2706) && menu.m_file_id == "040_command_menu")
                        {
                            item.m_text = "Randomized Mario RPG by takstijn and friends";
                        }
                        if ((item.m_id == 2707) && menu.m_file_id == "040_command_menu")
                        {
                            item.m_text = "Randomized Mario RPG by takstijn and friends";
                        }
                        if ((item.m_id == 2715) && menu.m_file_id == "040_command_menu")
                        {
                            item.m_text = "New Randomized game";
                        }
                        if (item.m_text == "Save")
                        {
                            //int i = 0;
                        }
                        //
                    }
                }

            }

        }
        public static void ShortenLanguage(string? language = null)
        {
            if (!modules[MODULES.SHORT_TEXT]) return;
            if (language == null)
            {
                //ShortenLanguage("lang/message_eng");
                ShortenLanguage("lang/message_eng_us");
                //ShortenLanguage("lang/message_esp");
                return;
            }
            var file = RequestFile(language);

            static bool IsReplaceable(string str)
            {
                return str.All(x => char.IsLetter(x) || char.IsPunctuation(x) || char.IsWhiteSpace(x));
            }
            File.Delete("tr.txt");
            foreach (var charac in file.Wrap<MessageData>())
            {
                if (IsReplaceable(charac.m_text))
                    charac.m_text = "Tak";
                else //if (charac.m_text.Contains("party") || charac.m_text.Contains("joined"))
                {
                    var parsed = String.Join("", charac.m_text.Select(x =>
                    {
                        if (IsReplaceable(x + ""))
                            return x + "";
                        else
                            return "\\u" + ((int)x).ToString("X4");
                    }));
                    Console.WriteLine(parsed);
                    File.AppendAllLines("tr.txt", new string[] { parsed + " |||||" });
                }
            }
        }
        public static void RandomizeEncounter()
        {
            var file3 = RequestFile("encounter");
            var file2 = RequestFile("encounter_pattern");
            var file = RequestFile("monster");

            BinaryObject[] monsters_ori = file.WorkSet.Select(x => x.Clone()).ToArray();
            BinaryObject[] monsters = file.WorkSet.ToArray();
            BinaryObject[] encounters = file2.WorkSet.ToArray();
            BinaryObject[] encounters_meta = file3.WorkSet.ToArray();

            var event_battles = encounters_meta.Where(x => (bool)x["_is_event_battle"]).ToList();
            var non_randomizable_battles = event_battles.SelectMany(x => ((int[])x["_encount_ptn_id"])).Distinct().ToList();
            //var randomizable_montsters = encounters.Where(item => !non_randomizable_battles.Contains((int)item["_encount_pattern_id"]))
            //                                   .SelectMany(item => (int[])(int[])item["_monster_id"]).Distinct().ToList();
            var randomizable_montsters = monsters.Select(x => (int)x["_character_id"]).Where(x => x < 1500 && x != MONSTER.Dry_Bones).ToList();
            if(modules[MODULES.MONSTER_XP])
            {
                foreach(var mons in file.Wrap<MonsterData>())
                {
                    mons._exp = r.Next(1, 50);
                }
            }
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
                    var mon = new MonsterData(item);
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
                        item[stat] = Math.Max(1, (int)((int)item[stat] * (Random())));
                    }

                    //item["_can_escape"] = true;
                }
                var d = encounters_meta.Select(c => c["_can_escape"]).ToList();
                foreach (var item in encounters_meta)
                {
                    //item["_can_escape"] = true;
                }
                foreach (var item in encounters)
                {
                    if (non_randomizable_battles.Contains((int)item["_encount_pattern_id"])) continue;
                    var lst = (int[])item["_monster_id"];
                    for (var i = 0; i < lst.Length; i++)
                    {
                        if (lst[i] > 1001 && lst[i] < 1500)
                        {
                            var mon_id = lst[i];
                            //var idx = all_ids.IndexOf(mon_id);
                            //if (idx != -1)
                            //{
                            //    var new_id = shuffled_ids[idx];
                            //    lst[i] = new_id;
                            //}
                            while (lst[i] == mon_id)
                                lst[i] = all_ids.Where(x => x != lst[i] && x >= lst[i] - 40 && x <= lst[i] + 40).OrderBy(x => r.Next()).FirstOrDefault(lst[i]);
                        }
                    }
                }
            }
        }
        public static void RandomizeZones()
        {
            if (!modules[MODULES.ZONES]) return;
            /*var file = RequestFile("map_jump_list");
            var result = file.Wrap<MapJumpData>();
            var original = result.Select(x => new MapJumpData(x.data)).ToList();
            var indexes = result.Select((x, i) => i).OrderBy(x => r.Next()).ToList();

            for (var i = 0; i < result.Count; i++)
            {
                result[i].m_dst_exit_id = original[indexes[i]].m_dst_exit_id;
                result[i].m_dst_map_id = original[indexes[i]].m_dst_map_id;
            }*/
        }
        public static void RandomizeWineRiver()
        {
            //var file = RequestFile("wine_river");
            //var result = file.Wrap<WineRiverData>();

            //var x = result.Select(x => x._kind).Distinct();

            //var groups = result.GroupBy(x => x._kind).Select(x => new { key = x.Key, count= x.Count() });

            //foreach (var item in result)
            //{
            //    item._kind = 2;
            //}
        }
        public static void RandomizeCharacterInitialStats()
        {
            var file = RequestFile("player_initialize");

            var result = file.WorkSet;
            if (modules[MODULES.INITIALIZE])
            {
                Console.WriteLine("Randomizing players initial stats");
                foreach (var item in result)
                {
                    var character = new PlayerInitializeData(item);
                    //if (character._chara_id == 4) character._chara_id = 1;
                    //if (character._chara_id == 1) character._chara_id = 4;
                    var stats = new string[] { "_hp","_attack",
                        "_defence","_magic_attack","_magic_defence","_speeed"
                    };
                    foreach (var stat in stats)
                    {
                        item[stat] = Math.Max(1, (int)((int)item[stat] * (Random())));
                    }
                    var skills = (int[])item["_learned_skill_id"];

                    item["_armor"] = (int)(new int[] { 0, 0, 0, ITEM.Lazy_Shell_armor, ITEM.Lovely_Dress }.OrderBy(x => r.Next()).First());
                    item["_weapon"] = (int)(new int[] { 0, 0, 0, ITEM.Slap_Glove, ITEM.Lucky_Hammer }.OrderBy(x => r.Next()).First());

                    if (modules[MODULES.SPECIALS])
                    {
                        var learnableSkills = new int[] { /*0, 103, 109, 111, 115, 120,*/
                                0,0,0,0,0,
                               Randomizer.ACTIONS.Jump,
                               Randomizer.ACTIONS.HP_Rain,
                               Randomizer.ACTIONS.Therapy,
                               Randomizer.ACTIONS.Flame_Wall,
                               Randomizer.ACTIONS.Monster_Toss,
                               Randomizer.ACTIONS.Valor_Force,
                               Randomizer.ACTIONS.Mega_Recover,
                               Randomizer.ACTIONS.Geno_Beam,
                               Randomizer.ACTIONS.Group_Hug,};
                        var new_skiils = learnableSkills.OrderBy(x => r.Next()).Take(2).ToList();
                        skills[0] = new_skiils[0];
                        skills[1] = new_skiils[1];

                        all_skills[(int)item["_chara_id"]].AddRange(new_skiils);
                    }
                }

                //var item1 = result[1];
                //var item2 = result[2];
                //var item3 = result[3];
                //var item4 = result[4];
                //var item5 = result[5];
                //result[1] = item4;
                //result[2] = item5;
                //result[3] = item1;
                //result[4] = item2;
                //result[5] = item3;
            }

        }
        public static void RandomizeCharacterLevelUp()
        {
            //levelup_mario.tbl
            var skills = new List<int> {
                               Randomizer.ACTIONS.Jump,
                               Randomizer.ACTIONS.HP_Rain,
                               Randomizer.ACTIONS.Therapy,
                               Randomizer.ACTIONS.Flame_Wall,
                               Randomizer.ACTIONS.Monster_Toss,
                               Randomizer.ACTIONS.Valor_Force,
                               Randomizer.ACTIONS.Mega_Recover,
                               Randomizer.ACTIONS.Geno_Beam,
                               Randomizer.ACTIONS.Group_Hug,};

            ReadCharacterLevelUp("mario", all_skills[PLAYER.MARIO]);
            ReadCharacterLevelUp("mallow", all_skills[PLAYER.MALLOW]);
            ReadCharacterLevelUp("geno", all_skills[PLAYER.GENO]);
            ReadCharacterLevelUp("koopa", all_skills[PLAYER.BOWSER]);
            ReadCharacterLevelUp("peach", all_skills[PLAYER.PEACH]);

            skills.AddRange(all_skills[PLAYER.MARIO]);
            skills.AddRange(all_skills[PLAYER.MALLOW]);
            skills.AddRange(all_skills[PLAYER.GENO]);
            skills.AddRange(all_skills[PLAYER.BOWSER]);
            skills.AddRange(all_skills[PLAYER.PEACH]);

            skills = skills.Distinct().ToList();
            for (var i = 0; i < 20; i++)
                skills.Add(0);
            RandomizeCharacterLevelUp("mario", skills, PLAYER.MARIO);
            RandomizeCharacterLevelUp("mallow", skills, PLAYER.MALLOW);
            RandomizeCharacterLevelUp("geno", skills, PLAYER.GENO);
            RandomizeCharacterLevelUp("koopa", skills, PLAYER.BOWSER);
            RandomizeCharacterLevelUp("peach", skills, PLAYER.PEACH);
        }
        public static void RandomizeCharacterLevelUp(string character, List<int> learnableSkill, int player_id)
        {
            var file = RequestFile("/levelup_" + character);
            var result = file.WorkSet;
            if (modules[MODULES.LEVELUP])
            {
                BinaryObject? previous = null;
                Console.WriteLine("Randomizing players level up for " + character);
                foreach (var item in result.Skip(1))
                {
                    var stats = new string[] { "_hp", "_hp_bonus", "_attack", "_attack_bonus",
                        "_magic_attack","_magic_attack_bonus","_defence",
                        "_defence_bonus","_magic_defence","_magic_defence_bonus"
                    };
                    foreach (var stat in stats)
                    {
                        item[stat] = (int)((int)item[stat] * (Random()));
                        if (previous != null)
                        {
                            //Prevent too big of debuff
                            item[stat] = Math.Max((int)previous[stat] - 20, (int)item[stat]);
                        }
                        if(modules[MODULES.SURPRISE])
                        {
                            item[stat] = Math.Max(1, (int)(((int)item[stat])* character_bonus[player_id]));
                        }
                    }
                    if (modules[MODULES.SPECIALS])
                    {
                        if ((int)item["_learn_skill"] > 0)
                        {
                            var newSkill = learnableSkill.OrderBy(x => r.Next()).First();
                            item["_learn_skill"] = newSkill;
                            all_skills[player_id].Add(newSkill);
                        }
                    }
                    previous = item;
                }
            }


        }
        public static void ReadCharacterLevelUp(string character, List<int> learnableSkill)
        {
            var file = RequestFile("/levelup_" + character);
            var result = file.WorkSet;
            if (modules[MODULES.LEVELUP])
            {
                foreach (var item in result.Skip(1))
                {
                    learnableSkill.Add((int)item["_learn_skill"]);
                }
            }
        }
        public static void RandomizeItems()
        {
            var file = RequestFile("stella_item_list");
            var result = file.Wrap<ItemData>();
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
                items.Add(item._item_id);


                if (modules[MODULES.EQUIP])
                {
                    //_can_equip_mario,_can_equip_mallow,_can_equip_geno,_can_equip_kupper,_can_equip_peach
                    var _can_equip_mario = (bool)item._can_equip_mario;
                    var _can_equip_mallow = (bool)item._can_equip_mallow;
                    var _can_equip_geno = (bool)item._can_equip_geno;
                    var _can_equip_kupper = (bool)item._can_equip_kupper;
                    var _can_equip_peach = (bool)item._can_equip_peach;
                    var is_equipable = _can_equip_mario || _can_equip_mallow || _can_equip_geno || _can_equip_kupper || _can_equip_peach;
                    if (is_equipable)
                    {
                        var equipable = new bool[] { false, false, false, false, false };

                        while (!equipable.Any(x => x))
                            equipable = equipable.Select(x => r.NextDouble() > 0.5).ToArray();

                        item._can_equip_mario = (bool)equipable[0];
                        item._can_equip_mallow = (bool)equipable[1];
                        item._can_equip_geno = (bool)equipable[2];
                        item._can_equip_kupper = (bool)equipable[3];
                        item._can_equip_peach = (bool)equipable[4];
                    }
                    if ((int)item._equip_kind_id == 1)
                        shop_weapons.Add((int)item._item_id);
                }
                if (modules[MODULES.ITEMS_PRICE])
                {
                    item._buy_price = (int)((int)item._buy_price * (Random()));
                    //item["_buy_price"] = 1;
                    item._buy_price_alto = (int)((int)item._buy_price_alto * (Random()));
                    item._buy_price_tenor = (int)((int)item._buy_price_tenor * (Random()));
                    item._buy_price_soprano = (int)((int)item._buy_price_soprano * (Random()));
                    item._sell_price = (int)((int)item._sell_price * (Random()));
                    //item["_sell_price"] = 100;
                    item._kaeru_coin_price = (int)((int)item._kaeru_coin_price * (Random()));
                    item._point_buy_price = (int)((int)item._point_buy_price * (Random()));
                    item._point_sell_price = (int)((int)item._point_sell_price * (Random()));
                }
                if ((int)item._explain_id > 0 && (int)item._buy_price > 0)
                {
                    shop_items.Add((int)item._item_id);
                }
                if (modules[MODULES.ITEMS])
                {
                    foreach (var stat in new string[] { "_speed", "_attack", "_magic_attack", "_defense", "_magic_defense" })
                    {
                        var prev_value = (int)item.data[stat];
                        item.data[stat] = Math.Max(10, Math.Max(prev_value - 5, (int)(prev_value * (Random() + 0.25))));

                    }

                    item._possession_limit_easy = 100;// Math.Max(2, (int)((int)item["_possession_limit_easy"] * (Random())));
                    item._possession_limit_normal = 100;// Math.Max(2, (int)((int)item["_possession_limit_normal"] * (Random())));
                }
                if ((bool)item._can_equip_mario)
                    all_equipable[1].Add((int)item._item_id);
                if ((bool)item._can_equip_mario)
                    all_equipable[2].Add((int)item._item_id);
                if ((bool)item._can_equip_mario)
                    all_equipable[3].Add((int)item._item_id);
                if ((bool)item._can_equip_mario)
                    all_equipable[4].Add((int)item._item_id);
                if ((bool)item._can_equip_mario)
                    all_equipable[5].Add((int)item._item_id);
            }

        }
        public static void RandomizeShop(string? shop = null)
        {
            if (shop == null)
            {
                RandomizeShop("shop");
                RandomizeShop("frog_shop");
                RandomizeShop("pickup_shop");
                return;
            }
            var file = RequestFile(shop);
            var result = file.WorkSet;
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

        }

        public static void RandomizeUnlocks()
        {
            var file = RequestFile("event_status");
            var result = file.Wrap<EventStatusData>();
            var unlocks = result.Where(x => (int)x._party_num > 0).Distinct().ToArray();
            foreach (var item in result)
            {
                //_bounus_hp
                var bonus_hp = (bool[])item._bounus_hp;
                for (var i = 0; i < bonus_hp.Length; i++) bonus_hp[i] = true;
                var bonus_pow = (bool[])item._bounus_pow;
                for (var i = 0; i < bonus_pow.Length; i++) bonus_pow[i] = true;
                var bonus_s = (bool[])item._bounus_s;
                for (var i = 0; i < bonus_s.Length; i++) bonus_s[i] = true;

                //_coin
                //_frog_coin
                item._coin = r.Next(1, 50);
                item._frog_coin = r.Next(1, 50);

                Console.WriteLine(item._event_id + ":" + item._event_status + ":" + item._party_num + ":" + String.Join(",", item._chara_id));
                item._party_num = 5;
                item._chara_id[0] = 1;
                item._chara_id[1] = 2;
                item._chara_id[2] = 3;
                item._chara_id[3] = 4;
                item._chara_id[4] = 5;
            }
        }
        public static void RandomizeTreasure()
        {
            var file = RequestFile("treasure_box");
            var result = file.Wrap<TreasureHuntBoxData>();
            var possible_0_value = result.Where(x => (int)x._treasure_type == 0).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_1_value = result.Where(x => (int)x._treasure_type == 1).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_2_value = result.Where(x => (int)x._treasure_type == 2).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_3_value = result.Where(x => (int)x._treasure_type == 3).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_4_value = result.Where(x => (int)x._treasure_type == 4).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_5_value = result.Where(x => (int)x._treasure_type == 5).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_6_value = result.Where(x => (int)x._treasure_type == 6).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_7_value = result.Where(x => (int)x._treasure_type == 7).Select(x => (int)x._treasure_value).Distinct().ToArray();
            var possible_new_types = new int[] { 1, 2, 3, 7 };
            var possible_values = new[] { possible_0_value, all_items, possible_2_value, possible_3_value, possible_4_value, possible_5_value, possible_6_value, possible_7_value };
            var resetTypes = result.Select(x => x._reset_type).Distinct().ToList();
            if (modules[MODULES.TREASURE])
            {
                Console.WriteLine("Randomizing treasure boxes");
                foreach (var item in result)
                {
                    if (possible_new_types.Contains((int)item._treasure_type))
                    {
                        //If is not a special chest, then randomize it
                        item._reset_type = 1;
                        item._treasure_type = (int)possible_new_types[r.Next(possible_new_types.Length)];
                        item._treasure_value = (int)(possible_values[(int)item._treasure_type].OrderBy(x => r.Next()).First());
                    }
                    //_treasure_type
                    //_treasure_value
                    //_type {[_treasure_type, 
                }
            }
            //Console.WriteLine(string.Join(",", result.Select(x => x["_treasure_type"]).Distinct()));
            //Console.WriteLine(string.Join(",", result.Select(x => x["_treasure_value"]).Distinct()));
            //Console.WriteLine(string.Join(",", possible_0_value));
            ////treasure_type 1 would be an item?C:\Users\moysk\Desktop\__\t\BinaryFormatDataStructure\README.md
            //Console.WriteLine(string.Join(",", possible_1_value));
            ////tresure_type 2 would be coins?
            //Console.WriteLine(string.Join(",", possible_2_value));
            ////tresure_type 3 would be frog coins?
            //Console.WriteLine(string.Join(",", possible_3_value));
            //Console.WriteLine(string.Join(",", possible_4_value));
            //Console.WriteLine(string.Join(",", possible_5_value));
            //Console.WriteLine(string.Join(",", possible_6_value));
            ////tresure_type 7 would be another coins?
            //Console.WriteLine(string.Join(",", possible_7_value));
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

            if (args.Contains("-a"))
            {
                needManualConfirm = false;
                foreach (var key in modules.Keys)
                    modules[key] = true;
            }
            foreach (var arg in args)
            {
                if (arg.StartsWith("-d"))
                {
                    danger = double.Parse(arg[2..]);
                }
                if (arg.StartsWith("-do"))
                {
                    danger_offset = double.Parse(arg[3..]);
                }
            }
            foreach (var key in modules.Keys)
            {
                if (args.Contains(key))
                {
                    needManualConfirm = false;
                    modules[key] = true;
                }
                if (args.Contains("-" + key))
                {
                    needManualConfirm = false;
                    modules[key] = false;
                }
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
        public static void CreateMissingAnimations()
        {
            var file = RequestFile("battle_motion_player");
            var result = file.WorkSet;
            var _player_id = result.Select(x => (BinaryObject)x)
                .Select(x => (int)x["_player_id"]).Distinct();

            int add = 0;
            foreach (var player in new[] {
                PLAYER.MARIO, PLAYER.MALLOW, PLAYER.GENO,PLAYER.BOWSER, PLAYER.PEACH})
            {
                var animationForHammer = result.Select(x => (BinaryObject)x)
                   .Where(x => (int)x["_player_id"] == player && (int)x["_skill_id"] == 1 && (int)x["_weapon_id"] == 0).ToList();
                if (modules[MODULES.EQUIP])
                    foreach (var weapon in shop_weapons)
                    {
                        if (!result.Select(x => (BinaryObject)x).Any(x => (int)x["_player_id"] == player && (int)x["_weapon_id"] == weapon))
                            foreach (var animPart in animationForHammer.Select(x => x.Clone()))
                            {
                                animPart["_weapon_id"] = weapon;
                                result.Add(animPart);
                                file.Reader?.AddObject(animPart);
                                add++;
                            }
                    }
                var firstSkillForPlayer = (int)result.Select(x => (BinaryObject)x)
                  .Where(x => (int)x["_player_id"] == player && (int)x["_skill_id"] != 1 && (int)x["_weapon_id"] == 0).First()["_skill_id"];

                var firstAnimation = result.Select(x => (BinaryObject)x)
                  .Where(x => (int)x["_player_id"] == player && (int)x["_skill_id"] == firstSkillForPlayer && (int)x["_weapon_id"] == 0).ToList();
                if (modules[MODULES.SPECIALS])
                    foreach (var skillSet in all_skills)
                        foreach (var skill in skillSet)
                        //foreach (var skill in all_skills[player])
                        {
                            if (!result.Select(x => (BinaryObject)x).Any(x => (int)x["_player_id"] == player && (int)x["_skill_id"] == skill))
                                foreach (var animPart in firstAnimation.Select(x => x.Clone()))
                                {
                                    animPart["_skill_id"] = skill;
                                    result.Add(animPart);
                                    file.Reader?.AddObject(animPart);
                                    add++;
                                }
                        }
            }

        }
        public static void RandomizeMonsterAttacks()
        {
            if (!modules[MODULES.MONSTER_SKILL]) return;

            var monsters_file = RequestFile("monster");
            var monsters_ai_file = RequestFile("monster_ai");
            var motion_file = RequestFile("battle_motion_monster");
            var monsters = monsters_file.Wrap<MonsterData>();
            var monsters_ai = monsters_ai_file.Wrap<MonsterAITableData>();
            var motions = motion_file.Wrap<BattleMotionPlayerData>();

            foreach (var monster in monsters)
            {
                monster._fp = Math.Max(50, monster._fp);
            }
            foreach (var monster in monsters_ai)
            {
                if (monster._character_id >= 1000 && monster._character_id < 1500)//To avoid bosses
                {
                    var skills = monster._skill_id.Where(x => x > 1).ToList();//1 is melee
                    if (skills.Count > 0)
                    {
                        for (var i = 0; i < monster._skill_id.Length; i++)
                        {
                            if (monster._skill_id[i] > 0)
                            {
                                var newSkill = ACTIONS.Enemies.OrderBy(x => r.Next()).First();
                                monster._skill_id[i] = newSkill;

                                var firstSkillForPlayer = motions
                         .Where(x => (int)x._player_id == monster._character_id && (int)x._skill_id != 1 && (int)x._weapon_id == 0).FirstOrDefault()?._skill_id ?? 0;

                                var firstAnimation = motions
                          .Where(x => (int)x._player_id == monster._character_id && (int)x._skill_id == firstSkillForPlayer && (int)x._weapon_id == 0).ToList();

                                foreach (var animPart in firstAnimation.Select(x => x.data.Clone()))
                                {
                                    animPart["_skill_id"] = newSkill;
                                    motion_file.WorkSet.Add(animPart);
                                    motion_file.Reader?.AddObject(animPart);
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Test()
        {
            {
                var file_to_generate = RequestFile("effect_list");
                var bo = file_to_generate.WorkSet.FirstOrDefault(x => x != null);
                var clz = CreateWrapper(file_to_generate, bo.TypeName);
            }
            {
                var file_to_generate = RequestFile("inn");
                var bo = file_to_generate.WorkSet.FirstOrDefault(x => x != null);
                var clz = CreateWrapper(file_to_generate, bo.TypeName);
            }


            //foreach (var kv in files)
            //{
            //    var bo = kv.Value.WorkSet.FirstOrDefault(x => x != null);
            //    if(bo != null)
            //    {
            //        var clz = CreateWrapper(kv.Value,bo.TypeName);

            //        Console.WriteLine(clz);
            //    }    
            //}

            var file = RequestFile("treasure_disappear");
            //var bo = file.WorkSet.FirstOrDefault(x => x != null);
            //var clz = CreateWrapper(file, bo.TypeName);

            var data = file.Wrap<TreasureHuntDisappearData>().ToList();
            foreach (TreasureHuntDisappearData treasure in data)
            {
                if (treasure._kind_id == 1)
                {
                    int k = 3;
                }
                if (treasure._kind_id == 6 /*|| treasure._needs_any_script*/)
                    continue;
                treasure._needs_any_script = false;
                /**
                 * 1 = Coin
                 * 2 = frog coin
                 * 3 = mushroom
                 * 4 = flower tab
                 * 5 = an item, use _item_id to set 
                 * 6 = item + management + script? (Always item 87)
                 */
                treasure._kind_id = (new int[] { 1, 2, 3, 4, 5 }).OrderBy(x => r.Next()).First();
                //treasure._is_frog_coin = treasure._kind_id == 2;
                //treasure._is_mushroom = treasure._kind_id == 3;
                //treasure._is_flower = treasure._kind_id == 4;
                if (treasure._kind_id == 5)//An item
                {
                    treasure._item_id = all_items.OrderBy(x => r.Next()).First();
                }
                else
                {
                    treasure._item_id = 0;
                }
                if (treasure._kind_id == 1)//A coin
                {
                    treasure._coin = r.Next(0, 100);
                }
                else
                {
                    treasure._coin = 0;
                }
                //treasure._restoration = 1;


            }

            var file2 = RequestFile("treasure_box");
            var boxes = file2.Wrap<TreasureHuntBoxData>();

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
            System.IO.Directory.CreateDirectory(dest_path + "\\lang");
            System.IO.Directory.CreateDirectory(dest_path + "\\..\\movies\\");

            RandomizeItems();
            RandomizeCharacterInitialStats();
            RandomizeTreasure();
            RandomizeCharacterLevelUp();
            RandomizeEncounter();
            RandomizeShop();
            RandomizeUnlocks();
            RandomizeMonsterAttacks();
            RandomizeWineRiver();
            RandomizeZones();
            CreateMissingAnimations();

            //RandomizeCutscenes();

            ShortenLanguage();
            Watermark();

            //player_action
            //encounter
            //shop
            //level_up

            Test();

            foreach (var kv in files)
            {
                Console.WriteLine("Saving " + kv.Key);
                kv.Value.Save();
            }


        }

        public static string CreateWrapper(TBLFile file, string typeName)
        {
            List<string> subClasses = new();
            var str = "public class " + typeName + " { \r\n";
            str += "    readonly BinaryObject data;\r\n";
            str += "    public " + typeName + "(BinaryObject bo){\r\n";
            str += "        this.data = bo;\r\n";
            str += "    }\r\n";
            var classInfo = file.Reader.GetClassInfo(typeName);

            for (int i = 0; i < classInfo.ClassInfo.MemberCount; i++)
            {
                var memberName = classInfo.ClassInfo.MemberNames[i];
                var memberType = classInfo.MemberTypeInfo.BinaryType[i];
                var memberTypePrimitive = classInfo.MemberTypeInfo.AdditionalInfos[i];

                if (memberType == BinaryType.Primitive)
                {
                    str += "    public " + memberTypePrimitive + " " + memberName + " { get { return (" + memberTypePrimitive + ")data[\"" + memberName + "\"]; } set { data[\"" + memberName + "\"] = value;} }\r\n";
                }
                else if (memberType == BinaryType.PrimitiveArray)
                {
                    str += "    public " + memberTypePrimitive + "[] " + memberName + " { get { return (" + memberTypePrimitive + "[])data[\"" + memberName + "\"]; } set {  data[\"" + memberName + "\"] = value; } }\r\n";
                }
                else if (memberType == BinaryType.String)
                {
                    str += "    public string " + memberName + " { get { return ((BinaryObjectStringRecord)data[\"" + memberName + "\"]).Value; } set {  ((BinaryObjectStringRecord)data[\"" + memberName + "\"]).Value = value; } }\r\n";
                }
                else if (memberType == BinaryType.Class)
                {
                    ClassTypeInfo classTypeInfo = (ClassTypeInfo)memberTypePrimitive;
                    if (classTypeInfo.TypeName.Contains("[]"))
                    {
                        //Array
                        str += "    public " + classTypeInfo.TypeName + " " + memberName + " { get { return ((object[])data[\"" + memberName + "\"]).Select(x=> new " + classTypeInfo.TypeName + "((BinaryObject)x)).ToArray(); } } }\r\n";
                    }
                    else
                    {
                        str += "    public " + classTypeInfo.TypeName + " " + memberName + " { get { return new " + classTypeInfo.TypeName + "((BinaryObject)data[\"" + memberName + "\"]); } } }\r\n";
                    }
                    subClasses.Add(classTypeInfo.TypeName.Replace("[]", ""));
                }
                else
                {
                    int j = 05;
                }
            }
            str += "}\r\n";
            foreach (var clz in subClasses)
            {
                str += CreateWrapper(file, clz);
            }
            return str;
        }
    }
}