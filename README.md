# Sistema de Directorio de Vehículos, Categorías y Clima 

Aplicación frontend desarrollada en **Angular** que se integra con un backend **C# WCF SOAP** para la gestión de un inventario y consume una **API REST externa** para mostrar datos meteorológicos en tiempo real.

##  Características y Tecnologías

* **Frontend:** Angular (Standalone Components), TypeScript, HTML, CSS.
* **Backend:** C# .NET, WCF (Windows Communication Foundation), SQL Server.
* **Integración SOAP:** Consumo nativo de endpoints `.svc` parseando XML a JSON e ignorando prefijos de espacios de nombres (`a:`).
* **Integración REST:** Conexión a la API pública de *Open-Meteo* para el clima en tiempo real de Quito.
* **CORS y SSR:** Configuración de proxy local (`proxy.conf.json`) y escudos anti-SSR (`DOMParser`) para evitar colisiones con Node.js.
* **UI Reactiva:** Uso de `ChangeDetectorRef` para forzar la sincronización visual de los datos asíncronos.

## ⚙️ Requisitos Previos

* **Visual Studio** (con cargas de trabajo para desarrollo web y WCF).
* **SQL Server** (con la base de datos de vehículos y categorías activa).
* **Node.js** (v18 o superior) y **Angular CLI** instalados.

##  Guía de Ejecución

### 1. Levantar el Backend (C# WCF)
El frontend depende de que el servidor de C# esté corriendo primero para evitar errores de conexión.

1. Abre la solución del backend en **Visual Studio**.
2. Verifica en tu archivo `Web.config` que la cadena de conexión apunte a tu instancia local de SQL Server.
3. Presiona el botón **Iniciar (Play verde)** para arrancar IIS Express.
4. Confirma que el navegador te abra una pestaña mostrando la página de servicio (por defecto en `http://localhost:5163/VehiculoService.svc`). Deja Visual Studio corriendo en segundo plano.

### 2. Levantar el Frontend (Angular)
1. Abre tu terminal (VS Code o CMD) en la carpeta raíz del proyecto Angular.
2. Instala las dependencias necesarias:
   ```bash
   npm install
Verifica que tu archivo proxy.conf.json en la raíz coincida exactamente con el puerto de tu backend:

JSON
{
  "/VehiculoService.svc": {
    "target": "http://localhost:5163",
    "secure": false,
    "changeOrigin": true
  }
}
Inicia el servidor de Angular forzando el uso del proxy:

Bash
ng serve -o
Al abrirse http://localhost:4200/ en tu navegador, navega por las tres pantallas para confirmar la integración:

Vehículos: Carga la tabla verde consumiendo VehiculoService.svc mediante SOAP.

Categorías: Carga la tabla azul consumiendo la interfaz IVehiculoService dentro del mismo archivo .svc.

Clima: Carga el recuadro celeste consultando directamente la API pública REST de Open-Meteo, incluyendo la alerta dinámica de temperatura.

Solución de Problemas Comunes
Error "Cannot POST /VehiculoService.svc (404 Not Found)": El proxy no está reconociendo la ruta o la terminal se quedó con una versión vieja. Detén la terminal (Ctrl + C), guarda todos los archivos y vuelve a ejecutar ng serve -o.

Las tablas SOAP salen en blanco pero no hay errores en consola: Verifica que el backend C# siga corriendo en Visual Studio. Si Angular recibió los datos pero no repintó la pantalla, asegúrate de que la instrucción this.cdr.detectChanges(); esté en tu .subscribe().

ReferenceError: DOMParser is not defined: Este error ocurre por el Server-Side Rendering (SSR) de Angular al recargar la página. Mantén siempre el escudo protector (if (typeof window === 'undefined') return [];) al inicio de tu función traductora parsearXML.
