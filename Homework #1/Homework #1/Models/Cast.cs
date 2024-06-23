using Homework__1.Models.Enums;

namespace Homework__1.Models
{
    public class Cast
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public Part Part { get; set; }
    }
}
