using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class AttackSO : ScriptableObject
{
    [SerializeField] float timeToExecute = 3f;
    [SerializeField] CommandTypes[] commands = null;

    public float TimeToExecute { get => timeToExecute; }
    public CommandTypes[] Commands { get => commands; }
}
