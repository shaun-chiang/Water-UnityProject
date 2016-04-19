using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Image img;
    public bool cd = false;
    public float waitTime;

    // Use this for initialization
    void Start()
    {
        img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd)
        {
            img.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }

        if (img.fillAmount <= 0)
        {
            cd = false;
        }
    }

    public void setCd(float cooldown)
    {
        cd = true;
        img.fillAmount = 1;
        waitTime = cooldown;
    }
}
