using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Ticker
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int NewsArticleId { get; set; }

    public NewsArticle NewsArticle { get; set; }  
}

