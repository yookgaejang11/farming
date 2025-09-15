using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FarmingManager : MonoBehaviour
{
    public garrage garrage;
    private static FarmingManager instance;
    public GameObject activeUi;
    public RaycastHit2D hit;
    public bool canEquiping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!canEquiping)
            {
                activeUi.SetActive(true);
                canEquiping = true;
            }
            else
            {
                activeUi.SetActive(false);
                canEquiping = false;
            }
        }


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, LayerMask.GetMask("soil"));
        
        if(hit.collider !=null && Input.GetKeyDown(KeyCode.Mouse0) && canEquiping)
        {
           if(garrage.maxSlot <= GameManager.Instance.AllCount())
            {
                GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                return;
            }
            Soil target = hit.collider.gameObject.GetComponent<Soil>();
            int seedPer = Random.Range(1, 101);
            if (!target.crops[SeedNum(target)].gameObject.GetComponent<Crop>().canGrow)
            {
                Destroy(target.crops[SeedNum(target)].gameObject);
            }
            if (CanGet(target))
            {
                if (GameManager.Instance.hoe == GameManager.playerHoe.basic)
                {
                    switch (target.crops[SeedNum(target)].GetComponent<Crop>().Name)
                    {

                        case "wheat":
                            if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                            {
                                GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                return;
                            }
                            GameManager.Instance.wheat += 1;
                            Debug.Log("adsfa");
                            if (seedPer <= 20)
                            {
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return ;
                                }
                                GameManager.Instance.wheat_seed += 1;
                            }
                            break;
                        case "corn":
                            if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                            {
                                GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                return;
                            }
                            GameManager.Instance.corn += 1;

                            if (seedPer <= 20)
                            {
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.corn_seed += 1;
                            }
                            break;
                        case "carrot":
                            if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                            {
                                GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                return;
                            }
                            GameManager.Instance.carrot += 1;

                            if (seedPer <= 20)
                            {
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.carrot_seed += 1;
                            }
                            break;
                        case "blue_corn":
                            if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                            {
                                GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                return;
                            }
                            GameManager.Instance.blue_corn += 1;

                            if (seedPer <= 20)
                            {
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.blue_corn_seed += 1;
                            }
                            break;
                        case "red_wheat":
                            if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                            {
                                GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                return;
                            }
                            GameManager.Instance.red_wheat += 1;

                            if (seedPer <= 20)
                            {
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.red_wheat_seed += 1;
                            }
                            break;
                    }
                }
                else if (GameManager.Instance.hoe == GameManager.playerHoe.rare)
                {
                    if ((CanGet(target)))
                    {
                        int cropper = Random.Range(1, 4);
                        if (garrage.maxSlot <= GameManager.Instance.AllCount() + cropper)
                        {
                            GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                            return;
                        }
                        switch (target.crops[SeedNum(target)].GetComponent<Crop>().Name)
                        {
                            case "wheat":
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + cropper)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.wheat += cropper;

                                if (seedPer <= 50)
                                {
                                    if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                    {
                                        GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                        return;
                                    }
                                    GameManager.Instance.wheat_seed += cropper;
                                }
                                break;
                            case "corn":
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + cropper)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.corn += cropper;

                                if (seedPer <= 50)
                                {
                                    if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                    {
                                        GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                        return;
                                    }
                                    GameManager.Instance.corn_seed += cropper;
                                }
                                break;
                            case "carrot":
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + cropper)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.carrot += cropper;

                                if (seedPer <= 50)
                                {
                                    if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                    {
                                        GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                        return;
                                    }
                                    GameManager.Instance.carrot_seed += cropper;
                                }
                                break;
                            case "blue_corn":
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + cropper)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.blue_corn += cropper;

                                if (seedPer <= 50)
                                {
                                    if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                    {
                                        GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                        return;
                                    }
                                    GameManager.Instance.blue_corn_seed += cropper;
                                }
                                break;
                            case "red_wheat":
                                if (garrage.maxSlot <= GameManager.Instance.AllCount() + cropper)
                                {
                                    GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                    return;
                                }
                                GameManager.Instance.red_wheat += cropper;

                                if (seedPer <= 50)
                                {
                                    if (garrage.maxSlot <= GameManager.Instance.AllCount() + 1)
                                    {
                                        GameManager.Instance.Error("더이상 수확할 수 없습니다!");
                                        return;
                                    }
                                    GameManager.Instance.red_wheat_seed += cropper;
                                }
                                break;
                        }
                    }

                    
                }

                Destroy(target.crops[SeedNum(target)].gameObject);

            }
            else if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0) && canEquiping && !CanGet(target) && target.crops[SeedNum(target)].gameObject.GetComponent<Crop>().canGrow)
            {
                GameManager.Instance.Error("수확할 수 없습니다");
            }

            


        }

    }


    public bool CanGet(Soil soil)
    {
        foreach(Crop s in soil.crops)
        {
            if(s != null)
            {
                if (s.canGet)
                {
                    return true;
                }

            }
            
        }
        return false;
    }

    public int SeedNum(Soil soil)
    {
        foreach (Crop s in soil.crops)
        {
            if (s != null)
            {
                if (s.canGet)
                {
                    return System.Array.IndexOf(soil.crops,s);
                }

            }

        }
        return 0;
    }
    public static FarmingManager Instance
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
