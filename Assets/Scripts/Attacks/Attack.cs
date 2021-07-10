using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public abstract class Attack : EffectSet 
{
    protected Collider2D attackCollider;
    protected GameStatHandler gameStatHandler;
    protected string targetLayer;

    private void Awake() {
        attackCollider = GetComponent<Collider2D>();
        gameStatHandler = GetComponent<GameStatHandler>();
        LoadAttack();
    }

    protected abstract void OnHit(Collider2D collision);

    private void LoadAttack() {
        string charactersFilepath = Directory.GetCurrentDirectory() + "\\xml\\Attacks.xml";

        XDocument charactersDocument = XDocument.Load(charactersFilepath);
        if (charactersDocument == null) {
            throw new FileNotFoundException("File not found: " + charactersFilepath);
        }

    }
}
