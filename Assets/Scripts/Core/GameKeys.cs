﻿namespace GameConstants {
    public static class GameKeys {
        public const string ANMIMATION_ACTIVATED_TRIGGER = "isActivated";
        public const string ANIMATION_DEAD_TRIGGER = "isDead";
        public const string ABILITY_SPARK_KEY = "Spark";
        public const string ABILITY_SPLITTER_KEY = "Splitter";
        public const string AXIS_CYCLE_EQUIP_KEY = "Cycle Equip";
        public const string AXIS_FIRE_1_KEY = "Fire1";
        public const string AXIS_HORIZONTAL_KEY = "Horizontal";
        public const string AXIS_JUMP_KEY = "Jump";
        public const string AXIS_SELECT_EQUIP_1_KEY = "Select Equip 1";
        public const string AXIS_SELECT_EQUIP_2_KEY = "Select Equip 2";
        public const string AXIS_VERTICAL_KEY = "Vertical";
        public const string LAYER_CHARACTER_UI_KEY = "Character UI";
        public const string LAYER_ENEMY_KEY = "Enemy";
        public const string LAYER_GROUND_KEY = "Ground";
        public const string LAYER_HITBOX_KEY = "Hitbox";
        public const string LAYER_PLAYER_KEY = "Player";
        public const string LAYER_WEAPON_KEY = "Weapon";
    }

    public enum GameStatEffects {
        DAMAGE,
        DAMAGE_PERCENT_MAX,
        DAMAGE_PERCENT_REMAINING,
        HEALING,
        HEALING_PERCENT_MAX,
        HEALING_PERCENT_MISSING,
        ARMOR_SHRED,
        ARMOR_SHRED_PERCENT_MAX,
        ARMOR_SHRED_PERCENT_REMAINING,
        ARMOR_REPAIR,
        ARMOR_REPAIR_PERCENT_MAX,
        ARMOR_REPAIR_PERCENT_MISSING,
        MOVEMENT_MOVE_SPEED_UP,
        MOPVEMENT_MOVE_SPEED_DOWN,
        MOVEMENT_JUMP_SPEED_UP,
        MOVEMENT_JUMP_SPEED_DOWN
    }

    public enum GameStatEffectCategories {
        DAMAGE,
        ARMOR_SHRED,
        HEALING,
        ARMOR_REPAIR,
        MOVEMENT
    }

    public static class UpgradeEffectTypes {
        public const string ADD = "ADD";
        public const string ADD_DECAY_AMOUNT = "ADD_DECAY_AMOUNT";
        public const string ADD_DECAY_RATE = "ADD_DECAY_RATE";
        public const string ADD_ABSORPTION = "ADD_ABSORPTION";
        public const string MULTIPLY = "MULTIPLY";
        public const string MULTIPLY_DECAY_AMOUNT = "MULTIPLY_DECAY_AMOUNT";
        public const string MULTIPLY_DECAY_RATE = "MULTIPLY_DECAY_RATE";
        public const string MULTIPLY_ABSORPTION = "MULTIPLY_ABSORPTION";
        public const string SET = "SET";
        public const string SET_DECAY_AMOUNT = "SET_DECAY_AMOUNT";
        public const string SET_DECAY_RATE = "SET_DECAY_RATE";
        public const string SET_ABSORPTION = "SET_ABSORPTION";
    }
}