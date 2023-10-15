using SmartEstimate.Models;

namespace SmartEstimate.Mock;

public static class QuoteMock {

    public static Dictionary<int, Quote> GetQuoteMockDict()
    {
        return new Dictionary<int, Quote>
        {
            { 1, new Quote {
                DbProps = new DbProps { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                Name = "Quote 1",
                SalesAssociate = "John Doe",
                ContactInfo = "johndoe@example.com",
                DealerAddress = new ShippingAddress {
                    Name = "Dealer 1",
                    Line1 = "123 Main St",
                    Line2 = "",
                    City = "Toronto",
                    Ontario = "ON",
                    PostalCode = "M1M 1M1"
                },
                CustomerAddress = new ShippingAddress {
                    Name = "Customer 1",
                    Line1 = "456 Elm St",
                    Line2 = "",
                    City = "Mississauga",
                    Ontario = "ON",
                    PostalCode = "L5L 5L5"
                },
                IsPickup = true,
                IsDelivery = false,
                IsDealer = true,
                IsApartment = false,
                IsMultiLevel = false,
                IsFreightForwarder = false,
                Status = QuoteStatus.Draft,
                CatelogPdfUrl = "https://example.com/catalog.pdf",
                Rooms = new List<Room> {
                    new Room {
                        DbProps = new DbProps { CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                        Name = "Room 1",
                        DoorStyle = new DoorStyle {
                            DbProps = new DbProps { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Style 1",
                            Price = 100.0f
                        },
                        Finish = new Finish {
                            DbProps = new DbProps { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Finish 1",
                            Price = 50.0f
                        },
                        Interior = new Interior {
                            DbProps = new DbProps { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Interior 1",
                            Price = 75.0f
                        },
                        DrawerHardware = new DrawerHardware {
                            DbProps = new DbProps { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Hardware 1",
                            Price = 25.0f
                        },
                        SubTotal = 250.0f,
                        Products = new List<Product> {
                            new Product {
                                DbProps = new DbProps { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P1",
                                Width = 10.0f,
                                Height = 20.0f,
                                Depth = 5.0f,
                                Left = true,
                                Right = false,
                                Int = 1,
                                Comments = "",
                                Price = 100.0f,
                                EXT = "",
                                Name = "Product 1"
                            },
                            new Product {
                                DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P2",
                                Width = 15.0f,
                                Height = 25.0f,
                                Depth = 10.0f,
                                Left = false,
                                Right = true,
                                Int = 2,
                                Comments = "",
                                Price = 150.0f,
                                EXT = "",
                                Name = "Product 2"
                            }
                        }
                    }
                }
            }},
            { 2, new Quote {
                DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                Name = "Quote 2",
                SalesAssociate = "Jane Smith",
                ContactInfo = "janesmith@example.com",
                DealerAddress = new ShippingAddress {
                    Name = "Dealer 2",
                    Line1 = "789 Oak St",
                    Line2 = "",
                    City = "Vancouver",
                    Ontario = "BC",
                    PostalCode = "V6H 1K2"
                },
                CustomerAddress = new ShippingAddress {
                    Name = "Customer 2",
                    Line1 = "321 Pine St",
                    Line2 = "",
                    City = "Burnaby",
                    Ontario = "BC",
                    PostalCode = "V5G 1A1"
                },
                IsPickup = false,
                IsDelivery = true,
                IsDealer = false,
                IsApartment = true,
                IsMultiLevel = false,
                IsFreightForwarder = false,
                Status = QuoteStatus.Draft,
                CatelogPdfUrl = "https://example.com/catalog.pdf",
                Rooms = new List<Room> {
                    new Room {
                        DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                        Name = "Room 1",
                        DoorStyle = new DoorStyle {
                            DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Style 1",
                            Price = 100.0f
                        },
                        Finish = new Finish {
                            DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Finish 1",
                            Price = 50.0f
                        },
                        Interior = new Interior {
                            DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Interior 1",
                            Price = 75.0f
                        },
                        DrawerHardware = new DrawerHardware {
                            DbProps = new DbProps { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Hardware 1",
                            Price = 25.0f
                        },
                        SubTotal = 250.0f,
                        Products = new List<Product> {
                            new Product {
                                DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P1",
                                Width = 10.0f,
                                Height = 20.0f,
                                Depth = 5.0f,
                                Left = true,
                                Right = false,
                                Int = 1,
                                Comments = "",
                                Price = 100.0f,
                                EXT = "",
                                Name = "Product 1"
                            },
                            new Product {
                                DbProps = new DbProps { Id = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P2",
                                Width = 15.0f,
                                Height = 25.0f,
                                Depth = 10.0f,
                                Left = false,
                                Right = true,
                                Int = 2,
                                Comments = "",
                                Price = 150.0f,
                                EXT = "",
                                Name = "Product 2"
                            }
                        }
                    },
                    new Room {
                        DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                        Name = "Room 2",
                        DoorStyle = new DoorStyle {
                            DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Style 2",
                            Price = 200.0f
                        },
                        Finish = new Finish {
                            DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Finish 2",
                            Price = 100.0f
                        },
                        Interior = new Interior {
                            DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Interior 2",
                            Price = 150.0f
                        },
                        DrawerHardware = new DrawerHardware {
                            DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Hardware 2",
                            Price = 50.0f
                        },
                        SubTotal = 500.0f,
                        Products = new List<Product> {
                            new Product {
                                DbProps = new DbProps { Id = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P3",
                                Width = 20.0f,
                                Height = 30.0f,
                                Depth = 15.0f,
                                Left = true,
                                Right = false,
                                Int = 3,
                                Comments = "",
                                Price = 200.0f,
                                EXT = "",
                                Name = "Product 3"
                            },
                            new Product {
                                DbProps = new DbProps { Id = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P4",
                                Width = 25.0f,
                                Height = 35.0f,
                                Depth = 20.0f,
                                Left = false,
                                Right = true,
                                Int = 4,
                                Comments = "",
                                Price = 300.0f,
                                EXT = "",
                                Name = "Product 4"
                            }
                        }
                    }
                }
            }},
            { 3, new Quote {
                DbProps = new DbProps { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                Name = "Quote 3",
                SalesAssociate = "Bob Johnson",
                ContactInfo = "bobjohnson@example.com",
                DealerAddress = new ShippingAddress {
                    Name = "Dealer 3",
                    Line1 = "456 Main St",
                    Line2 = "",
                    City = "Vancouver",
                    Ontario = "BC",
                    PostalCode = "V6H 1K2"
                },
                CustomerAddress = new ShippingAddress {
                    Name = "Customer 3",
                    Line1 = "789 Pine St",
                    Line2 = "",
                    City = "Burnaby",
                    Ontario = "BC",
                    PostalCode = "V5G 1A1"
                },
                IsPickup = false,
                IsDelivery = true,
                IsDealer = false,
                IsApartment = true,
                IsMultiLevel = false,
                IsFreightForwarder = false,
                Status = QuoteStatus.Draft,
                CatelogPdfUrl = "https://example.com/catalog.pdf",
                Rooms = new List<Room> {
                    new Room {
                        DbProps = new DbProps { Id = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                        Name = "Room 1",
                        DoorStyle = new DoorStyle {
                            DbProps = new DbProps { Id = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Style 1",
                            Price = 100.0f
                        },
                        Finish = new Finish {
                            DbProps = new DbProps { Id = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Finish 1",
                            Price = 50.0f
                        },
                        Interior = new Interior {
                            DbProps = new DbProps { Id = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Interior 1",
                            Price = 75.0f
                        },
                        DrawerHardware = new DrawerHardware {
                            DbProps = new DbProps { Id = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Hardware 1",
                            Price = 25.0f
                        },
                        SubTotal = 250.0f,
                        Products = new List<Product> {
                            new Product {
                                DbProps = new DbProps { Id = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P1",
                                Width = 10.0f,
                                Height = 20.0f,
                                Depth = 5.0f,
                                Left = true,
                                Right = false,
                                Int = 1,
                                Comments = "",
                                Price = 100.0f,
                                EXT = "",
                                Name = "Product 1"
                            },
                            new Product {
                                DbProps = new DbProps { Id = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P2",
                                Width = 15.0f,
                                Height = 25.0f,
                                Depth = 10.0f,
                                Left = false,
                                Right = true,
                                Int = 2,
                                Comments = "",
                                Price = 150.0f,
                                EXT = "",
                                Name = "Product 2"
                            }
                        }
                    },
                    new Room {
                        DbProps = new DbProps { Id = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                        Name = "Room 2",
                        DoorStyle = new DoorStyle {
                            DbProps = new DbProps { Id = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Style 2",
                            Price = 200.0f
                        },
                        Finish = new Finish {
                            DbProps = new DbProps { Id = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Finish 2",
                            Price = 100.0f
                        },
                        Interior = new Interior {
                            DbProps = new DbProps { Id = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Interior 2",
                            Price = 150.0f
                        },
                        DrawerHardware = new DrawerHardware {
                            DbProps = new DbProps { Id = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            Name = "Hardware 2",
                            Price = 50.0f
                        },
                        SubTotal = 500.0f,
                        Products = new List<Product> {
                            new Product {
                                DbProps = new DbProps { Id = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P3",
                                Width = 20.0f,
                                Height = 30.0f,
                                Depth = 15.0f,
                                Left = true,
                                Right = false,
                                Int = 3,
                                Comments = "",
                                Price = 200.0f,
                                EXT = "",
                                Name = "Product 3"
                            },
                            new Product {
                                DbProps = new DbProps { Id = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                                Code = "P4",
                                Width = 25.0f,
                                Height = 35.0f,
                                Depth = 20.0f,
                                Left = false,
                                Right = true,
                                Int = 4,
                                Comments = "",
                                Price = 300.0f,
                                EXT = "",
                                Name = "Product 4"
                            }
                        }
                    }
                }
            }
        }};
    }
};
