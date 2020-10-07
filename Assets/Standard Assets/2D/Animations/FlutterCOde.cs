using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlutterCOde : MonoBehaviour

{
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed*Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
