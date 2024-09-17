using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace isRock.Template
{
    public class Dify2LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string DifyAPIKey = "👉app_f0Bn____________x1v"; //👉repleace it with your Dify AI key
        const string adminUserId = "👉U52______________________30"; //👉repleace it with your Admin User Id
        const string channelAccessToken = "👉PZamXoS6ecMPVEq____________Ma2kmvXsPlFU="; //👉repleace it with your Channel Access Token

        private readonly CacheService _cacheService;

        public Dify2LineBotWebHookController(CacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [Route("api/Dify2LineBotWebHook")]
        [HttpPost]
        public IActionResult POST()
        {

            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = channelAccessToken;
                //配合Line Verify
                if (ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
                    ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();

                var responseMsg = "";
                //準備回覆訊息
                if (LineEvent != null && LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                {
                    //取得對話ID(from cache)
                    var Conversation_id = _cacheService.GetCache(LineEvent.source.userId);
                    //如果用戶輸入 /forget 則把 Conversation_id 清空，重啟對話
                    if (LineEvent.message.text.Trim().ToLower() == "/forget")
                    {
                        _cacheService.RemoveCache(LineEvent.source.userId);
                        Conversation_id = null;
                        responseMsg = "我已經忘記之前所有對話了";
                    }
                    else
                    {
                        //👇建立呼叫 Dify API 所需的 requestData 參數
                        var requestData = new
                        {
                            inputs = new { },
                            query = LineEvent.message.text, //👉取得使用者輸入文字
                            response_mode = "blocking",
                            conversation_id = Conversation_id is null ? "" : Conversation_id.ToString(), //👉取得對話ID
                            user = LineEvent.source.userId //👉取得使用者ID
                        };
                        var response = Dify.CallDifyChatMessagesAPI(DifyAPIKey, requestData);
                        responseMsg = response.answer;
                        //儲存對話ID(to cache)
                        _cacheService.SetCache(LineEvent.source.userId, response.conversation_id);
                    }
                }
                else if (LineEvent != null && LineEvent.type.ToLower() == "message")
                    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                else
                    responseMsg = $"收到 event : {LineEvent.type} ";
                //回覆訊息
                this.ReplyMessage(LineEvent.replyToken, responseMsg);
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage(adminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}