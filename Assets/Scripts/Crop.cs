using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crop : MonoBehaviour
{
    public Slider slider;
    public bool canGrow = true;
    public bool canGet=false;
    public GameObject seed;
    public GameObject MaxGrow;
    public string Name;
    public int maxGrowRange;
    public int curGrowRange;
    // Start is called before the first frame update
    void Start()
    {
        switch (Name)
        {
            case "wheat":
                maxGrowRange = 70;
                break;
            case "corn":
                maxGrowRange = 80;
                break;
            case "carrot":
                maxGrowRange = 180;
                break;
            case "blue_corn":
                maxGrowRange = 100;
                break;
            case "red_wheat":
                maxGrowRange = 60;
                break;
        }

        StartCoroutine(GrowCrop());
    }

    // Update is called once per frame
    void Update()
    {
        if (curGrowRange >= maxGrowRange)
        {
            seed.SetActive(false);
            MaxGrow.SetActive(true);
            canGet = true;
        }

        if (curGrowRange < 0)
        {
            canGrow = false;
            if(this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>()  != null)
            {
                this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
            }
            if (this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>() != null)
            {
                this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.black;
            }

        }


        slider.value = curGrowRange;
        slider.maxValue = maxGrowRange;
        
    }

    IEnumerator GrowCrop()
    {
        while(maxGrowRange != curGrowRange)
        {
            yield return new WaitForSeconds(1);
            if (canGrow)
            {
                switch (Name)
                {
                    case "wheat":
                        if (GameManager.Instance.whether == GameManager.whether_type.storm)
                        {
                            curGrowRange -= 1;
                        }
                        else if ((GameManager.Instance.whether == GameManager.whether_type.sunny || GameManager.Instance.whether == GameManager.whether_type.cloudy || GameManager.Instance.whether == GameManager.whether_type.rainy) &&(GameManager.Instance.inGameTime >= 6 && GameManager.Instance.inGameTime <= 18) && (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering >= 40 && this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering <= 80))
                            if (GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.sunny)
                            {
                                curGrowRange += 2;
                            }
                            else
                            {
                                curGrowRange += 1;
                            }
                        break;
                    case "corn":
                        if ((GameManager.Instance.whether == GameManager.whether_type.sunny || GameManager.Instance.whether == GameManager.whether_type.cloudy || GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.storm) && (GameManager.Instance.inGameTime >= 6 && GameManager.Instance.inGameTime <= 18) && (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering >= 50 && this.gameObject.transform.parent.gameObject.GetComponent<Soil>().watering <= 80))
                        {
                            if (GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.sunny)
                            {
                                curGrowRange += 2;
                            }
                            else if (GameManager.Instance.whether == GameManager.whether_type.storm)
                            {
                                curGrowRange -= 1;
                            }
                            else
                            {
                                curGrowRange += 1;
                            }
                        }
                        break;
                    case "carrot":
                        if ((GameManager.Instance.whether == GameManager.whether_type.sunny || GameManager.Instance.whether == GameManager.whether_type.cloudy || GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.storm || GameManager.Instance.whether == GameManager.whether_type.ice_ball) && (GameManager.Instance.inGameTime >= 3 && GameManager.Instance.inGameTime <= 22) && (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering >= 50 && this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering <= 80))
                        {
                            if (GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.sunny)
                            {
                                curGrowRange += 2;
                            }
                            else if (GameManager.Instance.whether == GameManager.whether_type.storm)
                            {
                                curGrowRange -= 1;
                            }
                            else
                            {
                                curGrowRange += 1;
                            }
                        }
                        break;
                    case "blue_corn":
                        if ((GameManager.Instance.whether == GameManager.whether_type.sunny || GameManager.Instance.whether == GameManager.whether_type.cloudy || GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.storm) && (GameManager.Instance.inGameTime >= 18 && GameManager.Instance.inGameTime <= 5) && (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering  >= 40 && this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering  <= 70))
                        {
                            if (GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.sunny)
                            {
                                curGrowRange += 2;
                            }
                            else if (GameManager.Instance.whether == GameManager.whether_type.storm)
                            {
                                curGrowRange -= 1;
                            }
                            else
                            {
                                curGrowRange += 1;
                            }
                        }
                        break;
                    case "red_wheat":
                        if (GameManager.Instance.whether == GameManager.whether_type.storm)
                        {
                            curGrowRange -= 1;
                        }
                        else if ((GameManager.Instance.whether == GameManager.whether_type.sunny || GameManager.Instance.whether == GameManager.whether_type.cloudy || GameManager.Instance.whether == GameManager.whether_type.rainy) && (GameManager.Instance.inGameTime >= 0 && GameManager.Instance.inGameTime <= 24) && (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering >= 30 && this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Soil>().watering <= 60))
                            if (GameManager.Instance.whether == GameManager.whether_type.rainy || GameManager.Instance.whether == GameManager.whether_type.sunny)
                            {
                                curGrowRange += 2;
                            }
                            else
                            {
                                curGrowRange += 1;
                            }
                        break;
                }
            }
        }
    }
}
