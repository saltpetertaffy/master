using GameConstants;
using System;

[Serializable]
public class Save
{
    public int lives;
    public string[] abilityLoadout;

    public Save() {
        lives = 3;
        abilityLoadout = new string[2] {GameKeys.ABILITY_SPARK_KEY, GameKeys.ABILITY_SPLITTER_KEY};
    }

    public Save(int lives, string[] abilityLoadout) {
        this.lives = lives;
        this.abilityLoadout = abilityLoadout;
    }
}
