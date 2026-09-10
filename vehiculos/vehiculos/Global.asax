<%@ Application Language="C#" %>
<script runat="server">
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        // 1. Permitimos el acceso a tu frontend (puerto 4200)
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        
        // 2. Si Angular envía la petición de seguridad (OPTIONS), le decimos que sí y cortamos la respuesta para que WCF no moleste.
        if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, SOAPAction");
            HttpContext.Current.Response.End();
        }
    }
</script>