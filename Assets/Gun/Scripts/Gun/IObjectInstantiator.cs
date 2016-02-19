using UnityEngine;

namespace Brainz.Demo.TDD.Gun
{
	public interface IObjectInstantiator
	{
		void Instantiate(GameObject prefab);
	}
}