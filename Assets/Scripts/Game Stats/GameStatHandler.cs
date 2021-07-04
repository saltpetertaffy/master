using UnityEngine;
using GameConstants;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class GameStatHandler : MonoBehaviour
{
    TextEmitter textEmitter = null;
    List<string> gameStatKeys;

    private void Awake() {
        textEmitter = FindObjectOfType<TextEmitter>();
        GetAllStatKeys();
    }

    private void GetAllStatKeys() {
        string statsFilepath = Directory.GetCurrentDirectory() + "\\xml\\Stats.xml";

        XDocument statsDocument = XDocument.Load(statsFilepath);
        if (statsDocument == null) {
            throw new FileNotFoundException("File not found: " + statsFilepath);
        }
        gameStatKeys = statsDocument.Descendants("Stat")
                                    .Select(j => j.Attribute("statkey").Value)
                                    .ToList();
    }
}
