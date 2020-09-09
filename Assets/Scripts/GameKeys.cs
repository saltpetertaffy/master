namespace GameConstants {
    public static class GameKeys {
        public const string ANMIMATION_ACTIVATED_TRIGGER = "isActivated";
        public const string ANIMATION_DEAD_TRIGGER = "isDead";
        public const string AXIS_FIRE_1_KEY = "Fire1";
        public const string AXIS_HORIZONTAL_KEY = "Horizontal";
        public const string AXIS_JUMP_KEY = "Jump";
        public const string AXIS_VERTICAL_KEY = "Vertical";
        public const string LAYER_CHARACTER_UI_KEY = "Character UI";
        public const string LAYER_GROUND_KEY = "Ground";
        public const string LAYER_HITBOX_KEY = "Hitbox";
        public const string LAYER_PLAYER_KEY = "Player";
        public const string LAYER_WEAPON_KEY = "Weapon";
    }

    public enum GameStatEffects {
        DAMAGE = 0,
        DAMAGE_PERCENT_MAX = 1,
        DAMAGE_PERCENT_REMAINING = 2,
        HEALING = 3,
        HEALING_PERCENT_MAX = 4,
        HEALING_PERCENT_MISSING = 5,
        ARMOR_SHRED = 6,
        ARMOR_SHRED_PERCENT_MAX = 7,
        ARMOR_SHRED_PERCENT_REMAINING = 8,
        ARMOR_REPAIR = 9,
        ARMOR_REPAIR_PERCENT_MAX = 10,
        ARMOR_REPAIR_PERCENT_MISSING = 11
    }
}
