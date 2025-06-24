# 🔄 Swagger Replacement Showcase

This repository demonstrates three different UI tools for exploring OpenAPI specs in a .NET 10 (preview) project:

- [OpenAPI-UI](https://github.com/jakubkozera/openapi-ui)
- [SwaggerUI](https://github.com/swagger-api/swagger-ui)
- [Scalar](https://github.com/scalar/scalar)

Each tool is configured in its own branch:
| Branch       | Description                                           |
|--------------|-------------------------------------------------------|
| [`openapi-ui`](https://github.com/Wajkt0r/swaggerreplacement/tree/openapi-ui) |  Modern dark UI with collections & outputs |
| [`swagger`](https://github.com/Wajkt0r/swaggerreplacement/tree/swagger)     |  Classic and reliable Swagger UI           |
| [`scalar`](https://github.com/Wajkt0r/swaggerreplacement/tree/scalar)       |  Sleek interface with full JWT support     |

---

## 📊 Quick Comparison

### 🧩 OpenAPI-UI

**Pros:**
- Modern and clean UI  
- New features like collections and outputs  
- Actively maintained  

**Cons:**
- New package – could introduce edge-case issues  
- Some request fields (e.g. `price`) not shown in example previews  

---

### 📜 SwaggerUI

**Pros:**
- Well-known and widely adopted  
- Stable and familiar  
- Tested across many versions  

**Cons:**
- Latest version (v9.0) was only released recently (June 13)  
- No extra UI features like collections/outputs  

---

### 🚀 Scalar

**Pros:**
- Clean interface with full support for current OpenAPI auth flows  
- JWT Bearer authorization works out of the box  

**Cons:**
- Heavier UI than Swagger  
- Slightly less minimal  

---

## ⚠️ Known Issues (with .NET 10 Preview)

- **Bearer Auth Missing in OpenAPI Spec:**  
  When using `.NET 10` with Microsoft's OpenAPI generator, the following block is not added automatically to `v1.json`:
  ```json
  "security": [
    { "Bearer": [] }
  ]
  ```
  Which is causing "issues" in OpenAPI-UI and Swagger
