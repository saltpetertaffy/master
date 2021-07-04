using GameConstants;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string characterId;

    protected GameStatHandler gameStatHandler;

    private void Awake() {
        gameStatHandler = GetComponent<GameStatHandler>();
        LoadCharacter();
    }

    private void LoadCharacter() {
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
                List<StatEffect> effects = new List<StatEffect>();
                foreach (XElement effectElement in upgradeElement.Descendants("UpgradeEffect").ToList()) {
                    StatEffect effectToLoad = new StatEffect(effectElement.Attribute("statkey").Value,
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
    }

    public void ApplyUpgrades(List<KeyValuePair<string, GameStat>> gameStatsToLoad, List<Upgrade> upgrades) {
        if (upgrades.Count == 0) { return; }

        List<StatEffect> setEffects = new List<StatEffect>();
        List<StatEffect> setDecayAmountEffects = new List<StatEffect>();
        List<StatEffect> setDecayRateEffects = new List<StatEffect>();
        List<StatEffect> setAbsorptionEffects = new List<StatEffect>();
        List<StatEffect> addEffects = new List<StatEffect>();
        List<StatEffect> addDecayAmountEffects = new List<StatEffect>();
        List<StatEffect> addDecayRateEffects = new List<StatEffect>();
        List<StatEffect> addAbsorptionEffects = new List<StatEffect>();
        List<StatEffect> multiplyEffects = new List<StatEffect>();
        List<StatEffect> multiplyDecayAmountEffects = new List<StatEffect>();
        List<StatEffect> multiplyDecayRateEffects = new List<StatEffect>();
        List<StatEffect> multiplyAbsorptionEffects = new List<StatEffect>();

        // enforce order of operations (set, add, multiply)
        foreach (Upgrade upgrade in upgrades) {
            foreach (StatEffect effect in upgrade.Effects) {
                switch (effect.effectType) {
                    case StatEffectTypes.SET:
                        setEffects.Add(effect);
                        break;
                    case StatEffectTypes.SET_DECAY_AMOUNT:
                        setDecayAmountEffects.Add(effect);
                        break;
                    case StatEffectTypes.SET_DECAY_RATE:
                        setDecayRateEffects.Add(effect);
                        break;
                    case StatEffectTypes.SET_ABSORPTION:
                        setAbsorptionEffects.Add(effect);
                        break;
                    case StatEffectTypes.ADD:
                        addEffects.Add(effect);
                        break;
                    case StatEffectTypes.ADD_DECAY_AMOUNT:
                        addDecayAmountEffects.Add(effect);
                        break;
                    case StatEffectTypes.ADD_DECAY_RATE:
                        addDecayRateEffects.Add(effect);
                        break;
                    case StatEffectTypes.ADD_ABSORPTION:
                        addAbsorptionEffects.Add(effect);
                        break;
                    case StatEffectTypes.MULTIPLY:
                        multiplyEffects.Add(effect);
                        break;
                    case StatEffectTypes.MULTIPLY_DECAY_AMOUNT:
                        multiplyDecayAmountEffects.Add(effect);
                        break;
                    case StatEffectTypes.MULTIPLY_DECAY_RATE:
                        multiplyDecayRateEffects.Add(effect);
                        break;
                    case StatEffectTypes.MULTIPLY_ABSORPTION:
                        multiplyAbsorptionEffects.Add(effect);
                        break;
                    default:
                        throw new EffectNotFoundException("Effect type not found: " + effect.effectType);
                }
            }
        }
        List<StatEffect> allEffects = new List<StatEffect>();
        allEffects.Concat(setEffects);
        allEffects.Concat(setDecayAmountEffects);
        allEffects.Concat(setDecayRateEffects);
        allEffects.Concat(setAbsorptionEffects);
        allEffects.Concat(addEffects);
        allEffects.Concat(addDecayAmountEffects);
        allEffects.Concat(addDecayRateEffects);
        allEffects.Concat(addAbsorptionEffects);
        allEffects.Concat(multiplyEffects);
        allEffects.Concat(multiplyDecayAmountEffects);
        allEffects.Concat(multiplyDecayRateEffects);
        allEffects.Concat(multiplyAbsorptionEffects);

        foreach (StatEffect effect in allEffects) {
            gameStatHandler.ModifyStat(effect);
        }
    }
}
