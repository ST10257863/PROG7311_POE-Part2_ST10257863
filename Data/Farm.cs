namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Farm
	{
		public int Id
		{
			get; set;
		}
		public string Name
		{
			get; set;
		}
		public string Location
		{
			get; set;
		}

		public ICollection<Farmer> Farmers
		{
			get; set;
		}
		public ICollection<Products> Products
		{
			get; set;
		}
	}
}