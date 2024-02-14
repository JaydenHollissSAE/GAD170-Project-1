using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class holds the function for generating enemy stats.
/// </summary>
public class GetEnemyStats : MonoBehaviour
{
    void Start()
    {
        /// <summary>
        /// Creates a temporary stat for assignment.
        /// </summary>
    public int tmpStats = Math.Round((Random.Ragne(0f,1f))*float(enemyLvl));
    if (tmpStats < 1) {
        tmpstats = 1;
        }
    }
}
