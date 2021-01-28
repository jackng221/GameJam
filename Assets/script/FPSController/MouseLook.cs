using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float xRotation = 0f;
    float xAxisClamp;

    public float mouseSensitivity = 1f;
    public Transform Player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Player.gameObject.GetComponent<FPSMovement>().ismenuopen == false))
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            Player.Rotate(Vector3.up * mouseX);
        }
    }
    private void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
