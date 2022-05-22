using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Commands Info", menuName = "Commands Info")]
public class CommandsSO : ScriptableObject
{
    [SerializeField] List<KeyCode> commandKeyCodes = null;
    [SerializeField] List<Sprite> commandSprites = null;

    Dictionary<KeyCode, Sprite> commandsToSprites = new Dictionary<KeyCode, Sprite>();

    private void OnEnable()
    {
        for (int i = 0; i < commandKeyCodes.Count; i++)
        {
            commandsToSprites.Add(commandKeyCodes[i], commandSprites[i]);
        }
    }

    public KeyCode GetValidKeyCode()
    {
        foreach (KeyCode key in commandKeyCodes)
        {
            if (Input.GetKeyDown(key)) { return key; }
        }

        return KeyCode.None;
    }

    public Sprite GetSpriteByCommand(KeyCode keyCode) {
        Debug.Log(commandsToSprites.Count);
        return commandsToSprites[keyCode]; }
}
