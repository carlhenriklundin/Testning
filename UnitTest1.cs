using System;
using Xunit;
using Lektion2;

namespace Lektion2.Tests
{
    public class KronorTests
    {
        [Fact]
        public void EmptyConstructor_ÖreShouldBeZero()
        {
            //Arrange
            int expected = 0;

            //Act   
            Kronor testKronor = new Kronor();

            //Assert
            Assert.True(testKronor.Öre == expected);
        }


        [Fact]
        public void ConstructorWithInitialValue_ÖreShouldBeInitialValue()
        {
            //Arrange
            int expected = 1055;

            //Act   
            Kronor testKronor = new Kronor(10,55);

            //Assert
            Assert.Equal(expected, testKronor.Öre);
        }


        [Fact]
        public void CopyConstructor_ÖreShouldBeCopiedValue()
        {
            //Arrange
            Kronor valueToBeCopied = new Kronor(10, 55);
            int expected = 1055;

            //Act   
            Kronor testKronor = new Kronor(valueToBeCopied);

            //Assert
            Assert.Equal(expected, testKronor.Öre);
        }

        [Fact]
        public void KronorPart_ReturnValueShouldBeOnlyKronor()
        {
            //Arrange
            Kronor testKronor = new Kronor(10, 0);
            int expected = 10;

            //Act   
            int actutal = testKronor.KronorPart();

            //Assert
            Assert.Equal(expected, actutal);
        }

        [Fact]
        public void ÖrePart_ReturnValueShouldBeOnlyÖren()
        {
            //Arrange
            Kronor testKronor = new Kronor(10, 55);
            int expected = 55;

            //Act   
            int actutal = testKronor.ÖrenPart();

            //Assert
            Assert.Equal(expected, actutal);
        }

        [Fact]
        public void Add_ÖreShouldBeÖrePlusAddedValue()
        {
            //Arrange
            Kronor testKronor = new Kronor(9, 44);
            int expected = 1999;

            //Act   
            Kronor actual = testKronor.Add(new Kronor(10, 55));

            //Assert
            Assert.Equal(expected, actual.Öre);
        }

        [Fact]
        public void Subtract_ÖreShouldBeÖreMinusSubstractValue()
        {
            //Arrange
            Kronor testKronor = new Kronor(11, 50);
            int expected = 95;

            //Act   
            Kronor actual = testKronor.Subtract(new Kronor(10, 55));

            //Assert
            Assert.Equal(expected, actual.Öre);
        }

        [Fact]
        public void IsPositive_ShouldBeTrueOnlyIfValueIsPositive()
        {
            //Arrange
            Kronor testKronorPositive = new Kronor(5, 55);
            Kronor testKronorNegative = new Kronor(-5, -55);

            //Act   
            bool positiveValue = testKronorPositive.IsPositive();
            bool negativeValue = testKronorNegative.IsPositive();
            //Assert
            Assert.True(positiveValue && !negativeValue);
        }

        [Fact]
        public void IsNegative_ShouldBeTrueOnlyIfValueIsNegative()
        {
            //Arrange
            Kronor testKronorPositive = new Kronor(5, 55);
            Kronor testKronorNegative = new Kronor(-5, -55);

            //Act   
            bool positiveValue = testKronorPositive.isNegative();
            bool negativeValue = testKronorNegative.isNegative();
            //Assert
            Assert.True(negativeValue && !positiveValue);
        }

        [Fact]
        public void IsZero_ShouldBeTrueOnlyIfValueIsZero()
        {
            //Arrange
            Kronor testKronorPositive = new Kronor(5, 55);
            Kronor testKronorNegative = new Kronor(-5, -55);
            Kronor testKronorZero = new Kronor();

            //Act   
            bool positiveValue = testKronorPositive.isZero();
            bool negativeValue = testKronorNegative.isZero();
            bool zeroValue = testKronorZero.isZero();

            //Assert
            Assert.True(zeroValue && !negativeValue && !positiveValue);
        }

    }

    public class WalletsTests
    {
        [Fact]
        public void EmptyConstructor_AmountShouldBeZero()
        {
            //Arrange
            Kronor expected = new Kronor(0,0);

            //Act   
            Wallet testWallet = new Wallet();

            //Assert
            Assert.Equal(expected.Öre, testWallet.Amount.Öre);
        }
        
        [Fact]
        public void ConstructorWithMoney_AmountShouldBeInitialValue()
        {
            //Arrange
            Kronor expected = new Kronor(5, 55);

            //Act   
            Wallet testWallet = new Wallet(new Kronor(5,55));

            //Assert
            Assert.Equal(expected.Öre, testWallet.Amount.Öre);
        }

        [Fact]
        public void ConstructorWithMoney_AmountShouldBeZeroWhenIntitalValueIsNegative()
        {
            //Arrange
            

            //Act   
            Wallet testWallet = new Wallet(new Kronor(-5, -55));

            //Assert
            Assert.True(testWallet.Amount.Öre == 0);
        }

        [Fact]
        public void Add_AmountShouldBeAmountPlusAddedValue()
        {
            //Arrange
            Kronor expected = new Kronor(10, 55);
            Wallet testWallet = new Wallet(new Kronor(5, 55));
            //Act   
            testWallet.Add(new Kronor(5,0));

            //Assert
            Assert.Equal(expected.Öre, testWallet.Amount.Öre);
        }

        [Fact]
        public void Remove_AmountShouldBeAmountMinusRemovedValue()
        {
            //Arrange
            Kronor expected = new Kronor(10, 10);
            Wallet testWallet = new Wallet(new Kronor(12, 15));
            //Act   
            testWallet.Remove(new Kronor(2, 5));

            //Assert
            Assert.Equal(expected.Öre, testWallet.Amount.Öre);
        }

        [Fact]
        public void RemoveToNegative_AmountShouldBeTheSameIfTheNewValueIsNegative()
        {
            //Arrange
            Wallet testWallet = new Wallet(new Kronor(12, 15));
            //Act   
            testWallet.Remove(new Kronor(13, 55));

            //Assert
            Assert.True(testWallet.Amount.Öre >= 0);
        }

        [Fact]
        public void RemoveAll_AmountShouldBeZero()
        {
            //Arrange
            Kronor expected = new Kronor();
            Wallet testWallet = new Wallet(new Kronor(12, 15));
            //Act   
            testWallet.RemoveAll();

            //Assert
            Assert.Equal(expected.Öre, testWallet.Amount.Öre);
        }
    }

    public class AccountTests
    {
        [Fact]
        public void EmptyConstructor_AmountShouldBeZero()
        {
            //Arrange
            Kronor expected = new Kronor(0, 0);

            //Act   
            Account testAccount = new Account();

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void Deposit_AmountShouldBeAmountPlusValue()
        {
            //Arrange
            Kronor expected = new Kronor(10, 55);
            Account testAccount = new Account(new Kronor(5, 55));
            //Act   
            testAccount.Deposit(new Kronor(5, 0));

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void Deposit_AmountShouldBeUnchangedIfAmountAndDepositValueIsNegative()
        {
            //Arrange
            Kronor expected = new Kronor(-10, -0);
            Account testAccount = new Account(new Kronor(-10, -0));
            //Act   
            testAccount.Deposit(new Kronor(-5, -0));

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void Withdraw_AmountShouldBeAmountMinusValue()
        {
            //Arrange
            Kronor expected = new Kronor(14, 0);
            Account testAccount = new Account(new Kronor(15, 0));
            //Act   
            testAccount.Withdraw(new Kronor(1, 0));

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void Withdraw_AmountShouldBeUnchangedIfValueIsMoreThan10ProcentOfAmount()
        {
            //Arrange
            Kronor expected = new Kronor(15, 0);
            Account testAccount = new Account(new Kronor(15, 0));
            //Act   
            testAccount.Withdraw(new Kronor(10, 0));

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void Withdraw_AmountShouldBeUnchangedIfAmountAndValueIsNegative()
        {
            //Arrange
            Kronor expected = new Kronor(-15, 0);
            Account testAccount = new Account(new Kronor(-15, 0));
            //Act   
            testAccount.Withdraw(new Kronor(1, 0));

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void RemoveAll_AmountShouldBeZero()
        {
            //Arrange
            Kronor expected = new Kronor();
            Account testAccount = new Account(new Kronor(15, 78));
            //Act   
            testAccount.RemoveAll();

            //Assert
            Assert.Equal(expected.Öre, testAccount.Amount.Öre);
        }

        [Fact]
        public void Transfer()
        {
            //Arrange
            Account fromAccount = new Account(new Kronor(15, 78));
            Account toAccount = new Account(new Kronor());
            Kronor expectedFromAccount = new Kronor(14,78);
            Kronor expectedToAccount = new Kronor(1,0);

            //Act   
            Account.Transfer(fromAccount, toAccount, new Kronor(1, 0));

            //Assert
            Assert.True(fromAccount.Amount.Öre == expectedFromAccount.Öre);
            Assert.True(toAccount.Amount.Öre == expectedToAccount.Öre);

        }

        [Fact]
        public void Transfer_BothAmountShouldBeUnchangedIfOneOfTheValuesIsTooLarge()
        {
            //Arrange
            Account fromAccount = new Account(new Kronor(15, 78));
            Account toAccount = new Account(new Kronor());
            Kronor expectedFromAccount = new Kronor(15, 78);
            Kronor expectedToAccount = new Kronor();

            //Act   
            Account.Transfer(fromAccount, toAccount, new Kronor(15, 0));

            //Assert
            Assert.True(fromAccount.Amount.Öre == expectedFromAccount.Öre);
            Assert.True(toAccount.Amount.Öre == expectedToAccount.Öre);

        }
    }
}
