using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int totalCommands = 2;
    [SerializeField] float qTETime = 3f;

    int inputCommands;
    bool isAttacking;
    float qTETimeLimit;

    public void Attack()
    {
        Debug.Log("Attack Started!");
        isAttacking = true;
        qTETimeLimit = Time.realtimeSinceStartup + qTETime;
    }

    private void Update()
    {
        if (isAttacking)
        {
            if (Time.realtimeSinceStartup > qTETimeLimit)
            {
                Debug.Log("Attack FAILED!");
                ResetAttack();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                inputCommands++;

                if (inputCommands >= totalCommands)
                {
                    Debug.Log("Attack Completed!");
                    ResetAttack();
                }
            }
        }
    }

    private void ResetAttack()
    {
        qTETimeLimit = 0;
        inputCommands = 0;
        isAttacking = false;
    }
}
