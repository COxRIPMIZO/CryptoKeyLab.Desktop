# CryptoKeyLab.Desktop 🖥️🔐

A modern, high-performance **Windows Desktop Client** built with **WPF (Windows Presentation Foundation)** and **.NET 9**, designed to consume the [CryptoKeyLab SaaS API](https://github.com/COxRIPMIZO/CryptoKeyLab). 

This project demonstrates a true **Client-Server Architecture**, proving that the CryptoKeyLab backend is completely client-agnostic and capable of serving web, mobile, and native desktop environments seamlessly.

---

### 🚀 Architecture & Integration
Unlike standard standalone desktop tools, **CryptoKeyLab.Desktop** does not contain heavy cryptographic algorithms locally. Instead, it acts as a lightweight, secure client that orchestrates data via RESTful API calls.

*   **Pattern:** Follows strict **MVVM (Model-View-ViewModel)** principles for clean separation of UI and business logic.
*   **API Consumption:** Uses asynchronous `HttpClient` to securely transmit data to the CryptoKeyLab API Gateway.
*   **Security:** Implements client-side state management for the temporary `X-API-KEY`, ensuring secure headers are attached to all outbound cryptographic requests.

---

### 🛡️ Key Features
*   **Native Windows Performance:** Fast, responsive UI leveraging hardware acceleration via WPF.
*   **Dynamic UI Rendering:** Reads metadata endpoints from the API to dynamically generate input fields (e.g., automatically requesting a 'Secret Key' only when the user selects HMAC algorithms).
*   **High-Precision Benchmarking:** Displays sub-millisecond execution times retrieved directly from the API response payload.
*   **SaaS Dashboard Access:** Allows users to generate and store 24-hour temporary API keys directly from the desktop interface.

---

### 🛠️ Tech Stack
| Category | Technology |
| :--- | :--- |
| **Framework** | .NET 9 |
| **UI Technology** | WPF (Windows Presentation Foundation) |
| **Design Pattern** | MVVM (Model-View-ViewModel) |
| **API Communication**| HttpClient, System.Text.Json |
| **Backend Target** | [CryptoKeyLab API](https://github.com/COxRIPMIZO/CryptoKeyLab) |

---

### ⚙️ Getting Started
To run this client locally, you must have the CryptoKeyLab API running.

1. Clone this repository.
2. Open `CryptoKeyLab.Desktop.sln` in Visual Studio.
3. In the application settings, set the `ApiBaseUrl` to your local or hosted API endpoint (e.g., `https://localhost:7036`).
4. Generate a temporary API Key via the UI to unlock the cryptographic engine.
5. Build and Run!

*Built by **0xz.0nfirex** - Bridging Enterprise Backends with Native Desktop Experiences.*
