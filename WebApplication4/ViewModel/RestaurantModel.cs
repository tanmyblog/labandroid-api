using Model.Models;

namespace WebApplication4.ViewModel
{
    public class RestaurantModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string type { get; set; }

        public RestaurantModel()
        {

        }

        public RestaurantModel(Restaurants t)
        {
            this.id = t.id;
            this.name = t.name;
            this.address = t.address;
            this.type = t.type;
        }
    }

    public class CreateRestaurant
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string type { get; set; }
    }

    public class UpdateRestaurant : CreateRestaurant
    {
        
    }
}