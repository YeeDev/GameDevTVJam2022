using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThingy : MonoBehaviour
{

    [SerializeField] KeyCode codeKey = KeyCode.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(codeKey))
        {
            Debug.Log(codeKey.ToString());
        }
    }
}
