using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSpeedUp : MonoBehaviour
{
    public float gameSpeedAcceleration = 0.01f;

    void Update()
    {
        Time.timeScale += gameSpeedAcceleration;
    }

}
