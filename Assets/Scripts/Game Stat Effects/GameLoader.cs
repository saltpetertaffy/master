using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public GameStatHandler gameStatHandler;
    public List<KeyValuePair<string, EffectSet>> effectSetList;
    public List<KeyValuePair<string, Character>> characterBaseList;
    
    void Awake()
    {
        gameStatHandler = new GameStatHandler();
        LoadGameStats();
        LoadEffectSets();
        LoadCharacterBases();
    }

    private void LoadGameStats() {
        string statsFilepath = Directory.GetCurrentDirectory() + "\\xml\\Stats.xml";

        XDocument statsDocument = XDocument.Load(statsFilepath);
        if (statsDocument == null) {
            throw new FileNotFoundException("File not found: " + statsFilepath);
        }
        List<XElement> statsToLoadXml = statsDocument.Descendants("Stat")
                                                     .ToList();

        foreach (XElement statElement in statsToLoadXml) {
            GameStat statToLoad = GetGameStatFromXml(statElement);
            gameStatHandler.AddStat(statToLoad);
        }
    }
    private void LoadEffectSets() {
        string effectSetsFilepath = Directory.GetCurrentDirectory() + "\\xml\\EffectSets.xml";

        XDocument effectSets = XDocument.Load(effectSetsFilepath);

        if (effectSets != null && effectSets.Descendants("EffectSet") != null) {
            List<XElement> effectSetsToLoadXml = effectSets.Descendants("EffectSet")
                                                           .ToList();
            foreach (XElement effectSetElement in effectSetsToLoadXml) {
                EffectSet effectSetToLoad = GetEffectSetFromXml(effectSetElement);
                effectSetList.Add(new KeyValuePair<string, EffectSet>(effectSetToLoad.GetId(), effectSetToLoad));
            }
        }
    }
    private void LoadCharacterBases() {
        string charactersFilepath = Directory.GetCurrentDirectory() + "\\xml\\Characters.xml";

        XDocument charactersDocument = XDocument.Load(charactersFilepath);
        if (charactersDocument == null) {
            throw new FileNotFoundException("File not found: " + charactersFilepath);
        }
        List<XElement> charactersToLoadXml = charactersDocument.Descendants("Character")
                                                             .ToList();
        foreach (XElement characterElement in charactersToLoadXml) {
            Character characterToAdd = new Character();
            string characterId = characterElement.Attribute("id").Value;
            string characterName = characterElement.Element("Name").Value;
            string characterDescription = characterElement.Element("Description").Value;

            List<XElement> characterStatElements = characterElement.Elements("Stat")
                                                                   .ToList();
            List<XElement> characterUpgradeElements = characterElement.Elements("Upgrade")
                                                                      .ToList();
            foreach
            foreach (XElement characterStatElement in characterStatElements) {
                string characterStatKey = characterStatElement.Attribute("statkey").Value;
                bool characterStatDecays = bool.Parse(characterStatElement.Attribute("decays").Value);
                bool characterStatAbsorbs = bool.Parse(characterStatElement.Attribute("absorbs").Value);
                
                GameStat statToAdd = gameStatHandler.GetGameStatByKey(characterStatKey);
                statToAdd.SetDecays(characterStatDecays);
                statToAdd.SetAbsorbs(characterStatAbsorbs);
                characterToAdd.gameStatHandler.AddStat(statToAdd);
            }
        }
    }

    private GameStat GetGameStatFromXml(XElement statElement) {
        string statKey = statElement.Attribute("statkey").Value;
        string statName = statElement.Element("Name").Value;
        GameStat stat = new GameStat(statKey, statName);

        Color statAnticolor = new Color(float.Parse(statElement.Element("Anticolor").Attribute("r").Value),
                                        float.Parse(statElement.Element("AntiColor").Attribute("g").Value),
                                        float.Parse(statElement.Element("Anticolor").Attribute("b").Value));
        stat.SetAnticolor(statAnticolor);

        Color statProcolor = new Color(float.Parse(statElement.Element("Procolor").Attribute("r").Value),
                                        float.Parse(statElement.Element("ProColor").Attribute("g").Value),
                                        float.Parse(statElement.Element("Procolor").Attribute("b").Value));
        stat.SetProcolor(statProcolor);
        stat.SetDamageReducedBy(statElement.Element("Interactions").Attribute("damagereducedby").Value.Split(','));
        stat.SetDamageBlockedBy(statElement.Element("Interactions").Attribute("damageblockedby").Value.Split(','));

        return stat;
    }

    private EffectSet GetEffectSetFromXml(XElement effectSetElement) {
        string effectSetId = effectSetElement.Attribute("id").Value;
        string effectSetName = effectSetElement.Element("Name").Value;
        string effectSetDescription = effectSetElement.Element("Description").Value;
        List<StatEffect> effects = new List<StatEffect>();

        foreach (XElement effectElement in effectSetElement.Descendants("Effect").ToList()) {
            StatEffect effectToLoad = new StatEffect(effectElement.Attribute("statkey").Value,
                                                     effectElement.Attribute("type").Value,
                                                     float.Parse(effectElement.Attribute("value").Value));
            effects.Add(effectToLoad);
        }

        EffectSet effectSetToLoad = new EffectSet(effectSetId, effectSetName, effectSetDescription, effects);
        return effectSetToLoad;
    }
}
