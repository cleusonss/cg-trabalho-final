using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScript : MonoBehaviour {

    [Range (1,8)]
    public float blinkPause;
    public bool cannotBlink = false;

    GameObject character;
    SkinnedMeshRenderer characterMeshRender;

    float blinkWeight;
    float blinkSpeed = 1500f;
    float maxBlinkWeight = 100f;
    float minBlinkWeight = 0f;

    bool isBlinking = true;

    void Start() {

        character = this.gameObject;
        characterMeshRender = character.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();

        StartCoroutine("Blink");
    }


    void Update() {
        
        if (cannotBlink == false) {

            if (isBlinking) {
                if (blinkWeight <= maxBlinkWeight) {
                    blinkWeight += Time.deltaTime * blinkSpeed;
                    characterMeshRender.SetBlendShapeWeight(0, blinkWeight);
                }
            }
            else {
                if (blinkWeight >= minBlinkWeight) {
                    blinkWeight -= Time.deltaTime * blinkSpeed;
                    characterMeshRender.SetBlendShapeWeight(0, blinkWeight);
                }
            }
        }
    }

    IEnumerator Blink() {

        while (cannotBlink == false) {

            yield return new WaitForSeconds(blinkPause);

            isBlinking = true;

            yield return new WaitForSeconds(.2f);

            isBlinking = false;

            yield return null;
        }
    }
}
