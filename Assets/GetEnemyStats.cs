/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class holds the function for generating enemy stats.
/// </summary>
public class GetEnemyStats : MonoBehaviour
{
    public int tmpStats;
    public int enemyLvl;
    public void GetEnemyStatsFunc()
    {
        /// <summary>
        /// Creates a temporary stat for assignment.
        /// </summary>
        int tmpStats = (int)Mathf.Round((Random.Range(0f,1f))*enemyLvl);
        if (tmpStats < 1) {
            tmpStats = 1;
        }
    }
}
*/