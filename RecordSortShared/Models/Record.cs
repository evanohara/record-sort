using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftJackRecordSortShared.Models
{
    public class Record
    {
        public Record()
        {
        }

        public Record(string lastName, string firstName, string gender, string favoriteColor, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
