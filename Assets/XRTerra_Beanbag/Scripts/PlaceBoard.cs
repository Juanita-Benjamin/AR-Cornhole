using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
public class PlaceBoard : Singleton<PlaceBoard>
{

    public GameObject boardPrefab;

    public GameObject placeBoardUIPrompt;

    private ARRaycastManager _arRaycastManager;

    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Camera _Camera;

    public bool isPlacing;

    private GameObject _board;
    // Start is called before the first frame update
    void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void startPlacingBoard()
    {
        if (!_Camera)
        {
            _Camera = Camera.main;
        }
        PromptToPlace(true);
        isPlacing = true;
    }
    private void PromptToPlace(bool show)
    {
        placeBoardUIPrompt.SetActive(show);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlacing)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (_arRaycastManager.Raycast(touch.position, _hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitpose = _hits[0].pose;

                    if (_board == null)
                    {
                        _board = Instantiate(boardPrefab, hitpose.position, hitpose.rotation);
                    }

                    else
                    {
                        _board.transform.position = hitpose.position;
                    }
                    
                    _board.transform.LookAt(_Camera.transform.position);
                    _board.transform.eulerAngles = new Vector3(0, _board.transform.eulerAngles.y-180, 0);

                    isPlacing = false;
                    PromptToPlace(false);
                }
            }
        }
    }
}
