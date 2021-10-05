using UnityEngine;

public class ExplodeCubes : MonoBehaviour
{
    private bool _collisionSet = false;
    public GameObject restartButton;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") && !_collisionSet)
        {
            for (int i = collision.transform.childCount - 1; i >= 0; i--)
            {
                Transform child = collision.transform.GetChild(i);
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(70f, Vector3.up, 15f);
                child.SetParent(null);
            }

            restartButton.SetActive(true);
            Camera.main.transform.position -= new Vector3(0, 0, 3f);

            Destroy(collision.gameObject);
            _collisionSet = true;
        }
    }
}