using UnityEngine;
using UnityEngine.UI;

public class DynamicCrosshair : MonoBehaviour
{
    public RectTransform leftImage;  // Left crosshair image
    public RectTransform rightImage; // Right crosshair image
    public float baseOffset = 50f;   // Base distance from the center
    public float accuracyFactor = 2f; // Multiplier for movement based on gun's inaccuracy

    private float movementAmount = 0f; // Current movement based on inaccuracy

    void Update()
{
    // Get player speed and calculate movement amount
    float playerSpeed = GetPlayerSpeed();
    float gunAccuracy = Mathf.Clamp01(1f - playerSpeed * 0.1f);
    movementAmount = (1f - gunAccuracy) * accuracyFactor;

    // Log values for debugging
    Debug.Log($"Player Speed: {playerSpeed}, Gun Accuracy: {gunAccuracy}, Movement Amount: {movementAmount}");

    // Adjust positions of crosshair images
    leftImage.anchoredPosition = new Vector2(-baseOffset - movementAmount, 0);
    rightImage.anchoredPosition = new Vector2(baseOffset + movementAmount, 0);
}


    float GetPlayerSpeed()
{
    Rigidbody playerRb = FindObjectOfType<Rigidbody>(); // Assumes the player has a Rigidbody
    if (playerRb != null)
    {
        return playerRb.linearVelocity.magnitude; // Returns the speed based on Rigidbody velocity
    }
    Debug.LogWarning("Player Rigidbody not found!");
    return 0f;
}

}
