# EventBooking

Event Booking System
The Event Booking System is a web-based application that provides users with the ability to browse upcoming events, book seats, and manage their event reservations. Event organizers can also list their events and manage attendee bookings through this platform.

Features
User Registration and Login: Create accounts and securely log in using user authentication.

Upcoming Events: View a list of upcoming events, including event details like name, date, venue, and available seats.

Event Details: Click on an event to access detailed information, including event name, date, venue, and available seats status.

Booking Seats: Book a specified number of seats for an event, subject to available seat capacity. Users receive booking confirmations via email.

Booking Confirmation: Users receive email confirmations after successfully booking seats, containing event details and booking information.

User Bookings: Access a list of booked events, displaying event names, dates, and venues. Users can also cancel bookings.

Venue Exploration: Explore a comprehensive list of available venues, with names and addresses.

Admin Event Management: Admins can effortlessly add new events to the system, update event details, and view booking information.

Email Notifications: Users receive automated email reminders 24 hours before their booked events, including event details and a reminder to attend.

Database Design
Tables: Users, Events, Venues, Bookings
Relationships: Users are linked to Booked Events, Events are associated with Venues, Bookings link Users and Events.
Technology Stack
Frontend: HTML, CSS, JavaScript
Backend: .NET (C#)
Database: Microsoft SQL Server
User Authentication: ASP.NET Identity
How to Use
Clone this repository to your local environment.
Set up the database using the provided SQL scripts.
Configure the connection strings in the backend code.
Build and run the application to start exploring events and booking seats.
Project Benefits
Streamlines event organization for event organizers.
Provides users with a convenient platform to discover and book events.
Enhances attendee engagement through automatic email reminders.
Admin tools simplify event management processes.
Project Impact
The Event Booking System revolutionizes event organization and attendance, benefiting both event organizers and attendees. It optimizes event booking, confirmation, and communication, elevating user experience and engagement.
