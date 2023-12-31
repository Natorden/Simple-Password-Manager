﻿using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;
using Web_Client.DTOs;

namespace Web_Client;
internal class WebClient : IWebClient
{
    private readonly IRestClient _client;
    private string _jwt;

    public WebClient(IRestClient client)
    {
        _client = client;
    }

    public async Task<PasswordVaultDto?> GetAsync(Guid? ownerGuid)
    {
        var response = await _client.RequestAsync<PasswordVaultDto?>(Method.Get, $"PasswordVault/{ownerGuid}", jwt: _jwt);

        if (!response.IsSuccessful) throw new Exception($"Error retreiving password vault");

        return response.Data!;
    }

    public async Task<Guid?> LoginAsync(UserDto user)
    {
        user.Guid = Guid.Empty;
        var response = await _client.RequestAsync<Guid?>(Method.Post, $"Login/Login", body: user);

        if (!response.IsSuccessful) throw new Exception($"Error logging in");

        if (response.Cookies.Count == 1)
        {
            _jwt = response.Cookies[0].Value;
        }
        return response.Data!;
    }

    public async Task<Guid?> CreateUserAsync(UserDto user)
    {
        var response = await _client.RequestAsync<Guid>(Method.Post, $"Login/Create", body: user);

        if (!response.IsSuccessful) throw new Exception($"Error creating a user in");

        return response.Data!;
    }

    public async Task<bool> UpdateAsync(Guid? ownerGuid, PasswordVaultDto vault)
    {
        if(_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<bool>(Method.Put, $"PasswordVault/{ownerGuid}", body: vault, jwt: _jwt);

        if (!response.IsSuccessful) throw new Exception($"Error updating password vault: {response}");

        return response.Data!;
    }

    public async Task<byte[]> GetSaltAsync(string username)
    {
        var response = await _client.RequestAsync<byte[]>(Method.Get, $"Login/Salt/{username}");

        if (!response.IsSuccessful) throw new Exception($"Error getting salt for {username}");

        return response.Data!;
    }
}


public static class RestExtentions
{
    public static async Task<RestResponse<T>> RequestAsync<T>(this IRestClient client, Method method, string? resource = null, object? body = null, string jwt = null)
    {
        var request = new RestRequest(resource, method);
        if (jwt != null)
        {
            request.AddHeader("Authorization", $"Bearer {jwt}");
        }
        if (body != null)
        {
            
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync<T>(request, method);
    }

    public static async Task<RestResponse> RequestAsync(this IRestClient client, Method method, string? resource = null, object? body = null, string jwt = null)
    {
        var request = new RestRequest(resource, method);
        if (jwt != null)
        {
            request.AddHeader("Authorization", $"Bearer {jwt}");
        }
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync(request, method);
    }
}