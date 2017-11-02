namespace UGS.statemachine {
	sealed class State02 : State {

		private readonly int max = 2;

		private int count = 0;

		internal State02(StateMachine owner, GuiData guiData, int max = 2) : base(owner, guiData) {
			this.max = max;
		}

		internal override void onStateEnter() {
			base.onStateEnter();
			count = 0;
		}

		internal override void onUpdate() {
			if (max <= ++count) {
				owner.setState(new State03(owner, string.Format("I'm a special-state-holding instance created by {0}!", this), UnityEngine.Random.Range(1, 5)));
			}
			base.onUpdate();
		}

		public override string ToString() {
			return string.Format("{0}(count:{1} < max:{2})", GetType(), count, max);
		}

	}
}
