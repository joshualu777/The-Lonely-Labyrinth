using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCam;
    public Camera[] zoomCam;

    GameObject gameController;
    SceneController sceneController;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        sceneController = gameController.GetComponent<SceneController>();
        foreach (Camera cam in zoomCam)
        {
            cam.enabled = false;
        }
        mainCam.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            zoomCam[SceneController.levels[sceneController.getScene()]].enabled = 
                !zoomCam[SceneController.levels[sceneController.getScene()]].enabled;
            mainCam.enabled = !mainCam.enabled;
        }
    }
}
