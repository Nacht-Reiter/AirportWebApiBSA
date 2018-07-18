using AirportWebApiBSA.DAL.EF;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DataSeeder
{
    public static async void Seed(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<AirportContext>();
        context.Database.EnsureCreated();
        await SeedPilots(context);
            
        SeedTickets(context).Wait();
        SeedCrews(context).Wait();
        SeedStewardesses(context).Wait();
        SeedAirCraftTypes(context).Wait();
        SeedAirCrafts(context).Wait();
        SeedFlights(context).Wait();
        SeedDepartures(context).Wait();

    }

    public static async Task SeedPilots(AirportContext context)
    {
        if (!context.Pilots.Any())
        {
            var ItemsList = new List<Pilot>
            {
                new Pilot
                {
                    FirstName = "John",
                    LastName = "Galt",
                    Birthday = new DateTime(1985, 5, 15),
                    Expirience = 5
                },
                new Pilot
                {
                    FirstName = "Hank",
                    LastName = "Rearden",
                    Birthday = new DateTime(1975, 12, 7),
                    Expirience = 3
                },
                new Pilot
                {
                    FirstName = "Francisco",
                    LastName = "d'Anconia",
                    Birthday = new DateTime(1988, 9, 17),
                    Expirience = 2
                }
            };
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();
        }

    }
    public static async Task SeedStewardesses(AirportContext context)
    {
        if (!context.Stewardesses.Any())
        {
            var ItemsList = new List<Stewardess>
            {
                new Stewardess
                {

                    FirstName = "Maria",
                    LastName = "Hernandez",
                    Birthday = new DateTime(1996, 7, 11),
                    CrewId = 1
                    

                },
                new Stewardess
                {
                    FirstName = "Sarah",
                    LastName = "Williams",
                    Birthday = new DateTime(1995, 12, 7),
                    CrewId = 1
                },
                new Stewardess
                {
                    FirstName = "Ann",
                    LastName = "Jones",
                    Birthday = new DateTime(1988, 9, 17),
                    CrewId = 2
                },
                new Stewardess
                {
                    FirstName = "Nancy",
                    LastName = "Taylor",
                    Birthday = new DateTime(1997, 3, 4),
                    CrewId = 2
                },
                new Stewardess
                {
                    FirstName = "Catherine",
                    LastName = "Clark",
                    Birthday = new DateTime(1992, 1, 28),
                    CrewId = 3
                }
            };
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();

        }

    }
    public static async Task SeedFlights(AirportContext context)
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
                        await new TicketRepository(context).Get(1),
                        await new TicketRepository(context).Get(2)
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
                        await new TicketRepository(context).Get(3),
                        await new TicketRepository(context).Get(4),
                        await new TicketRepository(context).Get(5)
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
                        await new TicketRepository(context).Get(6),
                        await new TicketRepository(context).Get(7),
                        await new TicketRepository(context).Get(8)
                    }
                }
            };
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();
        }

    }
    public static async Task SeedDepartures(AirportContext context)
    {
        if (!context.Departures.Any())
        {
            var ItemsList = new List<Departure>
            {
                new Departure
                {
                    FlightNumber = 1,
                    DepartureDate = new DateTime(2018, 07, 24),
                    Crew = await new CrewsRepository(context).Get(1),
                    AirCraft = await new AirCraftRepository(context).Get(1)
                },
                new Departure
                {
                    FlightNumber = 2,
                    DepartureDate = new DateTime(2018, 07, 25),
                    Crew = await new CrewsRepository(context).Get(2),
                    AirCraft = await new AirCraftRepository(context).Get(2)
                },
                new Departure
                {
                    FlightNumber = 3,
                    DepartureDate = new DateTime(2018, 07, 24),
                    Crew = await new CrewsRepository(context).Get(3),
                    AirCraft = await new AirCraftRepository(context).Get(3)
                }
            };
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();
        }

    }
    public static async Task SeedAirCrafts(AirportContext context)
    {
        if (!context.AirCrafts.Any())
        {
            var ItemsList = new List<AirCraft>
            {
                new AirCraft
                {
                    Name = "DF-23",
                    AirCraftType = await new AirCraftTypeRepository(context).Get(1),
                    Manufactured = new DateTime(1990, 12, 01),
                    Age = 28
                },
                new AirCraft
                {
                    Name = "DN-48",
                    AirCraftType = await new AirCraftTypeRepository(context).Get(2),
                    Manufactured = new DateTime(2012, 4, 18),
                    Age = 6
                },
                new AirCraft
                {
                    Name = "KL-18",
                    AirCraftType = await new AirCraftTypeRepository(context).Get(2),
                    Manufactured = new DateTime(2011, 9, 8),
                    Age = 7
                }
            };
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();
            context.Dispose();
        }

    }
    public static async Task SeedAirCraftTypes(AirportContext context)
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
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();
        }

    }
    public static async Task SeedCrews(AirportContext context)
    {
        if (!context.Crews.Any())
        {
            var ItemsList = new List<Crew>
            {
                new Crew
                {
                    Pilot = await new PilotsRepository(context).Get(1),
                    
                },
                new Crew
                {
                    Pilot = await new PilotsRepository(context).Get(2),
                    
                },
                new Crew
                {
                    Pilot = await new PilotsRepository(context).Get(3),
                    
                }
            };
            context.AddRange(ItemsList);
            context.SaveChanges();
        }

    }
    public static async Task SeedTickets(AirportContext context)
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
            await context.AddRangeAsync(ItemsList);
            context.SaveChanges();
        }

    }

}