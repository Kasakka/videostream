# Video Streaming Backend

This project is an ASP.NET Core-based video streaming backend. It is designed for local development and containerized deployment using Docker. The application dynamically lists any MP4 video file placed in the `videos` folder, streams video files using HTTP range requests (allowing features like seeking), and provides a user-friendly web interface.

## Features

- **Dynamic Video Listing:**  
  Automatically lists any MP4 files added to the `videos` folder at the project root.
  
- **Video Streaming:**  
  Streams video files using HTTP range requests, enabling users to seek within videos.
  
- **MVC Web UI:**  
  Provides a full web interface with controllers, views, and a shared layout (styled with Material Design using Materialize CSS). Users can browse available videos, view video details, and stream content directly from the browser.
  
- **Container Support:**  
  Dockerized application for easy deployment and consistent environments.
  
- **Local Development:**  
  Simple configuration to run locally—just add your MP4 video files to the `videos` folder and the app will list them.