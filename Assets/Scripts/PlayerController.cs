using UnityEngine;

public class PlayerController : MonoBehaviour {

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        var horizontalInputValue = Input.GetAxis("Horizontal");
        Debug.Log($"Horizontal Input value: {horizontalInputValue}");

        var verticalInputValue = Input.GetAxis("Vertical");
        Debug.Log($"Vertical Input value: {verticalInputValue}");
    }
}