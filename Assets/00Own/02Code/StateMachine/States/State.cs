using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UGS.statemachine {
	abstract class State {

		protected readonly StateMachine owner;

		internal readonly GuiData guiData;

		internal State(StateMachine owner, GuiData guiData) {
			this.owner = owner;
			this.guiData = guiData;
		}

		internal virtual void onStateEnter() { }

		internal virtual void onStateExit() { }

		internal virtual void onUpdate() {
			Debug.LogFormat("Hi, from {0}", this);
		}

	}
}
