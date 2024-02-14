import random
from enemyList import enemyList
from namesDatabase import namesList


def GetEnemyStats():
    GetEnemyStats.tmpStats = round((random.random())*int(EnemyBattle.enemyLvl))
    if GetEnemyStats.tmpStats < 1:
        GetEnemyStats.tmpStats = 1
def EnemyBattle():
    EnemyBattle.enemyName = str(random.choice(namesList)+' '+random.choice(namesList))

    EnemyBattle.currentEnemy = enemyList[random.randint(0, len(enemyList)-1)]
    EnemyBattle.enemyLvl = random.randint(playerLvl-6, playerLvl+2)
    if EnemyBattle.enemyLvl < 1:
        EnemyBattle.enemyLvl = 1
    GetEnemyStats()
    EnemyBattle.enemyAtk = GetEnemyStats.tmpStats
    GetEnemyStats()
    EnemyBattle.enemyDef = GetEnemyStats.tmpStats
    GetEnemyStats()
    EnemyBattle.enemyEva = GetEnemyStats.tmpStats
    GetEnemyStats()
    EnemyBattle.enemyCrt = GetEnemyStats.tmpStats
    GetEnemyStats()
    EnemyBattle.enemyHP = round(GetEnemyStats.tmpStats*10.532976543)
    
#debug tests
playerLvl = 25
EnemyBattle()
print("Current Enemy: "+EnemyBattle.enemyName+" the "+str(EnemyBattle.currentEnemy))
print("EnemyLvl: "+str(EnemyBattle.enemyLvl))
print("Atk: "+str(EnemyBattle.enemyAtk))
print("Def: "+str(EnemyBattle.enemyDef))
print("Eva: "+str(EnemyBattle.enemyEva))
print("Crt: "+str(EnemyBattle.enemyCrt))
print("HP: "+str(EnemyBattle.enemyHP))