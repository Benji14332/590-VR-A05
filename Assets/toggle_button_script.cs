using UnityEngine;
using UnityEngine.InputSystem;

public class toggle_button_script : MonoBehaviour
{
    public Camera cam;
    public Collider colorbutton;
    public Renderer bladerenderer;

    public Material bladematerial;
    public int i;

    public Color[] colors = {
        Color.red, Color.blue, Color.green
    };

    private void Start()
    {
        bladematerial = bladerenderer.material;
        i = 0;
    }

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            { // ray, hit info, max detection distance

                if (hit.collider == colorbutton) {
                    i = (i + 1) % 3;

                    bladematerial.SetColor("_BladeColor", colors[i]); //change in shader graph
                }
                
            }

        }
    }
}
