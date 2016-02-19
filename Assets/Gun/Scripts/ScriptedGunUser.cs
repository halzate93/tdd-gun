using Brainz.Demo.TDD.Gun;
using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD.Tests
{
	public class ScriptedGunUser : MonoBehaviour
	{
		[SerializeField]
		private float time;

		[Inject]
		private IGunBehaviour gun;

		private void Start()
		{
			Invoke("PullTrigger", time);
		}

		private void PullTrigger()
		{
			gun.Shoot();
		}
	}
}