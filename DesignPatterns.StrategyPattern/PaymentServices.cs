using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPattern
{
    internal class PaymentServices
    {
        static void Main(string[] args)
        {
            var paymentOptions = new PaymentOptions()
            {
                Amount = 0,
                CardHolderName = "Bedirhan Tong",
                CardNumber = "9471239441234",
                Cvv = "232",
                ExpirationDate = "12.04.2022"
            };

            var paymentService = new PaymentService();



            do
            {
                Console.WriteLine("Ödeme için banka seçiniz: (1: Garanti,  2: Ziraat,  3: Akbank)");
                var bank = Console.ReadLine();


                IPaymentService bankPaymentService = null;
                switch (bank)
                {
                    case "1":
                        bankPaymentService = new GarantiBankasiPayment();
                        break;
                    case "2":
                        bankPaymentService = new ZiraatBankasiPayment();
                        break;
                    case "3":
                        bankPaymentService = new AkbankBankasiPayment();
                        break;
                    default:
                        Console.WriteLine("Geçersiz banka seçimi");
                        break;

                }

                paymentService.SetPaymentService(bankPaymentService);
                paymentService.PayViaStrategy(paymentOptions);


            } while (Console.ReadKey().Key != ConsoleKey.Escape);













            //paymentService.SetPaymentService(new GarantiBankasiPayment());
            //paymentService.PayViaStrategy(paymentOptions);

            //paymentService.SetPaymentService(new ZiraatBankasiPayment());
            //paymentService.PayViaStrategy(paymentOptions);


            //paymentService.SetPaymentService(new AkbankBankasiPayment());
            //paymentService.PayViaStrategy(paymentOptions);




            Console.ReadLine();
        }
    }
    class PaymentService
    {
        private IPaymentService paymentService;


        public PaymentService(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        public PaymentService()
        {

        }
        public void SetPaymentService(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public bool PayViaStrategy(PaymentOptions paymentOption)
        {
            return paymentService.Pay(paymentOption);
        }

    }


    public class GarantiBankasiPayment : IPaymentService
    {
        public bool Pay(PaymentOptions paymentOptions)
        {
            Console.WriteLine("Garanti Bankası Payment Service");
            return true;
        }
    }

    public class ZiraatBankasiPayment : IPaymentService
    {
        public bool Pay(PaymentOptions paymentOptions)
        {
            Console.WriteLine("Ziraat Bankası Payment Service");
            return true;
        }

    }

    public class AkbankBankasiPayment : IPaymentService
    {
        public bool Pay(PaymentOptions paymentOptions)
        {
            Console.WriteLine("Akbank Bankası Payment Service");
            return true;
        }
    }

    interface IPaymentService
    {
        bool Pay(PaymentOptions paymentOptions);
    }

    public class PaymentOptions
    {


        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
        public decimal Amount { get; set; }

    }
}
