using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    //money amounts
    float moneyAMT;
    float moneyAMTRounded;
    public TextMeshProUGUI moneyText;

    //Growth Amounts
    private float Farmer1Growth;
    private float Farmer2Growth;
    private float Farmer3Growth;
    private float Farmer4Growth;
    private float Farmer5Growth;

    //Levels
    private float Farmer1Level;
    private float Farmer2Level;
    private float Farmer3Level;
    private float Farmer4Level;
    private float Farmer5Level;

    //Texts for Level
    public TextMeshProUGUI Farmer1LevelText;
    public TextMeshProUGUI Farmer2LevelText;
    public TextMeshProUGUI Farmer3LevelText;
    public TextMeshProUGUI Farmer4LevelText;
    public TextMeshProUGUI Farmer5LevelText;

    //Upgrade Buttons
    public Button Farmer1Upgrade;
    public Button Farmer2Upgrade;
    public Button Farmer3Upgrade;
    public Button Farmer4Upgrade;
    public Button Farmer5Upgrade;

    private void Start()
    {
        //load info from previous plays on device
        Farmer1Level = PlayerPrefs.GetFloat("farmer1level", 1);
        Farmer2Level = PlayerPrefs.GetFloat("farmer2level", 0);
        Farmer3Level = PlayerPrefs.GetFloat("farmer3level", 0);
        Farmer4Level = PlayerPrefs.GetFloat("farmer4level", 0);
        Farmer5Level = PlayerPrefs.GetFloat("farmer5level", 0);

        moneyAMT = PlayerPrefs.GetFloat("money", 0);
    }

    void Update()
    {
        //level to increase cash
        Farmer1Growth = Mathf.Pow(Farmer1Level, 3);
        Farmer2Growth = Mathf.Pow(Farmer2Level, 3);
        Farmer3Growth = Mathf.Pow(Farmer3Level, 3);
        Farmer4Growth = Mathf.Pow(Farmer4Level, 3);
        Farmer5Growth = Mathf.Pow(Farmer5Level, 3);

        //Update Level Texts
        Farmer1LevelText.text = Farmer1Level.ToString();
        Farmer2LevelText.text = Farmer2Level.ToString();
        Farmer3LevelText.text = Farmer3Level.ToString();
        Farmer4LevelText.text = Farmer4Level.ToString();
        Farmer5LevelText.text = Farmer5Level.ToString();

        //Update Money Texts
        moneyAMT += (Farmer1Growth + Farmer2Growth + Farmer3Growth + Farmer4Growth + Farmer5Growth) * Time.deltaTime;
        moneyAMTRounded = Mathf.Round(moneyAMT);
        moneyText.text = moneyAMTRounded.ToString();

        //Show Avalibility for Upgrade Buttons
        if(moneyAMTRounded>=Mathf.Pow(5, Farmer1Level + 1))
        {
            Farmer1Upgrade.interactable=true;
        }
        else
        {
            Farmer1Upgrade.interactable = false;
        }

        if (moneyAMTRounded >= Mathf.Pow(5, Farmer2Level + 1))
        {
            Farmer2Upgrade.interactable = true;
        }
        else
        {
            Farmer2Upgrade.interactable = false;
        }

        if (moneyAMTRounded >= Mathf.Pow(5, Farmer3Level + 1))
        {
            Farmer3Upgrade.interactable = true;
        }
        else
        {
            Farmer3Upgrade.interactable = false;
        }

        if (moneyAMTRounded >= Mathf.Pow(5, Farmer4Level + 1))
        {
            Farmer4Upgrade.interactable = true;
        }
        else
        {
            Farmer4Upgrade.interactable = false;
        }

        if (moneyAMTRounded >= Mathf.Pow(5, Farmer5Level + 1))
        {
            Farmer5Upgrade.interactable = true;
        }
        else
        {
            Farmer5Upgrade.interactable = false;
        }

        //set PlayerPrefs save functions
        PlayerPrefs.SetFloat("farmer1level", Farmer1Level);
        PlayerPrefs.SetFloat("farmer2level", Farmer2Level);
        PlayerPrefs.SetFloat("farmer3level", Farmer3Level);
        PlayerPrefs.SetFloat("farmer4level", Farmer4Level);
        PlayerPrefs.SetFloat("farmer5level", Farmer5Level);

        PlayerPrefs.SetFloat("money", moneyAMTRounded);
    }

    //fuctions for upgrade buttons
    public void Farmer1Up()
    {
        moneyAMT -= Mathf.Pow(5, Farmer1Level + 1);
        Farmer1Level += 1;
    }

    public void Farmer2Up()
    {
        moneyAMT -= Mathf.Pow(5, Farmer2Level + 1);
        Farmer2Level += 1;
    }

    public void Farmer3Up()
    {
        moneyAMT -= Mathf.Pow(5, Farmer3Level + 1);
        Farmer3Level += 1;
    }

    public void Farmer4Up()
    {
        moneyAMT -= Mathf.Pow(5, Farmer4Level + 1);
        Farmer4Level += 1;
    }

    public void Farmer5Up()
    {
        moneyAMT -= Mathf.Pow(5, Farmer5Level + 1);
        Farmer5Level += 1;
    }
}