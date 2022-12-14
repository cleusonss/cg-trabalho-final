using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkGhostPath : MonoBehaviour
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
    public GameObject Mark11;
    public GameObject Mark12;
    public GameObject Mark13;
    public GameObject Mark14;
    public GameObject Mark15;
    public GameObject Mark16;
    public GameObject Mark17;
    public GameObject Mark18;
    public GameObject Mark19;
    public GameObject Mark20;
    int MarkTracker;

    void Start()
    {
        MarkTracker = 0;
        TheMarker.transform.position = Mark01.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "pinkGhost")
        {
            MarkTracker += 1;
            if (MarkTracker == 20)
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
            else if (MarkTracker == 10)
            {
                TheMarker.transform.position = Mark11.transform.position;
            }
            else if (MarkTracker == 11)
            {
                TheMarker.transform.position = Mark12.transform.position;
            }
            else if (MarkTracker == 12)
            {
                TheMarker.transform.position = Mark13.transform.position;
            }
            else if (MarkTracker == 13)
            {
                TheMarker.transform.position = Mark14.transform.position;
            }
            else if (MarkTracker == 14)
            {
                TheMarker.transform.position = Mark15.transform.position;
            }
            else if (MarkTracker == 15)
            {
                TheMarker.transform.position = Mark16.transform.position;
            }
            else if (MarkTracker == 16)
            {
                TheMarker.transform.position = Mark17.transform.position;
            }
            else if (MarkTracker == 17)
            {
                TheMarker.transform.position = Mark18.transform.position;
            }
            else if (MarkTracker == 18)
            {
                TheMarker.transform.position = Mark19.transform.position;
            }
            else if (MarkTracker == 19)
            {
                TheMarker.transform.position = Mark20.transform.position;
            }
        }
    }

}
