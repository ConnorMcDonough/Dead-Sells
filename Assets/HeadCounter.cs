using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCounter : MonoBehaviour
{
    public Text txt;
    public int counter =0;

    void Start () {
        txt.text=": 0";
    }

    public void addHeadCount() {
        counter++;
        txt.text=": "+counter;
    }
    
}
