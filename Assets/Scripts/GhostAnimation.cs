using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{

    float shapePause = 2;
    public bool cannotShape = false;

    GameObject character;
    SkinnedMeshRenderer characterMeshRender;

    float shapeWeight = 0;
    float shapeSpeed = 250f;
    float maxShapeWeight = 100f;
    float minShapeWeight = 0f;

    bool isShapping = true;

    void Start()
    {

        character = this.gameObject;
        characterMeshRender = character.GetComponent<SkinnedMeshRenderer>();

        StartCoroutine("shapeGhost");
    }


    void Update()
    {

        if (cannotShape == false)
        {

            if (isShapping)
            {
                if (shapeWeight <= maxShapeWeight)
                {
                    shapeWeight += Time.deltaTime * shapeSpeed;
                    characterMeshRender.SetBlendShapeWeight(0, shapeWeight);
                }
            }
            else
            {
                if (shapeWeight >= minShapeWeight)
                {
                    shapeWeight -= Time.deltaTime * shapeSpeed;
                    characterMeshRender.SetBlendShapeWeight(0, shapeWeight);
                }
            }
        }
    }

    IEnumerator shapeGhost()
    {

        while (cannotShape == false)
        {

            yield return new WaitForSeconds(shapePause);

            isShapping = true;

            yield return new WaitForSeconds(.2f);

            isShapping = false;

            yield return null;
        }
    }
}
