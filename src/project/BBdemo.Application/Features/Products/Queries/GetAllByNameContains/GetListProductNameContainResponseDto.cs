namespace BBdemo.Application.Features.Products.Queries.GetAllByNameContains;

public class GetListProductNameContainResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public string CategoryName { get; set; }
}