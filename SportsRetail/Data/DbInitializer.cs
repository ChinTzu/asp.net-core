using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }

                if (!context.Products.Any())
                {
                    context.AddRange
                    (
                        new Product
                        {
                            Name = "Water Bottle",
                            Price = 69M,
                            ShortDescription = "Stay hydrated when you’re working out",
                            LongDescription = "LifeStraw Go Water Filter Bottle with 2-Stage Integrated Filter Straw for Travel, Hiking, Camping & Emergency Preparedness " +
                                              "and makes it perfect for outdoor adventures or as your daily hydration partner.",
                            Category = Categories["Accessories"],
                            ImageUrl = "https://i.ibb.co/jwSHzmh/a-bottle-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/myGBqnx/a-bottle-s.jpg"
                        },
                        new Product
                        {
                            Name = "Football",
                            Price = 19M,
                            ShortDescription = "Enjoy perfecting your game of skill",
                            LongDescription = "Let your youngster practice their skills with one of these Sondico Core XT Mini Footballs. " +
                                              "The balls feature 40 stitched panels for a quality construction whilst the Sondico branding on the front ensures a great look.",
                            Category = Categories["Accessories"],
                            ImageUrl = "https://i.ibb.co/tXh5Z2H/a-football-l.jpg",
                            InStock = true,
                            IsPreferredProduct = true,
                            ImageThumbnailUrl = "https://i.ibb.co/JkJMrSq/a-football-s.jpg"
                        },
                        new Product
                        {
                            Name = "Walking Poles",
                            Price = 290M,
                            ShortDescription = "For a successful trip",
                            LongDescription = "The Karrimor Carbon Walking Poles benefit from a carbon fibre construction, lightweight foam grip, three sections with fast-lock and a tungsten tip. " +
                                              "These walking poles also feature ergonomically designed handles with adjustable loops.",
                            Category = Categories["Accessories"],
                            ImageUrl = "https://i.ibb.co/2nJdTzY/a-walking-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/9VxSTbQ/a-walking-s.jpg"
                        },
                        new Product
                        {
                            Name = "Kids Backpack",
                            Price = 69M,
                            ShortDescription = "The best backpacks for the 2020 School Year",
                            LongDescription = "The Character Pocket Rucksack offers a great look for any youngster thanks to the large character styling to the front and two adjustable shoulder straps.",
                            Category = Categories["Kids"],
                            ImageUrl = "https://i.ibb.co/KVwCzHY/k-bagpack-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/Dwx6dWf/k-bagpack-s.jpg"
                        },
                        new Product
                        {
                            Name = "Kids Jacket",
                            Price = 209M,
                            ShortDescription = "Keep the kids cool and casual",
                            LongDescription = "Keep your little one comfortable and warm in this Karrimor Urban Jacket Junior, it features the special weathertite fabric which is wind and water resistant " +
                                              "making this great for all weather conditions. This Outdoor Jacket also benefits from a full length zip and adjustable hook and loop tape wristband and the padded pockets provide extra comfort and warmth.",
                            Category = Categories["Kids"],
                            ImageUrl = "https://i.ibb.co/FYR4XF4/k-jacket-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/f0k74L8/k-jacket-s.jpg"
                        },

                        new Product
                        {
                            Name = "Kids Scooter",
                            Price = 159M,
                            ShortDescription = " Offer your child a fun",
                            LongDescription = "Have fun with the No Fear Scooter featuring a lightweight alloy frame and quick release folding mechanism, making it easy to fold down flat for transport or storage, " +
                                              "complete with the colourful components such as foam handlebar grips, PVC wheels, a rear foot brake and a printed No Fear grip tape which provides a great look that also offers instant brand recognition!",
                            Category = Categories["Kids"],
                            ImageUrl = "https://i.ibb.co/6tcWP7r/k-scooter-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/rHJyy39/k-scooter-s.jpg"
                        },
                        new Product
                        {
                            Name = "Kids Shirt",
                            Price = 47M,
                            ShortDescription = "Spice up your child's wardrobe staples",
                            LongDescription = "Dress your youngster in comfort and style for their next cycling adventure in this Muddyfox Junior Boy's Short Sleeve Cycling Jersey, crafted as an over the head design" +
                                              " with a quarter zip fastening, short sleeves, high breathability, an elasticated waistband, three open back pockets and a zipped back pocket, colour contrasting panelling, reflective elements and Muddyfox branding.",
                            Category = Categories["Kids"],
                            ImageUrl = "https://i.ibb.co/sjYKGJW/k-shirt-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/64hFD1z/k-shirt-s.jpg"
                        },
                        new Product
                        {
                            Name = "Kids Shoes",
                            Price = 169M,
                            ShortDescription = "Let the younger ones run around with comfort and style ",
                            LongDescription = "The Character Light Up Infants Trainers are perfect for adding a splash of joy and light to the world around you! This stylish kicks feature a bright and lively print design, starring your favourite characters! " +
                                              "Complete with a hook and loop tape fastening for quick and easy fitting.",
                            Category = Categories["Kids"],
                            ImageUrl = "https://i.ibb.co/f8XYnPm/k-shoes-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/dQrpQLP/k-shoes-s.jpg"
                        },
                        new Product
                        {
                            Name = "Men Backpack",
                            Price = 489M,
                            ShortDescription = "High quality packs for any adventure and season",
                            LongDescription = "The Vibe Backpack is the perfect back-to-school or all-rounder piece with plenty to offer. Multiple compartments throughout pair perfectly with an appealing, " +
                                              "active design for an eye-catching backpack that’s just as functional as it is stylish.",
                            Category = Categories["Mens"],
                            ImageUrl = "https://i.ibb.co/nk5sGkH/m-backpack-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/VLQj4yD/m-backpack-s.jpg"
                        },
                        new Product
                        {
                            Name = "Men Cap",
                            Price = 59M,
                            ShortDescription = "Enhance your individual style",
                            LongDescription = "The Mens Under Armour Shadow 4.0 Cap has a lightweight design with mesh ventilation channels across the body to help increase breathability while reflective detail " +
                                              "to the front and back helps to increase your visbility, completed with the Under Armour branding.",
                            Category = Categories["Mens"],
                            ImageUrl = "https://i.ibb.co/bgY8qLp/m-cap-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/276bTbK/m-cap-s.jpg"
                        },
                        new Product
                        {
                            Name = "Men Gloves",
                            Price = 109M,
                            ShortDescription = "Fine tune your lifting, keep your hands warm",
                            LongDescription = "These Karrimor Thermal Gloves offer a great warm feeling thanks to the soft fleece lined inner and the windproof construction. along with an elasticated wrist " +
                                              "and a boxed finger for a more comfortable and secure fit, compete with a paring clip for easier storage.",
                            Category = Categories["Mens"],
                            ImageUrl = "https://i.ibb.co/q7RmxKr/m-gloves-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/wzT9FV5/m-gloves-s.jpg"
                        },
                        new Product
                        {
                            Name = "Men Pants",
                            Price = 109M,
                            ShortDescription = "Elevate your everyday style with casual mens pants",
                            LongDescription = "Canterbury Ctn Training Short Pants are perfect for activities such as rugby. Made from a thin, lightweight woven polyester and elasticated waistband with padded drawcord for comfort.",
                            Category = Categories["Mens"],
                            ImageUrl = "https://i.ibb.co/r7M2zG5/m-pants-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/BLwMLsF/m-pants-s.jpg"
                        },
                        new Product
                        {
                            Name = "Men Shirt",
                            Price = 80M,
                            ShortDescription = "Running Jogging Workout Clothes",
                            LongDescription = "A Versatile T Shirt to Keep You Cool and Dry. From the street to the gym, this t-shirt offers simplicity for any setting. The mesh fabric keeps you cool and dry throughout your day. " +
                                              "Subtle adidas branding runs down the chest.",
                            Category = Categories["Mens"],
                            ImageUrl = "https://i.ibb.co/pPP76zb/m-shirt-l.jpg",
                            InStock = true,
                            IsPreferredProduct = true,
                            ImageThumbnailUrl = "https://i.ibb.co/j5q0Yg1/m-shirt-s.jpg"
                        },
                        new Product
                        {
                            Name = "Men Shoes",
                            Price = 388M,
                            ShortDescription = "Designed for high performance",
                            LongDescription = "The GEL PTG unisex lifestyle sneaker by ASICSTIGER is ideal for basketball fans looking to incorporate something new into their look. Not only are they aesthetically based on classic basketball shoes, " +
                                               "they also boast a variety of similar features including traditional pivot points on the outsole and a stylish derby cut upper design. They also come equipped with an extra-grip outsole and a perforated vamp for extra ventilation and unbeatable all-day comfort.",
                            Category = Categories["Mens"],
                            ImageUrl = "https://i.ibb.co/DzH6rdR/m-shoes-l.jpg",
                            InStock = true,
                            IsPreferredProduct = true,
                            ImageThumbnailUrl = "https://i.ibb.co/vDq8Wyd/m-shoes-s.jpg"
                        },
                        new Product
                        {
                            Name = "Women Backpack",
                            Price = 199M,
                            ShortDescription = "Gym to hiking trip, pack it all",
                            LongDescription = "This sturdy gym sack keeps your workout gear ready to go. The drawcords double as shoulder straps, and a carry loop offers a transport option. " +
                                              "An oversize logo gives the bag a sporty finish.",
                            Category = Categories["Womens"],
                            ImageUrl = "https://i.ibb.co/x1RR6Wk/w-backpack-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/Y85vsYf/w-backpack-s.jpg"
                        },
                        new Product
                        {
                            Name = "Women Sports Bra",
                            Price = 388M,
                            ShortDescription = "You can stay comfortable while still being active",
                            LongDescription = "The USA Pro Padded Crop Top features a total seamless construction for unrestricted movement, coupled with the wicking and breathable PRO-dry construction " +
                                              "so you can keep cool and comfortable.",
                            Category = Categories["Womens"],
                            ImageUrl = "https://i.ibb.co/4461gMp/w-bra-l.jpg",
                            InStock = true,
                            IsPreferredProduct = true,
                            ImageThumbnailUrl = "https://i.ibb.co/GdVsBpd/w-bra-s.jpg"
                        },
                        new Product
                        {
                            Name = "Women Jacket",
                            Price = 199M,
                            ShortDescription = "We've got you covered, come rain or shine in year-round stylish",
                            LongDescription = "Stay warm with the Hi-Tec SIA Women's Insulated Jacket. Featuring lightweight insulation with wadded baffle detail that ensures that the chill stays out and you stay well insulated. The jacket is highly breathable and quick-drying " +
                                              "so that you remain feeling fresh from start to finish.",
                            Category = Categories["Womens"],
                            ImageUrl = "https://i.ibb.co/ckv1vTQ/w-jacket-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/yVNFkJJ/w-jacket-s.jpg"
                        },
                        new Product
                        {
                            Name = "Women Pants",
                            Price = 105M,
                            ShortDescription = "Make an impression during your workout",
                            LongDescription = "Give yourself the ultimate comfortable fit whilst working out in these USA Pro Seamless Tights - crafted with a super stretchy compression fit which is seamless to promote a close to skin fit that's chafe free.",
                            Category = Categories["Womens"],
                            ImageUrl = "https://i.ibb.co/CsqVr3b/w-pants-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/hCM99Sx/w-pants-s.jpg"
                        },
                        new Product
                        {
                            Name = "Women Shoes",
                            Price = 469M,
                            ShortDescription = "Made to go the distance, our ladies' trainer bring iconic wears",
                            LongDescription = "The No Wanderer Womens Slip On Trainers are ideal for wearing for everyday occasions and provide comfort under and around the foot.",
                            Category = Categories["Womens"],
                            ImageUrl = "https://i.ibb.co/6yDdLVL/w-shoes-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/s2WbrGZ/w-shoes-s.jpg"
                        },
                        new Product
                        {
                            Name = "Women Sunglasses",
                            Price = 79M,
                            ShortDescription = "perfect for protecting your eyes whilst cycling, running and more!",
                            LongDescription = "Not sure what style to choose? With its boxy shape and super-thick frames, you can’t go wrong with a classic retro square style. Available in a variety of prints and colors for both guys and gals, this is a go-to for every face shape and size.",
                            Category = Categories["Womens"],
                            ImageUrl = "https://i.ibb.co/hfqSXKb/w-glasses-l.jpg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://i.ibb.co/LvXF5nm/w-glasses-s.jpg"
                        }
                    );
                }

                context.SaveChanges(); 
            }
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Mens", Description="" },
                        new Category { CategoryName = "Womens", Description="" },
                        new Category { CategoryName = "Kids", Description="" },
                        new Category { CategoryName = "Accessories", Description="" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
