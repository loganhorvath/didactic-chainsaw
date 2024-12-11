using UnityEngine;
using UnityEngine.UI;

public class DynamicCrosshair : MonoBehaviour
{
    public RectTransform leftImage;  // Left crosshair image RectTransform
    public RectTransform rightImage; // Right crosshair image RectTransform
    public float baseOffset = 50f;   // Default distance from the center
    public float normalMovement = 20f; // Outward movement when WASD is pressed
    public float sprintMultiplier = 1.5f; // Multiplier for movement when Shift is held
    public float jumpMultiplier = 2f;    // Multiplier for movement when Space is pressed

    void Update()
    {
        // Base offset for the crosshair
        float offset = baseOffset;

        // Check if WASD keys are pressed
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Adjust movement for sprinting (Shift)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            offset += normalMovement * sprintMultiplier;
        }
        // Adjust movement for jumping (Space)
        else if (Input.GetKey(KeyCode.Space))
        {
            offset += normalMovement * jumpMultiplier;
        }
        // Adjust movement for normal WASD movement
        else if (isMoving)
        {
            offset += normalMovement;
        }

        // Update crosshair positions
        leftImage.anchoredPosition = new Vector2(-offset, 0);
        rightImage.anchoredPosition = new Vector2(offset, 0);
    }
}
