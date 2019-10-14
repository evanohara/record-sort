using CraftJackRecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftJackRecordSortShared.Dto
{
    public class RecordDto
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public RecordDto(string lastName, string firstName, string gender, string favoriteColor, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }

        public Record ToModel()
        {
            return new Record()
            {
                Id = Id,
                LastName = LastName,
                FirstName = FirstName,
                Gender = Gender,
                FavoriteColor = FavoriteColor,
                DateOfBirth = DateOfBirth.Value
            };
        }
    }
}
