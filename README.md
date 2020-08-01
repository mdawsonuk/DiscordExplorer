<p align="center">
  <a href="https://github.com/mdawsonuk/DiscordExplorer">
    <img src=".github/images/logo.png" alt="Logo" width="80" height="80">
  </a>
  
  <h3 align="center">Discord Explorer</h3>
	
  <p align="center">
    <a href="LICENCE" alt="Licence">
		<img src="https://img.shields.io/github/license/mdawsonuk/DiscordExplorer?style=flat-square" /></a>
	<a href="#backers" alt="Releases">
		<img src="https://img.shields.io/github/v/release/mdawsonuk/DiscordExplorer?include_prereleases&style=flat-square&color=blue" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/issues" alt="Issues">
		<img src="https://img.shields.io/github/issues/mdawsonuk/DiscordExplorer?style=flat-square" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/releases" alt="Downloads">
		<img src="https://img.shields.io/github/downloads/mdawsonuk/DiscordExplorer/total?style=flat-square" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/pulse" alt="Maintenance">
		<img src="https://img.shields.io/maintenance/yes/2020?style=flat-square" /></a>
	<a>
		<img src="https://img.shields.io/github/languages/code-size/mdawsonuk/DiscordExplorer?style=flat-square"
			alt="Repo Size"></a>
  </p>
  <p align="center">
    Parses the Discord cache files to retrieve emotes, messages, attachments, profiles and more
    <br />
    <a href="https://github.com/mdawsonuk/DiscordExplorer"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/mdawsonuk/DiscordExplorer/issues">Report a Bug</a>
    ·
    <a href="https://github.com/mdawsonuk/DiscordExplorer/issues">Request Feature</a>
  </p>
</p>


<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [License](#license)
<!--* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)-->



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]]()

Discord Explorer was created due to the lack of reliable Discord Digital Forensics tools.
Existing tools would parse database files which no long exist, or only parse cached image files.
The aim of this project is to parse the Discord Cache found in `%appdata\Discord\Cache` 
and extract not just images, but messages, emotes, attachments, profiles and intelligently organise
it for easy analysis of a user's Discord activity.

Core features:
* Parses the `index` file in the Discord Cache
* Loads all cached emotes/emojis
* Loads all cached avatars
* Loads all cached server/guild icons
* Loads all cached messages
* Loads all cached message attachments
* Loads all of the local user's connections, notes they've made for other users, server list, Discord Premium (Nitro) details and more
* Reconstruct message threads in a like-for-like Discord preview window
* Export all files extracted from cache - Discord's JSON files, images, videos and more

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

As Discord Explorer is built with .Net Core 3.1, it doesn't require any prerequisites if it is running on Windows 10/Windows Server 2016+. Lower than Windows 10/Windows Server 2016 is not officially supported. 

Discord Explorer's GUI can be run with Mono on Linux and OS X, but it is recommended to use Discord Explorer's Command Line on non-Windows systems.

### Installation
 
1. Clone the repo
```sh
git clone https://github.com/mdawsonuk/DiscordExplorer.git
```

<!-- USAGE EXAMPLES
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_



<!-- ROADMAP
## Roadmap

See the [open issues](https://github.com/mdawsonuk/DiscordExplorer/issues) for a list of proposed features (and known issues).



<!-- CONTRIBUTING
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<!-- CONTACT
## Contact

Project Link: [https://github.com/mdawsonuk/DiscordExplorer](https://github.com/mdawsonuk/DiscordExplorer)

<!-- ACKNOWLEDGEMENTS
## Acknowledgements

* []()
* []()
* []()-->

[product-screenshot]: .github/images/screenshot.png