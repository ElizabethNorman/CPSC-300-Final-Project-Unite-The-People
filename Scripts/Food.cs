/** This script allows food types to provide health to the object that collided with it. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public FoodChoices foodType;
    int healthPoints;

    public enum FoodChoices
    {
        //This is a very cool feature of unity, by created a public enum like this, it creates a drop down menu in the unity editor! Super cool!
        vodka,
        potato,
        cabbbage
    };

    void Start()
    {
        SwitchFoodType();
    }

    void SwitchFoodType()
    {
        switch (foodType)
        {
            case FoodChoices.vodka:
                healthPoints = 50;
                break;
            case FoodChoices.cabbbage:
                healthPoints = 20;
                break;
            case FoodChoices.potato:
                healthPoints = 10;
                break;

        }
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    
    }

   
    
}




