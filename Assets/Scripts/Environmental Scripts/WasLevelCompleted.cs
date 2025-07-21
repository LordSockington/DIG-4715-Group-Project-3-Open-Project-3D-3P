using UnityEngine;

public class WasLevelCompleted : MonoBehaviour
{
    [SerializeField]
    private GameObject check, level1Check, level2Check, level3Check;

    void Awake()
    {
        Invoke("PlaceChecks", 0.1f);
    }

    void PlaceChecks()
    {
        if (GameManagment.westHat == true)
        {
            Instantiate(check);
            check.transform.position = level1Check.transform.position;
        }

        if (GameManagment.sentaiHat == true)
        {
            Instantiate(check);
            check.transform.position = level2Check.transform.position;
        }

        if (GameManagment.noirHat == true)
        {
            Instantiate(check);
            check.transform.position = level3Check.transform.position;
        }
    }
}
