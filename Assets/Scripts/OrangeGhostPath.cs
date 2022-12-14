using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeGhostPath : MonoBehaviour
{
    public GameObject TheMarker;
    public GameObject Mark01;
    public GameObject Mark02;
    public GameObject Mark03;
    public GameObject Mark04;
    public GameObject Mark05;
    public GameObject Mark06;
    public GameObject Mark07;
    public GameObject Mark08;
    public GameObject Mark09;
    public GameObject Mark10;
    int MarkTracker;

    void Start()
    {
        MarkTracker = 0;
        TheMarker.transform.position = Mark01.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "orangeGhost")
        {
            MarkTracker += 1;
            if (MarkTracker == 10)
            {
                MarkTracker = 0;
            }

            if (MarkTracker == 0)
            {
                TheMarker.transform.position = Mark01.transform.position;
            }
            else if (MarkTracker == 1)
            {
                TheMarker.transform.position = Mark02.transform.position;
            }
            else if (MarkTracker == 2)
            {
                TheMarker.transform.position = Mark03.transform.position;
            }
            else if (MarkTracker == 3)
            {
                TheMarker.transform.position = Mark04.transform.position;
            }
            else if (MarkTracker == 4)
            {
                TheMarker.transform.position = Mark05.transform.position;
            }
            else if (MarkTracker == 5)
            {
                TheMarker.transform.position = Mark06.transform.position;
            }
            else if (MarkTracker == 6)
            {
                TheMarker.transform.position = Mark07.transform.position;
            }
            else if (MarkTracker == 7)
            {
                TheMarker.transform.position = Mark08.transform.position;
            }
            else if (MarkTracker == 8)
            {
                TheMarker.transform.position = Mark09.transform.position;
            }
            else if (MarkTracker == 9)
            {
                TheMarker.transform.position = Mark10.transform.position;
            }
        }
    }

}
