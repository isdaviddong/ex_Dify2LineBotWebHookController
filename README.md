# System Documentation

This documentation provides an overview of the system and explains the functionality of each code file.

## LineBotChatGPTWebHookController.cs

This file contains thefile contains the `Dify2LineBotWeclass, which is responsible for handling thentroller` class, wrequests. It includes the following functionalities:

- `POST` method: This method is triggered when a POST request is made to thed: This method is triggered endpoint. It processes made events, such as receiving messages, and performs actions based on the received messages.

## Program.cs

This file is the entry point of the application. It sets up the application's services and configures thent of request pipeline. The following functionalities are included:

- `WebApplication.CreateBuilder`: Creates a new instance of thereates a new instabuilder.
- `builder.Services.AddMemoryCache()`: Adds theAdds the `Memorservice to the container.
- `builder.Services.AddControllers()`: Adds the controllers to the container.
- `builder.Services.AddScoped<CacheService>()`: Adds theAdds the `CacheSas a scoped service.
- `builder.Services.AddEndpointsApiExplorer()`: Adds thedds the API exservices.
- `builder.Services.AddSwaggerGen()`: Addsdds Swagger/OpenAgeneration services.
- `app.UseSwagger()`: Configuresonfiguresmiddleware for generating ther middleware fdocument.
- `app.UseSwaggerUI()`: Configuresonfigures Swmiddleware for serving theI middlewarepage.
- `app.UseAuthorization()`: Adds authorization middleware to the pipeline.
- `app.MapControllers()`: Maps the controllers to the endpoints.
- `app.Run()`: Runs the application.

## Dify.cs

This file contains thefile conclass, which provides a static method `Dify` class, which provi. This method is responsible for making a POST request to thetatic metchat messages`Cal. It includes the following functionalities:

- `CallDifyChatMessagesAPI`: Calls thechat messchat messages API with the provided API key and request data. It sends anh the provirequest to the API endpoint, sets the necessary headers, serializes the request data to. It , and returns the response as a dynamic object.

## MemoryCache.cs

This file contains the `CacheService` class, which provides methods for storing, retrieving, and removing data from the memory cache. It includes the following functionalities:

- `SetCache`: Stores data in the memory cache with the specified key and expiration options.
- `GetCache`: Retrieves data from the memory cache based on the specified key.
- `RemoveCache`: Removes data from the memory cache based on the specified key.

---

# 中文說明

此文件提供系統的概述，並解釋每個程式碼檔案的功能。

## LineBotChatGPTWebHookController.cs

此檔案包含 `Dify2LineBotWebHookController` 類別，負責處理 Line bot webhook 請求。它包含以下功能：

- `POST` 方法：當對 `/api/Dify2LineBotWebHook` 端點進行 POST 請求時觸發此方法。它處理 Line 事件，例如接收訊息，並根據接收到的訊息執行相應的動作。

## Program.cs

此檔案是應用程式的進入點。它設定應用程式的服務並配置 HTTP 請求管線。以下功能包括：

- `WebApplication.CreateBuilder`：建立 `WebApplication` 建構器的新實例。
- `builder.Services.AddMemoryCache()`：將 `MemoryCache` 服務添加到容器中。
- `builder.Services.AddControllers()`：將控制器添加到容器中。
- `builder.Services.AddScoped<CacheService>()`：將 `CacheService` 添加為範圍服務。
- `builder.Services.AddEndpointsApiExplorer()`：添加 API explorer 服務。
- `builder.Services.AddSwaggerGen()`：添加 Swagger/OpenAPI 生成服務。
- `app.UseSwagger()`：配置 Swagger 中介軟體以生成 Swagger JSON 文件。
- `app.UseSwaggerUI()`：配置 Swagger UI 中介軟體以提供 Swagger UI 頁面。
- `app.UseAuthorization()`：將授權中介軟體添加到管線中。
- `app.MapControllers()`：將控制器映射到端點。
- `app.Run()`：執行應用程式。

## Dify.cs

此檔案包含 `Dify` 類別，提供靜態方法 `CallDifyChatMessagesAPI`。此方法負責對 Dify AI 聊天訊息 API 發出 POST 請求。它包含以下功能：

- `CallDifyChatMessagesAPI`：使用提供的 API 金鑰和請求資料呼叫 Dify AI 聊天訊息 API。它發送 HTTP POST 請求到 API 端點，設定必要的標頭，將請求資料序列化為 JSON，並將回應作為動態物件返回。

## MemoryCache.cs

此檔案包含 `CacheService` 類別，提供將資料存儲、檢索和從記憶體快取中刪除的方法。它包含以下功能：

- `SetCache`：使用指定的鍵和過期選項將資料存儲在記憶體快取中。
- `GetCache`：根據指定的鍵從記憶體快取中檢索資料。
- `RemoveCache`：根據指定的鍵從記憶體快取中刪除資料。

