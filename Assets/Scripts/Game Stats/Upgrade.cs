using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class Upgrade {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Duration { get; set; }
    public List<UpgradeEffect> Effects { get; set; }

    public Upgrade(string id, string name, string description, float duration, List<UpgradeEffect> effects) {
        Id = id;
        Name = name;
        Description = description;
        Duration = duration;
        Effects = effects;
    }

    public override string ToString() {
        string effectsString = "Effects:\n";
        foreach(UpgradeEffect effect in Effects) {
            effectsString += "-Stat: " + effect.GameStatKey + "\n--Type: " + effect.UpgradeEffectType + "\n--Value: " + effect.Value + "\n";
        }

        return "Id: " + Id + ",\nName: " + Name + ",\nDescription: " + Description + "\n" + effectsString;
    }
}
