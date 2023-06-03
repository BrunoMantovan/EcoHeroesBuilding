using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recyclesCreator : MonoBehaviour
{
    public List<GameObject> recyclesPrefabsCreated;
    public int numberPrefabsCreated;
    public float spawnMaxRadius;
    public float minimunDistance;
    // Start is called before the first frame update
    void Awake()
    {
        InstantiateRecycles();
    }
    private void InstantiateRecycles()
    {
        for (int i = 0; i < numberPrefabsCreated; i++)
        {
            Vector3 position = GetRandomPosition();
            if (CanSpawnPrefab(position))
            {
                GameObject prefab = recyclesPrefabsCreated[Random.Range(0, recyclesPrefabsCreated.Count)];
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
    private Vector3 GetRandomPosition()
    {
        Vector3 position = (Vector2)transform.position + Random.insideUnitCircle * spawnMaxRadius;
        position.z = 0f;
        return position;
    }
    private bool CanSpawnPrefab(Vector3 position)
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(position, minimunDistance))
        {
            if (collider.tag == "ship")
            {
                return false;
            }
        }
        return true;
    }
}