using GameConstants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;

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
                    Debug.Log(effectElement);
                    UpgradeEffect effectToLoad = new UpgradeEffect(effectElement.Attribute("statkey").Value,
                                                                   effectElement.Attribute("type").Value,
                                                                   float.Parse(effectElement.Attribute("value").Value));
                    effects.Add(effectToLoad);
                    Debug.Log(effectToLoad.GameStatKey + ", " + effectToLoad.UpgradeEffectType + ", " + effectToLoad.Value);
                }
                
                //Upgrade upgradetoLoad = new Upgrade(upgradeElement.Attribute("id"),
                  //                                  upgradeElement.Element("Name"),
                    //                                upgradeElement.Element("Description"),
                      //                              0f,
                        //                            null);
            }
        }
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
            ApplyPermanentEffect(mainCharacter, effect);    
        }
        foreach (UpgradeEffect effect in addUpgradeEffects) {
            ApplyPermanentEffect(mainCharacter, effect);
        }
        foreach (UpgradeEffect effect in multiplyUpgradeEffects) {
            ApplyPermanentEffect(mainCharacter, effect);
        }
    }

    private void ApplyPermanentEffect(MainCharacter mainCharacter, UpgradeEffect effect) {
        GameStat stat;
        switch (effect.UpgradeEffectType) {
            case UpgradeEffectTypes.SET:

                break;
            case UpgradeEffectTypes.ADD:

                break;
            case UpgradeEffectTypes.MULTIPLY:

                break;
        }
    }
}
