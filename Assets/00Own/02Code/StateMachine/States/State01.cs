namespace UGS.statemachine {
	sealed class State01 : State {

		private readonly int max;

		private int count = 0;

		internal State01(StateMachine owner, GuiData guiData, int max = 2) : base(owner, guiData) {
			this.max = max;
		}

		internal override void onStateEnter() {
			base.onStateEnter();
			count = 0;
		}

		internal override void onUpdate() {
			base.onUpdate();
			if (max <= ++count) {
				owner.setState(owner.State02);
			}
		}

		public override string ToString() {
			return string.Format("{0}(count:{1} < max:{2})", GetType(), count, max);
		}

	}
}
