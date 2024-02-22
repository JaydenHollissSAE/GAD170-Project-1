using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFunction : MonoBehaviour
{

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
    public int lvlBuffer;
    public int playerStats;
    public int playerAtk;
    public int playerDef;
    public int playerEva;
    public int playerCrt;
    public int playerHP;

    private void Start()
    {
        playerLvl = 3;
        GetPlayerStatsFunc();
        //string[] enemyList = { "Test1", "Test2", "Test3" };
        GetEnemyStatsFunc();
        //Debug.Log("Current Enemy: " + enemyName + " the " + currentEnemy);
        Debug.Log("Player Lvl: " + playerLvl);
        Debug.Log("Player Atk: " + playerAtk);
        Debug.Log("Player Def: " + playerDef);
        Debug.Log("Player Eva: " + playerEva);
        Debug.Log("Enemv Crt: " + playerCrt);
        Debug.Log("Player HP: " + playerHP);
        Debug.Log("Enemy Lvl: " + enemyLvl);
        Debug.Log("Enemy Atk: " + enemyAtk);
        Debug.Log("Enemy Def: " + enemyDef);
        Debug.Log("Enemy Eva: " + enemyEva);
        Debug.Log("Enemy Crt: " + enemyCrt);
        Debug.Log("Enemy HP: " + enemyHP);
    }

    public void Update()
    {
        

    }




    public void GetEnemyStatsFunc()
    {
        //string enemyName = namesList[Random.Range(0, namesList.Length - 1)];
        //string currentEnemy = enemyList[Random.Range(0, enemyList.Length - 1)];
        enemyLvl = Random.Range(playerLvl - 6, playerLvl + 1);
        if (enemyLvl < 1)
        {
            enemyLvl = 1;
        }
        Debug.Log("Run Stats");
        lvlBuffer = enemyLvl;
        GetStatsFunc();
        enemyAtk = tmpStats;
        GetStatsFunc();
        enemyDef = tmpStats;
        GetStatsFunc();
        enemyEva = tmpStats;
        GetStatsFunc();
        enemyCrt = tmpStats;
        GetStatsFunc();
        enemyHP = (int)Mathf.Round((float)(tmpStats * 10.532976543));

    }

    public void GetStatsFunc()
    {
        /// <summary>
        /// Creates a temporary stat for assignment.
        /// </summary>
        tmpStats = (int)Mathf.Round((Random.Range(0f, 1f)) * lvlBuffer);
        if (tmpStats < 1)
        {
            tmpStats = 1;
        }
    }

    public void GetPlayerStatsFunc()
    {
        lvlBuffer = playerLvl;
        GetStatsFunc();
        playerAtk = tmpStats;
        GetStatsFunc();
        playerDef = tmpStats;
        GetStatsFunc();
        playerEva = tmpStats;
        GetStatsFunc();
        playerCrt = tmpStats;
        GetStatsFunc();
        playerHP = (int)Mathf.Round((float)(tmpStats * 15.532976543));
    }
}
