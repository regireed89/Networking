using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerNetwork : NetworkBehaviour
{

    public float speed;
    [SerializeField]
    private GameObject cameraGo;
    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            cameraGo.SetActive(false);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            cameraGo.SetActive(false);
            return;
        }
        var x = Input.GetAxis("Horizontal") * speed;
        var z = Input.GetAxis("Vertical") * speed;
        transform.Translate(x, 0, z);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            s.AddComponent<Rigidbody>();
            s.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 100);
        }
    }
}
