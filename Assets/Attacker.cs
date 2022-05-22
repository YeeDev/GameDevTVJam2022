using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacker : MonoBehaviour
{
    //TODO Another way to search for it
    [SerializeField] Enemy currentEnemy = null;
    [SerializeField] CommandsSO commands = null;
    [SerializeField] Transform qTEBar = null;

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

        //TODO Use an event for this
        for (int i = 0; i < attackUsed.Commands.Length; i++)
        {
            qTEBar.GetChild(i).GetComponent<Image>().sprite = commands.GetSpriteByCommand(attackUsed.Commands[i]);
            qTEBar.GetChild(i).gameObject.SetActive(true);
        }
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

            KeyCode pressedKey = commands.GetValidKeyCode();
            if (pressedKey != KeyCode.None)
            {
                if (pressedKey != attackUsed.Commands[commandToCheck])
                {
                    Debug.Log($"QTE FAILED! {pressedKey} != {attackUsed.Commands[commandToCheck]}");
                    currentEnemy.DealDamage(attackUsed.PenaltyDamage);
                    ResetAttack();
                    return;
                }

                commandToCheck++;

                if (commandToCheck >= attackUsed.Commands.Length)
                {
                    Debug.Log("Attack Completed!");
                    currentEnemy.DealDamage(attackUsed.DamageDealt);
                    ResetAttack();
                }
            }
        }
    }

    private void ResetAttack()
    {
        qTETimeLimit = 0;
        commandToCheck = 0;
        isAttacking = false;

        foreach (Transform child in qTEBar)
        {
            child.gameObject.SetActive(false);
        }
    }
}
