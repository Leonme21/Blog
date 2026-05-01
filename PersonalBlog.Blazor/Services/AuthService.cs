using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace PersonalBlog.Blazor.Services
{
    public class AuthService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action? OnChange;

        public AuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return false;
            if (IsTokenExpired(token))
            {
                await LogoutAsync();
                return false;
            }
            return true;
        }

        private bool IsTokenExpired(string token)
        {
            try
            {
                var payload = token.Split('.')[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var json = System.Text.Encoding.UTF8.GetString(jsonBytes);
                var jsonElement = System.Text.Json.JsonDocument.Parse(json).RootElement;
                if (jsonElement.TryGetProperty("exp", out var expProp))
                {
                    var expTime = expProp.GetInt64();
                    var expires = DateTimeOffset.FromUnixTimeSeconds(expTime).UtcDateTime;
                    return expires < DateTime.UtcNow;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            base64 = base64.Replace('-', '+').Replace('_', '/');
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        }

        public async Task LoginAsync(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", token);
            NotifyStateChanged();
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
            NotifyStateChanged();
        }

        public async Task<bool> IsAdminAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return false;
            try
            {
                var payload = token.Split('.')[1];

                
                payload = payload.Replace('-', '+').Replace('_', '/');
                
                switch (payload.Length % 4)
                {
                    case 2: payload += "=="; break;
                    case 3: payload += "="; break;
                }
                var jsonBytes = Convert.FromBase64String(payload);
                var json = System.Text.Encoding.UTF8.GetString(jsonBytes);
                var jsonElement = System.Text.Json.JsonDocument.Parse(json).RootElement;
                
                string? role = null;
                if (jsonElement.TryGetProperty("role", out var roleProp))
                {
                    role = roleProp.GetString();
                }
                else if (jsonElement.TryGetProperty("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", out var claimProp))
                {
                    role = claimProp.GetString();
                }
                return role == "Admin";
            }
            catch
            {
                
                return false;
            }
        }


        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
