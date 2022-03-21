using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Character;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    [SerializeField] private Character character;

    private void OnTriggerExit2D(Collider2D other)
    {
        var target = other.GetComponent<Character>();
        if (target)
        {
            target.Info.Health.Current -= 999999;
        }
    }
}
