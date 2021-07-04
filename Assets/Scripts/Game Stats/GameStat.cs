using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour {
    protected string statKey;
    protected string statName;
    protected float currentValue;
    protected float maxValue;
    protected float decayAmount = 0f;
    protected float decayRate = 0f;
    protected float absorption = 0f;

    protected bool decays = false;
    protected bool absorbs = false;

    public GameStat(string statKey, string name, bool decays = false, bool absorbs = false) {
        this.statKey = statKey;
        this.name = name;
        this.decays = decays;
        this.absorbs = absorbs;
    }

    public string GetStatKey() {
        return statKey;
    }
    public float GetCurrentValue() {
        return currentValue;
    }
    public float GetDecayAmount() {
        return decayAmount;
    }
    public float GetDecayRate() {
        return decayRate;
    }
    public float GetAbsorption() {
        return absorption;
    }
    public void SetCurrentValue(float value) {
        this.currentValue = value;
    }
    public void SetDecayAmount(float value) {
        this.decayAmount = value;
    }
    public void SetDecayRate(float value) {
        this.decayRate = value;
    }
    public void SetAbsorption(float value) {
        this.absorption = value;
    }
}
