using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text textUI = GameObject.Find("Canvas/textEngine").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
