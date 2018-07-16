using AirportWebApiBSA.DAL.EF;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

public class DataSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<AirportContext>();
        context.Database.EnsureCreated();
        SeedPilots(context);
        
        
        SeedTickets(context);
        SeedCrews(context);
        SeedStewardesses(context);
        SeedAirCraftTypes(context);
        SeedAirCrafts(context);
        SeedFlights(context);
        SeedDepartures(context);
    }

    public static void SeedPilots(AirportContext context)
    {
        if (!context.Pilots.Any())
        {
            var ItemsList = new List<Pilot>
            {
                new Pilot
                {
                    Name = "John",
                    Surname = "Galt",
                    Birthday = new DateTime(1985, 5, 15)
                },
                new Pilot
                {
                    Name = "Hank",
                    Surname = "Rearden",
                    Birthday = new DateTime(1975, 12, 7)
                },
                new Pilot
                {
                    Name = "Francisco",
                    Surname = "d'Anconia",
                    Birthday = new DateTime(1988, 9, 17)
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedStewardesses(AirportContext context)
    {
        if (!context.Stewardesses.Any())
        {
            var ItemsList = new List<Stewardess>
            {
                new Stewardess
                {
                    Name = "Maria",
                    Surname = "Hernandez",
                    Birthday = new DateTime(1996, 7, 11),
                    CrewId = 1
                    

                },
                new Stewardess
                {
                    Name = "Sarah",
                    Surname = "Williams",
                    Birthday = new DateTime(1995, 12, 7),
                    CrewId = 1
                },
                new Stewardess
                {
                    Name = "Ann",
                    Surname = "Jones",
                    Birthday = new DateTime(1988, 9, 17),
                    CrewId = 2
                },
                new Stewardess
                {
                    Name = "Nancy",
                    Surname = "Taylor",
                    Birthday = new DateTime(1997, 3, 4),
                    CrewId = 2
                },
                new Stewardess
                {
                    Name = "Catherine",
                    Surname = "Clark",
                    Birthday = new DateTime(1992, 1, 28),
                    CrewId = 3
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedFlights(AirportContext context)
    {
        if (!context.Flights.Any())
        {
            var ItemsList = new List<Flight>
            {
                new Flight
                {
                    DepartureTime = new DateTime(2018, 07, 24, 16, 30, 00),
                    ArrivalTime = new DateTime(2018, 07, 24, 23, 17, 00),
                    EntryPoint = "London",
                    Destination = "New-York",
                    Tickets = new List<Ticket>
                    {
                        new TicketRepository(context).Get(1),
                        new TicketRepository(context).Get(2)
                    }
                },
                new Flight
                {
                    DepartureTime = new DateTime(2018, 07, 25, 11, 15, 00),
                    ArrivalTime = new DateTime(2018, 07, 25, 14, 05, 00),
                    EntryPoint = "Kyiv",
                    Destination = "Munich",
                    Tickets = new List<Ticket>
                    {
                        new TicketRepository(context).Get(3),
                        new TicketRepository(context).Get(4),
                        new TicketRepository(context).Get(5)
                    }
                },
                new Flight
                {
                    DepartureTime = new DateTime(2018, 07, 26, 13, 47, 00),
                    ArrivalTime = new DateTime(2018, 07, 26, 15, 23, 00),
                    EntryPoint = "Amsterdam",
                    Destination = "Tanger",
                    Tickets = new List<Ticket>
                    {
                        new TicketRepository(context).Get(6),
                        new TicketRepository(context).Get(7),
                        new TicketRepository(context).Get(8)
                    }
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedDepartures(AirportContext context)
    {
        if (!context.Departures.Any())
        {
            var ItemsList = new List<Departure>
            {
                new Departure
                {
                    FlightNumber = 1,
                    DepartureDate = new DateTime(2018, 07, 24),
                    Crew = new CrewsRepository(context).Get(1),
                    AirCraft = new AirCraftRepository(context).Get(1)
                },
                new Departure
                {
                    FlightNumber = 2,
                    DepartureDate = new DateTime(2018, 07, 25),
                    Crew = new CrewsRepository(context).Get(2),
                    AirCraft = new AirCraftRepository(context).Get(2)
                },
                new Departure
                {
                    FlightNumber = 3,
                    DepartureDate = new DateTime(2018, 07, 24),
                    Crew = new CrewsRepository(context).Get(3),
                    AirCraft = new AirCraftRepository(context).Get(3)
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedAirCrafts(AirportContext context)
    {
        if (!context.AirCrafts.Any())
        {
            var ItemsList = new List<AirCraft>
            {
                new AirCraft
                {
                    Name = "DF-23",
                    AirCraftType = new AirCraftTypeRepository(context).Get(1),
                    Manufactured = new DateTime(1990, 12, 01)
                },
                new AirCraft
                {
                    Name = "DN-48",
                    AirCraftType = new AirCraftTypeRepository(context).Get(2),
                    Manufactured = new DateTime(2012, 4, 18)
                },
                new AirCraft
                {
                    Name = "KL-18",
                    AirCraftType = new AirCraftTypeRepository(context).Get(2),
                    Manufactured = new DateTime(2011, 9, 8)
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedAirCraftTypes(AirportContext context)
    {
        if (!context.AirCraftTypes.Any())
        {
            var ItemsList = new List<AirCraftType>
            {
                new AirCraftType
                {
                    Model = "Concord",
                    PassengersCapacity = 75,
                    CargoCapacity = 300
                },
                new AirCraftType
                {
                    Model = "Airbus A-380",
                    PassengersCapacity = 500,
                    CargoCapacity = 2000
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedCrews(AirportContext context)
    {
        if (!context.Crews.Any())
        {
            var ItemsList = new List<Crew>
            {
                new Crew
                {
                    Pilot = new PilotsRepository(context).Get(1),
                    
                },
                new Crew
                {
                    Pilot = new PilotsRepository(context).Get(2),
                    
                },
                new Crew
                {
                    Pilot = new PilotsRepository(context).Get(3),
                    
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static void SeedTickets(AirportContext context)
    {
        if (!context.Tickets.Any())
        {
            var ItemsList = new List<Ticket>
            {
                new Ticket
                {
                    FlightNumber = 1,
                    Price = 10000
                },
                new Ticket
                {
                    FlightNumber = 1,
                    Price = 12000
                },
                new Ticket
                {
                    FlightNumber = 2,
                    Price = 5000
                },
                new Ticket
                {
                    FlightNumber = 2,
                    Price = 4500
                },
                new Ticket
                {
                    FlightNumber = 2,
                    Price = 6000
                },
                new Ticket
                {
                    FlightNumber = 3,
                    Price = 8000
                },
                new Ticket
                {
                    FlightNumber = 3,
                    Price = 8000
                },
                new Ticket
                {
                    FlightNumber = 3,
                    Price = 7500
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }

}