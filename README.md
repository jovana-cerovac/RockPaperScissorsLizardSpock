# Rock Paper Scissors Lizard Spock – Full Stack Application

A full-stack implementation of the classic game [**Rock Paper Scissors Lizard Spock**](https://www.samkass.com/theories/RPSSL.html), designed to demonstrate clean architecture, service separation, and a modern frontend experience.

---

## Solution Overview

This solution is composed of three main components:

- [**Frontend**](frontend/rpsls-game/Readme.md) – A modern React 19 application that provides an interactive UI for users to play the game.
- [**GameAPI**](backend/GameAPI/Readme.md) – A .NET 8 Web API responsible for handling game sessions, evaluating results, and maintaining the scoreboard.
- [**ChoiceAPI**](backend/ChoiceAPI/Readme.md) – A .NET 8 Web API responsible for managing and retrieving game choices.

The architecture follows a microservice-style backend separation, with RESTful APIs consumed by the frontend using **RTK Query**.

The component interaction is presented [here](/Component_interaction.puml)

