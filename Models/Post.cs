﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int BlogId { get; set; }
        
        public string AuthorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }


        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        public string Abstract { get; set; }


        [Required]
        public string Content { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public Nullable<DateTime> Updated { get; set; }


        public string Slug { get; set; }


        public byte[] ImageData { get; set; }

        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }



    }
}