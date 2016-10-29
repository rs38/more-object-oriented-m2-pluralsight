using System;
using BranchingDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BranchingDemoTests {
    [TestClass]
    public class UnitTest1 {

        Account a;
        Action action = () => Debug.WriteLine("unfreeze");

        [TestInitialize()]
        public void Init() {
            a = new Account(action);
        }

        [TestMethod]
        public void Balance10() {
            a.Deposit(10);
            Assert.AreEqual(10, a.Balance);
        }
        [TestMethod]
        public void withdraw() {
            a.Withdraw(10);
            Assert.AreEqual(0, a.Balance);
        }
        [TestMethod]
        public void freezed() {

            a.Deposit(10);
            a.Freeze();
            a.Withdraw(1);    
            Assert.AreEqual(10, a.Balance);
        }

        [TestMethod]
        public void freezed2() {

            a.Deposit(10);
           
            a.Deposit(1); //wake up
            Assert.AreEqual(11, a.Balance);
            a.Withdraw(2);
            Assert.AreEqual(11, a.Balance);
            a.HolderVerified();
            a.Withdraw(2);
            Assert.AreEqual(9, a.Balance);
            a.Freeze();
            a.Withdraw(2);
            Assert.AreEqual(7, a.Balance);

        }


    }
}
