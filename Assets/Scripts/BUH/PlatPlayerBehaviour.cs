using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatPlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<ICollectable>() != null)
        {   //Makes the THING IT HITS run Collect function
            ICollectable collectable = collision.GetComponent<ICollectable>();
            switch (collectable.type)
            {
                case CollectableType.None:
                    break;
                case CollectableType.Money:
                    coinCount += collectable.Collect(); //run script And add value
                    break;
                case CollectableType.Key:
                    break;
                case CollectableType.Gem:
                    coinCount += collectable.Collect();
                    break;
                case CollectableType.Special:
                    collectable.Collect(); //run the script
                    break;
            }
        }
    }
}