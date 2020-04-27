using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreTextHandler : MonoBehaviour
{
    public Text title;
    public Text subtitle;
    public Text total;
    public Text totalScore;
    public Text best;
    public Text bestScore;
    public Text impact;
    public Text impactScore;
    public GameObject newRecord;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TimeSelected()
    {
        title.text = "Time";
        subtitle.text = "Nice work!";
        total.text = "Total Time";
        totalScore.text = "2:05";
        best.text = "Best Time";
        bestScore.text = "2:15";
        impact.text = "Challenge Time Impact";
        impactScore.text = "-2 hours";
        newRecord.SetActive(true);
    }

    public void EnvironmentalImpactSelected()
    {
        title.text = "Environmental Impact";
        subtitle.text = "Room for Improvement!";
        total.text = "Total Impact";
        totalScore.text = "-20";
        best.text = "Best Impact";
        bestScore.text = "-15";
        impact.text = "Challenge Evironmental Impact";
        impactScore.text = "-50";
        newRecord.SetActive(false);
    }

    public void ComfortSelected()
    {
        title.text = "Comfort";
        subtitle.text = "Fairly good!";
        total.text = "Comfort Gained";
        totalScore.text = "+5";
        best.text = "Best Comfort Gained";
        bestScore.text = "+25";
        impact.text = "Challenge Comfort Impact";
        impactScore.text = "+15";
        newRecord.SetActive(false);
    }

    public void MoneySelected()
    {
        title.text = "Money";
        subtitle.text = "Fairly good!";
        total.text = "Total Money Impact";
        totalScore.text = "-50";
        best.text = "Best Money Impact";
        bestScore.text = "-5";
        impact.text = "Money in Bank";
        impactScore.text = "1500";
        newRecord.SetActive(false);
    }
}
