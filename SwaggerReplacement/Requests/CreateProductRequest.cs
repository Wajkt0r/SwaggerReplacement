namespace SwaggerReplacement.Requests;

/// <summary>
/// Data for creating or updating a product.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Product price.
    /// </summary>
    public decimal Price { get; set; }
}
