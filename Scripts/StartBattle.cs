using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class holds the function for the battle initiation sequence.
/// </summary>
public class StartBattle : MonoBehaviour
{
    void Start()
    {
        public string enemyName = namesList[Random.Range(0,namesList.Count-1)];
        public string currentEnemy = enemyList[Random.Range(0,enemyList.Count-1)];
        public int enemyLvl = Random.Range(playerLvl-6,playerLvl+1);
        if (enemyLvl < 1) {
            enemyLvl = 1;
        }
        GetEnemyStats.Start();
        public int enemyAtk = tmpStats;
        GetEnemyStats.Start();
        public int enemyDef = tmpStats;
        GetEnemyStats.Start();
        public int enemyEva = tmpStats;    
        GetEnemyStats.Start();
        public int enemyCrt = tmpStats;    
        GetEnemyStats.Start();
        public int enemyHP = Math.Round(tmpStats*10.532976543);    
    }
/*
    void Update()
    {

    }
*/


}