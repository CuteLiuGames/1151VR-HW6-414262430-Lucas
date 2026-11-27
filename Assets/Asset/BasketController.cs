using UnityEngine;

public class BasketController : MonoBehaviour
{
    AudioSource audio;
    public AudioClip appleSE;
    public AudioClip bombSE;
    GameObject director;

    GameObject itemGeneratorActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        audio = GetComponent<AudioSource>();
        director = GameObject.Find("GameDirector");
        itemGeneratorActive = GameObject.Find("ItemGenerator");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            audio.PlayOneShot(this.appleSE);
            Debug.Log("接到了！ Tag=Apple");
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else if (other.CompareTag("Bomb"))
        {
            audio.PlayOneShot(this.bombSE);
            Debug.Log("哎呀呀呀呀！ Tag=Bomb");
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && itemGeneratorActive.GetComponent<ItemGenerator>().isActive)
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
