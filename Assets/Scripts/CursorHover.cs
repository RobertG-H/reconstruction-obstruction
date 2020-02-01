using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHover : MonoBehaviour
{
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start(){
	    textMesh = GetComponent<TextMesh>();
        textMesh.color = Color.black;
    }

    void OnMouseEnter(){
	    textMesh.color = Color.red;
    }

    void OnMouseExit() {
	    textMesh.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
