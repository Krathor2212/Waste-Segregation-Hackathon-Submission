using UnityEngine;

public class BinDetector : MonoBehaviour
{
    public MockClassifier.WasteType binType;

    [Header("Waste Type Sounds")]
    public AudioClip organicClip;
    public AudioClip metalClip;
    public AudioClip plasticClip;

    [Header("Destroy Sound")]
    public AudioClip destroyClip;

    private AudioSource audioSource;

    void Start()
    {
        // Ensure the bin has an AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("➡ Something entered the bin trigger!");

        MockClassifier item = other.GetComponent<MockClassifier>();
        if (item != null)
        {
            // Play the correct sound based on waste type
            switch (item.assignedType)
            {
                case MockClassifier.WasteType.Organic:
                    if (organicClip) audioSource.PlayOneShot(organicClip);
                    break;
                case MockClassifier.WasteType.Metal:
                    if (metalClip) audioSource.PlayOneShot(metalClip);
                    break;
                case MockClassifier.WasteType.Plastic:
                    if (plasticClip) audioSource.PlayOneShot(plasticClip);
                    break;
            }

            // Score update logic
            if (item.assignedType == binType)
            {
                Debug.Log($"✅ Correct: {item.name} = {binType}");
                FindObjectOfType<GameManager>().UpdateScore(1);
            }
            else
            {
                Debug.Log($"❌ Incorrect: {item.name} ≠ {binType}");
                FindObjectOfType<GameManager>().UpdateScore(0);
            }

            // Play destroy sound and destroy the waste
            if (destroyClip)
                AudioSource.PlayClipAtPoint(destroyClip, other.transform.position);

            Destroy(other.gameObject);
        }
    }
}
