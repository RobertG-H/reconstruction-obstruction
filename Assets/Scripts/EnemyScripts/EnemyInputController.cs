using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyInputController : MonoBehaviour
{
    public EnemyController enemyController;
    private int counter;

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
        counter = 0;

    }
    private void Update()
    {
        counter += 1;
        if (counter == 200)
        {
            //Random.Range(0.0f, 1.0f);
            enemyController.HandleHorizontal(1.0f);
        }
        else if (counter == 350)
        {
            enemyController.HandleHorizontal(0.0f);

        }
        else if (counter == 450)
        {
            enemyController.HandleHorizontal(-1.0f);
        }
        else if (counter == 600)
        {
            enemyController.HandleHorizontal(0.0f);
            counter = 0;
        }
    }

    public void StopEnemy()
    {
        return;
        enemyController.HandleHorizontal(0.0f);
        counter = 0;
    }
}