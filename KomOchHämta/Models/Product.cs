﻿namespace KomOchHämta.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public bool Reserved { get; set; }
        public int UserId { get; set; }
    }
}
