<a name="readme-top"></a>
<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->


<!-- PROJECT LOGO -->

<p align="center">
<img width="300" height="125" src="https://i.imgur.com/w5hcUtR.png">
</p>

<div align="center">

<h3 align="center">Lab Automata</h3>

  <p align="center">
    A complete .NET laboratory DAQ application.
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

It is also a learning project - one of my goals is to make to make it all encompasing. That means it has a front end GUI, backend systems, database communication, CI/CD pipelines, a Web API, and version control.

# Tech Stack

<ul>
    <li> Core </li>
    <ul>
        <li>.NET 8 & C# 12</li>
    </ul>
    <li> GUI </li>
        <ul><li>Windows Presentation Foundation (WPF)</li></ul>
    <li> Backend </li>
    <ul>
        <li>MVVM architecture</li>
        <li>Dependency Injection with Microsoft.Extensions.DependencyInjection</li>
        <li>Entity Framework Core for interacting with a PostgreSQL database</li>
        <li>ASP.NET Web Api tested and documented with Swagger</li>
        <li>ScottPlot for a wonderful API wrapper for Matplotlib</li>
    </ul>
    <li>Database</li>
    <ul> 
        <li>PostgreSQL along with pgAdmin4 for management</li>
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