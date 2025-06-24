namespace SwaggerReplacement.Models;

/// <summary>
/// Represents a product.
/// </summary>
public class Product
{
    /// <summary>
    /// Product ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Product price.
    /// </summary>
    public decimal Price { get; set; }
}
