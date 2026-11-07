using UnityEngine;
using UnityEngine.InputSystem;

public class switch_script : MonoBehaviour
{
    public Camera cam;
    public Collider light_switch;
    public BladeScript bs;

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100f)) { // ray, hit info, max detection distance
                if (hit.collider == light_switch) {
                    Debug.Log("on/off triggered");

                    bs.bladeactive = !bs.bladeactive;

                    if (bs.bladeactive)
                    {
                        bs.interpolationval = Mathf.Abs(bs.interpolationval);
                        bs.blade.SetActive(true);
                    }
                    else { 
                        bs.interpolationval= -Mathf.Abs(bs.interpolationval);
                    }
                }
            }

        }
    }
}
