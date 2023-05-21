using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenInfoScript : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public int currentScore = 0;
    public int currentBullets = 20;
    public int maxAmmo = 20;
    public int inventory = 80;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textInfo.text = "Score: " + currentScore + "/20\nBullets: " + currentBullets + "/" + maxAmmo + "\nInventory: " + inventory;
    }
    public void getCurrentAmmo(int ammo, int invent)
    {
        currentBullets = ammo;
        inventory = invent;
    }
}
