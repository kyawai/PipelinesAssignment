﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButton : MonoBehaviour {

    public void changemenu ( string play)
    {
        Application.LoadLevel("play");
    }
}
