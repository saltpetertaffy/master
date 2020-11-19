using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string EnemyId;
    [SerializeField] protected GameObject attack;
    [SerializeField] protected GameObject attackPoint;

    protected UpgradeHandler upgradeHandler;

    protected void Start() {
        upgradeHandler = GetComponent<UpgradeHandler>();
        LoadEnemy(EnemyId);
    }

    public GameObject GetAttack() {
        return attack;
    }

    public void SetAttack(GameObject attack) {
        this.attack = attack;
    }

    public abstract void Attack();

    protected void LoadEnemy(string enemyId) {
        List<string> upgradeIds = new List<string>();
        string upgradesFilepath = Directory.GetCurrentDirectory() + "\\Enemies\\Enemies.xml";

        XDocument upgrades = XDocument.Load(upgradesFilepath);
        if (upgrades != null && upgrades.Descendants("Enemy") != null) {
            upgradeIds = upgrades.Descendants("Enemy").Where(i => i.Attribute("id").Value == enemyId)
                                                      .Descendants("UpgradeId")
                                                      .Select(j => j.Attribute("id").Value)
                                                      .ToList();
        }
        upgradeHandler.LoadUpgrades(upgradeIds);
    }
}
