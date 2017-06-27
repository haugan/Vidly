using System.Collections.Generic;

namespace Vidly.Dto
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}