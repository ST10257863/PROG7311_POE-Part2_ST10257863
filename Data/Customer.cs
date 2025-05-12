public class Customer
{
	public int Id
	{
		get; set;
	}

	public string UserId
	{
		get; set;
	}
	public ApplicationUser User
	{
		get; set;
	}

	public string? BillingAddress
	{
		get; set;
	}
}