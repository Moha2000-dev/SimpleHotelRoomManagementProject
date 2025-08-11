using System;
using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Services;
using SimpleHotelRoomManagementProject.Repositories;
using SimpleHotelRoomManagementProject.Helpers;

namespace SimpleHotelRoomManagementProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Explicit types for repositories and services
            IRoomRepository roomRepo = new RoomRepository();
            IGuestRepository guestRepo = new GuestRepository();
            IBookingRepository bookingRepo = new BookingRepository();
            IReviewRepository reviewRepo = new ReviewRepository();

            IRoomService roomService = new RoomService(roomRepo);
            IGuestService guestService = new GuestService(guestRepo);
            IBookingService bookingService = new BookingService(bookingRepo);
            IReviewService reviewService = new ReviewService(reviewRepo);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===== Simple Hotel Room Management =====");
                Console.WriteLine("1. List all rooms");
                Console.WriteLine("2. Add a new room");
                Console.WriteLine("3. List all guests");
                Console.WriteLine("4. Add a new guest");
                Console.WriteLine("5. List all bookings");
                Console.WriteLine("6. Add a new booking");
                Console.WriteLine("7. List all reviews");
                Console.WriteLine("8. Add a new review");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        List<Room> rooms = roomService.GetAllRooms();
                        foreach (Room room in rooms)
                            Console.WriteLine($"{room.RoomId} | {room.RoomNumber} | {room.Type} | {room.PricePerNight:C} | Available: {room.IsAvailable}");
                        break;
                    case "2":
                        Room newRoom = new Room();
                        Console.Write("Room Number: "); newRoom.RoomNumber = Console.ReadLine();
                        Console.Write("Type: "); newRoom.Type = Console.ReadLine();
                        Console.Write("Price Per Night: "); newRoom.PricePerNight = decimal.Parse(Console.ReadLine());
                        newRoom.IsAvailable = true;
                        roomService.AddRoom(newRoom);
                        Console.WriteLine("Room added!\n");
                        break;
                    case "3":
                        List<Guest> guests = guestService.GetAllGuests();
                        foreach (Guest guest in guests)
                            Console.WriteLine($"{guest.GuestId} | {guest.Name} | {guest.Email}");
                        break;
                    case "4":
                        Guest newGuest = new Guest();
                        Console.Write("Name: "); newGuest.Name = Console.ReadLine();
                        Console.Write("Email: "); newGuest.Email = Console.ReadLine();
                        Console.Write("Phone: "); newGuest.PhoneNumber = Console.ReadLine();
                        newGuest.CheckInDate = DateTime.Now;
                        newGuest.CheckOutDate = DateTime.Now.AddDays(1);
                        guestService.AddGuest(newGuest);
                        Console.WriteLine("Guest added!\n");
                        break;
                    case "5":
                        List<Booking> bookings = bookingService.GetAllBookings();
                        foreach (Booking booking in bookings)
                            Console.WriteLine($"{booking.BookingId} | Guest: {booking.GuestId} | Room: {booking.RoomId} | {booking.CheckInDate:d} - {booking.CheckOutDate:d} | {booking.Status}");
                        break;
                    case "6":
                        Booking newBooking = new Booking();
                        Console.Write("Guest ID: "); newBooking.GuestId = int.Parse(Console.ReadLine());
                        Console.Write("Room ID: "); newBooking.RoomId = int.Parse(Console.ReadLine());
                        Console.Write("Check-in date (yyyy-mm-dd): "); newBooking.CheckInDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Check-out date (yyyy-mm-dd): "); newBooking.CheckOutDate = DateTime.Parse(Console.ReadLine());
                        newBooking.Status = "Confirmed";
                        newBooking.TotalAmount = 0; // Optionally calculate
                        bookingService.AddBooking(newBooking);
                        Console.WriteLine("Booking added!\n");
                        break;
                    case "7":
                        List<Review> reviews = reviewService.GetAllReviews();
                        foreach (Review review in reviews)
                            Console.WriteLine($"{review.ReviewId} | Guest: {review.GuestId} | Room: {review.RoomId} | {review.Rating}/5 | {review.Comment}");
                        break;
                    case "8":
                        Review newReview = new Review();
                        Console.Write("Guest ID: "); newReview.GuestId = int.Parse(Console.ReadLine());
                        Console.Write("Room ID: "); newReview.RoomId = int.Parse(Console.ReadLine());
                        Console.Write("Reviewer Name: "); newReview.ReviewerName = Console.ReadLine();
                        Console.Write("Rating (1-5): "); newReview.Rating = int.Parse(Console.ReadLine());
                        Console.Write("Comment: "); newReview.Comment = Console.ReadLine();
                        newReview.Date = DateTime.Now;
                        reviewService.AddReview(newReview);
                        Console.WriteLine("Review added!\n");
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
