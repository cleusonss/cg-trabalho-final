using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraStatic;
    public GameObject cameraPacman;

    //AudioListener cameraStaticAudioLis;
    //AudioListener cameraPacmanAudioLis;

    // Start is called before the first frame update
    void Start() {

        //Get Camera Listeners
        //cameraStaticAudioLis = cameraStatic.GetComponent<AudioListener>();
        //cameraPacmanAudioLis = cameraPacman.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update() {

        //Change camera keyboard
        switchCamera();
    }

    void switchCamera() {
        if (Input.GetKeyDown(KeyCode.C)) {
            cameraChangeCounter();
        }
    }

    void cameraChangeCounter() {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    void cameraPositionChange(int camPosition) {
        if (camPosition > 1) {
            camPosition = 0;
        }

        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0) {
            cameraStatic.SetActive(true);
            //cameraStaticAudioLis.enabled = true;

            //cameraPacmanAudioLis.enabled = false;
            cameraPacman.SetActive(false);
        }
        //Set camera position 2
        else if (camPosition == 1) {
            cameraPacman.SetActive(true);
            //cameraPacmanAudioLis.enabled = true;

            //cameraStaticAudioLis.enabled = false;
            cameraStatic.SetActive(false);
        }
    }
}
