
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;

namespace NorthumbriaTestFramework.Utilities
{
    public class FileReader
    {      
            public static AppSettings ReadSettings()
            {
                // Get the path to the config file
                var configPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appSettings.json");
                var configFile = File.ReadAllText(configPath);

                // Set up JSON serializer options
                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

                // Deserialize and return the settings
                return JsonSerializer.Deserialize<AppSettings>(configFile, jsonSerializerOptions);
            }
        }
    }
