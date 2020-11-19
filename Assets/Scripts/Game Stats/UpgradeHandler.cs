﻿using GameConstants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    public void LoadUpgrades(string[] upgradeIds) {
        List<Upgrade> upgradesToLoad = new List<Upgrade>();
        string upgradesFilepath = Directory.GetCurrentDirectory() + "\\Upgrades\\Upgrades.xml";

        XDocument upgrades = XDocument.Load(upgradesFilepath);

        if (upgrades != null && upgrades.Descendants("Upgrade") != null) {
            List<XElement> upgradesToLoadXml = upgrades.Descendants("Upgrade")
                                            .Where(i => Array.Exists(upgradeIds, upgradeId => upgradeId.Equals(i.Attribute("id").Value)))
                                            .ToList();
            foreach (XElement upgradeElement in upgradesToLoadXml) {
                List<UpgradeEffect> effects = new List<UpgradeEffect>();
                foreach (XElement effectElement in upgradeElement.Descendants("UpgradeEffect").ToList()) {
                    UpgradeEffect effectToLoad = new UpgradeEffect(effectElement.Attribute("statkey").Value,
                                                                   effectElement.Attribute("type").Value,
                                                                   float.Parse(effectElement.Attribute("value").Value));
                    effects.Add(effectToLoad);
                }
                
                Upgrade upgradetoLoad = new Upgrade(upgradeElement.Attribute("id").Value,
                                                    upgradeElement.Element("Name").Value,
                                                    upgradeElement.Element("Description").Value,
                                                    0f,
                                                    effects);
                upgradesToLoad.Add(upgradetoLoad);
            }
        }
        ApplyPermanentUpgrades(upgradesToLoad);
    }

    public void ApplyPermanentUpgrades(List<Upgrade> upgrades) {
        if (upgrades.Count == 0) { return; }

        List<UpgradeEffect> setUpgradeEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> addUpgradeEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> multiplyUpgradeEffects = new List<UpgradeEffect>();

        foreach (Upgrade upgrade in upgrades) {
            foreach (UpgradeEffect effect in upgrade.Effects) {
                switch (effect.UpgradeEffectType) {
                    case UpgradeEffectTypes.SET:
                        setUpgradeEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.ADD:
                        addUpgradeEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.MULTIPLY:
                        multiplyUpgradeEffects.Add(effect);
                        break;
                    default:
                        throw new EffectNotFoundException("Effect type not found: " + effect.UpgradeEffectType);
                }
            }
        }

        MainCharacter mainCharacter = FindObjectOfType<MainCharacter>();

        // enforce order of operations (set, add, multiply)
        foreach (UpgradeEffect effect in setUpgradeEffects) {
            ApplySetEffect(mainCharacter, effect);    
        }
        foreach (UpgradeEffect effect in addUpgradeEffects) {
            ApplyAddEffect(mainCharacter, effect);
        }
        foreach (UpgradeEffect effect in multiplyUpgradeEffects) {
            ApplyMultiplyEffect(mainCharacter, effect);
        }
        Debug.Log(mainCharacter.GetComponent<Health>().MaximumHealth + ", " +
                  mainCharacter.GetComponent<Armor>().MaximumArmor + ", " +
                  mainCharacter.MoveSpeed);
    }

    private void ApplySetEffect(MainCharacter mainCharacter, UpgradeEffect effect) {
        switch (effect.GameStatKey) {
            case GameStats.STAT_HEALTH:
                mainCharacter.GetComponent<Health>().MaximumHealth = effect.Value;
                break;
            case GameStats.STAT_ARMOR:
                mainCharacter.GetComponent<Armor>().MaximumArmor = effect.Value;
                break;
            case GameStats.STAT_MOVE_SPEED:
                mainCharacter.MoveSpeed = effect.Value;
                break;
            case GameStats.STAT_JUMP_SPEED:
                mainCharacter.JumpSpeed = effect.Value;
                break;
            case GameStats.STAT_ATTACK_SPEED:
                mainCharacter.AttackSpeed = effect.Value;
                break;
            case GameStats.STAT_MIDAIR_REVERSE_SPEED:
                mainCharacter.MidairReverseSpeed = effect.Value;
                break;
            default:
                throw new StatNotFoundException("Stat not found: " + effect.GameStatKey);
        }
    }

    private void ApplyAddEffect(MainCharacter mainCharacter, UpgradeEffect effect) {
        switch (effect.GameStatKey) {
            case GameStats.STAT_HEALTH:
                mainCharacter.GetComponent<Health>().MaximumHealth += effect.Value;
                break;
            case GameStats.STAT_ARMOR:
                mainCharacter.GetComponent<Armor>().MaximumArmor += effect.Value;
                break;
            case GameStats.STAT_MOVE_SPEED:
                mainCharacter.MoveSpeed += effect.Value;
                break;
            case GameStats.STAT_JUMP_SPEED:
                mainCharacter.JumpSpeed += effect.Value;
                break;
            case GameStats.STAT_ATTACK_SPEED:
                mainCharacter.AttackSpeed += effect.Value;
                break;
            case GameStats.STAT_MIDAIR_REVERSE_SPEED:
                mainCharacter.MidairReverseSpeed += effect.Value;
                break;
            default:
                throw new StatNotFoundException("Stat not found: " + effect.GameStatKey);
        }
    }

    private void ApplyMultiplyEffect(MainCharacter mainCharacter, UpgradeEffect effect) {
        switch (effect.GameStatKey) {
            case GameStats.STAT_HEALTH:
                mainCharacter.GetComponent<Health>().MaximumHealth *= effect.Value;
                break;
            case GameStats.STAT_ARMOR:
                mainCharacter.GetComponent<Armor>().MaximumArmor *= effect.Value;
                break;
            case GameStats.STAT_MOVE_SPEED:
                mainCharacter.MoveSpeed *= effect.Value;
                break;
            case GameStats.STAT_JUMP_SPEED:
                mainCharacter.JumpSpeed *= effect.Value;
                break;
            case GameStats.STAT_ATTACK_SPEED:
                mainCharacter.AttackSpeed *= effect.Value;
                break;
            case GameStats.STAT_MIDAIR_REVERSE_SPEED:
                mainCharacter.MidairReverseSpeed *= effect.Value;
                break;
            default:
                throw new StatNotFoundException("Stat not found: " + effect.GameStatKey);
        }
    }
}
