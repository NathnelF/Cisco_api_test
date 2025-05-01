// See https://aka.ms/new-console-template for more information

/* 
HTTP method: POST
URL endpoint: https://id.cisco.com/oauth2/default/v1/token
Content-Type: application/x-www-form-urlencoded
Body: URL-encoded parameters:
grant_type: client_credentials
client_id: (your application Client ID)
client_secret: (your application Client Secret

*/

using System.Net.Http.Headers;
using DotNetEnv;

Env.Load();

string authUrl = "https://id.cisco.com/oauth2/default/v1/token";
string key = Environment.GetEnvironmentVariable("CLIENT_ID")
     ?? throw new InvalidOperationException("CLIENT_ID environment variable is not set.");
string secret = Environment.GetEnvironmentVariable("CLIENT_SECRET")
    ?? throw new InvalidOperationException("CLIENT_SECRET environmental variable is not set");
string requestUrlBase = "https://apix.cisco.com/software/suggestion/v2/suggestions/releases/productIds/";

string productId = "ASR-903";

HttpClient client = new HttpClient();
Authorize auth = new Authorize();
SuggestionRequest requestor = new SuggestionRequest();

string access_token = await auth.GetBearerToken(client, authUrl, key, secret);

string response = await requestor.SuggestionByProductID(client, requestUrlBase, productId, access_token);

Console.WriteLine($"Suggested Release: {response}");

