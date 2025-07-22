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
            Instantiate(check, new Vector3 (levelWesternCheck.transform.position.x, levelWesternCheck.transform.position.y, levelWesternCheck.transform.position.z), Quaternion.identity);
        }

        if (GameManagment.sentaiHat == true)
        {
            Instantiate(check, new Vector3(levelSentaiCheck.transform.position.x, levelSentaiCheck.transform.position.y, levelSentaiCheck.transform.position.z), Quaternion.identity);
        }

        if (GameManagment.noirHat == true)
        {
            Instantiate(check, new Vector3(levelNoirCheck.transform.position.x, levelNoirCheck.transform.position.y, levelNoirCheck.transform.position.z), Quaternion.identity);
        }
    }
}
