
<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <h1 align="center">Rift</h1>

  <p align="center">
    A library for building microservices with ASP.NET Core
    <br />
    <a href="https://github.com/R46narok/Rift/wiki"><strong>Explore the docs »</strong></a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

<div align="center">
<img align="center" src="https://github.com/R46narok/Rift/blob/master/images/logo.png">
</div>

*Rift* is a set of libraries, which aim to make developing microservices easier.

The library features:
* Data abstractions
* Events
* CQRS and Mediator
* Cloud Service Providers(Azure)
* Message brokers (Azure Service Bus)
* Protected storage (Azure Key Vault)

The solutions follows the microservice approach and is designed to improve scalability and capacity for lots of requests per second. The architecture is security oriented.

<p align="right">(<a href="#top">back to top</a>)</p>



### Built With

The following frameworks/technologies were used to build the project:

* [Microsoft Azure](https://azure.microsoft.com/en-us/)
* [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)
<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

To get a local copy of the libraries do the following.

### Prerequisites

Make sure you have the following packages/SDKs installed:
* .NET Core 6
* A valid Azure subscription

### Installation

Below is an example of how to add the libraries as dependencies from the official packages published on [NuGet](https://www.nuget.org/profiles/r46narok).

1. Make sure you are in the project directory
   ```sh
   cd PROJECT_DIR
   ```
2. Install the main package
   ```sh
   dotnet add package Rift.Core
   ```
3. Install the CSP package
   ```sh
   dotnet add package Rift.CloudServiceProviders
   ```

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

To learn more about how the library works and the various patterns it provides, go to the [wiki](https://github.com/R46narok/Rift/wiki).

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- ROADMAP -->
## Roadmap

- [x] Update README
- [ ] Document the project further

See the [open issues](https://github.com/r46narok/rift/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- CONTACT -->
## Authors

👤  **Stanimir Kolev**

-   [R46narok](https://github.com/R46narok)
-   [StanimirKolev](https://www.linkedin.com/in/stanimir-kolev-60984a227/)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

The following libraries were used in the development of the project:

* [MediatR](https://github.com/jbogard/MediatR) - .NET library for CQRS and Mediator pattern
* [FluentValidation](https://fluentvalidation.net/) - .NET library for building strongly-typed validation rules
* [AutoMapper](https://automapper.org/) - .NET convention-based object-object mapper

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/r46narok/rift.svg?style=for-the-badge
[contributors-url]: https://github.com/r46narok/rift/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/r46narok/rift.svg?style=for-the-badge
[forks-url]: https://github.com/r46narok/rift/network/members
[stars-shield]: https://img.shields.io/github/stars/r46narok/rift.svg?style=for-the-badge
[stars-url]: https://github.com/r46narok/rift/stargazers
[issues-shield]: https://img.shields.io/github/issues/r46narok/rift.svg?style=for-the-badge
[issues-url]: https://github.com/r46narok/rift/issues
[license-shield]: https://img.shields.io/github/license/r46narok/rift.svg?style=for-the-badge
[license-url]: https://github.com/r46narok/rift/blob/master/LICENSE.txt
[product-screenshot]: images/logo.png
