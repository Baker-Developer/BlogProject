﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string AuthorId { get; set; }

        public string ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Comment")]
        public string Body { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public Nullable<DateTime> Updated { get; set; }

        public Nullable<DateTime> Moderated { get; set; }

        public Nullable<DateTime> Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; }

        // Navigation properties
        public virtual Post Post { get; set; }

        public virtual IdentityUser Author { get; set; }

        public virtual IdentityUser Moderator { get; set; }

    }
}