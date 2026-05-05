using UnityEngine;

public class HordeSender : MonoBehaviour
{
    [SerializeField] GameObject hordeSend;
    [SerializeField] Transform plrTrans;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    [SerializeField] int chanceToHaveKnife = 100;

    float timer;

    private bool CanSummonKnife()
    {
        int chance = Random.Range(0, 100);
        return chance <= chanceToHaveKnife;
    }
    private void UpdateTimer() => timer = Random.Range(minTime, maxTime);
    private void Start()
    {
        UpdateTimer();
    }

    private void Update()
    {
        timer = Mathf.Clamp(timer - Time.deltaTime, 0, maxTime);

        if (timer <= 0)
        {
            UpdateTimer();
            GameObject newHorde = Instantiate(hordeSend);
            newHorde.transform.SetParent(transform.parent, true);
            newHorde.transform.position = new Vector3(plrTrans.position.x - 25, newHorde.transform.position.y, 0);

            Transform knifePiece = newHorde.transform.Find("KnifePiece");
            if (knifePiece != null)
                if (knifePiece.gameObject.activeSelf)
                {
                    bool knifeSummoned = CanSummonKnife();
                    Debug.Log(knifeSummoned);
                    knifePiece.gameObject.SetActive(knifeSummoned);
                    knifePiece.GetComponent<KnifeCollection>().DoCheck();
                }

            newHorde.GetComponent<HordeObjectMovement>().enabled = true;
        }
    }
}
