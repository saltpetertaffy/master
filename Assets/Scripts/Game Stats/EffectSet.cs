using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class EffectSet {
    private string id;
    private string name;
    private string description;
    private float duration;
    private List<StatEffect> effects;

    public EffectSet(string id, string name, string description, List<StatEffect> effects) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.effects = effects;
    }

    public string GetId() {
        return id;
    }
    public string GetName() {
        return name;
    }
    public string GetDescription() {
        return description;
    }
    public float GetDuration() {
        return duration;
    }
    public List<StatEffect> GetEffects() {
        return effects;
    }
    public void SetId(string id) {
        this.id = id;
    }
    public void SetName(string name) {
        this.name = name;
    }
    public void SetDescription(string description) {
        this.description = description;
    }
    public void SetDuration(float duration) {
        this.duration = duration;
    }
    public void SetEffects(List<StatEffect> effects) {
        this.effects = effects;
    }

    public override string ToString() {
        string effectsString = "Effects:\n";
        foreach(StatEffect effect in effects) {
            effectsString += "-Stat: " + effect.gameStatKey + "\n--Type: " + effect.effectType + "\n--Value: " + effect.value + "\n";
        }

        return "Id: " + id + ",\nName: " + name + ",\nDescription: " + description + "\n" + effectsString;
    }
}
