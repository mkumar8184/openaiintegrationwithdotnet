using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAILib.Dto;
using System.Net.Http.Headers;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace OpenAIIntegration
{
    public interface IOpenAIService
    {
        Task<string> TriggerOpenAI(string prompt);
        Task<EmployeeList> GetEmployeeReports(string prompt);
    }

    public class OpenAIService : IOpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenAIService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            var apiKey = _configuration["OpenAISetting:APIKey"];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        //get result from open ai 
        public async Task<string> TriggerOpenAI(string prompt)
        {
            var request = CreateAIRequest(prompt);
            var jsonContent = JsonSerializer.Serialize(request);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["OpenAISetting:BaseUrl"], content);
            return await HandleResponse(response);
        }

        //result from local db
        public async Task<EmployeeList> GetEmployeeReports(string prompt)
        {
            var employeeDb = "ChatDatabase\\employeedb.json";

            var messages = LoadMessages(employeeDb);
            messages.Add(new ChatMessage { role = "user", content = prompt });

            var requestBody = CreateRequestBody(messages);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseData = await HandleResponseAsync(response, prompt);
            var parseJson = JsonConvert.DeserializeObject<EmployeeList>(responseData);
            if (parseJson == null)
            {
                return new EmployeeList();
            }
            await SaveMessages(prompt, responseData);
            return parseJson;


        }

        private string CreateRequestBody(List<ChatMessage> messages)
        {
            var body = new { model = "gpt-3.5-turbo", messages };
            return JsonSerializer.Serialize(body);
        }
        private async Task<string> HandleResponseAsync(HttpResponseMessage response, string userMessage)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var data = JsonSerializer.Deserialize<AIResponseDto>(responseContent);
                var responseText = data.choices[0].message.content;

                return responseText.ToString();
            }
            else
            {
                Console.WriteLine($"Failed with status code {response.StatusCode}");
                // Optionally handle or log the failure
                return string.Empty; // Return an appropriate response if needed
            }
        }

        private AIRequestDto CreateAIRequest(string prompt)
        {
            return new AIRequestDto
            {
                Model = "gpt-3.5-turbo",
                Messages = new List<AIMessageRequestDto>
                {
                    new AIMessageRequestDto
                    {
                        Role = "user",
                        Content = prompt
                    }
                },
                MaxTokens = 100
            };
        }

        private async Task<string> HandleResponse(HttpResponseMessage response)
        {
            var resjson = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(resjson);
                throw new System.Exception(errorResponse.Error.Message);
            }

            var data = JsonSerializer.Deserialize<AIResponseDto>(resjson);
            return data.choices[0].message.content;
        }

        private List<ChatMessage> LoadMessages(string employeeDataset)
        {


            var file = $"ChatDatabase\\searchhistory.json";
            var messages = new List<ChatMessage>();
            if (System.IO.File.Exists(file))
            {
                var jsonString = System.IO.File.ReadAllText(file);
                messages = JsonSerializer.Deserialize<List<ChatMessage>>(jsonString);
            }
            else
            {
                messages.Add(new ChatMessage
                {
                    role = "system",
                    content = "" +
                   $"You are an information extractor. Please extract employee information only from the following dataset in JSON format: {employeeDataset}. " +
        $"Make sure to only use the provided data and do not reference any external information. " +
        $"The result set should be returned in the following JSON structure: {EmployeeResult.GetEmployeeTemplateString()}."
                });
            }

            return messages;
        }
        private async Task SaveMessages(string userMessage, string gptResponse)
        {

            var employeeDb = "ChatDatabase\\employeedb.json";

            var file = $"ChatDatabase\\searchhistory.json";

            var messages = LoadMessages(JsonSerializer.Serialize(employeeDb));
            messages.Add(new ChatMessage { role = "user", content = userMessage });
            messages.Add(new ChatMessage { role = "assistant", content = gptResponse });

            var json = JsonSerializer.Serialize(messages);
            await System.IO.File.WriteAllTextAsync(file, json);

        }
    }
}
