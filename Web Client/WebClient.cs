using RestSharp;
using System.Text.Json;
using Web_Client.DTOs;

namespace Web_Client;
internal class WebClient : IWebClient
{
    private readonly IRestClient _client;

    public WebClient(IRestClient client)
    {
        _client = client;
    }

    public async Task<PasswordVaultDto> GetAsync(Guid ownerGuid)
    {
        var response = await _client.RequestAsync<PasswordVaultDto>(Method.Get, $"PasswordVault/{ownerGuid}");

        if (!response.IsSuccessful) throw new Exception($"Error retreiving password vault");

        return response.Data!;
    }

    public async Task<Guid?> LoginAsync(UserDto user)
    {
        var response = await _client.RequestAsync<Guid?>(Method.Post, $"Login", body: user);

        if (!response.IsSuccessful) throw new Exception($"Error logging in");

        return response.Data!;
    }

    public async Task<Guid?> CreateUserAsync(UserDto user)
    {
        var response = await _client.RequestAsync<Guid?>(Method.Post, $"Login/Create", body: user);

        if (!response.IsSuccessful) throw new Exception($"Error logging in");

        return response.Data!;
    }

    public async Task<bool> UpdateAsync(Guid ownerGuid, PasswordVaultDto vault)
    {
        var response = await _client.RequestAsync<bool>(Method.Put, $"PasswordVault/{ownerGuid}", body: vault);

        if (!response.IsSuccessful) throw new Exception($"Error updating password vault");

        return response.Data!;
    }
}


public static class RestExtentions
{
    public static async Task<RestResponse<T>> RequestAsync<T>(this IRestClient client, Method method, string? resource = null, object? body = null)
    {
        var request = new RestRequest(resource, method);
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync<T>(request, method);
    }

    public static async Task<RestResponse> RequestAsync(this IRestClient client, Method method, string? resource = null, object? body = null)
    {
        var request = new RestRequest(resource, method);
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync(request, method);
    }
}