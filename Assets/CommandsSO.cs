using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Commands Info", menuName = "Commands Info")]
public class CommandsSO : ScriptableObject
{
    [SerializeField] List<KeyCode> commandKeyCodes = null;

    public KeyCode GetValidKeyCode()
    {
        foreach (KeyCode key in commandKeyCodes)
        {
            if (Input.GetKeyDown(key)) { return key; }
        }

        return KeyCode.None;
    }
}
