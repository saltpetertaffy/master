using GameConstants;
using System;
using System.Collections.Generic;

[Serializable]
public class Save
{
    public int Lives                    { get; set; }
    public string[] AbilityLoadout      { get; set; }
    public string[] PermanentUpgrades   { get; set; }

    public Save() {
        Lives = 3;
        AbilityLoadout = new string[2] {GameKeys.ABILITY_SPARK_KEY, GameKeys.ABILITY_SPLITTER_KEY};
        PermanentUpgrades = new string[3] { "base", "addHealth1", "multiplyHealth1" };
    }

    public Save(int lives, string[] abilityLoadout) {
        this.Lives = lives;
        this.AbilityLoadout = abilityLoadout;
    }
}
