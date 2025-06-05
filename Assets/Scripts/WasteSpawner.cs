using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    public GameObject[] wastePrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 3f;

    [Header("Spawn Sound")]
    public AudioClip spawnSound;
    private AudioSource audioSource;

    void Start()
    {
        // Setup audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        InvokeRepeating(nameof(SpawnWaste), 2f, spawnInterval);
    }

    void SpawnWaste()
    {
        int index = Random.Range(0, wastePrefabs.Length);
        Instantiate(wastePrefabs[index], spawnPoint.position, Quaternion.identity);

        // Play spawn sound
        if (spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }
}
