## 🧩 Swagger [localhost:port/swagger]

I think there's no need to mention Swagger features. I'm just linking the same issue which appeared in OpenAPI-UI

### 1. 🔐 Authorization (Bearer) not generated in OpenAPI spec

In .NET 10, when using the OpenAPI generator, the following section was **not automatically included** in the final OpenAPI spec (`v1.json`):

```json
"security": [
  { "Bearer": [] }
]
```
As a result, the Authorize button does not appear in SwaggerUI, Scalar, or OpenAPI-UI.
In .NET 9, we could handle this by implementing an OpenApiDocumentTransformer, but this no longer works in .NET 10 due to internal API changes. So far, we haven’t found an equivalent workaround.

✅ When we manually added the Bearer block to the spec, everything worked as expected across all tools (SwaggerUI, OpenAPI-UI).

📌 A similar issue was reported and fixed in Scalar (it was resolved for the .NET 9:
https://github.com/scalar/scalar/issues/4055
