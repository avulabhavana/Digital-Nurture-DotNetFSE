# Kafka Chat Application

## Overview

Kafka Chat Application is a Windows Forms (.NET Framework) application that demonstrates real-time messaging using Apache Kafka. The application allows multiple clients to send and receive messages through a Kafka topic.

## Features

- Send messages to Kafka
- Receive messages from Kafka
- Real-time communication
- Windows Forms GUI
- Apache Kafka Producer and Consumer
- Supports multiple chat clients

## Technologies Used

- C#
- .NET Framework 4.7.2
- Windows Forms
- Apache Kafka 3.9.1
- ZooKeeper
- Confluent.Kafka NuGet Package

## Prerequisites

- Visual Studio 2022
- Java JDK 21
- Apache Kafka
- ZooKeeper

## Kafka Setup

Start ZooKeeper

```cmd
zookeeper-server-start.bat ..\..\config\zookeeper.properties
```

Start Kafka Broker

```cmd
kafka-server-start.bat ..\..\config\server.properties
```

Create Topic

```cmd
kafka-topics.bat --create --topic chatapp --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

## Running the Application

1. Open the solution in Visual Studio.
2. Restore NuGet packages.
3. Build the project.
4. Run multiple instances of the application.
5. Type a message and click **Send**.
6. Messages are displayed in all running chat windows.

## Project Structure

```
KafkaChatApp6
│
├── Form1.cs
├── Program.cs
├── App.config
├── packages.config
├── Properties
└── README.md
```

## Kafka Configuration

Topic Name

```
chatapp
```

Bootstrap Server

```
localhost:9092
```

Consumer Group

```
chat-group
```

## Output

- Messages sent by one client are received by all connected clients.
- Demonstrates Kafka Producer and Consumer communication.

## Author

Jithendra
