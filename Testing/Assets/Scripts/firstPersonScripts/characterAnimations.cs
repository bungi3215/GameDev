using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimations : MonoBehaviour {

    // Update is called once per frame

    Animator playerCharacter;

    void Start()
    {
        playerCharacter = GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetButtonDown("Vertical"))
        {
            playerCharacter.Play("walk");

        }
	}
}
