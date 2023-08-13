# Event Booking System

**Project Description:**
The Event Booking System is a web-based application that allows users to view upcoming events, book seats, and manage their event reservations. The system provides a platform for event organizers to list their events and manage attendee bookings. Users can browse through a variety of events, view event details, book seats, receive booking confirmations, and receive reminders about their upcoming events.

## Key Features:

- **User Registration and Login:**
  - Users can create accounts and log in securely.
  - User authentication ensures data privacy and security.

- **Upcoming Events:**
  - Users can view a list of upcoming events.
  - Events include details such as name, date, venue, and available seats.
  - Past events and canceled events are not displayed.

- **Event Details:**
  - Users can click on an event to view its details.
  - Event details page includes event name, date, venue, and available seats.
  - Users can see if an event is fully booked.

- **Booking Seats:**
  - Users can book a specific number of seats for an event.
  - Booking is subject to available seat capacity.
  - Booking confirmation email is sent to users.

- **Booking Confirmation:**
  - Users receive an email confirmation upon successful booking.
  - Confirmation email contains event details and booking information.

- **User Bookings:**
  - Users can view a list of their booked events.
  - Booked events display event name, date, and venue.
  - Users can cancel their bookings.

- **Venue Exploration:**
  - Users can explore a list of available venues.
  - Venue list includes names and addresses.

- **Admin Event Management:**
  - Admins can add new events to the system.
  - Admins can update event details such as name, date, venue, and available seats.
  - Admins can view a list of all bookings for an event.

- **Email Notifications:**
  - Users receive email reminders 24 hours before their booked events.
  - Reminders include event details and a reminder to attend.

## Database Design:

- **Tables:** Users, Events, Venues, Bookings
- **Relationships:** Users have booked Events, Events take place at Venues, Bookings link Users and Events

## Technology Stack:

- **Frontend:** HTML, CSS, JavaScript
- **Backend:** .NET (C#)
- **Database:** Microsoft SQL Server
- **User Authentication:** ASP.NET Identity

## Project Benefits:

- Event organizers can easily list events and manage bookings.
- Users have a convenient platform to discover and book events.
- Automatic email reminders improve attendee engagement.
- Admin tools streamline event management processes.

## Project Impact:

The Event Booking System simplifies the process of event organization and attendance for both event organizers and attendees. It streamlines event booking, confirmation, and communication, enhancing user experience and engagement.
