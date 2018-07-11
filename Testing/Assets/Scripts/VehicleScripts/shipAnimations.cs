using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipAnimations : MonoBehaviour {

    public ParticleSystem thrustersForward;
    public ParticleSystem thrustersBackward;
    public ParticleSystem thrustersTop;
    public ParticleSystem thrustersBottom;
    public ParticleSystem thrustersLeft;
    public ParticleSystem thrustersRight;
    private GameObject gameData;

    // Update is called once per frame

    void Update () {

        var inside = GameManager.isInsideVehicle;

        if(inside == true)
        {
            var verticalThruster = Input.GetAxis("Vertical");
            var HorizontalThruster = Input.GetAxis("Horizontal");
            var lateralThrusters = Input.GetAxis("lift");

            /**
             * Forward / backward
            **/
            if (verticalThruster > 0)
            {
                thrustersForward.Play();
            }
            else if (verticalThruster < 0)
            {
                thrustersBackward.Play();
            }
            else {
                thrustersForward.Stop();
                thrustersBackward.Stop();
            }

            /**
             * Up / Down
            **/
            
            if (lateralThrusters > 0)
            {
                thrustersBottom.Play();
            }
            else if (lateralThrusters < 0)
            {
                thrustersTop.Play();
            }
            else
            {
                thrustersTop.Stop();
                thrustersBottom.Stop();
            }

            /**
             * Sides
            **/
            if (HorizontalThruster > 0)
            {
                thrustersLeft.Play();
            }
            else if (HorizontalThruster < 0)
            {
                thrustersRight.Play();
            }
            else
            {
                thrustersRight.Stop();
                thrustersLeft.Stop();
            }
        }
    }
}
