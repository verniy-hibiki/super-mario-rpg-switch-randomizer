using BinaryFormatDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS8603
    public class ItemData
    {
        public readonly BinaryObject data;
        public ItemData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _item_id { get { return (Int32)data["_item_id"]; } set { data["_item_id"] = value; } }
        public Int32 _kind_id { get { return (Int32)data["_kind_id"]; } set { data["_kind_id"] = value; } }
        public Int32 _equip_kind_id { get { return (Int32)data["_equip_kind_id"]; } set { data["_equip_kind_id"] = value; } }
        public Int32 _menu_icon_id { get { return (Int32)data["_menu_icon_id"]; } set { data["_menu_icon_id"] = value; } }
        public Boolean _can_equip_mario { get { return (Boolean)data["_can_equip_mario"]; } set { data["_can_equip_mario"] = value; } }
        public Boolean _can_equip_mallow { get { return (Boolean)data["_can_equip_mallow"]; } set { data["_can_equip_mallow"] = value; } }
        public Boolean _can_equip_geno { get { return (Boolean)data["_can_equip_geno"]; } set { data["_can_equip_geno"] = value; } }
        public Boolean _can_equip_kupper { get { return (Boolean)data["_can_equip_kupper"]; } set { data["_can_equip_kupper"] = value; } }
        public Boolean _can_equip_peach { get { return (Boolean)data["_can_equip_peach"]; } set { data["_can_equip_peach"] = value; } }
        public Int32 _buy_price { get { return (Int32)data["_buy_price"]; } set { data["_buy_price"] = value; } }
        public Int32 _buy_price_alto { get { return (Int32)data["_buy_price_alto"]; } set { data["_buy_price_alto"] = value; } }
        public Int32 _buy_price_tenor { get { return (Int32)data["_buy_price_tenor"]; } set { data["_buy_price_tenor"] = value; } }
        public Int32 _buy_price_soprano { get { return (Int32)data["_buy_price_soprano"]; } set { data["_buy_price_soprano"] = value; } }
        public Int32 _sell_price { get { return (Int32)data["_sell_price"]; } set { data["_sell_price"] = value; } }
        public Int32 _kaeru_coin_price { get { return (Int32)data["_kaeru_coin_price"]; } set { data["_kaeru_coin_price"] = value; } }
        public Int32 _point_buy_price { get { return (Int32)data["_point_buy_price"]; } set { data["_point_buy_price"] = value; } }
        public Int32 _point_sell_price { get { return (Int32)data["_point_sell_price"]; } set { data["_point_sell_price"] = value; } }
        public Int32 _speed { get { return (Int32)data["_speed"]; } set { data["_speed"] = value; } }
        public Int32 _attack { get { return (Int32)data["_attack"]; } set { data["_attack"] = value; } }
        public Int32 _defense { get { return (Int32)data["_defense"]; } set { data["_defense"] = value; } }
        public Int32 _magic_attack { get { return (Int32)data["_magic_attack"]; } set { data["_magic_attack"] = value; } }
        public Int32 _magic_defense { get { return (Int32)data["_magic_defense"]; } set { data["_magic_defense"] = value; } }
        public Boolean _is_lost_when_used { get { return (Boolean)data["_is_lost_when_used"]; } set { data["_is_lost_when_used"] = value; } }
        public Boolean _can_sell { get { return (Boolean)data["_can_sell"]; } set { data["_can_sell"] = value; } }
        public Boolean _can_throw_away { get { return (Boolean)data["_can_throw_away"]; } set { data["_can_throw_away"] = value; } }
        public Int32 _resist_element_per { get { return (Int32)data["_resist_element_per"]; } set { data["_resist_element_per"] = value; } }
        public Boolean _invalid_fear { get { return (Boolean)data["_invalid_fear"]; } set { data["_invalid_fear"] = value; } }
        public Boolean _invalid_poison { get { return (Boolean)data["_invalid_poison"]; } set { data["_invalid_poison"] = value; } }
        public Boolean _invalid_sleep { get { return (Boolean)data["_invalid_sleep"]; } set { data["_invalid_sleep"] = value; } }
        public Boolean _invalid_silent { get { return (Boolean)data["_invalid_silent"]; } set { data["_invalid_silent"] = value; } }
        public Boolean _invalid_mashroom { get { return (Boolean)data["_invalid_mashroom"]; } set { data["_invalid_mashroom"] = value; } }
        public Boolean _invalid_scarecrow { get { return (Boolean)data["_invalid_scarecrow"]; } set { data["_invalid_scarecrow"] = value; } }
        public Boolean _invalid_instant_death { get { return (Boolean)data["_invalid_instant_death"]; } set { data["_invalid_instant_death"] = value; } }
        public Int32 _motion_id { get { return (Int32)data["_motion_id"]; } set { data["_motion_id"] = value; } }
        public Int32 _model_id { get { return (Int32)data["_model_id"]; } set { data["_model_id"] = value; } }
        public Int32 _act_id { get { return (Int32)data["_act_id"]; } set { data["_act_id"] = value; } }
        public Int32 _explain_id { get { return (Int32)data["_explain_id"]; } set { data["_explain_id"] = value; } }
        public Int32 _original_order { get { return (Int32)data["_original_order"]; } set { data["_original_order"] = value; } }
        public Int32 _possession_limit_easy { get { return (Int32)data["_possession_limit_easy"]; } set { data["_possession_limit_easy"] = value; } }
        public Int32 _possession_limit_normal { get { return (Int32)data["_possession_limit_normal"]; } set { data["_possession_limit_normal"] = value; } }
    }

    public class PlayerInitializeData
    {
        readonly BinaryObject data;
        public PlayerInitializeData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _chara_id { get { return (Int32)data["_chara_id"]; } set { data["_chara_id"] = value; } }
        public Int32 _level { get { return (Int32)data["_level"]; } set { data["_level"] = value; } }
        public Int32 _hp { get { return (Int32)data["_hp"]; } set { data["_hp"] = value; } }
        public Int32 _attack { get { return (Int32)data["_attack"]; } set { data["_attack"] = value; } }
        public Int32 _defence { get { return (Int32)data["_defence"]; } set { data["_defence"] = value; } }
        public Int32 _magic_attack { get { return (Int32)data["_magic_attack"]; } set { data["_magic_attack"] = value; } }
        public Int32 _magic_defence { get { return (Int32)data["_magic_defence"]; } set { data["_magic_defence"] = value; } }
        public Int32 _speeed { get { return (Int32)data["_speeed"]; } set { data["_speeed"] = value; } }
        public Int32[] _learned_skill_id { get { return (Int32[])data["_learned_skill_id"]; } set { data["_learned_skill_id"] = value; } }
        public Int32 _weapon { get { return (Int32)data["_weapon"]; } set { data["_weapon"] = value; } }
        public Int32 _armor { get { return (Int32)data["_armor"]; } set { data["_armor"] = value; } }
        public Int32 _accessory { get { return (Int32)data["_accessory"]; } set { data["_accessory"] = value; } }
        public Int32 _exp { get { return (Int32)data["_exp"]; } set { data["_exp"] = value; } }
    }

    public class TreasureHuntBoxData
    {
        readonly BinaryObject data;
        public TreasureHuntBoxData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _id { get { return (Int32)data["_id"]; } set { data["_id"] = value; } }
        public Int32 _save_id { get { return (Int32)data["_save_id"]; } set { data["_save_id"] = value; } }
        public Int32 _type { get { return (Int32)data["_type"]; } set { data["_type"] = value; } }
        public Int32 _treasure_type { get { return (Int32)data["_treasure_type"]; } set { data["_treasure_type"] = value; } }
        public Int32 _treasure_value { get { return (Int32)data["_treasure_value"]; } set { data["_treasure_value"] = value; } }
        public Int32 _encounter_id { get { return (Int32)data["_encounter_id"]; } set { data["_encounter_id"] = value; } }
        public Int32 _reset_type { get { return (Int32)data["_reset_type"]; } set { data["_reset_type"] = value; } }
    }

    public class LevelUpData
    {
        readonly BinaryObject data;
        public LevelUpData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _level { get { return (Int32)data["_level"]; } set { data["_level"] = value; } }
        public Int32 _exp { get { return (Int32)data["_exp"]; } set { data["_exp"] = value; } }
        public Int32 _hp { get { return (Int32)data["_hp"]; } set { data["_hp"] = value; } }
        public Int32 _hp_bonus { get { return (Int32)data["_hp_bonus"]; } set { data["_hp_bonus"] = value; } }
        public Int32 _attack { get { return (Int32)data["_attack"]; } set { data["_attack"] = value; } }
        public Int32 _attack_bonus { get { return (Int32)data["_attack_bonus"]; } set { data["_attack_bonus"] = value; } }
        public Int32 _defence { get { return (Int32)data["_defence"]; } set { data["_defence"] = value; } }
        public Int32 _defence_bonus { get { return (Int32)data["_defence_bonus"]; } set { data["_defence_bonus"] = value; } }
        public Int32 _magic_attack { get { return (Int32)data["_magic_attack"]; } set { data["_magic_attack"] = value; } }
        public Int32 _magic_attack_bonus { get { return (Int32)data["_magic_attack_bonus"]; } set { data["_magic_attack_bonus"] = value; } }
        public Int32 _magic_defence { get { return (Int32)data["_magic_defence"]; } set { data["_magic_defence"] = value; } }
        public Int32 _magic_defence_bonus { get { return (Int32)data["_magic_defence_bonus"]; } set { data["_magic_defence_bonus"] = value; } }
        public Int32 _learn_skill { get { return (Int32)data["_learn_skill"]; } set { data["_learn_skill"] = value; } }
    }

    public class EncounterData
    {
        readonly BinaryObject data;
        public EncounterData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _encounter_id { get { return (Int32)data["_encounter_id"]; } set { data["_encounter_id"] = value; } }
        public Int32 _character_id { get { return (Int32)data["_character_id"]; } set { data["_character_id"] = value; } }
        public Int32 _floor_id { get { return (Int32)data["_floor_id"]; } set { data["_floor_id"] = value; } }
        public string _floor_cell_name { get { return ((BinaryObjectStringRecord)data["_floor_cell_name"])?.Value; } set { ((BinaryObjectStringRecord)data["_floor_cell_name"]).Value = value; } }
        public Int32 _battle_floor_id { get { return (Int32)data["_battle_floor_id"]; } set { data["_battle_floor_id"] = value; } }
        public Int32 _default_position_type { get { return (Int32)data["_default_position_type"]; } set { data["_default_position_type"] = value; } }
        public Boolean _can_escape { get { return (Boolean)data["_can_escape"]; } set { data["_can_escape"] = value; } }
        public Boolean _is_event_battle { get { return (Boolean)data["_is_event_battle"]; } set { data["_is_event_battle"] = value; } }
        public Int32 _replace_ptn_id { get { return (Int32)data["_replace_ptn_id"]; } set { data["_replace_ptn_id"] = value; } }
        public Int32[] _encount_ptn_ratio { get { return (Int32[])data["_encount_ptn_ratio"]; } set { data["_encount_ptn_ratio"] = value; } }
        public Int32[] _encount_ptn_id { get { return (Int32[])data["_encount_ptn_id"]; } set { data["_encount_ptn_id"] = value; } }
        public Int32 _bgm_id { get { return (Int32)data["_bgm_id"]; } set { data["_bgm_id"] = value; } }
    }

    public class EncountPatternData
    {
        readonly BinaryObject data;
        public EncountPatternData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _encount_pattern_id { get { return (Int32)data["_encount_pattern_id"]; } set { data["_encount_pattern_id"] = value; } }
        public Int32[] _monster_id { get { return (Int32[])data["_monster_id"]; } set { data["_monster_id"] = value; } }
        public Single[] _pos_x { get { return (Single[])data["_pos_x"]; } set { data["_pos_x"] = value; } }
        public Single[] _pos_y { get { return (Single[])data["_pos_y"]; } set { data["_pos_y"] = value; } }
        public Single[] _pos_z { get { return (Single[])data["_pos_z"]; } set { data["_pos_z"] = value; } }
        public Int32[] _cursor_order { get { return (Int32[])data["_cursor_order"]; } set { data["_cursor_order"] = value; } }
    }

    public class MonsterData
    {
        readonly BinaryObject data;
        public MonsterData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _monster_id { get { return (Int32)data["_monster_id"]; } set { data["_monster_id"] = value; } }
        public Int32 _character_id { get { return (Int32)data["_character_id"]; } set { data["_character_id"] = value; } }
        public Int32 _hp { get { return (Int32)data["_hp"]; } set { data["_hp"] = value; } }
        public Int32 _fp { get { return (Int32)data["_fp"]; } set { data["_fp"] = value; } }
        public Int32 _attack { get { return (Int32)data["_attack"]; } set { data["_attack"] = value; } }
        public Int32 _defense { get { return (Int32)data["_defense"]; } set { data["_defense"] = value; } }
        public Int32 _magic_attack { get { return (Int32)data["_magic_attack"]; } set { data["_magic_attack"] = value; } }
        public Int32 _magic_defense { get { return (Int32)data["_magic_defense"]; } set { data["_magic_defense"] = value; } }
        public Int32 _speed { get { return (Int32)data["_speed"]; } set { data["_speed"] = value; } }
        public Int32 _avoid { get { return (Int32)data["_avoid"]; } set { data["_avoid"] = value; } }
        public Int32 _resist_jump { get { return (Int32)data["_resist_jump"]; } set { data["_resist_jump"] = value; } }
        public Int32 _resist_fire { get { return (Int32)data["_resist_fire"]; } set { data["_resist_fire"] = value; } }
        public Int32 _resist_thunder { get { return (Int32)data["_resist_thunder"]; } set { data["_resist_thunder"] = value; } }
        public Int32 _resist_ice { get { return (Int32)data["_resist_ice"]; } set { data["_resist_ice"] = value; } }
        public Boolean _invalid_fear { get { return (Boolean)data["_invalid_fear"]; } set { data["_invalid_fear"] = value; } }
        public Boolean _invalid_poison { get { return (Boolean)data["_invalid_poison"]; } set { data["_invalid_poison"] = value; } }
        public Boolean _invalid_sleep { get { return (Boolean)data["_invalid_sleep"]; } set { data["_invalid_sleep"] = value; } }
        public Boolean _invalid_silent { get { return (Boolean)data["_invalid_silent"]; } set { data["_invalid_silent"] = value; } }
        public Int32 _resist_sheep { get { return (Int32)data["_resist_sheep"]; } set { data["_resist_sheep"] = value; } }
        public Boolean _invalid_geno_cutter { get { return (Boolean)data["_invalid_geno_cutter"]; } set { data["_invalid_geno_cutter"] = value; } }
        public Boolean _invalid_holy_water { get { return (Boolean)data["_invalid_holy_water"]; } set { data["_invalid_holy_water"] = value; } }
        public Boolean _invalid_yoshi_cookie { get { return (Boolean)data["_invalid_yoshi_cookie"]; } set { data["_invalid_yoshi_cookie"] = value; } }
        public Int32 _start_state { get { return (Int32)data["_start_state"]; } set { data["_start_state"] = value; } }
        public Int32 _exp { get { return (Int32)data["_exp"]; } set { data["_exp"] = value; } }
        public Int32 _coin { get { return (Int32)data["_coin"]; } set { data["_coin"] = value; } }
        public Boolean _is_drop_100per { get { return (Boolean)data["_is_drop_100per"]; } set { data["_is_drop_100per"] = value; } }
        public Int32 _drop_item_id_1 { get { return (Int32)data["_drop_item_id_1"]; } set { data["_drop_item_id_1"] = value; } }
        public Int32 _drop_item_id_2 { get { return (Int32)data["_drop_item_id_2"]; } set { data["_drop_item_id_2"] = value; } }
        public Int32 _drop_item_by_yoshi_cookie { get { return (Int32)data["_drop_item_by_yoshi_cookie"]; } set { data["_drop_item_by_yoshi_cookie"] = value; } }
        public Int32 _bonus_flower_id { get { return (Int32)data["_bonus_flower_id"]; } set { data["_bonus_flower_id"] = value; } }
        public Int32 _bonus_flower_persent { get { return (Int32)data["_bonus_flower_persent"]; } set { data["_bonus_flower_persent"] = value; } }
        public Int32 _appear_ptn_id { get { return (Int32)data["_appear_ptn_id"]; } set { data["_appear_ptn_id"] = value; } }
        public Int32 _escape_ptn_id { get { return (Int32)data["_escape_ptn_id"]; } set { data["_escape_ptn_id"] = value; } }
        public Single _collision_size_x { get { return (Single)data["_collision_size_x"]; } set { data["_collision_size_x"] = value; } }
        public Single _collision_size_y { get { return (Single)data["_collision_size_y"]; } set { data["_collision_size_y"] = value; } }
        public Single _collision_size_z { get { return (Single)data["_collision_size_z"]; } set { data["_collision_size_z"] = value; } }
        public Single _collision_offset_x { get { return (Single)data["_collision_offset_x"]; } set { data["_collision_offset_x"] = value; } }
        public Single _collision_offset_y { get { return (Single)data["_collision_offset_y"]; } set { data["_collision_offset_y"] = value; } }
        public Single _collision_offset_z { get { return (Single)data["_collision_offset_z"]; } set { data["_collision_offset_z"] = value; } }
        public Single _scale { get { return (Single)data["_scale"]; } set { data["_scale"] = value; } }
        public Int32 _nanikangaeteruno_id { get { return (Int32)data["_nanikangaeteruno_id"]; } set { data["_nanikangaeteruno_id"] = value; } }
        public Int32 _nanikangaeteruno_mess_num { get { return (Int32)data["_nanikangaeteruno_mess_num"]; } set { data["_nanikangaeteruno_mess_num"] = value; } }
        public Int32 _ryuuyou_chara_id { get { return (Int32)data["_ryuuyou_chara_id"]; } set { data["_ryuuyou_chara_id"] = value; } }
        public Int32 _cookie_hit_percent { get { return (Int32)data["_cookie_hit_percent"]; } set { data["_cookie_hit_percent"] = value; } }
        public Int32 _monster_book_sort_order { get { return (Int32)data["_monster_book_sort_order"]; } set { data["_monster_book_sort_order"] = value; } }
        public Int32 _monster_book_msg_id { get { return (Int32)data["_monster_book_msg_id"]; } set { data["_monster_book_msg_id"] = value; } }
        public Int32 _monster_book_area_id { get { return (Int32)data["_monster_book_area_id"]; } set { data["_monster_book_area_id"] = value; } }
        public Int32 _monster_book_fixed_position { get { return (Int32)data["_monster_book_fixed_position"]; } set { data["_monster_book_fixed_position"] = value; } }
        public Int32 _monster_book_encounter_id { get { return (Int32)data["_monster_book_encounter_id"]; } set { data["_monster_book_encounter_id"] = value; } }
        public Int32 _monster_book_encount_pattern_id { get { return (Int32)data["_monster_book_encount_pattern_id"]; } set { data["_monster_book_encount_pattern_id"] = value; } }
        public Int32 _monster_book_multiple_display { get { return (Int32)data["_monster_book_multiple_display"]; } set { data["_monster_book_multiple_display"] = value; } }
        public Int32 _monster_book_camera_pattern { get { return (Int32)data["_monster_book_camera_pattern"]; } set { data["_monster_book_camera_pattern"] = value; } }
        public Single _monster_book_pos_move_x { get { return (Single)data["_monster_book_pos_move_x"]; } set { data["_monster_book_pos_move_x"] = value; } }
        public Single _monster_book_pos_move_z { get { return (Single)data["_monster_book_pos_move_z"]; } set { data["_monster_book_pos_move_z"] = value; } }
        public Boolean _dying_disp { get { return (Boolean)data["_dying_disp"]; } set { data["_dying_disp"] = value; } }
    }

    public class ShopData
    {
        readonly BinaryObject data;
        public ShopData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _shop_id { get { return (Int32)data["_shop_id"]; } set { data["_shop_id"] = value; } }
        public Boolean _is_kino_shop { get { return (Boolean)data["_is_kino_shop"]; } set { data["_is_kino_shop"] = value; } }
        public Boolean _is_drink_shop { get { return (Boolean)data["_is_drink_shop"]; } set { data["_is_drink_shop"] = value; } }
        public Int32 _area_id { get { return (Int32)data["_area_id"]; } set { data["_area_id"] = value; } }
        public Int32[] _item_id { get { return (Int32[])data["_item_id"]; } set { data["_item_id"] = value; } }
        public Int32 _shop_name_id { get { return (Int32)data["_shop_name_id"]; } set { data["_shop_name_id"] = value; } }
    }

    public class FrogShopData
    {
        readonly BinaryObject data;
        public FrogShopData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _shop_id { get { return (Int32)data["_shop_id"]; } set { data["_shop_id"] = value; } }
        public Int32 _area_id { get { return (Int32)data["_area_id"]; } set { data["_area_id"] = value; } }
        public Int32[] _item_id { get { return (Int32[])data["_item_id"]; } set { data["_item_id"] = value; } }
        public Int32 _shop_name_id { get { return (Int32)data["_shop_name_id"]; } set { data["_shop_name_id"] = value; } }
    }

    public class PickUpShopData
    {
        readonly BinaryObject data;
        public PickUpShopData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _shop_id { get { return (Int32)data["_shop_id"]; } set { data["_shop_id"] = value; } }
        public Int32 _area_id { get { return (Int32)data["_area_id"]; } set { data["_area_id"] = value; } }
        public Int32[] _item_id { get { return (Int32[])data["_item_id"]; } set { data["_item_id"] = value; } }
        public Int32 _shop_name_id { get { return (Int32)data["_shop_name_id"]; } set { data["_shop_name_id"] = value; } }
    }

    public class EventStatusData
    {
        readonly BinaryObject data;
        public EventStatusData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _event_id { get { return (Int32)data["_event_id"]; } set { data["_event_id"] = value; } }
        public string _event_status { get { return ((BinaryObjectStringRecord)data["_event_status"])?.Value; } set { ((BinaryObjectStringRecord)data["_event_status"]).Value = value; } }
        public string _section { get { return ((BinaryObjectStringRecord)data["_section"])?.Value; } set { ((BinaryObjectStringRecord)data["_section"]).Value = value; } }
        public Int32 _floor_id { get { return (Int32)data["_floor_id"]; } set { data["_floor_id"] = value; } }
        public Int32 _coin { get { return (Int32)data["_coin"]; } set { data["_coin"] = value; } }
        public Int32 _frog_coin { get { return (Int32)data["_frog_coin"]; } set { data["_frog_coin"] = value; } }
        public Int32 _party_num { get { return (Int32)data["_party_num"]; } set { data["_party_num"] = value; } }
        public Int32[] _chara_id { get { return (Int32[])data["_chara_id"]; } set { data["_chara_id"] = value; } }
        public Int32[] _chara_lv { get { return (Int32[])data["_chara_lv"]; } set { data["_chara_lv"] = value; } }
        public Boolean[] _bounus_pow { get { return (Boolean[])data["_bounus_pow"]; } set { data["_bounus_pow"] = value; } }
        public Boolean[] _bounus_hp { get { return (Boolean[])data["_bounus_hp"]; } set { data["_bounus_hp"] = value; } }
        public Boolean[] _bounus_s { get { return (Boolean[])data["_bounus_s"]; } set { data["_bounus_s"] = value; } }
        public Int32[] _weapon_id { get { return (Int32[])data["_weapon_id"]; } set { data["_weapon_id"] = value; } }
        public Int32[] _armor_id { get { return (Int32[])data["_armor_id"]; } set { data["_armor_id"] = value; } }
        public Int32[] _accessory_id { get { return (Int32[])data["_accessory_id"]; } set { data["_accessory_id"] = value; } }
    }

    public class BattleMotionPlayerData
    {
        public readonly BinaryObject data;
        public BattleMotionPlayerData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _player_id { get { return (Int32)data["_player_id"]; } set { data["_player_id"] = value; } }
        public Int32 _skill_id { get { return (Int32)data["_skill_id"]; } set { data["_skill_id"] = value; } }
        public Int32 _weapon_id { get { return (Int32)data["_weapon_id"]; } set { data["_weapon_id"] = value; } }
        public Int32 _exec_condition { get { return (Int32)data["_exec_condition"]; } set { data["_exec_condition"] = value; } }
        public Int32 _exec_condition_param { get { return (Int32)data["_exec_condition_param"]; } set { data["_exec_condition_param"] = value; } }
        public Int32 _proceed_condition { get { return (Int32)data["_proceed_condition"]; } set { data["_proceed_condition"] = value; } }
        public Int32 _proceed_condition_param { get { return (Int32)data["_proceed_condition_param"]; } set { data["_proceed_condition_param"] = value; } }
        public Int32 _total_frame { get { return (Int32)data["_total_frame"]; } set { data["_total_frame"] = value; } }
        public Int32 _internal_processing { get { return (Int32)data["_internal_processing"]; } set { data["_internal_processing"] = value; } }
        public Int32 _loop_condition { get { return (Int32)data["_loop_condition"]; } set { data["_loop_condition"] = value; } }
        public Int32 _loop_back_index { get { return (Int32)data["_loop_back_index"]; } set { data["_loop_back_index"] = value; } }
        public Int32 _loop_limit { get { return (Int32)data["_loop_limit"]; } set { data["_loop_limit"] = value; } }
        public Int32 _interrept_anim_id { get { return (Int32)data["_interrept_anim_id"]; } set { data["_interrept_anim_id"] = value; } }
        public Int32 _move_chara { get { return (Int32)data["_move_chara"]; } set { data["_move_chara"] = value; } }
        public Int32 _move_chara_index { get { return (Int32)data["_move_chara_index"]; } set { data["_move_chara_index"] = value; } }
        public string _move_chara_parent { get { return ((BinaryObjectStringRecord)data["_move_chara_parent"])?.Value; } set { ((BinaryObjectStringRecord)data["_move_chara_parent"]).Value = value; } }
        public Int32 _anim_set { get { return (Int32)data["_anim_set"]; } set { data["_anim_set"] = value; } }
        public Int32 _move_route { get { return (Int32)data["_move_route"]; } set { data["_move_route"] = value; } }
        public Int32 _move_route_index { get { return (Int32)data["_move_route_index"]; } set { data["_move_route_index"] = value; } }
        public Int32 _chara_height_decision_method { get { return (Int32)data["_chara_height_decision_method"]; } set { data["_chara_height_decision_method"] = value; } }
        public Single _move_pos_x { get { return (Single)data["_move_pos_x"]; } set { data["_move_pos_x"] = value; } }
        public Single _move_pos_y { get { return (Single)data["_move_pos_y"]; } set { data["_move_pos_y"] = value; } }
        public Single _move_pos_z { get { return (Single)data["_move_pos_z"]; } set { data["_move_pos_z"] = value; } }
        public Int32 _chara_move_condition { get { return (Int32)data["_chara_move_condition"]; } set { data["_chara_move_condition"] = value; } }
        public Int32 _move_stert_frame { get { return (Int32)data["_move_stert_frame"]; } set { data["_move_stert_frame"] = value; } }
        public Int32 _move_frame { get { return (Int32)data["_move_frame"]; } set { data["_move_frame"] = value; } }
        public Single _move_speed { get { return (Single)data["_move_speed"]; } set { data["_move_speed"] = value; } }
        public Int32 _move_pattern { get { return (Int32)data["_move_pattern"]; } set { data["_move_pattern"] = value; } }
        public Single _chara_jump_height { get { return (Single)data["_chara_jump_height"]; } set { data["_chara_jump_height"] = value; } }
        public Single _chara_wave_num { get { return (Single)data["_chara_wave_num"]; } set { data["_chara_wave_num"] = value; } }
        public Int32 _chara_rotate_condition { get { return (Int32)data["_chara_rotate_condition"]; } set { data["_chara_rotate_condition"] = value; } }
        public Int32 _chara_rotate_method { get { return (Int32)data["_chara_rotate_method"]; } set { data["_chara_rotate_method"] = value; } }
        public Int32 _chara_rotate_direction { get { return (Int32)data["_chara_rotate_direction"]; } set { data["_chara_rotate_direction"] = value; } }
        public Single _chara_rotate_angle { get { return (Single)data["_chara_rotate_angle"]; } set { data["_chara_rotate_angle"] = value; } }
        public Int32 _chara_rotate_frame { get { return (Int32)data["_chara_rotate_frame"]; } set { data["_chara_rotate_frame"] = value; } }
        public Int32 _chara_rotate_start_frame { get { return (Int32)data["_chara_rotate_start_frame"]; } set { data["_chara_rotate_start_frame"] = value; } }
        public Int32 _motion_play_condition { get { return (Int32)data["_motion_play_condition"]; } set { data["_motion_play_condition"] = value; } }
        public Int32 _motion_id { get { return (Int32)data["_motion_id"]; } set { data["_motion_id"] = value; } }
        public Int32 _motion_id2 { get { return (Int32)data["_motion_id2"]; } set { data["_motion_id2"] = value; } }
        public Int32 _motion_id3 { get { return (Int32)data["_motion_id3"]; } set { data["_motion_id3"] = value; } }
        public Int32 _motion_blend_frame { get { return (Int32)data["_motion_blend_frame"]; } set { data["_motion_blend_frame"] = value; } }
        public Int32 _motion_disp_pattern { get { return (Int32)data["_motion_disp_pattern"]; } set { data["_motion_disp_pattern"] = value; } }
        public Int32 _actor_disp { get { return (Int32)data["_actor_disp"]; } set { data["_actor_disp"] = value; } }
        public Int32 _actor_afterimage_lifespan { get { return (Int32)data["_actor_afterimage_lifespan"]; } set { data["_actor_afterimage_lifespan"] = value; } }
        public Int32 _actor_afterimage_param_index { get { return (Int32)data["_actor_afterimage_param_index"]; } set { data["_actor_afterimage_param_index"] = value; } }
        public Int32 _move_chara_rotate_component_condition { get { return (Int32)data["_move_chara_rotate_component_condition"]; } set { data["_move_chara_rotate_component_condition"] = value; } }
        public Int32 _move_chara_rotate_component { get { return (Int32)data["_move_chara_rotate_component"]; } set { data["_move_chara_rotate_component"] = value; } }
        public Int32 _move_chara_rotate_component_start_frame { get { return (Int32)data["_move_chara_rotate_component_start_frame"]; } set { data["_move_chara_rotate_component_start_frame"] = value; } }
        public Int32 _move_chara_rotate_component_frame { get { return (Int32)data["_move_chara_rotate_component_frame"]; } set { data["_move_chara_rotate_component_frame"] = value; } }
        public Int32 _hit_condition { get { return (Int32)data["_hit_condition"]; } set { data["_hit_condition"] = value; } }
        public Int32 _hit_target { get { return (Int32)data["_hit_target"]; } set { data["_hit_target"] = value; } }
        public Int32 _hit_frame { get { return (Int32)data["_hit_frame"]; } set { data["_hit_frame"] = value; } }
        public Int32 _hit_offset_frame { get { return (Int32)data["_hit_offset_frame"]; } set { data["_hit_offset_frame"] = value; } }
        public Int32 _hit_motion_id { get { return (Int32)data["_hit_motion_id"]; } set { data["_hit_motion_id"] = value; } }
        public Int32 _hit_effect_id { get { return (Int32)data["_hit_effect_id"]; } set { data["_hit_effect_id"] = value; } }
        public Int32 _hit_se_id { get { return (Int32)data["_hit_se_id"]; } set { data["_hit_se_id"] = value; } }
        public Int32 _damage_value_disp_condition { get { return (Int32)data["_damage_value_disp_condition"]; } set { data["_damage_value_disp_condition"] = value; } }
        public Int32 _bad_status_change_condition { get { return (Int32)data["_bad_status_change_condition"]; } set { data["_bad_status_change_condition"] = value; } }
        public Int32 _dead_anim_condition { get { return (Int32)data["_dead_anim_condition"]; } set { data["_dead_anim_condition"] = value; } }
        public Int32 _zako_dead_motion_id { get { return (Int32)data["_zako_dead_motion_id"]; } set { data["_zako_dead_motion_id"] = value; } }
        public Int32 _zako_dead_effect_id { get { return (Int32)data["_zako_dead_effect_id"]; } set { data["_zako_dead_effect_id"] = value; } }
        public Int32 _action_command_input { get { return (Int32)data["_action_command_input"]; } set { data["_action_command_input"] = value; } }
        public Int32 _action_command_max_num { get { return (Int32)data["_action_command_max_num"]; } set { data["_action_command_max_num"] = value; } }
        public Int32 _input_start_frame { get { return (Int32)data["_input_start_frame"]; } set { data["_input_start_frame"] = value; } }
        public Int32 _input_period { get { return (Int32)data["_input_period"]; } set { data["_input_period"] = value; } }
        public Int32 _sweetspot_input_start_frame { get { return (Int32)data["_sweetspot_input_start_frame"]; } set { data["_sweetspot_input_start_frame"] = value; } }
        public Int32 _sweetspot_input_period { get { return (Int32)data["_sweetspot_input_period"]; } set { data["_sweetspot_input_period"] = value; } }
        public Int32 _is_message { get { return (Int32)data["_is_message"]; } set { data["_is_message"] = value; } }
        public Int32 _message_id { get { return (Int32)data["_message_id"]; } set { data["_message_id"] = value; } }
        public Int32 _message_num { get { return (Int32)data["_message_num"]; } set { data["_message_num"] = value; } }
        public Int32 _message_disp_method { get { return (Int32)data["_message_disp_method"]; } set { data["_message_disp_method"] = value; } }
        public string _message_disp_position { get { return ((BinaryObjectStringRecord)data["_message_disp_position"])?.Value; } set { ((BinaryObjectStringRecord)data["_message_disp_position"]).Value = value; } }
        public Int32 _message_disp_position_index { get { return (Int32)data["_message_disp_position_index"]; } set { data["_message_disp_position_index"] = value; } }
        public Int32 _chara_color_id { get { return (Int32)data["_chara_color_id"]; } set { data["_chara_color_id"] = value; } }
        public Int32 _screen_color_change { get { return (Int32)data["_screen_color_change"]; } set { data["_screen_color_change"] = value; } }
        public Int32 _screen_color_frame { get { return (Int32)data["_screen_color_frame"]; } set { data["_screen_color_frame"] = value; } }
        public Int32 _is_screen_color_action_command_link { get { return (Int32)data["_is_screen_color_action_command_link"]; } set { data["_is_screen_color_action_command_link"] = value; } }
        public Single _screen_color_r { get { return (Single)data["_screen_color_r"]; } set { data["_screen_color_r"] = value; } }
        public Single _screen_color_g { get { return (Single)data["_screen_color_g"]; } set { data["_screen_color_g"] = value; } }
        public Single _screen_color_b { get { return (Single)data["_screen_color_b"]; } set { data["_screen_color_b"] = value; } }
        public Single _screen_color_a { get { return (Single)data["_screen_color_a"]; } set { data["_screen_color_a"] = value; } }
        public Int32 _screen_color_vertex_color { get { return (Int32)data["_screen_color_vertex_color"]; } set { data["_screen_color_vertex_color"] = value; } }
        public Int32 _is_exclude_character_from_screen_color { get { return (Int32)data["_is_exclude_character_from_screen_color"]; } set { data["_is_exclude_character_from_screen_color"] = value; } }
        public Int32 _special_effect { get { return (Int32)data["_special_effect"]; } set { data["_special_effect"] = value; } }
        public Int32 _effect_id { get { return (Int32)data["_effect_id"]; } set { data["_effect_id"] = value; } }
        public string _effect_parent { get { return ((BinaryObjectStringRecord)data["_effect_parent"])?.Value; } set { ((BinaryObjectStringRecord)data["_effect_parent"]).Value = value; } }
        public Int32 _effect_disp_condition { get { return (Int32)data["_effect_disp_condition"]; } set { data["_effect_disp_condition"] = value; } }
        public Int32 _effect_disp_start_frame { get { return (Int32)data["_effect_disp_start_frame"]; } set { data["_effect_disp_start_frame"] = value; } }
        public Int32 _effect_unit_id { get { return (Int32)data["_effect_unit_id"]; } set { data["_effect_unit_id"] = value; } }
        public Int32 _effect_is_anim_change { get { return (Int32)data["_effect_is_anim_change"]; } set { data["_effect_is_anim_change"] = value; } }
        public Int32 _effect_change_anim_id { get { return (Int32)data["_effect_change_anim_id"]; } set { data["_effect_change_anim_id"] = value; } }
        public Int32 _effect_anim_blend_frame { get { return (Int32)data["_effect_anim_blend_frame"]; } set { data["_effect_anim_blend_frame"] = value; } }
        public Int32 _effect_anim_speed_setting { get { return (Int32)data["_effect_anim_speed_setting"]; } set { data["_effect_anim_speed_setting"] = value; } }
        public Int32 _effect_anim_end_frame { get { return (Int32)data["_effect_anim_end_frame"]; } set { data["_effect_anim_end_frame"] = value; } }
        public Int32 _effect_anim_action_command_link { get { return (Int32)data["_effect_anim_action_command_link"]; } set { data["_effect_anim_action_command_link"] = value; } }
        public Int32 _effect_move_start_frame { get { return (Int32)data["_effect_move_start_frame"]; } set { data["_effect_move_start_frame"] = value; } }
        public Int32 _effect_move_frame_decide_method { get { return (Int32)data["_effect_move_frame_decide_method"]; } set { data["_effect_move_frame_decide_method"] = value; } }
        public Int32 _effect_move_frame { get { return (Int32)data["_effect_move_frame"]; } set { data["_effect_move_frame"] = value; } }
        public Single _effect_move_speed { get { return (Single)data["_effect_move_speed"]; } set { data["_effect_move_speed"] = value; } }
        public string _effect_life_span_scale_particle_name { get { return ((BinaryObjectStringRecord)data["_effect_life_span_scale_particle_name"])?.Value; } set { ((BinaryObjectStringRecord)data["_effect_life_span_scale_particle_name"]).Value = value; } }
        public Int32 _effect_move_pattern { get { return (Int32)data["_effect_move_pattern"]; } set { data["_effect_move_pattern"] = value; } }
        public Single _effect_jump_height { get { return (Single)data["_effect_jump_height"]; } set { data["_effect_jump_height"] = value; } }
        public Single _effect_bound_ratio { get { return (Single)data["_effect_bound_ratio"]; } set { data["_effect_bound_ratio"] = value; } }
        public Int32 _effect_wave_num { get { return (Int32)data["_effect_wave_num"]; } set { data["_effect_wave_num"] = value; } }
        public string _effect_disp_start { get { return ((BinaryObjectStringRecord)data["_effect_disp_start"])?.Value; } set { ((BinaryObjectStringRecord)data["_effect_disp_start"]).Value = value; } }
        public string _effect_rotation_start { get { return ((BinaryObjectStringRecord)data["_effect_rotation_start"])?.Value; } set { ((BinaryObjectStringRecord)data["_effect_rotation_start"]).Value = value; } }
        public string _effect_disp_end { get { return ((BinaryObjectStringRecord)data["_effect_disp_end"])?.Value; } set { ((BinaryObjectStringRecord)data["_effect_disp_end"]).Value = value; } }
        public Int32 _effect_disp_start_index { get { return (Int32)data["_effect_disp_start_index"]; } set { data["_effect_disp_start_index"] = value; } }
        public Int32 _effect_disp_end_index { get { return (Int32)data["_effect_disp_end_index"]; } set { data["_effect_disp_end_index"] = value; } }
        public Int32 _is_effect_disp_target_num { get { return (Int32)data["_is_effect_disp_target_num"]; } set { data["_is_effect_disp_target_num"] = value; } }
        public Int32 _effect_disp_target_num_frame_interval { get { return (Int32)data["_effect_disp_target_num_frame_interval"]; } set { data["_effect_disp_target_num_frame_interval"] = value; } }
        public Int32 _effect_disp_target_num_order { get { return (Int32)data["_effect_disp_target_num_order"]; } set { data["_effect_disp_target_num_order"] = value; } }
        public Single _effect_disp_start_offset_x { get { return (Single)data["_effect_disp_start_offset_x"]; } set { data["_effect_disp_start_offset_x"] = value; } }
        public Single _effect_disp_start_offset_y { get { return (Single)data["_effect_disp_start_offset_y"]; } set { data["_effect_disp_start_offset_y"] = value; } }
        public Single _effect_disp_start_offset_z { get { return (Single)data["_effect_disp_start_offset_z"]; } set { data["_effect_disp_start_offset_z"] = value; } }
        public Single _effect_disp_end_offset_x { get { return (Single)data["_effect_disp_end_offset_x"]; } set { data["_effect_disp_end_offset_x"] = value; } }
        public Single _effect_disp_end_offset_y { get { return (Single)data["_effect_disp_end_offset_y"]; } set { data["_effect_disp_end_offset_y"] = value; } }
        public Single _effect_disp_end_offset_z { get { return (Single)data["_effect_disp_end_offset_z"]; } set { data["_effect_disp_end_offset_z"] = value; } }
        public Single _effect_end_pos_ratio { get { return (Single)data["_effect_end_pos_ratio"]; } set { data["_effect_end_pos_ratio"] = value; } }
        public Int32 _is_effect_end_pos_height_directly_set { get { return (Int32)data["_is_effect_end_pos_height_directly_set"]; } set { data["_is_effect_end_pos_height_directly_set"] = value; } }
        public Single _effect_end_pos_final_height { get { return (Single)data["_effect_end_pos_final_height"]; } set { data["_effect_end_pos_final_height"] = value; } }
        public Single _effect_distance_from_camera { get { return (Single)data["_effect_distance_from_camera"]; } set { data["_effect_distance_from_camera"] = value; } }
        public Single _effect_scale { get { return (Single)data["_effect_scale"]; } set { data["_effect_scale"] = value; } }
        public Int32 _effect_rotate_method { get { return (Int32)data["_effect_rotate_method"]; } set { data["_effect_rotate_method"] = value; } }
        public Int32 _effect_rotate_direction { get { return (Int32)data["_effect_rotate_direction"]; } set { data["_effect_rotate_direction"] = value; } }
        public Int32 _effect_rotate_angle { get { return (Int32)data["_effect_rotate_angle"]; } set { data["_effect_rotate_angle"] = value; } }
        public Int32 _effect_rotate_frame { get { return (Int32)data["_effect_rotate_frame"]; } set { data["_effect_rotate_frame"] = value; } }
        public Int32 _effect_rotate_start_frame { get { return (Int32)data["_effect_rotate_start_frame"]; } set { data["_effect_rotate_start_frame"] = value; } }
        public Int32 _effect_afterimage_lifespan { get { return (Int32)data["_effect_afterimage_lifespan"]; } set { data["_effect_afterimage_lifespan"] = value; } }
        public Int32 _effect_afterimage_param_index { get { return (Int32)data["_effect_afterimage_param_index"]; } set { data["_effect_afterimage_param_index"] = value; } }
        public Int32 _effect_change_id { get { return (Int32)data["_effect_change_id"]; } set { data["_effect_change_id"] = value; } }
        public Int32 _effect_change_frame { get { return (Int32)data["_effect_change_frame"]; } set { data["_effect_change_frame"] = value; } }
        public Int32 _effect_end_condition { get { return (Int32)data["_effect_end_condition"]; } set { data["_effect_end_condition"] = value; } }
        public Int32 _effect_total_frame { get { return (Int32)data["_effect_total_frame"]; } set { data["_effect_total_frame"] = value; } }
        public Int32 _camera_id { get { return (Int32)data["_camera_id"]; } set { data["_camera_id"] = value; } }
        public Int32 _camera_start_frame { get { return (Int32)data["_camera_start_frame"]; } set { data["_camera_start_frame"] = value; } }
        public Int32 _camera_effect { get { return (Int32)data["_camera_effect"]; } set { data["_camera_effect"] = value; } }
        public Int32 _camera_effect_frame { get { return (Int32)data["_camera_effect_frame"]; } set { data["_camera_effect_frame"] = value; } }
        public Single _camera_effect_shake_max_range { get { return (Single)data["_camera_effect_shake_max_range"]; } set { data["_camera_effect_shake_max_range"] = value; } }
        public Int32 _camera_effect_shake_half_period { get { return (Int32)data["_camera_effect_shake_half_period"]; } set { data["_camera_effect_shake_half_period"] = value; } }
        public Int32 _camera_move_condition { get { return (Int32)data["_camera_move_condition"]; } set { data["_camera_move_condition"] = value; } }
        public Int32 _camera_move_start_frame { get { return (Int32)data["_camera_move_start_frame"]; } set { data["_camera_move_start_frame"] = value; } }
        public Int32 _camera_move_frame { get { return (Int32)data["_camera_move_frame"]; } set { data["_camera_move_frame"] = value; } }
        public Int32 _camera_look_at_position { get { return (Int32)data["_camera_look_at_position"]; } set { data["_camera_look_at_position"] = value; } }
        public Single _camera_look_at_position_offset_x { get { return (Single)data["_camera_look_at_position_offset_x"]; } set { data["_camera_look_at_position_offset_x"] = value; } }
        public Single _camera_look_at_position_offset_y { get { return (Single)data["_camera_look_at_position_offset_y"]; } set { data["_camera_look_at_position_offset_y"] = value; } }
        public Single _camera_look_at_position_offset_z { get { return (Single)data["_camera_look_at_position_offset_z"]; } set { data["_camera_look_at_position_offset_z"] = value; } }
        public Single _camera_delta_distance { get { return (Single)data["_camera_delta_distance"]; } set { data["_camera_delta_distance"] = value; } }
        public Single _camera_rotate_x { get { return (Single)data["_camera_rotate_x"]; } set { data["_camera_rotate_x"] = value; } }
        public Single _camera_rotate_y { get { return (Single)data["_camera_rotate_y"]; } set { data["_camera_rotate_y"] = value; } }
        public Int32 _se_condition { get { return (Int32)data["_se_condition"]; } set { data["_se_condition"] = value; } }
        public Int32 _se_id { get { return (Int32)data["_se_id"]; } set { data["_se_id"] = value; } }
        public Int32 _se_frame { get { return (Int32)data["_se_frame"]; } set { data["_se_frame"] = value; } }
        public Single _se_volume { get { return (Single)data["_se_volume"]; } set { data["_se_volume"] = value; } }
        public Int32 _se_pos { get { return (Int32)data["_se_pos"]; } set { data["_se_pos"] = value; } }
        public Int32 _se_pos_index { get { return (Int32)data["_se_pos_index"]; } set { data["_se_pos_index"] = value; } }
        public Int32 _movie_id { get { return (Int32)data["_movie_id"]; } set { data["_movie_id"] = value; } }
    }

    public class MessageData
    {
        readonly BinaryObject data;
        public MessageData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 m_id { get { return (Int32)data["m_id"]; } set { data["m_id"] = value; } }
        public Int32 m_chara_id { get { return (Int32)data["m_chara_id"]; } set { data["m_chara_id"] = value; } }
        public string m_text { get { return ((BinaryObjectStringRecord)data["m_text"])?.Value; } set { ((BinaryObjectStringRecord)data["m_text"]).Value = value; } }
    }


    public class MenuTextData
    {
        readonly BinaryObject data;
        public MenuTextData(BinaryObject bo)
        {
            this.data = bo;
        }
        public string m_file_id { get { return ((BinaryObjectStringRecord)data["m_file_id"])?.Value; } set { ((BinaryObjectStringRecord)data["m_file_id"]).Value = value; } }
        public Boolean m_is_serial { get { return (Boolean)data["m_is_serial"]; } set { data["m_is_serial"] = value; } }
        public Int32 m_revision { get { return (Int32)data["m_revision"]; } set { data["m_revision"] = value; } }
        public MenuTextItem?[] m_data { get { return ((object[])data["m_data"]).Select(x => x!=null? new MenuTextItem((BinaryObject)x):null).ToArray(); } }
    }

    public class MenuTextItem
    {
        readonly BinaryObject data;
        public MenuTextItem(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 m_id { get { return (Int32)data["m_id"]; } set { data["m_id"] = value; } }
        public string m_text { get { return ((BinaryObjectStringRecord)data["m_text"])?.Value; } set { ((BinaryObjectStringRecord)data["m_text"]).Value = value; } }
    }
    public class TreasureHuntDisappearData
    {
        readonly BinaryObject data;
        public TreasureHuntDisappearData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _floor_id { get { return (Int32)data["_floor_id"]; } set { data["_floor_id"] = value; } }
        public string _floor_name { get { return ((BinaryObjectStringRecord)data["_floor_name"])?.Value; } set { ((BinaryObjectStringRecord)data["_floor_name"]).Value = value; } }
        /**
         * 1 = MANAGEMENT? 
         * 2 = frog coin
         * 3 = mushroom
         * 4 = flower tab
         * 5 = an item, use _item_id to set 
         * 6 = item + management + script? (Always item 87)
         */
        public Int32 _kind_id { get { return (Int32)data["_kind_id"]; } set { data["_kind_id"] = value; } }
        public Int32 _management_id { get { return (Int32)data["_management_id"]; } set { data["_management_id"] = value; } }
        public Int32 _item_id { get { return (Int32)data["_item_id"]; } set { data["_item_id"] = value; } }
        public Int32 _coin { get { return (Int32)data["_coin"]; } set { data["_coin"] = value; } }
        public Int32 _large_coin { get { return (Int32)data["_large_coin"]; } set { data["_large_coin"] = value; } }
        public Boolean _is_frog_coin { get { return (Boolean)data["_is_frog_coin"]; } set { data["_is_frog_coin"] = value; } }
        public Boolean _is_mushroom { get { return (Boolean)data["_is_mushroom"]; } set { data["_is_mushroom"] = value; } }
        public Boolean _is_flower { get { return (Boolean)data["_is_flower"]; } set { data["_is_flower"] = value; } }
        public Boolean _needs_any_script { get { return (Boolean)data["_needs_any_script"]; } set { data["_needs_any_script"] = value; } }
        public Int32 _restoration { get { return (Int32)data["_restoration"]; } set { data["_restoration"] = value; } }
        public Int32 _treasure_id { get { return (Int32)data["_treasure_id"]; } set { data["_treasure_id"] = value; } }
    }
    public class MonsterAITableData
    {
        readonly BinaryObject data;
        public MonsterAITableData(BinaryObject bo)
        {
            this.data = bo;
        }
        public Int32 _table_id { get { return (Int32)data["_table_id"]; } set { data["_table_id"] = value; } }
        public Int32[] _skill_ratio { get { return (Int32[])data["_skill_ratio"]; } set { data["_skill_ratio"] = value; } }
        public Int32[] _skill_id { get { return (Int32[])data["_skill_id"]; } set { data["_skill_id"] = value; } }
        public Int32 _character_id { get { return (Int32)data["_character_id"]; } set { data["_character_id"] = value; } }
    }


#pragma warning restore IDE1006 // Naming Styles

}
