﻿using System.Text.Json.Serialization;

namespace OpenAILib.Dto
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public AIError Error { get; set; }
    }
    public class AIError
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("param")]
        public string Param { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
    public class AIRequestDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("messages")]
        public List<AIMessageRequestDto> Messages { get; set; }

        [JsonPropertyName("temperature")]
        public float Temperature { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }
    }

    public class AIMessageRequestDto
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
    public class AIResponseDto
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }

    public class Choice
    {
        public int index { get; set; }
        public Message message { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }
    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
    public class AIChoice
    {
        public string text { get; set; }
        public float probability { get; set; }
        public float[] logprobs { get; set; }
        public int[] finish_reason { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
