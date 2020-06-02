using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Dtos
{
    public class UserForUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Country { get; set; }
    }
}