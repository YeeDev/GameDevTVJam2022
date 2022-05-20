using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    enum CommandType { Up, Down, Left, Right, NONE }

    [SerializeField] float qTETime = 3f;
    [SerializeField] CommandType[] commands = null;

    int commandToCheck;
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

            CommandType currentCommand = ReadInputs();
            if (currentCommand != CommandType.NONE)
            {
                if (currentCommand != commands[commandToCheck])
                {
                    Debug.Log("QTE FAILED!");
                    ResetAttack();
                }

                commandToCheck++;

                if (commandToCheck >= commands.Length)
                {
                    Debug.Log("Attack Completed!");
                    ResetAttack();
                }
            }
        }
    }

    private CommandType ReadInputs()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) { return CommandType.Down; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { return CommandType.Up; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { return CommandType.Left; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { return CommandType.Right; }
        return CommandType.NONE;
    }

    private void ResetAttack()
    {
        qTETimeLimit = 0;
        commandToCheck = 0;
        isAttacking = false;
    }
}
