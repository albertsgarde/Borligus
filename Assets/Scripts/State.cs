using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour 
{
    public Text moneyText;

    private float money;

	// Use this for initialization
	void Start () 
	{
        Money = 4;
	}

    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            moneyText.text = "Money: " + money;
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
