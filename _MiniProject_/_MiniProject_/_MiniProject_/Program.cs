using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using _MiniProject_;


namespace MiniProject_TrainReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=ICS-LT-68Q0LQ3;Initial Catalog=MiniCaseStudyDB;Integrated Security=True";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                             WELCOME TO RAILWAYS  TICKET BOOKING SYSTEM           ");
            Console.ResetColor();
            Console.WriteLine();



            
            string adminUsername = "admin";
            string adminPassword = "admin@123";
            string userLoginId = "user";
            string userPassword = "user@123";

            Console.WriteLine("Select Option:");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Login");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdminLogin(adminUsername, adminPassword, connectionString);
                    break;
                case "2":
                    UserLogin(userLoginId, userPassword, connectionString);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.ReadKey();
        }

        static void AdminLogin(string adminUsername, string adminPassword , string connectionString)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\nADMIN LOGIN:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Username: ");
            string usernameInput = Console.ReadLine();
            Console.Write("Password: ");
            string passwordInput = Console.ReadLine();

            if (usernameInput == adminUsername && passwordInput == adminPassword)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("Admin logged in successfully.");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Select Option:");
                    Console.WriteLine("1. Add Train");
                    Console.WriteLine("2. Update Train");
                    Console.WriteLine("3. Delete Train");
                    Console.WriteLine("4. View Bookings");
                    Console.WriteLine("5. View Cancellations");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");
                    string adminChoice = Console.ReadLine();

                    switch (adminChoice)
                    {
                        case "1":
                            AddTrain( connectionString);
                            break;
                        case "2":
                            UpdateTrain( connectionString);
                            break;
                        case "3":
                            Console.Write("Enter Train ID to delete: ");
                            int trainIdToDelete = Convert.ToInt32(Console.ReadLine());
                            DeleteTrain(trainIdToDelete);
                            break;
                        case "4":
                            ViewBookings( connectionString);
                            break;
                        case "5":
                            ViewCancellations( connectionString);
                            break;
                        case "6":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.Write("Do you want to perform another action? (yes/no): ");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice.ToLower() != "yes")
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid admin login credentials.");
                Console.ReadLine();
                AdminLogin( adminUsername,  adminPassword,  connectionString);
            }

        }

        static void AddTrain(string connectionString)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\nAdd Train:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Enter Train ID: ");
            int trainId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Class: ");
            string trainClass = Console.ReadLine();
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string fromStation = Console.ReadLine();
            Console.Write("Enter To Station: ");
            string toStation = Console.ReadLine();
            Console.Write("Enter Total Berths: ");
            int totalBerths = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Available Berths: ");
            int availableBerths = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Fare: ");
            decimal fare = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Is Active (Active/Inactive): ");
            string isActive = Console.ReadLine();


            using (var context = new MiniCaseStudyDBEntities())
            {
                
                var existingTrain = context.trains.FirstOrDefault(t => t.Train_Id == trainId);
                if (existingTrain != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Error: Train with the same ID already exists.");
                    return;
                }

                
                var newTrain = new train
                {
                    Train_Id = trainId,
                    Class = trainClass,
                    TrainName = trainName,
                    FromStation = fromStation,
                    ToStation = toStation,
                    TotalBerths = totalBerths,
                    AvailableBerths = availableBerths,
                    Fare = fare,
                    IsActive = isActive
                };

                context.trains.Add(newTrain);
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("Train added successfully.");
            }
        }
        static void UpdateTrain(string connectionString)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\nUpdate Train:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Enter Train ID to update: ");
            int trainId = Convert.ToInt32(Console.ReadLine());

            using (var context = new MiniCaseStudyDBEntities())
            {
                
                var train = context.trains.FirstOrDefault(t => t.Train_Id == trainId);
                if (train != null)
                {
                    Console.WriteLine("Enter new details:");

                    Console.Write("New Train Name: ");
                    string newTrainName = Console.ReadLine();
                    Console.Write("New From Station: ");
                    string newFromStation = Console.ReadLine();
                    Console.Write("New To Station: ");
                    string newToStation = Console.ReadLine();
                    Console.Write("New Total Berths: ");
                    int newTotalBerths = Convert.ToInt32(Console.ReadLine());
                    Console.Write("New Available Berths: ");
                    int newAvailableBerths = Convert.ToInt32(Console.ReadLine());
                    Console.Write("New Fare: ");
                    decimal newFare = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Is Active (Active/Inactive): ");
                    string newIsActive = Console.ReadLine();

                    
                    train.TrainName = newTrainName;
                    train.FromStation = newFromStation;
                    train.ToStation = newToStation;
                    train.TotalBerths = newTotalBerths;
                    train.AvailableBerths = newAvailableBerths;
                    train.Fare = newFare;
                    train.IsActive = newIsActive;
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine("Train details updated successfully.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Error: Train not found.");
                }
            }
        }

        static void DeleteTrain(int trainId)
        {
            Console.Clear();
            using (var context = new MiniCaseStudyDBEntities())
            {
                var trainToDelete = context.trains.FirstOrDefault(t => t.Train_Id == trainId);
                if (trainToDelete != null)
                {
                    if (trainToDelete.IsActive.Equals("Active", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.Write("This train is active. Are you sure you want to delete it? (yes/no): ");
                        string confirmation = Console.ReadLine();
                        if (confirmation.ToLower() == "yes")
                        {
                            // Soft delete by setting IsActive to "Inactive"
                            trainToDelete.IsActive = "Inactive";
                            context.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Train deactivated successfully!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Train deactivation cancelled.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Train is already inactive.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Train not found.");
                }
            }
        }





        static void ViewBookings(string connectionString)
        {
            Console.Clear();
            using (var context = new MiniCaseStudyDBEntities())
            {
                var bookings = context.ViewBookings().ToList();
                Console.WriteLine("Bookings:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.Booking_Id}, Train ID: {booking.Train_Id}, Class: {booking.Class}, Passenger Name: {booking.PassengerName}");
                }
            }
        }

        static void ViewCancellations(string connectonString)
        {
            Console.Clear();
            using (var context = new MiniCaseStudyDBEntities())
            {
                var cancellations = context.ViewCancellations().ToList();
                Console.WriteLine("Cancellations:");
                foreach (var cancellation in cancellations)
                {
                    Console.WriteLine($"Cancellation ID: {cancellation.CancellationDetailId}, Booking ID: {cancellation.BookingId}, Seats Cancelled: {cancellation.SeatsCancelled}");
                }
            }
        }


        static void UserLogin(string userLoginId, string userPassword, string connectionString)
        {
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\nUSER LOGIN:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Login ID: ");
            string loginIdInput = Console.ReadLine();
            Console.Write("Password: ");
            string passwordInput = Console.ReadLine();

            if (loginIdInput == userLoginId && passwordInput == userPassword)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("User logged in successfully.");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("\nSelect Option:");
                    Console.WriteLine("1. Book Ticket");
                    Console.WriteLine("2. Cancel Ticket");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine("\nAvailable Trains:");
                            DisplayAvailableTrainsForBooking( connectionString);
                            Console.WriteLine("\nPassenger Booking:");
                            BookTicket(connectionString);
                            break;
                        case "2":
                            Console.WriteLine("\nPassenger Cancellation:");
                            CancelTicket(connectionString);
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Invalid user login credentials.");
                Console.ReadLine();
                UserLogin(userLoginId, userPassword, connectionString);
            }
        }

        static void DisplayAvailableTrainsForBooking(string connectionString)
        {
            using (var context = new MiniCaseStudyDBEntities())
            {
                var trains = context.trains.Where(t => t.IsActive.Equals("Active", StringComparison.OrdinalIgnoreCase)).ToList();
                if (trains.Any())
                {
                    Console.WriteLine("Available Trains:");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("| Train ID |   Class   |     Train Name          |   From     |    To      | Available Berths   |      Fare                    |");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------- -------------");
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"| {train.Train_Id,-9} | {train.Class,-9}  | {train.TrainName,-12}   | {train.FromStation,-8}  | {train.ToStation,-8} | {train.AvailableBerths,-17} | {train.Fare,-8:C}   |");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No available trains for booking.");
                }
            }
        }

        static void BookTicket(string connectonString)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Booking a ticket...");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("Enter Train ID: ");
            int trainId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Class: ");
            string trainClass = Console.ReadLine();
            Console.Write("Enter Passenger Name: ");
            string passengerName = Console.ReadLine();
            Console.Write("Enter Seats to Book: ");
            int seatsBooked = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Date of Travel (yyyy-MM-dd): ");
            DateTime dateOfTravel = DateTime.Parse(Console.ReadLine());

            using (var context = new MiniCaseStudyDBEntities())
            {
                var train = context.trains.FirstOrDefault(t => t.Train_Id == trainId && t.Class == trainClass);

                if (train != null && train.IsActive.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    if (train.AvailableBerths >= seatsBooked)
                    {
                        decimal totalAmount = (decimal)(seatsBooked * train.Fare);
                        var booking = new Booking
                        {
                            Train_Id = trainId,
                            Class = trainClass,
                            PassengerName = passengerName,
                            SeatsBooked = seatsBooked,
                            BookingDate = DateTime.Now,
                            DepartureDate = dateOfTravel, 
                            TotalAmount = totalAmount 
                        };

                        
                        train.AvailableBerths -= seatsBooked;

                        
                        context.Bookings.Add(booking);
                        context.SaveChanges();

                        
                        Console.WriteLine();
                        Console.WriteLine("Ticket booked successfully!");
                        Console.WriteLine();
                        Console.WriteLine("Ticket Details:");
                        Console.WriteLine($"Booking ID: {booking.Booking_Id}");
                        Console.WriteLine($"Train ID: {booking.Train_Id}");
                        Console.WriteLine($"Class: {booking.Class}");
                        Console.WriteLine($"Passenger Name: {booking.PassengerName}");
                        Console.WriteLine($"Seats Booked: {booking.SeatsBooked}");
                        Console.WriteLine($"Booking Date: {booking.BookingDate}");
                        Console.WriteLine($"Departure Date: {booking.DepartureDate}");
                        Console.WriteLine($"Total Amount: {booking.TotalAmount:C}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Not enough available berths.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Error: The selected train is not active or does not exist.");
                }
            }
        }




        static void CancelTicket(string connectonString)

        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Canceling a ticket...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Seats to Cancel: ");
            int seatsToCancel = Convert.ToInt32(Console.ReadLine());

            using (var context = new MiniCaseStudyDBEntities())
            {
                var booking = context.Bookings.FirstOrDefault(b => b.Booking_Id == bookingId);
                if (booking != null)
                {
                    decimal refundAmount = (decimal)(seatsToCancel * booking.train.Fare);

                    if (seatsToCancel <= booking.SeatsBooked)
                    {
                   
                        var cancellationDetails = new CancellationDetail
                        {
                            BookingId = bookingId,
                            SeatsCancelled = seatsToCancel,
                            RefundAmount = refundAmount,
                            CancellationDate = DateTime.Now
                        };

                        context.CancellationDetails.Add(cancellationDetails);
                        booking.SeatsBooked -= seatsToCancel;

                        if (booking.SeatsBooked == 0)
                        {
                            context.Bookings.Remove(booking);
                        }

                        _ = context.SaveChanges();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Ticket canceled successfully! Refund Amount: {refundAmount:C}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Error: Invalid number of seats to cancel.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Error: Booking ID not found.");
                }
            }
        }
    }
}