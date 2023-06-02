﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AVATrade.Domain.Models;

public class Ticker
{
    [Key]
    public int Id { get; set; }

    public string Value { get; set; }

    public int NewsArticleId { get; set; }

    public NewsArticle NewsArticle { get; set; }  
}

