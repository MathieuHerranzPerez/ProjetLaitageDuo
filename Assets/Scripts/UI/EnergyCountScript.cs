using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCountScript : MonoBehaviour
{
    Image energyBar;

    // Start is called before the first frame update
    void Start()
    {
        energyBar = GetComponent<Image>();
        energyBar.fillAmount = PlayerStats.Money / PlayerStats.MaxMoney;
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.fillAmount = (float)PlayerStats.Money / (float)PlayerStats.MaxMoney;
    }
}
