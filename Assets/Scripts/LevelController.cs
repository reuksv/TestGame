using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public delegate void WinAction();
    public static event WinAction OnWin;

    [SerializeField] int killToWin = 1;

    int killedEnemies = 0;

    void OnEnable()
    {
        Enemy.OnEnemyDied += OnEnemyDied;
    }

    void OnDisable()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;
    }

    void OnEnemyDied()
    {
        killedEnemies++;
        if (killedEnemies >= killToWin)
            Win();
    }

    void Win()
    {
        if (OnWin != null)
            OnWin();
    }
}
