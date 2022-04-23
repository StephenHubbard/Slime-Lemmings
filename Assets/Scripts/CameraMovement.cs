using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float zoomSpeed = .2f;

    void Start()
    {
        
    }

    void Update()
    {
        CamMovement();
        Zoom();
    }

    private void CamMovement() {
        if (Input.GetKey(KeyCode.W)) {
            gameObject.transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime) ;
        }
        if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            gameObject.transform.Translate(new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            gameObject.transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
        }
    }

    private void Zoom() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && cam.m_Lens.OrthographicSize < 10 ) {
            cam.m_Lens.OrthographicSize += zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && cam.m_Lens.OrthographicSize > 2) {
            cam.m_Lens.OrthographicSize -= zoomSpeed;
        }
    }
}
