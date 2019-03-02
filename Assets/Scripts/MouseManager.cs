using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static bool lockMouse = false;

    private bool isMouseLocked = false;

    void Update()
    {
        if (lockMouse && !isMouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;       // lock the cursor
            Cursor.visible = false;
            isMouseLocked = true;
        }
        else if (!lockMouse && isMouseLocked)
        {
            Cursor.lockState = CursorLockMode.None;         // unlock the cursor
            Cursor.visible = true;
            isMouseLocked = false;
        }
    }
}
