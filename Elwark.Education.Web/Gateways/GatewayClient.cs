using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Elwark.Education.Web.Infrastructure;
using Newtonsoft.Json;

namespace Elwark.Education.Web.Gateways
{
    internal abstract class GatewayClient
    {
        protected static readonly StringContent EmptyContent = new(string.Empty, Encoding.UTF8, "application/json");

        protected static async Task<ApiResponse<T>> ExecuteAsync<T>(Func<Task<HttpResponseMessage>> handler)
        {
            try
            {
                using var message = await handler();
                await using var stream = await message.Content.ReadAsStreamAsync();
                using var sr = new StreamReader(stream);
                using var jsonTextReader = new JsonTextReader(sr);
                if (message.IsSuccessStatusCode)
                    return ApiResponse<T>.Success(Json.Serializer.Deserialize<T>(jsonTextReader)!);

                var error = Json.Serializer.Deserialize<Error>(jsonTextReader)
                            ?? Error.Unknown;

                return ApiResponse<T>.Fail(error);
            }
            catch (HttpRequestException)
            {
                return ApiResponse<T>.Fail(Error.Unavailable);
            }
            catch(Exception)
            {
                return ApiResponse<T>.Fail(Error.Unknown);
            }
        }

        protected static StringContent ToJson<T>(T value)
        {
            var sb = new StringBuilder(256);
            var sw = new StringWriter(sb, CultureInfo.InvariantCulture);
            using var jsonWriter = new JsonTextWriter(sw) {Formatting = Json.Serializer.Formatting};

            Json.Serializer.Serialize(jsonWriter, value);

            return new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
        }
    }
}