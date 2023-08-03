using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab8
{
    [Table("User")]
    public class User
    {
        /// <summary>
        /// Users Id
        /// </summary>
        /// <example>101</example>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Users Name
        /// </summary>
        /// <example>Adam</example>
        public string Firstname { get; set; }

        /// <summary>
        /// Users Surname
        /// </summary>
        /// <example>Adam Smith</example>
        public string Lastname { get; set; }

        /// <summary>
        /// Users e-mail    
        /// </summary>
        /// <example>xxx@yyy.com</example>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// password
        /// </summary>
        /// <example>P@$$w0rd</example>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// active/passive
        /// </summary>
        /// <example>active/passive</example>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// admin/customer/HR
        /// </summary>
        /// <example>customer</example>
        [Required]
        public string Role { get; set; }

        public User()
        {

        }

        public User(int id, string firstname, string lastname, string email, string password, string status, string role)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            Status = status;
            Role = role;
        }
    }
}
