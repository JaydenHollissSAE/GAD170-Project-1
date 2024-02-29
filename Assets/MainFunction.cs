using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public int searchAmount;
    public string searchText;
    public string narCol = "<color=#CEA200>";
    public string plCol = "<color=#3C78EF>";
    public string enCol = "<color=#CB0606>";
    public string endCol = "</color>";
    public bool searchStatus = true;
    public bool BattleWon = false;
    public int expObtained;
    public int expNeeded = 20;
    public bool lvlUp = false;

    public void Start()
    {
        Debug.Log(narCol + "Welcome to Fishing!" + endCol);
        Debug.Log(narCol + "Controls: E = Enemy Stats, P = Player Stats, A = Attack" + endCol);
        playerLvl = 1;
        GetPlayerStatsFunc();
        GetEnemyStatsFunc();
        MainSequence();
    }

    public void MainSequence()
    {
        BattleWon = false;
        Debug.Log(narCol + "Begin Fishing" + endCol);
        EnemySearch();
        StartBattle();
    }

    public void Update()
    {
        if (BattleWon)
        {
            GetEnemyStatsFunc();
            if (lvlUp)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    GetPlayerStatsFunc();
                    lvlUp = false;
                    Debug.Log(narCol + "Stats Rerolled" + endCol);
                    Debug.Log(narCol + "Continue Fishing? (Y/N)" + endCol);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    lvlUp = false;
                    Debug.Log(narCol + "Continue Fishing? (Y/N)" + endCol);
                }
            }
            else 
            { 
                if (Input.GetKeyDown(KeyCode.Y)) 
                {
                    if (playerHP <= 0)
                    {
                        Start();
                    }
                    else
                    {
                        MainSequence();
                    }
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    Debug.Log(narCol + "Thank you for Fishing today!" + endCol);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (searchStatus)
        {
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log(narCol + "Displaying Player Stats" + endCol);
                    ViewStatsPlayer();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(narCol + "Displaying Enemy Stats" + endCol);
                    ViewStatsEnemy();
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    BattlePhase();
                }
            }
        }
    }
    public void BattlePhase()
    {
        Debug.Log(narCol + "You attack!" + endCol);
        if (((Random.Range(0.0f, enemyEva * 10f) / 100) != 0.4))
        {
            enemyHP = (int)(enemyHP - (playerAtk * (enemyDef * 0.01)));
            if ((Random.Range(0.0f, playerCrt * 10f)) / 100 == 0.4)
            {
                enemyHP = (int)(enemyHP - (playerAtk * (enemyDef * 0.01)));
                Debug.Log(narCol + "Critical Hit!" + endCol);
            }
        }
        else 
        {
            Debug.Log(narCol + "The attack missed!" + endCol);
        }
        Debug.Log(narCol + "The enemy strickes back!" + endCol);
        if (((Random.Range(0.0f, playerEva * 10f) / 100) != 0.4))
        {
            playerHP = (int)(playerHP - (enemyAtk * (playerDef * 0.01)));
            if ((Random.Range(0.0f, playerCrt * 10f)) / 100 == 0.4)
            {
                playerHP = (int)(playerHP - (enemyAtk * (playerDef * 0.01)));
                Debug.Log(narCol + "Critical Hit!" + endCol);
            }
        }
        else
        {
            Debug.Log(narCol + "The attack missed!" + endCol);
        }
        if (enemyHP <= 0) 
        {
            Debug.Log(narCol + "Enemy Defeated!" + endCol);
            expObtained = Random.Range(20+enemyLvl, 20+(enemyLvl*10));
            BattleWon = true;
            if (expObtained >= expNeeded) 
            {
                Debug.Log(narCol + "Leveled Up!" + endCol);
                playerLvl += 1;
                lvlUp = true;
                Debug.Log(narCol + "Reroll Player Stats (HP will not be recovered if stats are kept)? (Y/N)" + endCol);

            }
        }
        if (playerHP <= 0)
        {
            Debug.Log(narCol + "You were defeated" + endCol);
            BattleWon = true;
            Debug.Log(narCol + "Continue Fishing? (Y/N)" + endCol);
        }
    }



    public void ViewStatsPlayer()
    {
        Debug.Log(plCol + "Player Lvl: " + playerLvl + endCol);
        Debug.Log(plCol + "Player Atk: " + playerAtk + endCol);
        Debug.Log(plCol + "Player Def: " + playerDef + endCol);
        Debug.Log(plCol + "Player Eva: " + playerEva + endCol);
        Debug.Log(plCol + "Player Crt: " + playerCrt + endCol);
        Debug.Log(plCol + "Player HP: " + playerHP + endCol);
    }

    public void ViewStatsEnemy()
    {
        Debug.Log(enCol + "Enemy Lvl: " + enemyLvl + endCol);
        Debug.Log(enCol + "Enemy Atk: " + enemyAtk + endCol);
        Debug.Log(enCol + "Enemy Def: " + enemyDef + endCol);
        Debug.Log(enCol + "Enemy Eva: " + enemyEva + endCol);
        Debug.Log(enCol + "Enemy Crt: " + enemyCrt + endCol);
        Debug.Log(enCol + "Enemy HP: " + enemyHP + endCol);
    }

    public void EnemySearch()
    {
        searchStatus = false;
        searchText = "";
        searchAmount = Random.Range(5, 15);
        for (int i = 0; i < searchAmount; i++)
        {
            if (i != 0)
            {
                if (i % 3 == 0)
                {
                    searchText += " ";
                }
            }
            searchText += ".";
            Debug.Log(narCol + searchText + endCol);
        }
        searchStatus = true;
    }

    public void StartBattle()
    {
       if (enemyLvl > playerLvl)
        {
            currentEnemy = "a big one, this will be tough!";
        }
       else if (enemyLvl < playerLvl) {
            currentEnemy = "a small one, should be an easy catch!";
        }
       else
        {
            currentEnemy = "around your level, can you handle this?";
        }
        Debug.Log("<color=#CEA200>It's " + currentEnemy + "</color>");
    }

    public void GetEnemyStatsFunc()
    {
        enemyLvl = Random.Range(playerLvl - 6, playerLvl + 1);
        if (enemyLvl < 1)
        {
            enemyLvl = 1;
        }
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
