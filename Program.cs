using System;

namespace PaymentTypes_State
{
    class Payment
    {
        // A reference to the current items of the Payment.
        private PaymentFor _paymentfor = null;

        public Payment(PaymentFor items)
        {
            this.TransitionTo(items);
        }

        // The Payment allows changing the PaymentFor object at runtime.
        public void TransitionTo(PaymentFor items)
        {
            Console.WriteLine($"Payment: Transition to {items.GetType().Name}.");
            this._paymentfor = items;
            this._paymentfor.SetItems(this);
        }

        // The Payment delegates part of its behavior to the current PaymentFor
        // object.
        public void physicalproduct()
        {
            this._paymentfor.Action_PhysicalProduct();
        }

        public void book()
        {
            this._paymentfor.Action_Book();
        }

        public void membership()
        {
            this._paymentfor.Action_membership();
        }

        public void upgrademembership()
        {
            this._paymentfor.Action_upgrademembership();
        }

        public void video()
        {
            this._paymentfor.Action_video();
        }

    }

    abstract class PaymentFor
    {
        protected Payment _payment;

        public void SetItems(Payment payment)
        {
            this._payment = payment;
        }

        public abstract void Action_PhysicalProduct();

        public abstract void Action_Book();

        public abstract void Action_membership();

        public abstract void Action_upgrademembership();

        public abstract void Action_video();

    }

    /// <summary>
    /// If Payment is for Physical Product : To generate a Pakcing slip along with generating a commission payment to an agent.
    /// </summary>
    class PhysicalProduct : PaymentFor
    {
        public override void Action_PhysicalProduct()
        {
            Console.WriteLine("Payment for Physical Product");
            Console.WriteLine("Generate a packing slip fro shipping.");
            Console.WriteLine("Generate a commission payment to an agent.");
            this._payment.TransitionTo(new Book());
        }

        public override void Action_Book()
        {
            Console.WriteLine("PhysicalProduct handles Action_Book ");
        }

        public override void Action_membership()
        {
            Console.WriteLine("PhysicalProduct handles Action_membership");
        }

        public override void Action_upgrademembership()
        {
            Console.WriteLine("PhysicalProduct handles Action_upgrademembership");
        }

        public override void Action_video()
        {
            Console.Write("PhysicalProduct handles Action_video");
        }
    }

    /// <summary>
    /// If Payment is for Book: To generate duplicate Pakcing slip for royalty department along with generating a commission payment to an agent.
    /// </summary>
    class Book : PaymentFor
    {
        public override void Action_PhysicalProduct()
        {
            Console.Write("Book handles Action_PhysicalProduct.");
        }

        public override void Action_Book()
        {
            Console.WriteLine("Payment for BOOK.");
            Console.WriteLine("Duplicate packing Slip for royalty department.");
            Console.WriteLine("Generate a commission payment to an agent.");
            this._payment.TransitionTo(new Membership());
        }

        /// <summary>
        /// If Payment is for Membership: Activate membership + Email owner informing on Membership activation.
        /// </summary>
        public override void Action_membership()
        {
            Console.Write("Book handles Action_membership.");
        }

        /// <summary>
        /// If Payment is to Upgrade Membership: Apply an upgradation + Email owner informing on Membership upgradation.
        /// </summary>
        public override void Action_upgrademembership()
        {
            Console.WriteLine("Book handles Action_upgrademembership.");
        }

        /// <summary>
        /// If Payment is for Vido: Add free first aid viddo the the packing slip.
        /// </summary>
        public override void Action_video()
        {
            Console.Write("Book handles Action_video.");
        }


    }


    /// <summary>
    /// If Payment is for Membership : Activate Membership + Email owner and inform on Membership activation.
    /// </summary>
    class Membership : PaymentFor
    {
     
        public override void Action_PhysicalProduct()
        {
            Console.Write("Membership handles Action_PhysicalProduct .");
        }

        public override void Action_Book()
        {
            Console.Write("Membership handles Action_Book.");
        }

        public override void Action_membership()
        {
            Console.WriteLine("Payment for Membership.");
            Console.WriteLine("Activate the Membership.");
            Console.WriteLine("Email the owner & inform on Activation.");
            this._payment.TransitionTo(new UpgradeMembership());
        }

        public override void Action_upgrademembership()
        {
            Console.WriteLine("Membership handles Action_upgrademembership.");
        }

        public override void Action_video()
        {
            Console.Write("Membership handles Action_video.");
        }
        
    }

    /// <summary>
    /// If Payment is to upgrade Membership : Apply upgradation on Membership + Email owner and inform on Membership upgradation.
    /// </summary>
    class UpgradeMembership : PaymentFor
    {
        public override void Action_PhysicalProduct()
        {
            Console.Write("UpgradeMembership handles Action_PhysicalProduct.");
        }
        public override void Action_Book()
        {
            Console.Write("UpgradeMembership handles Action_Book.");
        }
    
        public override void Action_membership()
        {
            Console.Write("UpgradeMembership handles Action_membership.");
        }

        public override void Action_upgrademembership()
        {
            Console.WriteLine("Payment for Membership Upgrade.");
            Console.WriteLine("Apply an upgradation");
            Console.WriteLine("Email the owner & inform on Activation.");
            this._payment.TransitionTo(new Video());
        }
        public override void Action_video()
        {
            Console.Write("UpgradeMembership handles Action_video.");
        }

  
    }

    /// <summary>
    /// If Payment is Video : Add free first aid video to the packing slip.
    /// </summary>
    class Video : PaymentFor
    {
        public override void Action_PhysicalProduct()
        {
            Console.Write("Video handles Action_PhysicalProduct.");
        }

        public override void Action_Book()
        {
            Console.Write("Video handles Action_Book.");
        }


        public override void Action_membership()
        {
            Console.Write("Video handles Action_membership.");
        }

        public override void Action_upgrademembership()
        {
            Console.Write("Video handles Action_upgrademembership.");
        }

        public override void Action_video()
        {
            Console.WriteLine("Payment for Video.");
            Console.WriteLine("To add free First aid video to packing slip");
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var payment = new Payment(new PhysicalProduct());
            payment.physicalproduct();
            payment.book();
            payment.membership();
            payment.upgrademembership();
            payment.video();


        }
    }

}


