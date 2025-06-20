﻿namespace csharp_kafka.Producer.Features.Product.Core;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : BaseController
{
    private readonly CreateProductService _createProductService;

    public ProductController(CreateProductService createProductService)
    {
        _createProductService = createProductService;
    }

    [HttpPost("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var message = System.Text.Json.JsonSerializer.Serialize(request);
        await _createProductService.ProduceAsync("ProductTopic", message);

        return Content("Saving Product Successfully.");
    }
}
