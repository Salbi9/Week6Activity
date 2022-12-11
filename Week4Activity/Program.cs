using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydneyHotel
{
    class Program
    {
        class ReservationDetail
        {
            public string customerName { get; set; }
            public int age { get; set; }
            public int nights { get; set; }
            public string roomService { get; set; }
            public double totalPrice { get; set; }

        }
        // calulation of room services
        //Pujan Budathoki
        static double Price(int night, string isRoomService, int age)
        {
            double price = 0;
            if ((night > 0) && (night <= 3))
            {
                if (age < 7)
                {
                    price = 0.5 * 100 * night;
                }
                else
                {
                    price = 100 * night;
                }
            }
            else if ((night > 3) && (night <= 10))
            {
                if (age < 7)
                {
                    price = 0.5* 80.5 * night;
                }
                else
                {
                    price = 80.5 * night;
                }
            }
            else if ((night > 10) && (night <= 20))
            {
                if (age < 7)
                {
                    price = 0.5 *75.3 * night;
                }
                else
                {
                    price = 75.3 * night;
                }
            }
            //roomservice should be checked to lower yes
            if (isRoomService.ToLower()=="yes")
                return price+price*0.1;
            else
                return price;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel...............");
            Console.Write("\nEnter no. of Customer: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n--------------------------------------------------------------------\n");

            ReservationDetail[] rd = new ReservationDetail[n];
            //double total = 0;

            for (int i = 0; i < n; i++)
            {
                rd[i] = new ReservationDetail();
                DateTime now = DateTime.Now;
                Console.Write("Enter customer name: ");
                rd[i].customerName=Console.ReadLine();

                Console.Write("Enter your age: ");
                rd[i].age = Convert.ToInt32(Console.ReadLine());
               

                Console.Write("Enter the number of nights: ");
                rd[i].nights=Convert.ToInt32(Console.ReadLine());
                if (!(rd[i].nights > 0) && (rd[i].nights <= 20))
                {
                    Console.Write("Number of nights in between 1 to 20: ");

                    Console.Write("Enter the number of nights: ");
                    rd[i].nights = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Enter yes/no to indicate wheather you want a room service: ");
                rd[i].roomService=Console.ReadLine();

                rd[i].totalPrice = Price(rd[i].nights, rd[i].roomService, rd[i].age);
                Console.WriteLine($"The total price for {rd[i].customerName} is ${rd[i].totalPrice}");
                Console.WriteLine("\n--------------------------------------------------------------------");
                Console.WriteLine("The date and time of this booking details is:");
                Console.WriteLine(now.ToString("ddd MMM %d, yyyy"));
                Console.WriteLine(now.ToString("hh:mm:ss tt"));
                Console.WriteLine("\n--------------------------------------------------------------------");

                //total = total + rd[i].totalPrice;                
            }
            //Console.WriteLine("The total spendings of all customers is: ${0}", total);

            var (minPrice,minindex) = rd.Select(x=>x.totalPrice).Select((m,i) => (m,i)).Min();
            var (maxPrice,maxindex) = rd.Select(x => x.totalPrice).Select((m, i) => (m, i)).Max();

            ReservationDetail maxrd = rd[maxindex];
            ReservationDetail minrd =rd[minindex];

            Console.WriteLine("\n\t\t\t\tSummary of reservation");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine("Name\t\tNumber of nights\t\tRoom service\t\tCharge");
            Console.WriteLine($"{minrd.customerName}\t\t\t{minrd.nights}\t\t\t{minrd.roomService}\t\t\t{minrd.totalPrice}");
            Console.WriteLine($"{maxrd.customerName}\t\t\t{maxrd.nights}\t\t\t{maxrd.roomService}\t\t\t{maxrd.totalPrice}");
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine($"The customer spending the most is {maxrd.customerName}: ${maxrd.totalPrice}");
            Console.WriteLine($"The customer spending the least is {minrd.customerName}: ${minrd.totalPrice}");

            
            Console.WriteLine($"Press any key to continue....");
            Console.ReadLine();

        }
    }
}
