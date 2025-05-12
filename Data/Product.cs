namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Products
	{
		public int Id
		{
			get; set;
		}
		public string Name
		{
			get; set;
		}
		public string Category
		{
			get; set;
		}
		public DateTime ProductionDate
		{
			get; set;
		}

		// Foreign key to Farm
		public int FarmId
		{
			get; set;
		}
		public Farm Farm
		{
			get; set;
		}
	}

}