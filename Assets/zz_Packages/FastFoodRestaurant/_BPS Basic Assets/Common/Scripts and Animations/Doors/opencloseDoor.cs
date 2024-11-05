using System.Collections;
using UnityEngine;

namespace SojaExiles
{
	public class OpenCloseDoor : MonoBehaviour
	{
		[SerializeField] public Transform player;
		private Animator animator;
		private bool open;

		private void OnMouseOver()
		{
			if (player)
			{
				float dist = Vector3.Distance(player.position, transform.position);
				if (dist < 15)
				{
					if (Input.GetMouseButtonDown(0))
					{
						StartCoroutine(open ? Close() : Open());
					}
				}
			}
		}

		private IEnumerator Open()
		{
			print("you are opening the door");
			animator.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		private IEnumerator Close()
		{
			print("you are closing the door");
			animator.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}

        private void Awake()
        {
			animator = GetComponent<Animator>();
        }
    }
}