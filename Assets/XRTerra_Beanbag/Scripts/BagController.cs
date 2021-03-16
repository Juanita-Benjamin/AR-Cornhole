using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARCore;

public class BagController : MonoBehaviour
{
    public GameObject beanBag;
    public Transform throwLocation;

    private GameObject _bagsContainer;

    public float throwSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _bagsContainer = new GameObject("Bags Container");
    }

    public void ThrowBag()
    {
        var bag= Instantiate(beanBag, throwLocation,_bagsContainer);
        bag.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwSpeed, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
