using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ProgressBar;

public class Investment : MonoBehaviour
{
    public string Name;

    public float BasePrice;

    public float BaseIncome;

    public float BaseTime;

    public float Price { get; private set; }

    public float Income { get; private set; }

    public float Time { get; private set; }

    public State State;

    public Image ProgressBar;
    public Text Text;
    public Button UpgradeButton;
    public Button Button;

    private float curTime;

    public int Level { get; private set; }

	// Use this for initialization
	void Start ()
    {
        Price = BasePrice;
        Income = 0;
        Time = BaseTime;
        curTime = -1;
        Text.text = Name;
        Button.interactable = false;
        Level = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpgradeButton.interactable = State.Money >= Price;
        if (curTime != -1)
        {
            curTime += UnityEngine.Time.deltaTime;
            if (curTime >= Time)
            {
                curTime = -1;
                Fire();
                Button.interactable = true;
            }
        }
        ProgressBar.fillAmount = curTime == -1 ? 1 : curTime / Time;
    }

    void Activate()
    {
        curTime = 0;
        Button.interactable = false;
    }

    public void Fire()
    {
        State.Money += Income;
    }

    public void Upgrade()
    {
        if (Level == 0)
            Button.interactable = true;
        State.Money -= Price;
        Level++;
        Income += BaseIncome;
        Text.text = Name + ": " + Income;
    }
}
