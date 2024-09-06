using Newtonsoft.Json;

namespace machineTest_svc.Data
{
    public static class JsonFileHandler
    {
        public static List<T> ReadJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public static void WriteJsonFile<T>(string filePath, List<T> data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
