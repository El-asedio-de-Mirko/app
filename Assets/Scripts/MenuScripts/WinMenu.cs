using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuWin;
    // Start is called before the first frame update
    public void Win()
    {
        Time.timeScale = 0f;
        menuWin.SetActive(true);
    }
}
