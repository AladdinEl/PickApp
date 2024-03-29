﻿namespace KomOchHämta.Views.Products
{
	public class DetailsVM
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }
		public string UserId { get; set; }

		public string Location { get; set; }
        public string Message { get; set; }

        public DateTime Created { get; set; }
        public bool Reserved { get; set; }
		public string? ReservedBy { get; set; }

	}
}
