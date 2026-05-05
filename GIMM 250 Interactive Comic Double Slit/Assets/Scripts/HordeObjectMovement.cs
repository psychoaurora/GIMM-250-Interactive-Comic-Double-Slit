using UnityEngine;

public class HordeObjectMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private ParticleSystem particles;
    private Vector3 movement;
    private BoxCollider2D boxCollider;
    private VisionCheck checker;

    private bool eyeColor = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //horde moves to the right
        movement = new Vector3(1, 0, 0);
        checker = GameObject.FindGameObjectWithTag("Player").GetComponent<VisionCheck>();
        eyeColor = !checker.isUsingLeftEye;

        GetComponent<SpriteRenderer>().color = !checker.isUsingLeftEye ? Color.yellow : Color.blue;
        particles.startColor = !checker.isUsingLeftEye ? Color.yellow : Color.blue;
        particles.Emit(20);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: move object
        //Debug.Log("i exist");
        if (PauseMenu.GamePaused) return;
        transform.position += movement * movementSpeed;
        if (checker.isUsingLeftEye == eyeColor)
        {
            Transform knife = transform.Find("KnifePiece");
            //Transform knifeHier = transform.parent.Find("KnifePiece");
            if (knife != null) //&& knifeHier != null)
                if (knife.gameObject.activeSelf)
                {
                    knife.SetParent(transform.parent, true);
                    knife.GetComponent<FloatUpAndDown>().enabled = true;
                    knife.GetComponent<BoxCollider2D>().enabled = true;
                    knife.GetComponent<KnifeCollection>().enabled = true;
                }
                    
            gameObject.SetActive(false);
        }

    }



}
