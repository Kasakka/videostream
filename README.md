# Video Streaming Backend

This project is an ASP.NET Core-based video streaming backend. It is designed for local development and containerized deployment using Docker. The project demonstrates how to serve video files with HTTP range requests (supporting features like seeking) while also providing a user-friendly web interface using the Model-View-Controller (MVC) pattern.

## Features

- **Video Streaming:**  
  Stream video files using HTTP range requests. This allows users to seek to different parts of the video.
  
- **MVC Web UI:**  
  Provides a full web interface with views and controllers. Users can browse available videos, view details, and stream content directly from the browser.
  
- **Container Support:**  
  Dockerized application for easy deployment and consistent environments.
  
- **Local Development:**  
  Simple configuration to run locally, with an in-memory list of videos that can later be extended to use a database.
  
- **REST API Endpoint:**  
  Although the project now uses MVC, it retains the capability to stream video through a dedicated endpoint (e.g., `/Video/Stream/{id}`).