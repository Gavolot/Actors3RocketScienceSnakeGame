//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 


#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

using UnityEngine;

namespace Pixeye.Actors
{
	[CreateAssetMenu(menuName = "Actors/Plugables/Console", fileName = "Console")]
	public class PluggableConsole : Pluggable
	{
		[FoldoutGroup("SetupData")]
		public CommandsConsole commandsDebug;

		public override void Plug()
		{
			//LayerApp.Get<ProcessorConsole>().Setup(commandsDebug);
			LayerKernel.Add<ProcessorConsole>().Setup(commandsDebug);
			//Toolbox.Add<ProcessorConsole>().Setup(commandsDebug);
		}
	}
}