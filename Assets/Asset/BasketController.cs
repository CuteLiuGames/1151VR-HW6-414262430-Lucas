using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip appleSE;
    public AudioClip bombSE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            audio.PlayOneShot(this.appleSE);
            Debug.Log("接到了！ Tag=Apple");
        }
        else if (other.CompareTag("Bomb"))
        {
            audio.PlayOneShot(this.bombSE);
            Debug.Log("哎呀呀呀呀！ Tag=Bomb");
        }
        
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
