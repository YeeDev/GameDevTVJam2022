using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int totalCommands = 2;

    public void Attack()
    {
        StartCoroutine(ReadQTE());
    }

    IEnumerator ReadQTE()
    {
        Debug.Log("Attack Starts!");

        for (int i = 0; i < totalCommands; i++)
        {
            yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.L));
            Debug.Log("Hi!");
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("QTE Completed");
    }
}
