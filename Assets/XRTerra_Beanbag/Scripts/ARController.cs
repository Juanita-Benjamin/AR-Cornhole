using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation; //gives access to AR classes
using UnityEngine.Events;

[SerializeField]
public class BooleanEvent: UnityEvent<bool>{}
public class ARController : MonoBehaviour
{
    //manages the lifecycle of AR
    public ARSession aRSession;
    
    public ARSessionOrigin aRSessionOrigin;
    
    public ARPlaneManager planeManager;

    public GameObject scanUI;
    
    public static BooleanEvent OnARRunning = new BooleanEvent();
    // Start is called before the first frame update
    
    
    void Awake()
    {
        
        //base.Awake();
        
        //refer to 1:21:40 for why it is written this way
        ARController.OnARRunning.AddListener(ARListener);
    }
    void Start()
    {
        StartCoroutine(WaitForAr());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForAr()
    {
        bool checking = true;

        while (checking)
        {
            if (ARSession.state == ARSessionState.Unsupported)
            {
                ScreenLog.Log("AR not supported on device");
                yield break;
            }

            if (ARSession.state >= ARSessionState.Ready)
            {
                checking = false;
            }

            yield return null;
        }
        
        ScreenLog.Log("AR Supported");

        PromptToScan(true);

        //looking for planes by trackingn them
        while (planeManager.trackables.count == 0)
        {
            yield return null;
        }
        PromptToScan(false);
        ScreenLog.Log("Tracking Planes");
        
        OnARRunning.Invoke(true);
    }

    public void PromptToScan(bool show)
    {
        scanUI.SetActive(show);
    }

    private void ARListener(bool ar)
    {
        ScreenLog.Log("AR Listener: " + ar);
       // PlaceBoard
    }
}
