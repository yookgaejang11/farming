using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum waterCanLevel
{
    basic,
    rare
}

public enum GarrageLevel
{
    Level1,
    Level2,
    Level3
}

public class GameManager : MonoBehaviour
{
    public enum playerHoe
    {
        basic,
        rare
    }

    public enum playerWaterCan
    {
        basic, rare
    }
    public enum seedType
    {
        None,
        wheat,
        corn,
        carrot,
        blue_corn,
        red_wheat
    }

    public enum whether_type
    {
        sunny,
        cloudy,
        rainy,
        storm,
        ice_ball
    }

    public playerHoe hoe;
    public playerWaterCan waterCan;
    public whether_type whether;
    public seedType seeds;
    public Text PlayerMoneyTxt;
    public Player player;
    private static GameManager instance;
    public Text time;
    public float inGameTime =10; //1초당 12분  5초는 1시간 1분에 12시간 2분에 하루


    public GameObject GarrageUI;
    public GameObject garrageTxt;
    public bool garrageActive = false;


    public Text ErrorTxt;
    public int wheat_seed = 0;
    public int corn_seed = 0;
    public int carrot_seed = 0;
    public int blue_corn_seed = 0;
    public int red_wheat_seed = 0;
    public int allCount = 0;

    public int wheat = 0;
    public int corn = 0;
    public int carrot = 0;
    public int blue_corn = 0;
    public int red_wheat = 0;
    private void Awake()
    {
        if(instance == null)
        {

        instance = this; 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(Timer());
        int whetherNum = Random.Range(1, 6);
        switch (whetherNum)
        {
            case 1:
                whether = whether_type.sunny;
                break;
            case 2:
                whether = whether_type.cloudy;
                break;
            case 3:
                whether = whether_type.rainy;
                break;
            case 4:
                whether = whether_type.storm;
                break;
            case 5:
                whether = whether_type.ice_ball;
                break;
        }
    }

    public int AllCount()
    {
        return wheat + corn + carrot + blue_corn + red_wheat + wheat_seed + corn_seed + carrot_seed + blue_corn_seed + red_wheat_seed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneyTxt.text = player.haveMoney.ToString();
        if(inGameTime == 0)
        {
            int whetherNum = Random.Range(1, 6);
            switch(whetherNum)
            {
                case 1:
                    whether = whether_type.sunny;
                    break;
                case 2:
                    whether= whether_type.cloudy;
                    break;
                case 3:
                    whether = whether_type.rainy;
                    break;
                case 4:
                    whether = whether_type.storm;
                    break;
                case 5:
                    whether = whether_type.ice_ball;
                    break;
            }
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            inGameTime += 0.2f;
            if (inGameTime >= 24)
            {
                inGameTime -= 24;
            }
            time.text = Mathf.FloorToInt(inGameTime / 1).ToString("D2") + ":" +"00";
        }
    }


    public void Error(string errorTxt)
    {
        StartCoroutine(Errortxt(errorTxt));
    }

    IEnumerator Errortxt(string errorTxt)
    {
        ErrorTxt.text = errorTxt;
        yield return new WaitForSeconds(1);
        ErrorTxt.text = string.Empty;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
        
    }
}
