using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float movementFactor = 30f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 15;
    [SerializeField] private float positionPitchFactor = -1.35f; 

    void Update() {
        HandleTranslation();
        HandleRotation();
    }

    void HandleTranslation() {
        var localPosition = transform.localPosition;
        
        var xInputValue = Input.GetAxis("Horizontal");
        var xOffset = xInputValue * Time.deltaTime * movementFactor;
        var xPosRaw = localPosition.x + xOffset;
        var xClamped = Mathf.Clamp(xPosRaw, -xRange, xRange);

        var yInputValue = Input.GetAxis("Vertical");
        var yOffset = yInputValue * Time.deltaTime * movementFactor;
        var yPosRaw = localPosition.y + yOffset;
        var yClamped = Mathf.Clamp(yPosRaw, -yRange, yRange);
        
        transform.localPosition = new Vector3(
            xClamped,
            yClamped,
            localPosition.z
        );
    }

    void HandleRotation() {
        var localPosition = transform.localPosition;
        var pitch = localPosition.y * positionPitchFactor;
        var yaw = 0f;
        var roll = 0f;

        Debug.Log($"Local y position: {localPosition.y}; calculated pitch: {pitch}");
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}