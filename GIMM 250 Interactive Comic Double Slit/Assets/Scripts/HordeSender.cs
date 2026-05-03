using UnityEngine;

public class HordeSender : MonoBehaviour
{
    [SerializeField] GameObject hordeSend;
    [SerializeField] Transform plrTrans;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    float timer;

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
            newHorde.GetComponent<HordeObjectMovement>().enabled = true;
        }
    }
}
