﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Basliq minumum 3 simvol olmalidir.")]
        public string Title { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public string PhotoUrl { get; set; }
        public string SeoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
        public List<Comment> Comments { get; set; }
    } 
}
