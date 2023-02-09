﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PermissionBasedAuthorizationIntDotNet5.Contants;
using System.Collections.Generic;

namespace ApiCreateUserAndAssignPermissionsNotRole.Models
{
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }


        [Required(ErrorMessage = "User Name is required")]
        public string? Email { get; set; }



        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }



        public string? UserName { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
