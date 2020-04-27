using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceGenerator : MonoBehaviour
{
    public Dictionary<string, List<string>> choiceDictionary = new Dictionary<string, List<string>>()
    {
        {"Bread", new List<string> {"Supplies for homemade", "Get from bakery", "Buy bagged"}},
        {"Veggies", new List<string> {"In season veggies", "Bagged veggies", "Frozen veggies"}},
        {"Meat", new List<string> {"Beef", "Chicken", "Fish"}},
        {"Rice", new List<string> {"Bagged", "Self-serve", "Plastic jug"}},
        {"Liquid", new List<string> {"Bottled Beer", "Soda cans", "Juice"}},
    };
    public Text title;
    public GameObject button1Image;
    public Text button1Caption;
    public GameObject button2Image;
    public Text button2Caption;
    public GameObject button3Image;
    public Text button3Caption;
    // Start is called before the first frame update
    void Start()
    {
        // choiceDictionary["Bread"] = new List<string>();
        // choiceDictionary["Bread"].Add("Supplies for homemade");
        // choiceDictionary["Bread"].Add("Get from bakery");
        // choiceDictionary["Bread"].Add("Buy bagged");

        // choiceDictionary["Veggies"] = new List<string>();
        // choiceDictionary["Veggies"].Add("In season veggies");
        // choiceDictionary["Veggies"].Add("Bagged veggies");
        // choiceDictionary["Veggies"].Add("Frozen veggies");

        // choiceDictionary["Meat"] = new List<string>();
        // choiceDictionary["Meat"].Add("Beef");
        // choiceDictionary["Meat"].Add("Chicken");
        // choiceDictionary["Meat"].Add("Fish");

        // choiceDictionary["Rice"] = new List<string>();
        // choiceDictionary["Rice"].Add("Bagged");
        // choiceDictionary["Rice"].Add("Self serve");
        // choiceDictionary["Rice"].Add("Plastic jug");

        // choiceDictionary["Liquid"] = new List<string>();
        // choiceDictionary["Liquid"].Add("Bottled beer");
        // choiceDictionary["Liquid"].Add("Sode cans");
        // choiceDictionary["Liquid"].Add("Juice");
    }

    public void GenerateChoice()
    {
        Random rand = new Random();
        List<string> keyList = new List<string>(choiceDictionary.Keys);
        Debug.Log(keyList.Count);
        string randomKey = keyList[Random.Range(0, keyList.Count - 1)];
        List<string> valuesList = new List<string>(this.choiceDictionary[randomKey]);
        // do stuff with key and values
        title.text = randomKey;
        int randomIndex = Random.Range(0, valuesList.Count - 1);
        button1Caption.text = valuesList[randomIndex];
        valuesList.RemoveAt(randomIndex);
        randomIndex = Random.Range(0, valuesList.Count - 1);
        button2Caption.text = valuesList[randomIndex];
        valuesList.RemoveAt(randomIndex);
        randomIndex = Random.Range(0, valuesList.Count - 1);
        button3Caption.text = valuesList[randomIndex];
        valuesList.RemoveAt(randomIndex);
        // remove chosen key from dictionary
        this.choiceDictionary.Remove(randomKey);
    }
}
