using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    int commandToCheck;
    bool isAttacking;
    float qTETimeLimit;
    AttackSO attackUsed;


    public void Attack(AttackSO attack)
    {
        Debug.Log("Attack Started!");
        isAttacking = true;
        attackUsed = attack;
        qTETimeLimit = Time.realtimeSinceStartup + attack.TimeToExecute;
    }

    private void Update()
    {
        if (isAttacking)
        {
            if (Time.realtimeSinceStartup > qTETimeLimit)
            {
                Debug.Log("Attack FAILED!");
                ResetAttack();
                return;
            }

            CommandTypes currentCommand = ReadInputs();
            if (currentCommand != CommandTypes.NONE)
            {
                if (currentCommand != attackUsed.Commands[commandToCheck])
                {
                    Debug.Log($"QTE FAILED! {currentCommand} != {attackUsed.Commands[commandToCheck]}");
                    ResetAttack();
                    return;
                }

                commandToCheck++;

                if (commandToCheck >= attackUsed.Commands.Length)
                {
                    Debug.Log("Attack Completed!");
                    ResetAttack();
                }
            }
        }
    }

    //TODO Probably use KeyCodes Instead of this
    private CommandTypes ReadInputs()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) { return CommandTypes.Down; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { return CommandTypes.Up; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { return CommandTypes.Left; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { return CommandTypes.Right; }
        if (Input.GetKeyDown(KeyCode.L)) { return CommandTypes.Punch; }
        if (Input.GetKeyDown(KeyCode.K)) { return CommandTypes.Kick; }
        return CommandTypes.NONE;
    }

    private void ResetAttack()
    {
        qTETimeLimit = 0;
        commandToCheck = 0;
        isAttacking = false;
    }
}
