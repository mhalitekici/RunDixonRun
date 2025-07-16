using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    private Rigidbody rb;
    private GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Sahnede GameManager bul
        gm = GameObject.FindObjectOfType<GameManager>();
        if (gm == null)
        {
            Debug.LogError("❌ GameManager sahnede bulunamadı! Lütfen bir GameManager objesi oluştur ve scripti ekle.");
        }
    }

    void Update()
    {
        // Oyun başlamadıysa veya bitti ise hareket etme
        if (gm == null || !gm.isGameStarted || gm.isGameOver)
            return;

        // Sürekli ileri hareket
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.deltaTime;

        // Sağ / Sol
        float horizontal = 0f;
        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        else if (Input.GetKey(KeyCode.D)) horizontal = 1f;

        Vector3 sideMove = transform.right * horizontal * sideSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + forwardMove + sideMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gm == null) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gm.GameOver();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            gm.Finished();
        }
    }
}
