using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenPlacement : MonoBehaviour
{
    public static GardenPlacement instance;

    [Header("General Fields")]
    //List of items picked up
    public List<GameObject> items = new List<GameObject>();
    //flag indicates if the inventory is open or not
    public bool isOpen;
    [Header("UI Items Section")]
    //Inventory System Window
    public GameObject ui_Window;
    public Image[] items_images;

    public void PickUp(GameObject item)
    {
        items.Add(item);
        UpdateUI();
    }

    void UpdateUI()
    {
        HideAll();

        for (int i = 0; i < items.Count; i++)
        {
            items_images[i].sprite = items[i].GetComponent<Image>().sprite;
            items_images[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var i in items_images) { i.gameObject.SetActive(false); }
    }

    public void FinishedPlanted(int id)
    {
        
         if(items[id].GetComponent<Plant>().Type == Plant.PlantType.Planted)
         {
            items[id].GetComponent<Plant>().ConsumeEvent.Invoke();
                //Destroy the item in very tiny time
                Destroy(items[id], 0.1f);
                //Clear the item from the list
                items.RemoveAt(id);
                //Update UI
                UpdateUI();
         }
    }

    public void PlantDies(int id)
    {

        if (items[id].GetComponent<Plant>().Type == Plant.PlantType.Planted)
        {
            items[id].GetComponent<Plant>().ConsumeEvent.Invoke();
            //Destroy the item in very tiny time
            Destroy(items[id], 0.1f);
            //Clear the item from the list
            items.RemoveAt(id);
            //Update UI
            UpdateUI();
        }
    }

    public void Watering(int id)
    {
        if (items[id].GetComponent<Plant>().Type == Plant.PlantType.Planted)
        {
            items[id].GetComponent<Plant>().ConsumeEvent.Invoke();
            //Update UI
            UpdateUI();
        }
    }
}
