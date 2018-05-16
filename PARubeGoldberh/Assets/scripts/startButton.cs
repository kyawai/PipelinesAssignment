using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class startButton : MonoBehaviour {

    public void changemenu ( string play)
    {
        Application.LoadLevel("play");
    }
}
