## 🧩 OpenAPI-UI [localhost:port/openapi-ui]

The [OpenAPI-UI](https://github.com/jakubkozera/openapi-ui) package by [@jakubkozera](https://github.com/jakubkozera) was recently published, and the `README.md` is actively maintained – feel free to check it out.
It has a lot of unique features (check out collections / outputs).

### 🔍 Observations during integration

While integrating OpenAPI-UI in a .NET 10 (preview) API, we noticed two things:

---

### 1. ⚠️ Missing fields in example request

Some fields (e.g. `price`) from the request body were missing in the **example request preview**, despite being correctly defined in the OpenAPI schema (`components.schemas`). This only affected OpenAPI-UI — in **SwaggerUI** and **Scalar**, the fields were displayed correctly.
I had already written to the author of the package about it.

![image](https://github.com/user-attachments/assets/aa7e8895-e201-4627-a601-e77019edd628)


---

### 2. 🔐 Authorization (Bearer) not generated in OpenAPI spec

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

### 3. ⚙️ Summary

Pros:
- Modern and clean UI
- New features like collection, outputs etc.
- Actively maintened

Cons:
- New package which might result in some edge-case issues
- Missing fields in request (mentioned above)
