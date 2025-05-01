using System.Text.Json.Serialization;

public class Root
{
    [JsonPropertyName("productList")]
    public List<ProductListItem>? ProductList { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}

public class ProductListItem
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("product")]
    public Product? Product { get; set; }

    [JsonPropertyName("suggestions")]
    public List<Suggestion>? Suggestions { get; set; }
}

public class Product
{
    [JsonPropertyName("basePID")]
    public string? BasePID { get; set; }

    [JsonPropertyName("mdfId")]
    public string? MdfId { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("softwareType")]
    public string? SoftwareType { get; set; }
}

public class Suggestion
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isSuggested")]
    public string? IsSuggested { get; set; }

    [JsonPropertyName("releaseFormat1")]
    public string? ReleaseFormat1 { get; set; }

    [JsonPropertyName("releaseDate")]
    public string? ReleaseDate { get; set; }

    [JsonPropertyName("relDispName")]
    public string? RelDispName { get; set; }

    // Add more fields if needed...
}