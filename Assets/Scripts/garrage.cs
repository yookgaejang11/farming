using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class garrage : MonoBehaviour
{
    public Text Lvtxt;
    public Text slottxt;
    public Text pricetxt;
    public Player player;
    public int price = 30000;
    public int maxSlot;
    public int garrageLevel;
    public int currentSlot;

    public GameObject wheatObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject blueCornObj;
    public GameObject redWheatObj;

    public GameObject wheatseedObj;
    public GameObject cornSeedObj;
    public GameObject carrobSeedObj;
    public GameObject bluecornObj;
    public GameObject redwheatObj;

    public List<GameObject> objList = new List<GameObject>();
    public GameObject savedObj;
    
    // Start is called before the first frame update
    void Start()
    {
        Lvtxt.text = "창고 LV: " + garrageLevel;
        slottxt.text = "용량: " + currentSlot + "/" + maxSlot;
        pricetxt.text = "확장: " + price;
    }

    // Update is called once per frame
    void Update()
    {
        currentSlot = objList.Count;
    }

    public void Upgrade()
    {
        if(player.haveMoney >= price)
        {
            switch (garrageLevel)
            {
                case 1:
                    if (player.haveMoney >= price)
                    {
                        player.haveMoney -= price;
                        garrageLevel++;
                    }
                    price += 5000;
                    break;
                case 2:
                    if (player.haveMoney >= price)
                    {
                        player.haveMoney -= price;
                        garrageLevel++;
                    }
                    price += 5000;
                    break;
                case 3:
                    GameManager.Instance.Error("더이상 확장할 수 없습니다!");
                    break;
            }
        }
    }

    public void SortGarrage()
    {
        objList.Clear();
        for (int i = 0; i < GameManager.Instance.wheat; i++)
        {
            objList.Add(wheatObj);
        }
        for (int i = 0; i < GameManager.Instance.wheat_seed; i++)
        {
            objList.Add(wheatseedObj);
        }

        for (int i = 0; i < GameManager.Instance.corn; i++)
        {
            objList.Add(cornObj);
        }
        for (int i = 0; i < GameManager.Instance.corn_seed; i++)
        {
            objList.Add(cornSeedObj);
        }

        for (int i = 0; i < GameManager.Instance.carrot; i++)
        {
            objList.Add(carrotObj);
        }
        for (int i = 0; i < GameManager.Instance.carrot_seed; i++)
        {
            objList.Add(carrobSeedObj);
        }

        for (int i = 0; i < GameManager.Instance.blue_corn; i++)
        {
            objList.Add(blueCornObj);
        }
        for (int i = 0; i < GameManager.Instance.blue_corn_seed; i++)
        {
            objList.Add(bluecornObj);
        }

        for (int i = 0; i < GameManager.Instance.red_wheat; i++)
        {
            objList.Add(redWheatObj);
        }
        for (int i = 0; i < GameManager.Instance.red_wheat_seed; i++)
        {
            objList.Add(redwheatObj);
        }


        for (int i = 0; i < savedObj.transform.childCount; i++)
        {
            Destroy(savedObj.transform.GetChild(i).gameObject);
        }

        for(int i = 0;i < objList.Count;i++)
        {
            GameObject obj = GameObject.Instantiate(objList[i]);
            obj.transform.parent = savedObj.transform;
            RectTransform rect = obj.gameObject.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
            rect.localPosition = Vector3.zero;
        }
        

    }


    
}
