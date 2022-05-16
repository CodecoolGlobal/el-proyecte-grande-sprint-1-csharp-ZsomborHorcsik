﻿using FilmStock.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models
{
    public class MovieModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("title")]
        public string Title { set; get; }
        [JsonProperty("fullTitle")]
        public string FullTitle { set; get; }
        [JsonProperty("year")]
        public string Year { set; get; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("crew")]
        public string Crew { get; set; }
        [JsonProperty("imDbRating")]
        public string Rating { get; set; }
        [JsonProperty("imDbRatingCount")]
        public string IMDbRatingCount { get; set; }
        public ContentType Type { get; set; }
    }
}