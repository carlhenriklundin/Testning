using System;

namespace Lektion2
{
    public class Wallet
    {
        // Mängden pengar i plånboken, får aldrig vara negativt
        private Kronor amount;
        public Kronor Amount => amount;

        // Skapar en tom plånbok
        public Wallet()
        {
            //Ändring efter test: Det måste skapas en ny instans av kronor.
            amount = new Kronor();    
        }

        // Skapar en plånbok med pengar i
        public Wallet(Kronor money)
        {
            //Ändring efter test: Det måste skapas en ny instans av kronor.
            amount = new Kronor();
            Add(money);
            //Ändring efter test: Det ska inte gå att skapa en plånbok med ett negativt värde.
            if (amount.isNegative()) amount = new Kronor();
        }

        /* 
         * Lägger till pengar till plånboken.
         */
        public void Add(Kronor money)
        {
            //Ändring efter test: Det ska inte gå att lägga till negativa tal.
            if (money.isNegative()) return;
            amount = amount.Add(money);
        }

        /*
         * Tar pengar ur plånboken
         * Det ska inte gå att ta ut mer pengar än vad som finns i plånboken
         */
        public void Remove(Kronor money)
        {
            //Ändring efter test: En if-sats behövs för att det inte ska gå att ta ut mer pengar än vad som finns.
            if (amount.Öre < money.Öre) return;
            //Ändring efter test: Metoden Substract ska kallas och inte Add.
            amount = amount.Subtract(money);
        }

        /*
         * Tar bort alla pengar ur plånboken
         */
        public void RemoveAll()
        {
            amount = new Kronor();
        }
    }
}
