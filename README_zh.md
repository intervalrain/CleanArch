繁體中文 | [English](README.md)

# CleanArch - 乾淨架構學習專案

一個基於 .NET 9 的乾淨架構實現，專注於身份驗證服務，遵循 [Amantinband 乾淨架構模板](https://github.com/amantinband/clean-architecture) 的原則。

## 🏛️ 架構概覽

本專案展示了乾淨架構原則，重點關注：
- **關注點分離**：每個層次都有明確的職責
- **依賴反轉**：依賴關係指向領域核心
- **CQRS 模式**：使用 MediatR 實現命令查詢職責分離
- **領域驅動設計**：豐富的領域模型和錯誤處理

## 📁 專案結構

```
CleanArch/
├── CleanArch.Api/              # 表現層
│   ├── Controllers/            # API 控制器
│   ├── Common/                 # HTTP 工具和錯誤處理
│   └── Mappings/               # 請求/回應映射
├── CleanArch.Application/      # 應用層
│   ├── Authentication/         # 認證命令、查詢、處理器
│   └── Common/                 # 介面和抽象
├── CleanArch.Contracts/        # API 合約
│   └── Authentication/         # 請求/回應 DTO
├── CleanArch.Domain/           # 領域層
│   ├── Entities/               # 領域實體
│   ├── Common/Errors/          # 領域錯誤
│   └── Persistence/            # 儲存庫介面
├── CleanArch.Infrastructure/   # 基礎設施層
│   ├── Authentication/         # JWT 實現
│   ├── Persistence/            # 資料存取實現
│   └── Time/                   # 外部服務實現
└── Docs/                       # 文件
```

## 🚀 功能特色

### 身份驗證系統
- **用戶註冊**：建立新用戶帳號並進行驗證
- **用戶登入**：基於 JWT 的身份驗證
- **Token 生成**：可配置的安全 JWT Token
- **錯誤處理**：全面的基於領域的錯誤管理

### 架構模式
- **CQRS**：使用 MediatR 分離命令和查詢
- **儲存庫模式**：乾淨的資料存取抽象
- **依賴注入**：模組化服務註冊
- **對象映射**：使用 Mapster 進行高效能對象映射

## 🛠️ 技術堆疊

- **.NET 9**：最新的 .NET 框架
- **ASP.NET Core**：Web API 框架
- **MediatR**：CQRS 和中介者模式
- **Mapster**：高效能對象映射
- **JWT**：JSON Web Token 身份驗證
- **Swagger**：API 文件

## 📋 前置需求

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- IDE(Visual Studio Code)

## 🏃‍♂️ 開始使用

### 1. 複製儲存庫
```bash
git clone <你的儲存庫網址>
cd CleanArch
```

### 2. 建置解決方案
```bash
dotnet build
```

### 3. 執行應用程式
```bash
cd CleanArch.Api
dotnet run
```

### 4. 存取 API
- **Swagger UI**：`https://localhost:7077/swagger`
- **API 基本網址**：`https://localhost:7077`

## 📝 API 文件

### 身份驗證端點

#### 註冊用戶
```http
POST /auth/register
Content-Type: application/json

{
  "firstName": "張",
  "lastName": "三",
  "email": "zhang.san@example.com",
  "password": "SecurePassword123!"
}
```

#### 用戶登入
```http
POST /auth/login
Content-Type: application/json

{
  "email": "zhang.san@example.com",
  "password": "SecurePassword123!"
}
```

**回應格式：**
```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "張",
  "lastName": "三",
  "email": "zhang.san@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

詳細的 API 文件請參閱 [Docs/Api.md](./Docs/Api.md)。

## 🧪 測試

```bash
# 執行所有測試
dotnet test

# 執行並產生覆蓋率報告
dotnet test --collect:"XPlat Code Coverage"
```

## 📖 學習資源

本專案實現了以下模式和原則：

- **乾淨架構** by Robert C. Martin
- **Amantinband 乾淨架構模板**：[GitHub 儲存庫](https://github.com/amantinband/clean-architecture)
- **領域驅動設計** 原則
- **CQRS 和事件溯源** 模式

## 🤝 貢獻

這是一個學習專案。歡迎：
1. Fork 儲存庫
2. 建立功能分支
3. 進行修改
4. 提交 Pull Request

## 📄 授權

本專案僅供教育用途。歡迎作為學習資源使用。

## 🙏 致謝

- **Amantinband** 提供優秀的乾淨架構模板和教學
- **乾淨架構** 社群提供最佳實踐和模式
- **.NET 社群** 提供全面的文件和支援

---

**注意**：這是一個用於學習乾淨架構原則的學習專案。在生產環境使用前，需要額外考慮安全性、效能和可靠性等因素。