using System;
using UnityEngine;

namespace UGS.statemachine {
	sealed class StateMachine {

		internal readonly State State01, State02; // State03 is instance-based

		internal static GuiData
			GuiBad = new GuiData(Color.red),
			GuiMedium = new GuiData(Color.yellow),
			GuiGood = new GuiData(Color.green);

		private State state;

		public StateMachine() {
			State01 = new State01(this, GuiBad);
			State02 = new State02(this, GuiMedium);
			state = State01;
		}

		public GuiData getGUI() {
			return state.guiData;
		}

		public void setState(State newState) {
			Debug.LogFormat("State:{0} -> {1}", state, newState);
			state.onStateExit();
			this.state = newState;
			state.onStateEnter();
		}

		public void update() {
			state.onUpdate();
		}

		public void restart() {
			setState(State01);
		}

		public override string ToString() {
			return string.Format("StateMachine:\n{0}", state);
		}
	}
}
