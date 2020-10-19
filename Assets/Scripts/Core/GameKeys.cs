namespace GameConstants {
    public static class GameKeys {
        public const string ANMIMATION_ACTIVATED_TRIGGER = "isActivated";
        public const string ANIMATION_DEAD_TRIGGER = "isDead";
        public const string AXIS_FIRE_1_KEY = "Fire1";
        public const string AXIS_HORIZONTAL_KEY = "Horizontal";
        public const string AXIS_JUMP_KEY = "Jump";
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
        ARMOR_REPAIR_PERCENT_MISSING
    }

    public enum GameStatEffectTypes {
        DAMAGE,
        ARMOR_SHRED,
        HEALING,
        ARMOR_REPAIR
    }

    public enum GameStats {
        HEALTH,
        ARMOR
    }
}
