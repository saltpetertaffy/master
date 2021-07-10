using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat {
    protected string statKey;
    protected string statName;
    protected float currentValue = 0f;
    protected float maxValue = 0f;
    protected float decayAmount = 0f;
    protected float decayRate = 0f;
    protected float absorption = 0f;

    protected bool decays = false;
    protected bool absorbs = false;

    protected Color anticolor = Color.black;
    protected Color procolor = Color.black;

    protected string[] damageReducedBy;
    protected string[] damageBlockedBy;

    public GameStat(string statKey, string name) {
        this.statKey = statKey;
        this.statName = name;
    }

    public string GetStatKey() {
        return statKey;
    }
    public string GetStatName() {
        return statName;
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
    public bool Decays() {
        return decays;
    }
    public bool Absorbs() {
        return absorbs;
    }
    public Color GetAnticolor() {
        return anticolor;
    }
    public Color GetProcolor() {
        return procolor;
    }
    public string[] GetDamageReducedBy() {
        return damageReducedBy;
    }
    public string[] GetDamageBlockedBy() {
        return damageBlockedBy;
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
    public void SetDamageReducedBy(string[] damageReducedBy) {
        this.damageReducedBy = damageReducedBy;
    }
    public void SetDamageBlockedBy(string[] damageBlockedBy) {
        this.damageBlockedBy = damageBlockedBy;
    }
    public void SetDecays(bool decays) {
        this.decays = decays;
    }
    public void SetAbsorbs(bool absorbs) {
        this.absorbs = absorbs;
    }
    public void SetAnticolor(Color anticolor) {
        this.anticolor = anticolor;
    }
    public void SetProcolor(Color procolor) {
        this.procolor = procolor;
    }
}
