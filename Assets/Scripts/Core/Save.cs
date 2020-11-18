using GameConstants;
using System;
using System.Collections.Generic;

[Serializable]
public class Save
{
    public int Lives                        { get; set; }
    public string[] AbilityLoadout          { get; set; }
    public List<Upgrade> PermanentUpgrades  { get; set; }

    public Save() {
        Lives = 3;
        AbilityLoadout = new string[2] {GameKeys.ABILITY_SPARK_KEY, GameKeys.ABILITY_SPLITTER_KEY};
    }

    public Save(int lives, string[] abilityLoadout) {
        this.Lives = lives;
        this.AbilityLoadout = abilityLoadout;
    }
}
