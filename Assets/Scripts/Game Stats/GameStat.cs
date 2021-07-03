using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour {
    protected string id { get; set; }
    protected string name { get; set; }
    protected float currentValue { get; set; }
    protected float maxValue { get; set; }
    protected float decayAmount { get; set; } = 0f;
    protected float decayRate { get; set; } = 0f;
    protected float absorbRate { get; set; } = 0f;

    private bool decays { get; set; } = false;
    private bool absorbs { get; set; } = false;

    public GameStat(string id, string name, bool decays = false, bool absorbs = false) {
        this.id = id;
        this.name = name;
        this.decays = decays;
        this.absorbs = absorbs;
    }
}
