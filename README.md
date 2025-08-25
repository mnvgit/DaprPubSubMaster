DaprPubSubMaster

This solution demonstrates a Publisher → RabbitMQ → Subscriber workflow using Dapr pub/sub.
It uses .NET 8, Dapr sidecars, and RabbitMQ, fully containerized with Docker Compose.

Publisher sends events every few seconds.
Subscriber receives events via RabbitMQ and simulates storing them in a DB.
Both use Dapr sidecars for pub/sub.
</br></br>

⚡ Prerequisites
Docker Desktop
 installed.
.NET 8 SDK
 (optional, only if building outside Docker).
No manual RabbitMQ setup required — Docker Compose will handle it.
</br></br>

🏃 Running Locally

Open a terminal in the solution root:
cd DaprPubSubMaster
Start the solution using Docker Compose:
docker compose up --build
Wait until all services are up:
RabbitMQ → UI: http://localhost:15672
 (guest/guest)

DaprPublisherWorker: publishes events to RabbitMQ via Dapr and logs each message so users can track what was sent.</br>
DaprSubscriberApi: receives events from RabbitMQ via Dapr, simulates processing (e.g., saving to a database), and logs each received event.

</br></br>
🔧 Notes

No configuration required — all ports and RabbitMQ credentials are preconfigured.</br>
Dapr sidecars handle communication automatically; no hardcoded endpoints in code.</br>
Publisher and Subscriber communicate over gRPC.</br>
components/pubsub.yaml defines RabbitMQ pub/sub for Dapr.</br>
Publisher logs show messages being published.</br>
Subscriber logs show messages received and simulated DB storage.
</br></br>

⚡ Recommended VS Usage
Keep docker-compose.yml and docker-compose.override.yml in the solution root.
Open the solution in Visual Studio.
Use docker compose up --build from terminal, or add a Docker Compose project in VS for F5 debugging.
Do not hardcode Dapr endpoints in code — the SDK auto-detects ports via environment variables.
</br></br>

✅ Summary
This project demonstrates a ready-to-run Dapr + RabbitMQ pub/sub example using Docker Compose.
Just clone the repo and run:
docker compose up --build
Everything is containerized — no extra setup required.
