using System;

namespace Lektion2
{
    public class Kronor
    {
        /*
         * Totala värdet i öre. 
         * När vi väl har skapat ett Kronor-objekt ska det aldrig kunna ändras
         */
        private readonly int öre;

        public int Öre => öre;

        // Skapar tom Kronor
        public Kronor()
        {

        }

        // Skapar kopia av en annan Kronor
        public Kronor(Kronor kronor)
        {
            öre = kronor.ÖrenPart() + kronor.KronorPart() * 100;
        }
        /*
         * Skapar Kronor med initialt värde
         */
        public Kronor(int kronor, int öre)
        {
            //Ändring efter test: Det ska vara * 100 kronor istället för * 100 öre.
            this.öre = öre + kronor * 100;
        }

        /*
         * Returnerar kronordelen av kronorna
         */
        public int KronorPart()
        {
            //Ändring efter test: Det ska vara * 100 istället för * 10.
            return öre / 100;
        }


        /*
         * Returnerar öresdelen av kronorna
         */
        public int ÖrenPart()
        {
            //Ändring efter test: Det ska vara * 100 istället för * 10.
            return öre % 100;
        }
        /*
         * Adderar den här Kronor med other och returnerar resultatet
         */
        public Kronor Add(Kronor other)
        {
            //Ändring efter test. Första raden ska ändras.
            var temp = this.öre + other.öre;
            var tempKronor = temp / 100;
            var tempÖren = temp % 100;

            return new Kronor(tempKronor, tempÖren);
        }

        public Kronor Subtract(Kronor other)
        {
            //Ändring efter test. Första raden ska ändras.
            var temp = this.öre - other.öre;
            //Ändring efter test. Det ska stå 100 istället för 10.
            var tempKronor = temp / 100;
            var tempÖren = temp % 100;

            return new Kronor(tempKronor, tempÖren);
        }
        /*
         * Returnerar sant om kronorna har ett positivt värde
         */
        public bool IsPositive()
        {
            return öre > 0;
        }

        /*
         * Returnerar sant om kronorna har ett negativt värde
         */
        public bool isNegative()
        {
            //Ändring efter test. Det ska vara < och inte >.
            return öre < 0;
        }

        /*
         * Returnerar sant om kronorna har ett värde på 0
         */
        public bool isZero()
        {
            return öre == 0;
        }
    }
}
