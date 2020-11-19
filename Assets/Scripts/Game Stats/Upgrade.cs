using System.Collections;
using System.Collections.Generic;
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
}
