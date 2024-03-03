using OpenCover.Framework.Model;
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
    public bool battleWon = false;
    public int expObtained;
    public int expNeeded = 20;
    public bool lvlUp = false;
    public int currentplayerHP;

    public void Start()
    {
        /// <summary>
        /// Begins the game.
        /// </summary>
        Debug.Log(narCol + "Welcome to Fishing!" + endCol);
        Debug.Log(narCol + "Controls: E = Enemy Stats, P = Player Stats, A = Attack" + endCol);
        playerLvl = 1;
        GetPlayerStatsFunc();
        GetEnemyStatsFunc();
        MainSequence();
    }

    public void MainSequence()
    {
        /// <summary>
        /// The main sequence of events in the game to be repeated.
        /// </summary>
        battleWon = false;
        Debug.Log(narCol + "Begin Fishing" + endCol);
        EnemySearch();
        StartBattle();
    }

    public void Update()
    {
        /// <summary>
        /// Gameplay logic that constantly runs.
        /// </summary>
        if (battleWon)
        {
            /// <summary>
            /// Runs if a battle was won. Sets up for next battle or purges game based on input.
            /// </summary>
            GetEnemyStatsFunc();
            if (lvlUp)
            {
                /// <summary>
                /// Determines based on player input if the player stats reroll or not when a level up occurs.
                /// </summary>
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
                /// <summary>
                /// Determines if the game continues or not based on player input.
                /// </summary>
                if (Input.GetKeyDown(KeyCode.Y)) 
                {
                    /// <summary>
                    /// Restarts sequence based on if player is alive or not.
                    /// </summary>
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
                    /// <summary>
                    /// Purges can sequence to end the game.
                    /// </summary>
                    Debug.Log(narCol + "Thank you for Fishing today!" + endCol);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (searchStatus)
        {
            /// <summary>
            /// Determines gameplay actions based on player input.
            /// </summary>
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
        /// <summary>
        /// Runs logic for battle damage.
        /// </summary>
        /// <summary>
        /// Player turn.
        /// </summary>
        Debug.Log(narCol + "You attack!" + endCol);
        if (Random.Range(0, 100) > enemyEva)
        {
            /// <summary>
            /// Deals damage if the enemy didn't evade the attack.
            /// </summary>
            enemyHP = (int)(enemyHP - (playerAtk * (enemyDef * 0.01)));
            if (Random.Range(0, 100) < playerCrt)
            {
                /// <summary>
                /// Deals damage again for a critical hit.
                /// </summary>
                enemyHP = (int)(enemyHP - (playerAtk * (enemyDef * 0.01)));
                Debug.Log(narCol + "Critical Hit!" + endCol);
            }
        }
        else 
        {
            Debug.Log(narCol + "The attack missed!" + endCol);
        }
        /// <summary>
        /// Enemy turn.
        /// </summary>
        Debug.Log(narCol + "The enemy strickes back!" + endCol);
        if (Random.Range(0, 100) > playerEva)
        {
            /// <summary>
            /// Deals damage if the player didn't evade the attack.
            /// </summary>
            playerHP = (int)(playerHP - (enemyAtk * (playerDef * 0.01)));
            if (Random.Range(0, 100) < enemyCrt)
            {
                /// <summary>
                /// Deals damage again for a critical hit.
                /// </summary>
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
            /// <summary>
            /// Runs enemy defeated sequence.
            /// </summary>
            Debug.Log(narCol + "Enemy Defeated!" + endCol);
            expObtained = Random.Range(20+enemyLvl, 20+(enemyLvl*10));
            battleWon = true;
            if (expObtained >= expNeeded) 
            {
                /// <summary>
                /// Sets stage for level up sequence.
                /// </summary>
                Debug.Log(narCol + "Leveled Up!" + endCol);
                expObtained = expObtained - expNeeded;
                playerLvl += 1;
                lvlUp = true;
                Debug.Log(narCol + "Reroll Player Stats? (Y/N)" + endCol);
                playerHP = currentplayerHP - playerHP;
            }
        }
        else if (playerHP <= 0)
        {
            /// <summary>
            /// Runs player defeated sequence.
            /// </summary>
            Debug.Log(narCol + "You were defeated" + endCol);
            battleWon = true;
            Debug.Log(narCol + "Continue Fishing? (Y/N)" + endCol);
        }
    }



    public void ViewStatsPlayer()
    {
        /// <summary>
        /// Displays current player stats.
        /// </summary>
        Debug.Log(plCol + "Player Lvl: " + playerLvl + endCol);
        Debug.Log(plCol + "Player Atk: " + playerAtk + endCol);
        Debug.Log(plCol + "Player Def: " + playerDef + endCol);
        Debug.Log(plCol + "Player Eva: " + playerEva + endCol);
        Debug.Log(plCol + "Player Crt: " + playerCrt + endCol);
        Debug.Log(plCol + "Player HP: " + playerHP + endCol);
    }

    public void ViewStatsEnemy()
    {
        /// <summary>
        /// Displays current enemy stats.
        /// </summary>
        Debug.Log(enCol + "Enemy Lvl: " + enemyLvl + endCol);
        Debug.Log(enCol + "Enemy Atk: " + enemyAtk + endCol);
        Debug.Log(enCol + "Enemy Def: " + enemyDef + endCol);
        Debug.Log(enCol + "Enemy Eva: " + enemyEva + endCol);
        Debug.Log(enCol + "Enemy Crt: " + enemyCrt + endCol);
        Debug.Log(enCol + "Enemy HP: " + enemyHP + endCol);
    }

    public void EnemySearch()
    {
        /// <summary>
        /// Runs enemy search sequence.
        /// </summary>
        searchStatus = false;
        searchText = "";
        searchAmount = Random.Range(5, 15);
        for (int i = 0; i < searchAmount; i++)
        {
            /// <summary>
            /// Repeats search text randomly.
            /// </summary>
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
        /// <summary>
        /// Gives player a hint about the level of the enemy at the start of a battle.
        /// </summary>
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
        /// <summary>
        /// Assigns stats for enemy.
        /// </summary>
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
        if (enemyEva > 60)
        {
            enemyEva = Random.Range(0, 60);
        }
        GetStatsFunc();
        enemyCrt = tmpStats;
        if (enemyCrt > 75)
        {
            enemyCrt = Random.Range(0, 75);
        }
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
        /// <summary>
        /// Assigns stats for player.
        /// </summary>
        lvlBuffer = playerLvl;
        GetStatsFunc();
        playerAtk = tmpStats;
        GetStatsFunc();
        playerDef = tmpStats;
        GetStatsFunc();
        playerEva = tmpStats;
        if (playerEva > 60)
        {
            playerEva = Random.Range(0, 60);
        }
        GetStatsFunc();
        playerCrt = tmpStats;
        if (playerCrt > 75)
        {
            playerCrt = Random.Range(0, 75);
        }
        GetStatsFunc();
        playerHP = (int)Mathf.Round((float)(tmpStats * 15.532976543));
        currentplayerHP = playerHP;
        ViewStatsPlayer();
    }
}
