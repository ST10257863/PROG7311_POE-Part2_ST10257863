namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Farmer
	{
		public int Id
		{
			get; set;
		}

		// Foreign key to ApplicationUser
		public string UserId
		{
			get; set;
		}
		public ApplicationUser User
		{
			get; set;
		}

		public ICollection<Product> Products
		{
			get; set;
		} // Navigation property
	}
}