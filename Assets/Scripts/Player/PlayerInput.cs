﻿using UnityEngine;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    //CACHED REFERENCES
    Player player;

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }
}