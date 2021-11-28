using System;

namespace Lektion2
{
    public class Account
    {
        /*
         * Mängden pengar i kontot.
         * Får vara negativt, men aldrig minska när det redan är negativt
         * Exempel:
         * 5 - 10 är tillåtet
         * -10 + 5 är tillåtet
         * -1 + 7 är tillåtet
         * -10 -5 är inte tillåtet
         */
        private Kronor amount;
        public Kronor Amount => amount;

        // Skapar ett tomt konto
        public Account()
        {
            //Ändring efter test: Det behövs skapas en ny instans av Kronor.
            amount = new Kronor();
        }

        // Skapar ett konto med pengar i
        public Account(Kronor money)
        {
            //Ändring efter test: Det behövs skapas en ny instans av Kronor.
            amount = new Kronor();
            Deposit(money);
        }

        /* 
         * Sätter in pengar på kontot.
         */
        public void Deposit(Kronor money)
        {
            //Ändring efter test: Det behövs en if-sats så att det inte ska gå att lägga till negativt tal om amount redan är negativt.
            if (money.isNegative() && amount.isNegative()) return;
            amount = amount.Add(money);
        }

        /*
         * Tar ut pengar ur kontot
         * Minst 90% av pengarna måste finnas på kontot för att uttaget ska godkännas
         */
        public void Withdraw(Kronor money)
        {
            //Ändring efter test: Det behövs en if-sats som gör return om money är mer än 10% av amount.
            if (amount.Öre / 10 < money.Öre) return;
            amount = amount.Subtract(money);
        }

        /*
         * Tar bort alla pengar ur plånboken
         */
        public void RemoveAll()
        {
            amount = new Kronor();
        }

        /*
         * Överför pengar mellan två konton
         * Pengarna ska tas bort från from-kontot och läggas till till to-kontot
         * Övriga regler ska också upprätthållas
         */
        public static void Transfer(Account from, Account to, Kronor amount)
        {
            //Ändring efter test: Metoderna Withdraw och Add ska kallas för att övriga regler ska upprätthållas. 
            Kronor temp = from.amount;
            from.Withdraw(amount);

            if (temp.Öre == from.amount.Öre) return;
            
            to.amount = to.Amount.Add(amount);
        }
    }
}
