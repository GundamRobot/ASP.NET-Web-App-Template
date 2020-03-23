using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.ENTITIES
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int? GuardianID { get; set; }
        public int? TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private char gender;
        public char Gender {
            get { return gender; } 
            set
            {
                gender = Char.ToUpper(value);
            } 
        }
        public string AlbertaHealthCareNumber { get; set; }

        private string medicalAlertDetails;
        public string MedicalAlertDetails {
            get { return medicalAlertDetails; }
            set {
                if (value == "") 
                {
                    medicalAlertDetails = null;
                } 
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
