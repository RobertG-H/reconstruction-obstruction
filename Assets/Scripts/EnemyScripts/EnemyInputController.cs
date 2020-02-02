using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyInputController : MonoBehaviour
{
    public EnemyController enemyController;

    public Fixable fixable;
    private float timer;
    private float targetTime;

    private int action = 0;
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
        if (!fixable.isActive) return;
        // enemyController.HandleHorizontal(1.0f);
        timer += Time.deltaTime;
        if (timer >= targetTime)
        {
            if (action == -1 || action == 1)
            {
                action = 0;
            }
            else
                action = Random.Range(-1, 2);

            enemyController.HandleHorizontal(action);
            targetTime = Random.Range(1.0f, 3.0f);
            timer = 0;
        }

    }

    public void StopEnemy()
    {
        Debug.Log("GOT HORZONTAL RAYCAST");
        return;
        enemyController.HandleHorizontal(0.0f);
        timer = 0;
    }
}