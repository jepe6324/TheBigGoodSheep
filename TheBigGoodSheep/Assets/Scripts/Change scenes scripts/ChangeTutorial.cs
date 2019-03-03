using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTutorial : MonoBehaviour {

    public void Tutorialscene()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
