using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Soil : MonoBehaviour
{
    public int cropCount = 0;
    public TextMeshProUGUI text;
    public Slider slider;
    public bool canSet = true;
    public int watering = 50;
    public int wateringValue;
    public Crop[] crops = new Crop[9];
    public List<Crop> Crops = new List<Crop>(9);

    // Start is called before the first frame update
    void Start()
    {
        
        watering = Mathf.Clamp(watering, 0, 100);
        watering = 50;
        StartCoroutine(WateringRange());
        slider.maxValue = 100;
        slider.value = watering;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = watering;
        text.text = watering + "/100";
        if(watering < 0)
        {
            watering = 0;
        }

        if(cropCount ==9)
        {
            canSet = false;
        }
        else
        {
            canSet = true;
        }
    }

    IEnumerator WateringRange()
    {
       while (true)
        {
            yield return new WaitForSeconds(5);
            switch (GameManager.Instance.whether)
            {
                case GameManager.whether_type.sunny:
                    wateringValue = -1;
                    break;
                case GameManager.whether_type.cloudy:
                    wateringValue = -1;
                    break;
                case GameManager.whether_type.rainy:
                    wateringValue = 1;
                    break;
                case GameManager.whether_type.storm:
                    wateringValue = -10;
                    break;
                case GameManager.whether_type.ice_ball:
                    wateringValue = -15;
                    break;

            }
            if (watering+wateringValue <=100 && watering + wateringValue >= 0)
            {
                watering += wateringValue;
            }
        }
    }


    IEnumerator Ice_age()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(GameManager.Instance.whether == GameManager.whether_type.ice_ball)
            {
                List<Crop> crop = new List<Crop>();
                foreach(Crop c in crops)
                {
                    if (c != null)
                    {
                        crop.Add(c);
                    }
                }

                
                int breakPer = Random.Range(1, 101);
                if(breakPer <= 2)
                {
                    int num = 0;
                    foreach (Crop c in crop)
                    {
                        if (c != null)
                        {
                            num++;
                        }
                    }
                    int ran = Random.Range(0,num);
                    int ran2 =Random.Range(0,num);
                    Destroy(crop[ran]);
                    Destroy(crop[ran2]);
                    while(ran == ran2)
                    {
                        ran2 = Random.Range(0,num);
                    }

                }

            }

        }
    }
}
