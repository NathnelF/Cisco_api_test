using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public class SuggestionRequest {

    public async Task<string> SuggestionByProductID(HttpClient client, string baseUrl, string productId, string accessToken)
    {
        string url = baseUrl + $"{productId}";

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        HttpResponseMessage response = await client.GetAsync(url);

        string responseText = await response.Content.ReadAsStringAsync();

        Root? result = JsonSerializer.Deserialize<Root>(responseText);

        if (result != null)
        {
            foreach (var product in result.ProductList!)
            {
                foreach (var suggestion in product.Suggestions!)
                {
                    string version = suggestion.RelDispName!;
                    if (version == "")
                    {
                        return $"Can't find product with pid {productId}";
                    } else
                    {
                        return version;
                    }
                    
                }
            }
        }

        return $"Can't find product with pid {productId}";

    }
}