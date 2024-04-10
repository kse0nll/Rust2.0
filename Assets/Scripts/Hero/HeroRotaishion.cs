using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRotaishion : MonoBehaviour
{
    public float sensivity;
    public GameObject camera;
    private float cameraAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseMoveX*sensivity, 0));

        float mouseMoveY = Input.GetAxis("Mouse Y");
        cameraAngle -= mouseMoveY*sensivity;
        cameraAngle = Mathf.Clamp(cameraAngle, -70, 45);
        camera.transform.localRotation = Quaternion.Euler(cameraAngle, 0, 0);
    }

}
