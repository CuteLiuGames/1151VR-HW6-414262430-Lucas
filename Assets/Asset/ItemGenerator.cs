using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1.0f;
    float delta = 0f;
    float ratio = 2;
    float speed = -0.03f;

    public bool isActive = false;

    public void setParameter (float span, float speed, float ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    public void Reset()
    {
        delta = 0f;
    }
    public void SetDefault()
    {
        span = 1.0f;
        ratio = 2;
        speed = -0.03f;
    }

    public void SetState(bool active)
    {
        isActive = active;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {
                this.delta = 0;
                GameObject item;
                int dice = Random.Range(1, 11);
                if (dice <= this.ratio)
                {
                    item = Instantiate(bombPrefab);
                }
                else
                {
                    item = Instantiate(applePrefab);
                }
                float x = Random.Range(-1, 2);
                float z = Random.Range(-1, 2);
                item.transform.position = new Vector3(x, 4, z);
                item.GetComponent<ItemController>().dropSpeed = speed;
            }
        }
    }
}
