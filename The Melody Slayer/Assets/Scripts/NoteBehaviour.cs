using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour {
    [SerializeField]
    private float seconds = 10f;
    [SerializeField][Range(0.1f, 100)]
    private float noteSpeed = 10f;

    private void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(seconds);

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update()
    {
		if (gameObject.activeInHierarchy == true)
        {
            transform.Translate(new Vector3(0, 0, -(noteSpeed) * Time.deltaTime));
        }
	}
}
