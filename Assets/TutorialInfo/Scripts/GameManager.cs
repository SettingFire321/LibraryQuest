using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static SortedList libraryNames;
    public TextMeshProUGUI libraryDesc;

    // Start is called before the first frame update
    void Awake()
    {
        libraryNames = new SortedList();
        setLibraries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLibraries(){
        libraryNames.Add("Main", "100 Larkin Street");
        libraryNames.Add("Anza", "550 37th Ave");
        libraryNames.Add("Bayview", "5075 3rd Street");
        libraryNames.Add("Bernal Heights", "500 Cortland Ave");
        libraryNames.Add("Chinatown", "1135 Powell St");
        libraryNames.Add("Eureka Valley", "1 Jose Sarria Court");
        libraryNames.Add("Excelsior", "4400 Mission Street");
        libraryNames.Add("Glen Park", "2825 Diamond Street");
        libraryNames.Add("Golden Gate Valley", "1801 Green Street");
        libraryNames.Add("Ingleside", "1298 Ocean Ave");
        libraryNames.Add("Marina", "1890 Chestnut Street");
        libraryNames.Add("Merced", "155 Winston Drive");
        libraryNames.Add("Mission", "1234 Valencia Street");
        libraryNames.Add("Mission Bay", "960 4th Street");
        libraryNames.Add("Noe Valley", "451 Jersey Street");
        libraryNames.Add("North Beach", "850 Columbus Ave");
        libraryNames.Add("Ocean View", "345 Randolph Street");
        libraryNames.Add("Park", "833 Page Street");
        libraryNames.Add("Parkside", "1200 Taraval Street");
        libraryNames.Add("Portola", "380 Bacon Street");
        libraryNames.Add("Potrero", "1616 20th Street");
        libraryNames.Add("Presidio", "3150 Sacramento Street");
        libraryNames.Add("Richmond", "351 9th Avenue");
        libraryNames.Add("Sunset", "1305 18th Avenue");
        libraryNames.Add("Treasure Island", "800 Avenue H");
        libraryNames.Add("Visitacion Valley", "201 Leland Avenue");
        libraryNames.Add("Western Addition", "1550 Scott Street");
        libraryNames.Add("West Portal", "190 Lenox Way");
        libraryNames.Add("Ortega", "3223 Ortega Street");
    }

}