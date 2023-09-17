using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    public GameObject[] endLocations;
    public float humanSpeed;
    public float gameSpeed;

    GameObject gameController;
    SceneController sceneController;
    float trackDist;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        sceneController = gameController.GetComponent<SceneController>();
    }

    void Update()
    {
        Vector3 finalLocation = endLocations[SceneController.levels[
            sceneController.getScene()]].transform.position;
        float dist = (finalLocation - gameObject.transform.position).magnitude - 0.8f;
        trackDist = dist / gameSpeed * humanSpeed * 10;
    }
    public string getTrackDist()
    {
        if (sceneController.getScene() == "LV3")
        {
            return string.Format("{0, 4}", "???");
        }
        return string.Format("{0, 4}", (int) trackDist);
    }
}
