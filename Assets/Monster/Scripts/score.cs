using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class score : MonoBehaviour
{
    public static int Score { get; set; }
    public GameObject[] listMonster;
    private static void initScore()
    {
        Score = 0;
    }
    private void Awake()
    {
        FindObjectOfType<Text>().text = "Score 0";
        createMonster();
    }

    public void createMonster()
    {
        if (GameObject.FindGameObjectsWithTag("enemie").Length <= 1)
        {
            int listMonsterSize = listMonster.Length;
            if (listMonsterSize >= 0)
            {
                int indexMonster = random(0, listMonsterSize);
                Instantiate(listMonster[indexMonster], vectorAleatory(), Quaternion.identity);
            }
        }
    }

    private static float random(float startNumber, float endNumber)
    {
        return Random.Range(startNumber, endNumber);
    }
    
    private static int random(int startNumber, int endNumber)
    {
        return Random.Range(startNumber, endNumber);
    }

    public Vector3 vectorAleatory()
    {
        float startNumber = 5.0f;
        float endNumber = 10.0f;
        float positionX = random(startNumber, endNumber);
        float positionZ = random(startNumber, endNumber);
        return new Vector3(positionX, 0, positionZ);
    }
}
