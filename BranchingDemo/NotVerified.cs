﻿using System;

namespace BranchingDemo
{
    class NotVerified : IAccountState {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze) {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance) {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() {
            this.OnUnfreeze();  //<- added notification for verification
            return new Active(this.OnUnfreeze); 
        }
        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}