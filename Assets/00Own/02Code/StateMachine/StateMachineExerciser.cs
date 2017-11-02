using UnityEngine;

namespace UGS.statemachine {

	public sealed class StateMachineExerciser : MonoBehaviour {

		private StateMachine stateMachine;

		public void Awake() {
			stateMachine = new StateMachine();
		}

		public void OnGUI() {
			var obc = GUI.backgroundColor;
			var guiData = stateMachine.getGUI();
			GUI.backgroundColor = guiData.colour; // if possible, I'd prefer guiData.applyStyle() and keep colour private.
			GUILayout.Label(stateMachine.ToString());
			if (GUILayout.Button("Update")) {
				stateMachine.update();
			}
			GUI.backgroundColor = obc;

			if (GUILayout.Button("Restart (explicit state setting)")) {
				stateMachine.setState(stateMachine.State01); // example of externally triggered state by explicit state
			}

			if (GUILayout.Button("Restart (semantic state setting)")) {
				stateMachine.restart(); // example of externally triggered state by semantically meaningful method
			}
		}

	}

}
