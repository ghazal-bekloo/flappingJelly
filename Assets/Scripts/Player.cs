
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float strength = 5f;
     public float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


     private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
           
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
           
            FindObjectOfType<GameManager>().IncreaseScore();

        }
    }
}
