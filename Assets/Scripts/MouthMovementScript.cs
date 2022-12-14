using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthMovementScript : MonoBehaviour {

    [Range(1, 8)]
    public float mouthMovementPause;
    public bool cannotMoveMouth = false;

    GameObject character;
    SkinnedMeshRenderer characterMeshRender;

    float moveMouthWeight;
    float moveMouthSpeed = 1500f;
    float maxMoveMouthWeight = 100f;
    float minMoveMouthWeight = 0f;

    bool isMovingMouth = true;

    void Start() {

        character = this.gameObject;
        characterMeshRender = character.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();

        StartCoroutine("MouthClosed");
    }


    void Update() {

        if (cannotMoveMouth == false) {

            if (isMovingMouth) {
                if (moveMouthWeight <= maxMoveMouthWeight) {
                    moveMouthWeight += Time.deltaTime * moveMouthSpeed;
                    characterMeshRender.SetBlendShapeWeight(1, moveMouthWeight);
                }
            }
            else {
                if (moveMouthWeight >= minMoveMouthWeight) {
                    moveMouthWeight -= Time.deltaTime * moveMouthSpeed;
                    characterMeshRender.SetBlendShapeWeight(1, moveMouthWeight);
                }
            }
        }
    }

    IEnumerator MouthClosed()
    {

        while (cannotMoveMouth == false)
        {

            yield return new WaitForSeconds(mouthMovementPause);

            isMovingMouth = true;

            yield return new WaitForSeconds(.2f);

            isMovingMouth = false;

            yield return null;
        }
    }
}
