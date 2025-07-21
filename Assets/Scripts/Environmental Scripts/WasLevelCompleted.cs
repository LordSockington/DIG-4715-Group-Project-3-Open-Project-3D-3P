using UnityEngine;

public class WasLevelCompleted : MonoBehaviour
{
    [SerializeField]
    private GameObject check, levelWesternCheck, levelSentaiCheck, levelNoirCheck;

    void Awake()
    {
        Invoke("PlaceChecks", 0.1f);
    }

    void PlaceChecks()
    {
        if (GameManagment.westernHat == true)
        {
            Instantiate(check);
            check.transform.position = levelWesternCheck.transform.position;
        }

        if (GameManagment.sentaiHat == true)
        {
            Instantiate(check);
            check.transform.position = levelSentaiCheck.transform.position;
        }

        if (GameManagment.noirHat == true)
        {
            Instantiate(check);
            check.transform.position = levelNoirCheck.transform.position;
        }
    }
}
