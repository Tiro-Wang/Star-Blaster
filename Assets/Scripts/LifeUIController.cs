using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] liveIcons;
    public void UpdateLives(int livesNum)
    {
        for (int i = 0; i < liveIcons.Length; i++)
        {
            liveIcons[i].SetActive(false);
        }
        for (int i = 0;i < livesNum; i++)
        {
            liveIcons[i].SetActive (true);
        }
    }
}
