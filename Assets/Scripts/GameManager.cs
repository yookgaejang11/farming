using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    public whether_type whether;
    public seedType seeds;
    public Text PlayerMoneyTxt;
    public Player player;
    private static GameManager instance;
    public Text time;
    public float inGameTime =10; //1초당 12분  5초는 1시간 1분에 12시간 2분에 하루

    public Text ErrorTxt;

    public int wheat_seed = 0;
    public int corn_seed = 0;
    public int carrot_seed = 0;
    public int blue_corn_seed = 0;
    public int red_wheat_seed = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneyTxt.text = player.haveMoney.ToString();
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
