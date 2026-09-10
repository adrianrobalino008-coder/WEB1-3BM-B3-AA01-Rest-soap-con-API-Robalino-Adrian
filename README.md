# Sistema de Directorio de Vehículos, Categorías y Clima 

Aplicación frontend desarrollada en **Angular** que se integra con un backend **C# WCF SOAP** para la gestión de un inventario de vehículos y categorías, y consume una **API REST externa** para mostrar datos meteorológicos en tiempo real.

##  Características Principales

* **Consumo de Servicios SOAP:** Integración nativa con endpoints `.svc` (WCF) enviando `xmlEnvelope` a través de `HttpClient`.
* **Traductor XML a JSON:** Implementación de un parser dinámico a prueba de fallos para extraer nodos XML ignorando prefijos de espacios de nombres (ej. `a:Vehiculo`).
* **Soporte SSR (Server-Side Rendering):** Escudo de protección en el parseo del DOM (`DOMParser`) para evitar colisiones durante la renderización en el servidor (Node.js).
* **Bypass de CORS:** Configuración de un proxy local (`proxy.conf.json`) para un enrutamiento seguro hacia el backend en C# (IIS Express).
* **Consumo REST Externo:** Conexión a la API pública de *Open-Meteo* para obtener la temperatura y velocidad del viento en Quito, Ecuador, incluyendo un sistema de advertencias dinámicas según el clima.
* **Actualización de Interfaz (UI):** Uso de `ChangeDetectorRef` para forzar la sincronización de la vista tras la resolución asíncrona de promesas/observables.

## 🛠️ Tecnologías Utilizadas

* **Frontend:** Angular (Standalone Components), TypeScript, HTML, CSS.
* **Backend:** C# .NET, WCF (Windows Communication Foundation), API SOAP.
* **Base de Datos:** SQL Server (Gestionado vía C#).
* **APIs Externas:** Open-Meteo REST API.

## ⚙️ Configuración y Ejecución

### 1. Backend (C# WCF)
1. Abre la solución del backend en **Visual Studio**.
2. Asegúrate de que los servicios (`VehiculoService.svc`) estén configurados para ejecutarse.
3. Inicia el proyecto (IIS Express). Verifica que el puerto coincida con el configurado en el proxy del frontend (por defecto: `http://localhost:5163`).

### 2. Frontend (Angular)
1. Clona el repositorio y abre una terminal en la carpeta del proyecto.
2. Instala las dependencias:
   ```bash
   npm install
