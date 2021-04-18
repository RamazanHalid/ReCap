using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCar { get; set; }

        public CarImage()
        {
            DateCar = DateTime.Now;
        }
    }
}