using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField]
    private Text pointsCanvasText;
    
    private int points;


    public void AddPoints(int points)
    {
        this.points += points;
        this.pointsCanvasText.text = this.points.ToString();
    }

    public void Restart()
    {
        this.points = 0;
        this.pointsCanvasText.text = this.points.ToString();
    }
}
