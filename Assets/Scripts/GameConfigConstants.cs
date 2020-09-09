namespace GameConstants {
    public static class GameConfigConstants {
        // Determines how fast the main character must be moving horizontally 
        // in midair for a reversal of direction to be considered "trying to go the other way"
        public const float GAME_JUMP_MINIMUM_X_THRESHOLD = 3f;

        // The Input Manager dead zone setting is inaccessible in code
        public const float INPUT_DEAD_ZONE = 0.1f;

        // Width of stat bar = maxStatValue * this + 
        public const float UI_STAT_BAR_SCALING_MULTIPLIER = .1f;

        // Width of stat bar foreground = (maxStatValue * scalingMultiplier) - this
        public const float UI_STAT_BAR_FOREGROUND_RIGHT_MARGIN = 0f;

        // width of stat bar background = (maxStatValue * scalingMultiplier) + this
        public const float UI_STAT_BAR_BACKGROUND_MARGIN = .4f;
    }
}