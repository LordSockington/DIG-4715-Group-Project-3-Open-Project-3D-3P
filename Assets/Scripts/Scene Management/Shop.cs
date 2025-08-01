using UnityEngine;

public class Shop : MonoBehaviour
{
    public delegate void SpeedItem();
    public static event SpeedItem SpeedUp;

    public delegate void HealthItem();
    public static event HealthItem HealthUp;

    public delegate void AttackItem();
    public static event AttackItem AttackUp;

    public int speedPrice = 30;
    public int healthPrice = 30;
    public int attackPrice = 50;

    private bool noEnergyDrink = true, noButteryPopcorn = true, noDipNDots = true;

    public void EnergyDrink()
    {
        if (GameManagment.coins > speedPrice && noEnergyDrink == true)
        {
            SpeedUp.Invoke();
            noEnergyDrink = false;
        }   
    }

    public void ButteryPopcorn()
    {
        if (GameManagment.coins > healthPrice && noButteryPopcorn == true)
        {
            HealthUp.Invoke();
            noButteryPopcorn = false;
        }
    }

    public void DipNDots()
    {
        if (GameManagment.coins > attackPrice && noDipNDots == true)
        {
            AttackUp.Invoke();
            noDipNDots = false;
        }
    }

}
