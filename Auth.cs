using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.Json;

public class Authorize {


    public async Task<string> GetBearerToken(HttpClient client, string url, string key, string secret)
    {
        
        //ask to receive a json response from the server.
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //we need to take a form urlencoded content. To do so we use the class that converts it from a dictionary<string, string>
        var formData = new Dictionary<string,string>
        {
            {"grant_type", "client_credentials"},
            {"client_id", key},
            {"client_secret", secret}
        };

        //this converts our form data dictionary
        HttpContent content = new FormUrlEncodedContent(formData);

        //make the request
        HttpResponseMessage response = await client.PostAsync(url, content);

        //recieves json repsonse then concerts to string
        string responseText = await response.Content.ReadAsStringAsync();
        TokenResponse? responseToken = JsonSerializer.Deserialize<TokenResponse>(responseText);
        if (responseToken == null || string.IsNullOrEmpty(responseToken.access_token)){
            throw new InvalidOperationException("Failed to retrieve access token from response.");
        }
        string accessToken = responseToken.access_token;
        return accessToken;
    }
}

