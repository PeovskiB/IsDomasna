using System.ComponentModel.DataAnnotations;

namespace IsDomasna.Models.DTOs
{
    
        public class UserPermissionsDto
        {
            public string UserId { get; set; }

            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Display(Name = "Current Role")]
            public string CurrentRole { get; set; }

            [Display(Name = "New Role")]
            public string NewRole { get; set; }
        }
   

}
