using System;

namespace Users.Dtos
{
    public class UserForReadDto
    {
       public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime DateOfBirth { get; set; }
       
        public string Country { get; set; }
    }
}