using UnityEngine;

public class PlayerController : MonoBehavior
{
    void Update() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertival") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Rotate(0,0,z);
    }
}
