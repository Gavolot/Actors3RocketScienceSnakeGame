using Pixeye.Actors;
using UnityEngine;

namespace Pixeye.Source
{
	[CreateAssetMenu]
	public class CommandsGame : CommandsConsole
	{
		[Bind]
		public void Hello()
		{
			Debug.Log("ACTORS!!!");
		}
		[Bind]
		public void go(int buildIndex){
			SceneMain.ChangeTo(buildIndex);
		}
		[Bind]
		public void gotoo(string sceneName){
			SceneMain.ChangeTo(sceneName);
		}

	}
}