using AuthZero.Client.SharedLibrary.Common.Configuration;
using AuthZero.Client.SharedLibrary.Common.ErrorHandling;
using AuthZero.Client.SharedLibrary.Common.General;
using AuthZero.Client.SharedLibrary.Requests.AssignUserRoles;
using AuthZero.Client.SharedLibrary.Requests.ConfirmUserEmail;
using AuthZero.Client.SharedLibrary.Requests.CreateAUser;
using AuthZero.Client.SharedLibrary.Requests.GetAccessToken;
using AuthZero.Client.SharedLibrary.Requests.GetAccessToken.ClientCredentials;
using AuthZero.Client.SharedLibrary.Requests.GetAccessToken.ResourceOwnerPassword;
using AuthZero.Client.SharedLibrary.Requests.Roles;
using AuthZero.Client.SharedLibrary.Requests.User;
using JorgeSerrano.Json;
using System.Net.Http.Json;
using System.Text.Json;

namespace AuthZero.Client.SharedLibrary.Common
{
    public class AuthZeroHttpClient
    {
        private HttpClient _httpClient;
        private readonly AuthZeroConfiguration _config;
        private readonly JsonSerializerOptions _serializationOptions;
        private readonly JsonSerializerOptions _errorSerializationOptions;

        public AuthZeroHttpClient(HttpClient httpClient, AuthZeroConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _serializationOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
            };
            _errorSerializationOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Result<AccessTokenResponse>> GetAccessTokenByResourceOwnerPasswordAsync(
            GetAccessTokenResourceOwnerRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync<GetAccessTokenResourceOwnerRequest>(
                $"{_config.BaseAddress}/oauth/token", request, _serializationOptions, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return await GetErrorResultAsync<AccessTokenResponse>(response.Content, cancellationToken);
            }

            return await GenerateResponseResultAsync<AccessTokenResponse>(response.Content, cancellationToken);
        }

        public async Task<Result<AccessTokenResponse>> GetAccessTokenByResourceOwnerPasswordAsync(
            GetAccessTokenClientCredentialsRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync<GetAccessTokenClientCredentialsRequest>(
                $"{_config.BaseAddress}/oauth/token", request, _serializationOptions, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return await GetErrorResultAsync<AccessTokenResponse>(response.Content, cancellationToken);
            }

            return await GenerateResponseResultAsync<AccessTokenResponse>(response.Content, cancellationToken);
        }

        public async Task<Result<UserResponse>> CreateANewUserAsync(
            CreateAUserRequest request,
            CancellationToken cancellationToken)
        {

            var response = await _httpClient.PostAsJsonAsync<CreateAUserRequest>(
                 $"{_config.BaseAddress}/{_config.ApiPath}/{_config.ApiVersion}/users",
                 request,
                 _serializationOptions,
                 cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return await GetErrorResultAsync<UserResponse>(response.Content, cancellationToken);
            }

            return await GenerateResponseResultAsync<UserResponse>(response.Content, cancellationToken);
        }


        public async Task<NoContentResult> AssignUserToRolesAsync(string userId, AssignUserRolesRequest request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync<AssignUserRolesRequest>(
                $"{_config.BaseAddress}/{_config.ApiPath}/{_config.ApiVersion}/users/{userId}/roles",
                request, _serializationOptions, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return await GetNoContentErrorResultAsync(response.Content, cancellationToken);
            }

            return NoContentResult.Success();
        }

        public async Task<Result<UserResponse>> GetUserByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"{_config.BaseAddress}/{_config.ApiPath}/{_config.ApiVersion}/users/{userId}", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return await GetErrorResultAsync<UserResponse>(response.Content, cancellationToken);
            }

            return await GenerateResponseResultAsync<UserResponse>(response.Content, cancellationToken);
        }

        public async Task<Result<List<Role>>> GetUserRolesAsync(string userId, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"{_config.BaseAddress}/{_config.ApiPath}/{_config.ApiVersion}/users/{userId}/roles", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return await GetErrorResultAsync<List<Role>>(response.Content, cancellationToken);
            }

            return await GenerateResponseResultAsync<List<Role>>(response.Content, cancellationToken);
        }

        public async Task<NoContentResult> UpdateUserEmailConfirmationStatusAsync(string userId, bool emailVerified, CancellationToken cancellationToken)
        {
            var confirmUserEmailRequestBody = new ConfirmUserEmailRequest { EmailVerified = emailVerified };
            var response = await _httpClient.PatchAsJsonAsync($"{_config.BaseAddress}/{_config.ApiPath}/{_config.ApiVersion}/users", confirmUserEmailRequestBody, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return await GetNoContentErrorResultAsync(response.Content, cancellationToken);
            }

            return NoContentResult.Success();
        }

        private async Task<Result<T>> GenerateResponseResultAsync<T>(HttpContent content, CancellationToken cancellationToken) where T : class
        {
            var response = await content.ReadFromJsonAsync<T>(_serializationOptions, cancellationToken);
            if (response is null)
            {
                throw new Exception("Error: Could not get/parse response content from HttpContent");
            }

            return Result<T>.Success(response);
        }

        private async Task<Result<T>> GetErrorResultAsync<T>(HttpContent content, CancellationToken cancellationToken) where T : class
        {
            var errorResponse = await content.ReadFromJsonAsync<ErrorResponse>(_errorSerializationOptions, cancellationToken);
            if (errorResponse is null)
                throw new Exception("Error: Could not parse Auth Zero error response");

            return Result<T>.Failure(errorResponse);
        }

        private async Task<NoContentResult> GetNoContentErrorResultAsync(HttpContent content, CancellationToken cancellationToken)
        {
            var errorResponse = await content.ReadFromJsonAsync<ErrorResponse>(_errorSerializationOptions, cancellationToken);
            if (errorResponse is null)
                throw new Exception("Error: Could not parse Auth Zero error response");

            return NoContentResult.Failure(errorResponse);
        }

    }
}