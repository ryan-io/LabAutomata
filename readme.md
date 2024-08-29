<a name="readme-top"></a>
<!-- PROJECT LOGO -->
<p align="center">
<img width="300" height="125" src="https://i.imgur.com/w5hcUtR.png">
</p>
<blockquote>
au·tom·a·ton/ôˈtämədən,ôˈtäməˌtän/ a machine that performs a function according to a predetermined set of coded instructions, especially one capable of a range of programmed responses to different circumstances
</blockquote>
<div align="center">

<h3 align="center">Lab Automata</h3>

  <p align="center">
    A .NET application to automate laboratory data acquisiton (DAQ) and processing. Allows a laboratory to track equipment, work requests, test instances, calibrations, and personnel.
    <br />
    <br />
    <a href="https://github.com//ryan-io/CommandPipeline/issues">Report Bug</a>
    ·
    <a href="https://github.com//ryan-io/CommandPipeline/issues">Request Feature</a>
  </p>
</div>

---
<!-- TABLE OF CONTENTS -->

<details align="center">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#overview">Overview</a></li>
    <li><a href="#tech-stack">Technical Stack</a></li>
    <li><a href="#getting-started">Getting Started & Usage</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments-and-credit">Acknowledgments</a></li>
  </ol>
</details>

---

<!-- ABOUT THE PROJECT -->

# Overview

This passion project comes as the result of an 8 year professional career within an automotive qualification laboratory. The focus was on executing OEM product validation. During validations, an enormous amount of data is acquired: temperature, humidity, voltage input/output, software logging, and quiescient current to name a few. Any and all parameters needed to be collected and logged as data. The intent of this project is to provide a rather generic application for interfacing with your DAQ systems. 

It is also a project to showcase a large breadth of software concepts - one of my goals is to make to make it all encompasing. Depth-wise, it is a bit shallow in areas. Overall, it has a front end GUI, backend systems, database communication, CI/CD pipelines, a Web API, Blynk IoT integration, and version control. Communciation between devices, HMI, and this application are primarily done via MQTT.

Circuit schematics were created with TinkerCad

[Imgur](https://imgur.com/YqvqOb7)

# Tech Stack

<ul>
    <li> Core </li>
    <ul>
        <li>.NET 8 & C# 12</li>
    </ul>
    <li> Solution </li>
    <ul>
        <li>LabAutomata</li>
        <ul><li>The WPF project and entry point of the application</li></ul>
    </ul>
     <ul>
        <li>LabAutomata.Db</li>
        <ul><li>Contains an API for establishing database connections with Entity Framework Core</li>
        <li>Models for your application would be defined here</li>
        </ul>
    </ul>
     <ul>
        <li>LabAutomata.Library</li>
        <ul><li>Business logic and services are defined here</li></ul>
    </ul>
     <ul>
        <li>LabAutomata.Tests.Unit</li>
        <ul><li>A testing project for the LabAutomata project</li></ul>
    </ul>
     <ul>
        <li>LabAutomata.Wpf.Library</li>
        <ul><li>This project contains all view models and commands for use with MVVM</li></ul>
    </ul>
     <ul>
        <li>LabAutomata.Wpf.Tests.Unit</li>
        <ul><li>A testing project for the LabAutomata.Wpf.Library project</li></ul>
    </ul>
     <ul>
        <li>LabAutomata.Wap</li>
        <ul><li>Windows Application Packaging project for creating MSIX packages</li></ul>
    </ul>
      <ul>
        <li>LabAutomata.IoT</li>
        <ul>
          <li>Project for handling the Internet of Things related logic</li>
          <li>Implmenets MQTT.net for communicaiton with an ESP8266/ESP01 module</li>
          <li>Communication is done via MQTT w/ C++ written in Arduino IDE</li>
        </ul>
    </ul>
    <li> GUI </li>
        <ul>
          <li>Windows Presentation Foundation (WPF)</li>
          <li>Controls are made to be as modular and isolated as possible</li>
      </ul>
    <li> Backend </li>
    <ul>
        <li>MVVM architecture</li>
        <li>Dependency Injection with Microsoft.Extensions.DependencyInjection</li>
        <li>Entity Framework Core for interacting with a PostgreSQL database</li>
        <li>ASP.NET Web Api tested and documented with Swagger</li>
        <li>ScottPlot for a wonderful API wrapper for Matplotlib</li>
    </ul>
      <li> Testing </li>
        <ul>
        <li>xUnit</li>
        <li>NSusbstitute</li>
        <li>Fluent Assertions</li>
      </ul>
    <li>Web API</li>
    <ul> 
        <li>ASP.NET Core Web API using MVC</li>
        <li>Uses ErrorOr as a fluent discrimanted union package for an error or a result
    </ul>
    <li>Database</li>
    <ul> 
        <li>PostgreSQL along with pgAdmin4 for DB management</li>
        <li>Mockaroo for populating a test/mock database with data</li>
    </ul>
    <li>Logging</li>
    <ul> 
        <li>My own logging package that is a simple wrapper for SeriLog</li>
        <li>Implements ILogger from the Microsoft.Extensions.Logging package</li>
    </ul>
     <li>CI/CD</li>
    <ul> 
        <li>GitHub Actions</li>
        <li>A workflow for new releases that uses tags to invoke this workflow</li>
        <li>A workflow for running unit tests on all libraries when a push is made</li>
    </ul>
    <li>Design Patterns</li>
    <ul> 
        <li>IoC</li>
        <li>Repository</li>
        <li>Command</li>
        <li>Singleton</li>
        <li>Builder</li>
        <li>Factory</li>
        <li>Iterator</li>
        <li>Observer</li>
        <li>Services</li>
    </ul>
    <li>Miscellaneous</li>
    <ul> 
        <li>I implore SOLID principles with the caveat that I approach these principles more as guidelines or tools rather than strict rules. A core piece of software is maintainability and extensibility. With that said, there are time crunches where I need to get something release. Separation of concerns may not be the best, it could appear more as a jumble of code, or I fail to document a piece of code. These are perfect opportunties for me to go back through the SDLC and refactor code like this. It is an ever evolving process and you can very easily put yourself in a place where development of a piece of software never ceases to end.</li>
    </ul>
</ul>

# Running Notes
<ul>
<li>LabAutomata.Library has dependency on LabAutomata.Db</li>
<li>LabAutomata has dependency on LabAutomata.Library & LabAutomata.Db</li>
</ul>

# Creating entities
<ol>
  <li>Query a model factory -> this should return a discriminated union of ErrorOr that validates the entity was successfully created from the factory<li>
  <li>If ErroOr.IsError -> return an IActionResult of type error; let the consumer know there was a problem creating the entity within the controller (factory) call</li>
  <li>Pass this new entity into the servicer -> the service will depond on a respoitory of the same type; this will add the newly created/validated entity into your database</li>
  <li>The user service will propogate it's own list of ErrorOr</li>
  <li>In summary -> the controller needs to check ErrorOr from creating the model and the ErrorOr invoking the sercice to add it to a repostiory</li>
  <li>There is a documented example currently in the SsTempTestsController class</li>
</ol>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
# License

Distributed under the MIT License.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTACT -->
# Contact

<p align="center">
<b><u>RyanIO</u></b> 
<br/><br/> 
<a href = "mailto:ryan.io@programmer.net?subject=[RIO]%20Procedural%20Generator%20Project" >[Email]</a>
<br/>
<a href="https://www.linkedin.com/in/ryan-stanek/">
[LinkedIn]</a>
<br/>
<a href="https://github.com/ryan-io">[GitHub]</a></p>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
# Acknowledgments and Credit

* [Placeholder]()
	* PlaceHolder

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo_name.svg?style=for-the-badge
[contributors-url]: https://github.com/github_username/repo_name/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/github_username/repo_name.svg?style=for-the-badge
[forks-url]: https://github.com/github_username/repo_name/network/members
[stars-shield]: https://img.shields.io/github/stars/github_username/repo_name.svg?style=for-the-badge
[stars-url]: https://github.com/github_username/repo_name/stargazers
[issues-shield]: https://img.shields.io/github/issues/github_username/repo_name.svg?style=for-the-badge
[issues-url]: https://github.com/github_username/repo_name/issues
[license-shield]: https://img.shields.io/github/license/github_username/repo_name.svg?style=for-the-badge
[license-url]: https://github.com/github_username/repo_name/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: images/screenshot.png
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com