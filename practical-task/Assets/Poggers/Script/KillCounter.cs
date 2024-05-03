using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public TMP_Text counterText;
    int kills;

    private void Update()
    {
        Showkills();
    }

    private void Showkills()
    {
        counterText.text = kills.ToString();
    }

    public void AddKill()
    {
        kills++;
    }

}