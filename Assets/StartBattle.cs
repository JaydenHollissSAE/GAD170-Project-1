using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class holds the function for the battle initiation sequence.
/// </summary>
public class StartBattle : MonoBehaviour
{
    GetEnemyStats GetEnemyStatsFunc;

    public string enemyName;
    public string currentEnemy;
    public int enemyLvl;
    public int enemyStats;
    public int enemyAtk;
    public int enemyDef;
    public int enemyEva;
    public int enemyCrt;
    public int enemyHP;
    public int tmpStats;
    public string[] namesList;
    public string[] enemyList;
    public int playerLvl;

    private void Start()
    {
        string[] enemyList = { "Test1", "Test2", "Test3" };
        StartBattleFunc();
        Debug.Log("Current Enemy: " + enemyName + " the " + currentEnemy);
        Debug.Log("EnemyLvl: " + enemyLvl.ToString());
        Debug.Log("Atk: " + enemyAtk);
        Debug.Log("Def: " + enemyDef.ToString());
        Debug.Log("Eva: " + enemyEva.ToString());
        Debug.Log("Crt: " + enemyCrt.ToString());
        Debug.Log("HP: " + enemyHP.ToString());
    }

    public void StartBattleFunc()
    {
        string enemyName = namesList[Random.Range(0, namesList.Length-1)];
        string currentEnemy = enemyList[Random.Range(0, enemyList.Length - 1)];
        int enemyLvl = Random.Range(playerLvl-6,playerLvl+1);
        if (enemyLvl < 1) {
            enemyLvl = 1;
        }
        int tmpStats = 1;
        GetEnemyStats.GetEnemyStatsFunc();
        int enemyAtk = tmpStats;
        GetEnemyStats.GetEnemyStatsFunc();
        int enemyDef = tmpStats;
        GetEnemyStats.GetEnemyStatsFunc();
        int enemyEva = tmpStats;
        GetEnemyStats.GetEnemyStatsFunc();
        int enemyCrt = tmpStats;
        GetEnemyStats.GetEnemyStatsFunc();
        int enemyHP = (int)Mathf.Round((float)(tmpStats * 10.532976543));    
    }
}