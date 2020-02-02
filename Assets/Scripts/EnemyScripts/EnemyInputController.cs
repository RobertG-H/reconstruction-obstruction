using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyInputController : MonoBehaviour
{
    public EnemyController enemyController;
    private float timer;
    private float targetTime;

    void OnEnable()
    {

        EnemyController.OnHorzRayCast += StopEnemy;
    }

    void OnDisable()
    {
        EnemyController.OnHorzRayCast -= StopEnemy;
    }

    private void Start()
    {
        timer = 0;
        targetTime = Random.Range(1.0f, 3.0f);

    }
    private void Update()
    {
        // enemyController.HandleHorizontal(1.0f);
        timer += Time.deltaTime;
        if(timer >= targetTime)
        {
            int action = Random.Range(-1, 1);
            enemyController.HandleHorizontal(action);
            targetTime = Random.Range(1.0f, 3.0f);
            timer = 0;
        }

    }

    public void StopEnemy()
    {
        return;
        enemyController.HandleHorizontal(0.0f);
        timer = 0;
    }
}