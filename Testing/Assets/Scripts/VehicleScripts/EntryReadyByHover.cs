using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryReadyByHover : MonoBehaviour {

    void OnMouseOver()
    {
        //GameManager.hoveredObject = gameObject.tag;
    }

    private void OnMouseExit()
    {
        GameManager.hoveredObject = "";
    }

    private void OnMouseEnter()
    {
        GameManager.hoveredObject = gameObject.tag;
    }
}
