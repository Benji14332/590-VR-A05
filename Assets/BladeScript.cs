using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BladeScript : MonoBehaviour
{
    public float extendspeed = 0.01f;
    public GameObject blade;

    public bool bladeactive;
    public float smin;
    public float smax;
    public float interpolationval;

    public float currentscale;

    public float localsx;
    public float localsz;

    void Start() {
        localsx = transform.localScale.x;
        localsz = transform.localScale.z;

        smax = transform.localScale.y;
        currentscale = smax;

        interpolationval = smax / extendspeed;

        bladeactive = true;


    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            bladeactive = !bladeactive;

            if (bladeactive)
            {
                interpolationval = Mathf.Abs(interpolationval);
                blade.SetActive(true);
            }
            else { 
            interpolationval= -Mathf.Abs(interpolationval);
            }
        }

        currentscale += interpolationval * Time.deltaTime;
        //change per delta time

        currentscale = Mathf.Clamp(currentscale,smin,smax);

        //apply the change
        transform.localScale = new Vector3(localsx, currentscale, localsz);

        if (blade != null) {
            if (!bladeactive && currentscale <= smin) {
                blade.SetActive(false);
            }
        }//hide when off
    }
}
