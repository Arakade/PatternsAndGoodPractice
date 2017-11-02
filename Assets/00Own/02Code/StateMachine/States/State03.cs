namespace UGS.statemachine {
	sealed class State03 : State {

		private readonly int max = 2;

		private readonly string extraInfo;

		private int count = 0;

		internal State03(StateMachine owner, GuiData guiData, string extraInfo, int max = 2) : base(owner, guiData) {
			this.max = max;
			this.extraInfo = extraInfo;
		}

		internal State03(StateMachine owner, string extraInfo, int max = 2) : base(owner, StateMachine.GuiGood) {
			this.max = max;
			this.extraInfo = extraInfo;
		}

		// don't explicitly need this since only run through it once but good defensive practice.
		internal override void onStateEnter() {
			base.onStateEnter();
			count = 0;
		}

		internal override void onUpdate() {
			if (max <= ++count) {
				owner.setState(owner.State01);
			}
			base.onUpdate();
		}

		public override string ToString() {
			return string.Format("{0}(count:{1} < max:{2}, extraInfo:\"{3}\")", GetType(), count, max, extraInfo);
		}

	}
}
