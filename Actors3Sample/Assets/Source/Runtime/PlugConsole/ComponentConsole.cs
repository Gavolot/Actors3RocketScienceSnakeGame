//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 

using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Pixeye.Actors {
	public class ComponentConsole : MonoBehaviour {
		public TMP_InputField fieldInput;
		public TMP_Text fieldOutput;
		public Scrollbar scrollbar;
		public TextMeshProUGUI labelDebug;

		CanvasGroup canvasGroup;
		float caretTimer;
		float tickDebug;
		ProcessorConsole processorConsole;
		Vector2Int size;
		string commandCached = string.Empty;

		FastString debugStr = new FastString (256);

		//Timer timerCheckEventSystem;
		RoutineCall timerCheckEventSystem;

		public void ActivateConsole (bool activating) {
			if (activating) {
				gameObject.SetActive (true);
				canvasGroup.alpha = 1;
				if(EventSystem.current.currentInputModule)
					fieldInput.ActivateInputField ();

				return;
			}

			canvasGroup.alpha = 0;
			gameObject.SetActive (false);
		}

		void Awake () {
			LayerKernel.WaitFor (0.1f, () => EventSystem.current.SetSelectedGameObject (fieldInput.gameObject));
			processorConsole = LayerKernel.Get<ProcessorConsole> ();
			canvasGroup = GetComponent<CanvasGroup> ();
			canvasGroup.alpha = 0;
		}

		void Start () {
			transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			AddMessage ("Welcome back, commander\nType <color=#00cc66>?</color> or <color=#00cc66>Help</color> to get list of commands");
		}

		void OnEnable () {
			CheckEventSystem ();

			fieldInput.onSubmit.AddListener (AddToConsole);
			fieldInput.onValueChanged.AddListener (ChangeText);

			fieldInput.caretPosition = 1;
			tickDebug = 0.0f;
			RenderDebug (0.0f);
			StartCoroutine (_ColorLine ());
		}

		void CheckEventSystem () {
			var evSystem = EventSystem.current;
			if (evSystem == null) {
				Debug.Log ($"Console -> <color=#00CD64>Event System</color> was added to the {SceneManager.GetActiveScene().name} ");
				//evSystem = new GameObject("Event System", typeof(EventSystem), typeof(StandaloneInputModule)).GetComponent<EventSystem>();
				evSystem = LayerKernel.Obj.Create ("Event System").gameObject.GetComponent<EventSystem> ();
			}

			fieldInput.enabled = true;

			//timerCheckEventSystem.t = 0.1f;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		void RenderDebug (float fps) {
			debugStr.Clear ();

			debugStr.Append ($"FPS: {fps.ToString("F1")} Time: {LayerKernel.Time.deltaTime}ms GPU memory: {SystemInfo.graphicsMemorySize}mb Sys Memory: {SystemInfo.systemMemorySize}mb")
				.Append ($"\nAllocatedMemory: {Profiler.GetTotalAllocatedMemoryLong() / 1048576}mb UnusedMemory: {Profiler.GetTotalUnusedReservedMemoryLong() / 1048576}mb ReservedMemory: {Profiler.GetTotalReservedMemoryLong() / 1048576}mb")
				.Append ($"\nActors: {Every.Ecs.GetAliveAmount()} Ticks: {LayerKernel.GetTicksCount}");

			labelDebug.text = debugStr.ToString ();
		}

		IEnumerator _ColorLine () {
			var textInfo = fieldInput.textComponent.textInfo;
			fieldInput.textComponent.ForceMeshUpdate ();

			Color32[] newVertexColors;
			Color32 c0 = fieldInput.textComponent.color;
			fieldInput.textComponent.renderMode = TextRenderFlags.DontRender;
			yield return new WaitForSeconds (0.1f);
			while (true) {
				var characterCount = textInfo.characterCount;

				if (characterCount == 0) {
					yield return new WaitForSeconds (0.25f);
					continue;
				}

				for (var i = 0; i < characterCount; i++) {
					if (!textInfo.characterInfo[i].isVisible) continue;
					var materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
					newVertexColors = textInfo.meshInfo[materialIndex].colors32;
					var vertexIndex = textInfo.characterInfo[i].vertexIndex;
					if (i >= size.x && i <= size.y) {
						c0 = new Color32 (0, 205, 100, 255);
					} else c0 = new Color32 (255, 255, 255, 255);

					newVertexColors[vertexIndex + 0] = c0;
					newVertexColors[vertexIndex + 1] = c0;
					newVertexColors[vertexIndex + 2] = c0;
					newVertexColors[vertexIndex + 3] = c0;
				}

				fieldInput.textComponent.UpdateVertexData ();
				if (LayerKernel.IsQuittingOrChangingScene ()) yield break;
				yield return new WaitForSeconds (UnityEngine.Time.deltaTime);
			}
		}

		void OnDisable () {
			if (LayerKernel.IsQuittingOrChangingScene ()) return;

			fieldInput.text = string.Empty;
			fieldInput.onSubmit.RemoveListener (AddToConsole);
			fieldInput.onValueChanged.RemoveListener (ChangeText);
			if (EventSystem.current != null)
				EventSystem.current.SetSelectedGameObject (null);
		}

		void AddMessage (string line) {
			if (line == string.Empty) return;
			fieldOutput.text += "-> " + line + "\n";
		}

		void ChangeText (string line) {
			var firstWord = line.Split (' ') [0];
			var method = processorConsole.GetMethod (firstWord);
			if (method == null) {
				size = new Vector2Int (-1, -1);
			} else {
				size = new Vector2Int (0, firstWord.Length);
			}
		}

		void AddToConsole (string line) {
			line = processorConsole.ParseCommand (line);

			fieldInput.ActivateInputField ();
			scrollbar.value = 0;

			if (Input.GetKey (KeyCode.BackQuote)) return;

			if (line == string.Empty) return;
			commandCached = fieldInput.text;
			fieldInput.text = string.Empty;

			AddMessage (line);
		}

		float deltaCount;
		float frameCount;

		void Update () {
			var delta = UnityEngine.Time.deltaTime;
			++frameCount;
			deltaCount += UnityEngine.Time.timeScale / delta;

			tickDebug += delta;

			/*if (timerCheckEventSystem.t > 0)
			{
				timerCheckEventSystem.t -= delta;
				if (timerCheckEventSystem.t <= 0)
				{
					timerCheckEventSystem.action();
				}
			}*/

			if (tickDebug >= 1f) {
				RenderDebug (deltaCount / frameCount);
				tickDebug = 0.0f;
				deltaCount = 0f;
				frameCount = 0f;
			}

			caretTimer += delta * 10;
			fieldInput.caretColor = Color.white * Mathf.Sin (caretTimer);

			if (!Input.GetKeyDown (KeyCode.UpArrow)) return;
			if (commandCached == string.Empty) return;

			fieldInput.text = commandCached;
			fieldInput.caretPosition = commandCached.Length;
			fieldInput.stringPosition = commandCached.Length;
		}
	}
}