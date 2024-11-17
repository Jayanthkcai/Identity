1. Register Application in Azure. Navigate to Azure Active Directory > App registrations > New registration.
2. In the application, for Redirect URI, enter the URL where your app will handle OAuth responses, e.g., https://localhost:5001/signin-oidc and click Register.
3. After registering, you'll need the Client ID and Tenant ID from the app's Overview page. Also, create a client secret by going to Certificates & secrets > New client secret. Save the secret value, as it will be used in your application.
4. Install the necessary packages to the application
    - Microsoft.AspNetCore.Authentication.AzureAD.UI
    - Microsoft.Identity.Web
    - Microsoft.Identity.Web.UI
5. Update appsetting.json with
    ```markdown
        "AzureAd": {
        "Instance": "https://login.microsoftonline.com/",
        "Domain": "YOUR_DOMAIN",
        "TenantId": "YOUR_TENANT_ID",
        "ClientId": "YOUR_CLIENT_ID",
        "ClientSecret": "YOUR_CLIENT_SECRET",
        "CallbackPath": "/signin-oidc"
    }
    ```
6.  Implement authentication in the [application](OAuth-Azure/) 