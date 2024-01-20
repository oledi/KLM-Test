using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchOnOff : MonoBehaviour
{
    public Light lightComp;
    public float interval;
    private float timer;
    private Button button;

    //private bool isBlinking;
    public bool setLightsOn;

    void Awake()
    {
        setLightsOn = false;
        button = GameObject.Find("lights").GetComponent<Button>();
        button.onClick.AddListener(TurnOnAllLights);
    }

    // Update is called once per frame
    void Update()
    {
        if(setLightsOn == true) { BlinkingLight(); }      
    }

    private void BlinkingLight() {

        timer += Time.deltaTime;

        if (timer > interval)
        {
            lightComp.enabled = !lightComp.enabled;
            timer -= interval;
        }

    }

    public void TurnOnAllLights() {
       if(setLightsOn == false)
        {
            setLightsOn = true;
        }
        else { setLightsOn = false; lightComp.enabled = false; }
    }
}
