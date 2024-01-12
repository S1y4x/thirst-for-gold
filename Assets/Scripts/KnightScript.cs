using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    Animator animatorKnight;
    Animator animatorOrc;

    GameObject[] knightArray = new GameObject[3];
    GameObject[] orcArray = new GameObject[3];
    void Start()
    {
        for (int i = 0; i < 3; i++) knightArray[i] = GameObject.Find($"Knight{i}");
        for (int i = 0; i < 3; i++) orcArray[i] = GameObject.Find($"Orc{i}");
        foreach (GameObject knight in knightArray) animatorKnight = knight.GetComponent<Animator>();
        foreach (GameObject orc in orcArray) animatorOrc = orc.GetComponent<Animator>();
    }

    void Update()
    {
        foreach (GameObject knight in knightArray) animatorKnight.SetBool("isWinning", true);
        foreach (GameObject orc in orcArray)
        {
            animatorOrc.SetBool("isRunning", true);
            orc.transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }
    }
}
