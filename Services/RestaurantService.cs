using ContosoPizza.Models;
using ContosoPizza.Services;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
    public static class RestaurantService
    {
        static List<Restaurant> Restaurants { get; }
        static List<Pizza> Pizzas { get;}
        static int nextId = 4;
        static RestaurantService()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Momma Lombardi's", Address = "123 Jump St., Boca Raton, FL 33426", Phone = "561-453-2345", Menu = PizzaService.GetAll() },
                new Restaurant { Id = 2, Name = "Luce", Address = "125 Granby St., Norfolk, VA 23510", Phone = "757-435-2134", Menu = PizzaService.GetAll() },
                new Restaurant { Id = 3, Name = "Sheesh", Address = "420 Nice Ave., Bay Shore, NY 11706", Phone = "631-598-3298", Menu = PizzaService.GetAll() }
            };
        }

        public static List<Restaurant> GetAll() => Restaurants;

        public static Restaurant Get(int id) => Restaurants.FirstOrDefault(p => p.Id == id);

        public static void Add(Restaurant Restaurant)
        {
            Restaurant.Id = nextId++;
            Restaurants.Add(Restaurant);
        }

        public static void Delete(int id)
        {
            var Restaurant = Get(id);
            if(Restaurant is null)
                return;

            Restaurants.Remove(Restaurant);
        }

        public static void Update(Restaurant Restaurant)
        {
            var index = Restaurants.FindIndex(p => p.Id == Restaurant.Id);
            if(index == -1)
                return;

            Restaurants[index] = Restaurant;
        }
    }
};