using System.Net.Http.Headers;
using System.Text;

namespace isRock.Template
{
    public class Dify
    {
        public static dynamic CallDifyChatMessagesAPI(string apiKey, object requestData)
        {
            var client = new HttpClient();

            // 設定 API 網址
            var apiUrl = $"https://api.dify.ai/v1/chat-messages";

            // 設定 HTTP request headers
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}"); //👉Azure OpenAI key
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            // 將 requestData 物件序列化成 JSON 字串
            string jsonRequestData = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            // 建立 HTTP request 內容
            var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
            // 傳送 HTTP POST request
            var response = client.PostAsync(apiUrl, content).Result;
            // 取得 HTTP response 內容
            var responseContent = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new System.Exception($"API回應錯誤：{responseContent}");
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
            return obj;
        }
    }
}
