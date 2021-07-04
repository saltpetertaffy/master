using GameConstants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public List<KeyValuePair<string, GameStat>> LoadCharacter(string characterId) {
        List<string> statIds = new List<string>();
        List<string> upgradeIds = new List<string>();
        string charactersFilepath = Directory.GetCurrentDirectory() + "\\xml\\Characters.xml";

        XDocument charactersDocument = XDocument.Load(charactersFilepath);
        if (charactersDocument == null) {
            throw new FileNotFoundException("File not found: " + charactersFilepath);
        }
        IEnumerable<XElement> characterLoadData = charactersDocument.Descendants("Character")
                                              .Where(j => j.Attribute("id").Value == characterId);
        if (characterLoadData == null) {
            throw new CharacterNotFoundException("Character not found, id: " + characterId);
        }
        statIds = characterLoadData.Descendants("Stat")
                                   .Select(j => j.Attribute("statkey").Value)
                                   .ToList();
        upgradeIds = characterLoadData.Descendants("Character")
                                       .Select(j => j.Attribute("id").Value)
                                       .ToList();
        

        List<KeyValuePair<string, GameStat>> gameStatsToLoad = new List<KeyValuePair<string, GameStat>>();
        string statsFilepath = Directory.GetCurrentDirectory() + "\\xml\\Stats.xml";

        XDocument statsDocument = XDocument.Load(statsFilepath);
        if (statsDocument == null) {
            throw new FileNotFoundException("File not found: " + statsFilepath);
        }
        List<XElement> statsToLoadXml = statsDocument.Descendants("Stat")
                                                     .Where(i => statIds.Contains(i.Attribute("statkey").Value))
                                                     .ToList();
        foreach (XElement statElement in statsToLoadXml) {
            GameStat statToLoad = new GameStat(statElement.Attribute("statkey").Value, 
                                               statElement.Element("Name").Value,
                                               bool.Parse(statElement.Attribute("decays").Value),
                                               bool.Parse(statElement.Attribute("absorbs").Value));
            gameStatsToLoad.Add(new KeyValuePair<string, GameStat>(statToLoad.GetStatKey(), statToLoad));
        }

        List<Upgrade> upgradesToLoad = new List<Upgrade>();
        string upgradesFilepath = Directory.GetCurrentDirectory() + "\\xml\\Upgrades.xml";

        XDocument upgrades = XDocument.Load(upgradesFilepath);

        if (upgrades != null && upgrades.Descendants("Upgrade") != null) {
            List<XElement> upgradesToLoadXml = upgrades.Descendants("Upgrade")
                                            .Where(i => upgradeIds.Contains(i.Attribute("id").Value))
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
        ApplyUpgrades(gameStatsToLoad, upgradesToLoad);
        return gameStatsToLoad;
    }

    public void ApplyUpgrades(List<KeyValuePair<string, GameStat>> gameStatsToLoad, List<Upgrade> upgrades) {
        if (upgrades.Count == 0) { return; }

        List<UpgradeEffect> setEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> setDecayAmountEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> setDecayRateEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> setAbsorptionEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> addEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> addDecayAmountEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> addDecayRateEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> addAbsorptionEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> multiplyEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> multiplyDecayAmountEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> multiplyDecayRateEffects = new List<UpgradeEffect>();
        List<UpgradeEffect> multiplyAbsorptionEffects = new List<UpgradeEffect>();

        // enforce order of operations (set, add, multiply)
        foreach (Upgrade upgrade in upgrades) {
            foreach (UpgradeEffect effect in upgrade.Effects) {
                switch (effect.upgradeEffectType) {
                    case UpgradeEffectTypes.SET:
                        setEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.SET_DECAY_AMOUNT:
                        setDecayAmountEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.SET_DECAY_RATE:
                        setDecayRateEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.SET_ABSORPTION:
                        setAbsorptionEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.ADD:
                        addEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.ADD_DECAY_AMOUNT:
                        addDecayAmountEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.ADD_DECAY_RATE:
                        addDecayRateEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.ADD_ABSORPTION:
                        addAbsorptionEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.MULTIPLY:
                        multiplyEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.MULTIPLY_DECAY_AMOUNT:
                        multiplyDecayAmountEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.MULTIPLY_DECAY_RATE:
                        multiplyDecayRateEffects.Add(effect);
                        break;
                    case UpgradeEffectTypes.MULTIPLY_ABSORPTION:
                        multiplyAbsorptionEffects.Add(effect);
                        break;
                    default:
                        throw new EffectNotFoundException("Effect type not found: " + effect.upgradeEffectType);
                }
            }
        }

        foreach (UpgradeEffect effect in setEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);    
        }
        foreach (UpgradeEffect effect in setDecayAmountEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in setDecayRateEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in setAbsorptionEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in addEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in addDecayAmountEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in addDecayRateEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in addAbsorptionEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in multiplyEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in multiplyDecayAmountEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in multiplyDecayRateEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
        foreach (UpgradeEffect effect in multiplyAbsorptionEffects) {
            ApplyUpgradeEffect(gameStatsToLoad, effect);
        }
    }

    private void ApplyUpgradeEffect(List<KeyValuePair<string, GameStat>> gameStats, UpgradeEffect effect) {
        foreach (KeyValuePair<string, GameStat> statPair in gameStats) {
            GameStat stat = statPair.Value;
            if (stat.GetStatKey() == effect.gameStatKey) {
                switch (effect.upgradeEffectType) {
                    case UpgradeEffectTypes.SET:
                        stat.SetCurrentValue(effect.value);
                        return;
                    case UpgradeEffectTypes.ADD:
                        stat.SetCurrentValue(stat.GetCurrentValue() + effect.value);
                        return;
                    case UpgradeEffectTypes.MULTIPLY:
                        stat.SetCurrentValue(stat.GetCurrentValue() * effect.value);
                        return;
                    case UpgradeEffectTypes.SET_DECAY_AMOUNT:
                        stat.SetDecayAmount(effect.value);
                        return;
                    case UpgradeEffectTypes.ADD_DECAY_AMOUNT:
                        stat.SetDecayAmount(stat.GetDecayAmount() + effect.value);
                        return;
                    case UpgradeEffectTypes.MULTIPLY_DECAY_AMOUNT:
                        stat.SetDecayAmount(stat.GetDecayAmount() * effect.value);
                        return;
                    case UpgradeEffectTypes.SET_DECAY_RATE:
                        stat.SetDecayRate(effect.value);
                        return;
                    case UpgradeEffectTypes.ADD_DECAY_RATE:
                        stat.SetDecayRate(stat.GetDecayRate() + effect.value);
                        return;
                    case UpgradeEffectTypes.MULTIPLY_DECAY_RATE:
                        stat.SetDecayRate(stat.GetDecayRate() * effect.value);
                        return;
                    case UpgradeEffectTypes.SET_ABSORPTION:
                        stat.SetAbsorption(effect.value);
                        return;
                    case UpgradeEffectTypes.ADD_ABSORPTION:
                        stat.SetAbsorption(stat.GetAbsorption() + effect.value);
                        return;
                    case UpgradeEffectTypes.MULTIPLY_ABSORPTION:
                        stat.SetAbsorption(stat.GetAbsorption() * effect.value);
                        return;
                }
            }
        }
    }
}
