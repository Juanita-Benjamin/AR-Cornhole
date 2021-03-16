using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenLog : Singleton<ScreenLog>
{

    public static TextMeshPro textLog;
    // Start is called before the first frame update
    void Start()
    {
        textLog.text = "";
    }

    //if something isn't displaying refer to 2/17/21 XRT, 53:18
    public static void Log(string message)
    {
        if (message[0] != '\n')
        {
            message = '\n' + message;
        }

        textLog.text += message;
        Debug.Log(message);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
