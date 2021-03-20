using System.ComponentModel.DataAnnotations;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Customer:IEntity
       {
           [Key]
        public int UserrId { get; set; }
        public string CompanyName { get; set; }
    }
}