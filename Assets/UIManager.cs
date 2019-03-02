using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TPManager tpManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TPtoSouth()
    {
        tpManager.TPtoSouth();
    }

    public void TPtoNorth()
    {
        tpManager.TPtoNorth();
    }

    public void TPtoEast()
    {
        tpManager.TPtoEast();
    }

    public void TPtoWest()
    {
        tpManager.TPtoWest();
    }
}
