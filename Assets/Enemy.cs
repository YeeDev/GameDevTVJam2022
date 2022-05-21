using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 10;

    public void DealDamage(int damageDealt)
    {
        health -= damageDealt;
        Debug.Log($"I took {damageDealt}, I onlye have {health} health remaining");
    }
}
