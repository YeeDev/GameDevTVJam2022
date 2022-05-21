using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class AttackSO : ScriptableObject
{
    [SerializeField] float timeToExecute = 3f;
    [SerializeField] CommandTypes[] commands = null;
    [SerializeField] int damageDealt = 0;
    [SerializeField] int failedQTEPenalty = 0;

    public float TimeToExecute { get => timeToExecute; }
    public CommandTypes[] Commands { get => commands; }
    public int DamageDealt { get => damageDealt; }
    public int PenaltyDamage { get => damageDealt - failedQTEPenalty; }
}
