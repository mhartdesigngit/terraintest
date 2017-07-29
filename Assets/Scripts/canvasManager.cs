using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour
{
    List<GameObject> landscape = new List<GameObject>();
    List<GameObject> plants = new List<GameObject>();
    List<GameObject> rocks = new List<GameObject>();
    Button forwardlandscape;
    Button backwardslandscape;
    Button forwardplants;
    Button backwardsplants;
    Button forwardrocks;
    Button backwardsrocks;
    public int counter =0;
    public int pflanzenzaehler = 0;
    public int rockzaehler = 0;

    void Start ()
    {
        //Liste der Landscapes
        GameObject landschaften = GameObject.Find("Landscapes");
        for (int i =0 ; i< landschaften.transform.childCount; i++)
        {
            landscape.Add(landschaften.transform.GetChild(i).gameObject);
            
        }
        landscape[counter % 4].SetActive(true);
        landscape[(counter % 4) + 1].SetActive(false);
        landscape[(counter % 4) + 2].SetActive(false);
        landscape[(counter % 4) + 3].SetActive(false);


        //Liste der Pflanzen
        GameObject pflanzen = GameObject.Find("Plants");
        for (int i = 0; i < pflanzen.transform.childCount; i++)
        {
            plants.Add(pflanzen.transform.GetChild(i).gameObject);

        }
        plants[pflanzenzaehler % 4].SetActive(true);
        plants[(pflanzenzaehler % 4) + 1].SetActive(false);
        plants[(pflanzenzaehler % 4) + 2].SetActive(false);
        plants[(pflanzenzaehler % 4) + 3].SetActive(false);

        //Liste der Rocks
        GameObject steine = GameObject.Find("Rocks");
        for(int i =0;i < steine.transform.childCount;i++)
        {
            rocks.Add(steine.transform.GetChild(i).gameObject);
        }
        rocks[rockzaehler % 6].SetActive(true);
        rocks[(rockzaehler %  6)+1].SetActive(false);
        rocks[(rockzaehler % 6)+2].SetActive(false);
        rocks[(rockzaehler % 6)+3].SetActive(false);
        rocks[(rockzaehler % 6)+4].SetActive(false);
        rocks[(rockzaehler % 6)+5].SetActive(false);



        //Buttondefinitionen
        forwardlandscape = GameObject.Find("forwardlandscape").GetComponent<Button>();
        backwardslandscape = GameObject.Find("backwardslandscape").GetComponent<Button>();
        forwardplants = GameObject.Find("forwardplants").GetComponent<Button>();
        backwardsplants = GameObject.Find("backwardsplants").GetComponent<Button>();
        forwardrocks = GameObject.Find("forwardrocks").GetComponent<Button>();
        backwardsrocks = GameObject.Find("backwardsrocks").GetComponent<Button>();

    }
	
    //Buttonmethode vorwärts
	public void fwechselLandscape()
    {
        counter = counter +1;
        int a = Mathf.Abs(counter) % 4;
        int b = Mathf.Abs(counter + 1) % 4;
        int c = Mathf.Abs(counter + 2) % 4;
        int d = Mathf.Abs(counter + 3) % 4;
        landscape[a].SetActive(true);
        landscape[b].SetActive(false);
        landscape[c].SetActive(false);
        landscape[d].SetActive(false);
        
    }
    public void fwechselPlants()
    {
        pflanzenzaehler = pflanzenzaehler + 1;
        int a = Mathf.Abs(pflanzenzaehler) % 4;
        int b = Mathf.Abs(pflanzenzaehler + 1) % 4;
        int c = Mathf.Abs(pflanzenzaehler + 2) % 4;
        int d = Mathf.Abs(pflanzenzaehler + 3) % 4;
        plants[a].SetActive(true);
        plants[b].SetActive(false);
        plants[c].SetActive(false);
        plants[d].SetActive(false);
    }
    public void fwechselRocks()
    {
        rockzaehler = rockzaehler + 1;
        int a = Mathf.Abs(rockzaehler) % 6;
        int b = Mathf.Abs(rockzaehler + 1) % 6;
        int c = Mathf.Abs(rockzaehler + 2) % 6;
        int d = Mathf.Abs(rockzaehler + 3) % 6;
        int e = Mathf.Abs(rockzaehler + 4) % 6;
        int f = Mathf.Abs(rockzaehler + 5) % 6;
        rocks[a].SetActive(true);
        rocks[b].SetActive(false);
        rocks[c].SetActive(false);
        rocks[d].SetActive(false);
        rocks[e].SetActive(false);
        rocks[f].SetActive(false);
    }

    //Buttonmethode rückwärts
    public void bwechselLandscape()
    {
        counter = counter -1;
        int a = Mathf.Abs(counter) % 4;
        int b = Mathf.Abs(counter + 1) % 4;
        int c = Mathf.Abs(counter + 2) % 4;
        int d = Mathf.Abs(counter + 3) % 4;
        landscape[a].SetActive(true);
        landscape[b].SetActive(false);
        landscape[c].SetActive(false);
        landscape[d].SetActive(false);
    }
    public void bwechselPlants()
    {
        pflanzenzaehler = pflanzenzaehler - 1;
        int a = Mathf.Abs(pflanzenzaehler) % 4;
        int b = Mathf.Abs(pflanzenzaehler + 1) % 4;
        int c = Mathf.Abs(pflanzenzaehler + 2) % 4;
        int d = Mathf.Abs(pflanzenzaehler + 3) % 4;
        plants[a].SetActive(true);
        plants[b].SetActive(false);
        plants[c].SetActive(false);
        plants[d].SetActive(false);
    }
    public void bwechselRocks()
    {
        rockzaehler = rockzaehler - 1;
        int a = Mathf.Abs(rockzaehler) % 6;
        int b = Mathf.Abs(rockzaehler + 1) % 6;
        int c = Mathf.Abs(rockzaehler + 2) % 6;
        int d = Mathf.Abs(rockzaehler + 3) % 6;
        int e = Mathf.Abs(rockzaehler + 4) % 6;
        int f = Mathf.Abs(rockzaehler + 5) % 6;
        rocks[a].SetActive(true);
        rocks[b].SetActive(false);
        rocks[c].SetActive(false);
        rocks[d].SetActive(false);
        rocks[e].SetActive(false);
        rocks[f].SetActive(false);
    }

    void Update ()
    {
	
	}
}
