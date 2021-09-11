using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveLayers : MonoBehaviour
{
    public float firstLayer;
    public float secondLayer;
    public float thirdLayer;
    public float fourthLayer;
    public float fifthLayer;
    [SerializeField] float maxValueOfEachLayer = 100;

    public void AddToLayers(float amount)
    {
        if (fifthLayer >= maxValueOfEachLayer) return;

        if(firstLayer < maxValueOfEachLayer)
        {
            firstLayer += amount;
        }
        else
        {
            if (secondLayer < maxValueOfEachLayer)
            {
                secondLayer += amount;
            }
            else
            {
                if (thirdLayer < maxValueOfEachLayer)
                {
                    thirdLayer += amount;
                }
                else
                {
                    if (fourthLayer < maxValueOfEachLayer)
                    {
                        fourthLayer += amount;
                    }
                    else
                    {
                        fifthLayer += amount;
                    }
                }
            }
        }
    }
    public void ReduceLayers(float amount)
    {
        if (fifthLayer >= amount)
        {
            fifthLayer -= amount;
        }
        else
        {
            if (fourthLayer >= amount)
            {
                fourthLayer -= amount;
            }
            else
            {
                if (thirdLayer >= amount)
                {
                    thirdLayer -= amount;
                }
                else
                {
                    if (secondLayer >= amount)
                    {
                        secondLayer -= amount;
                    }
                    else if (firstLayer >= amount)
                    {
                        firstLayer -= amount;
                        if (firstLayer < 0)
                        {
                            //Die
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
