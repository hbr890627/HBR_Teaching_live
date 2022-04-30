using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Text hpText;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        hpText.text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHealthBar(int hp)
    {
        slider.value = hp;
        hpText.text = hp.ToString();
    }
}
