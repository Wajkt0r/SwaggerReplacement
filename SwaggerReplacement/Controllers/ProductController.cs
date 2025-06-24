using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwaggerReplacement.Models;
using SwaggerReplacement.Requests;

namespace SwaggerReplacement.Controllers;

/// <summary>
/// Manages the product catalog.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static readonly List<Product> _products = new();

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>List of products.</returns>
    /// <response code="200">Returns list of products</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Product>> GetAll()
        => Ok(_products);

    /// <summary>
    /// Retrieves a product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns>Single product if found.</returns>
    /// <response code="200">Returns the product</response>
    /// <response code="404">Product not found</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<Product> GetById(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
            return NotFound("Product not found.");

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">Request for creating new product.</param>
    /// <returns>Created product ID.</returns>
    /// <response code="201">Product created successfully</response>
    /// <response code="400">Invalid input</response>
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || request.Price <= 0)
            return BadRequest("Invalid name or price.");

        var productId = Guid.NewGuid();

        var product = new Product
        {
            Id = productId,
            Name = request.Name,
            Price = request.Price
        };

        _products.Add(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, new { id = product.Id });
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="request">Request to update product.</param>
    /// <response code="204">Product updated</response>
    /// <response code="404">Product not found</response>
    /// <response code="400">Invalid input</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromBody] UpdateProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || request.Price <= 0)
            return BadRequest("Invalid name or price.");

        var product = _products.FirstOrDefault(p => p.Id == request.Id);
        if (product is null)
            return NotFound("Product not found.");

        product.Name = request.Name;
        product.Price = request.Price;

        return NoContent();
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">ID of the product to delete.</param>
    /// <response code="204">Product deleted</response>
    /// <response code="404">Product not found</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
            return NotFound("Product not found.");

        _products.Remove(product);
        return NoContent();
    }
}
