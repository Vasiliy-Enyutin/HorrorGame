using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Fields

    [SerializeField] private float mouseSensitivity = 100f;

    private Transform player;
    private float xRotation = 0;

    #endregion

    #region Methods

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = transform.parent;
    }
    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

    #endregion
}
