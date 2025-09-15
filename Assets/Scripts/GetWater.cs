using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWater : MonoBehaviour
{
    public GameObject waterUi;
    public bool CanUseWater;
    public bool WaterCanMode;
    public bool CanGetWater;
    public int maxWater = 3;
    public int curWater = 0;

    public Slider slider;
    public Text text;
    public waterCanLevel waterCanLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (waterCanLevel == waterCanLevel.rare)
        {
            maxWater = 6;
            
        }
        else
        {
            maxWater = 3;
        }
        slider.maxValue = maxWater;
        slider.value = curWater;
        text.text = curWater + " / " + maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanGetWater && Input.GetKeyDown(KeyCode.C))
        {
            curWater = maxWater;
        }

        if(curWater > 0)
        {
            CanUseWater = true;
            text.color = Color.white;
        }
        else
        {
            CanUseWater = false;
            text.color = Color.red;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(WaterCanMode)
            {
                WaterCanMode = false;
                waterUi.SetActive(false);
            }
            else if(!WaterCanMode)
            {
                WaterCanMode = true;
                waterUi.SetActive(true);
            }
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, LayerMask.GetMask("soil"));
        if(hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(curWater ==0)
                {
                    GameManager.Instance.Error("물이 부족합니다!");
                    return;
                }

                switch (waterCanLevel)
                {
                    case waterCanLevel.basic:
                        {
                            hit.collider.GetComponent<Soil>().watering += 50;
                            if(hit.collider.GetComponent<Soil>().watering + 50 >= 100)
                            {
                                hit.collider.GetComponent<Soil>().watering = 100;
                            }
                            curWater -= 1;
                            break;
                        }
                    case waterCanLevel.rare:
                        {
                            hit.collider.GetComponent<Soil>().watering += 20;
                            if (hit.collider.GetComponent<Soil>().watering + 20 >= 100)
                            {
                                hit.collider.GetComponent<Soil>().watering = 100;
                            }
                            curWater -= 1;
                            break;
                        }
                }
            }
        }

        slider.value = curWater;
        text.text = curWater + " / " + maxWater;

    }
}
