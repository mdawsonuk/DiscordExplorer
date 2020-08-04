<p align="center">
  <a href="https://github.com/mdawsonuk/DiscordExplorer">
    <img src=".github/images/logo.png" alt="Logo" width="80" height="80">
  </a>
  
  <h3 align="center">Discord Explorer</h3>
	
  <p align="center">
    <a href="LICENCE" alt="Licence">
		<img src="https://img.shields.io/github/license/mdawsonuk/DiscordExplorer?style=flat-square" /></a>
	<a alt="Releases">
		<img src="https://img.shields.io/github/v/release/mdawsonuk/DiscordExplorer?include_prereleases&style=flat-square&color=blue" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/issues" alt="Issues">
		<img src="https://img.shields.io/github/issues/mdawsonuk/DiscordExplorer?style=flat-square" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/releases" alt="Downloads">
		<img src="https://img.shields.io/github/downloads/mdawsonuk/DiscordExplorer/total?style=flat-square" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/pulse" alt="Maintenance">
		<img src="https://img.shields.io/maintenance/yes/2020?style=flat-square" /></a>
	<a href="https://github.com/mdawsonuk/DiscordExplorer/">
		<img src="https://img.shields.io/github/languages/code-size/mdawsonuk/DiscordExplorer?style=flat-square"
			alt="Repo Size"></a>
  </p>
  <p align="center">
    Parses the Discord cache files to retrieve emotes, messages, attachments, profiles and more
    <br />
    <a href="https://github.com/mdawsonuk/DiscordExplorer/wiki"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/mdawsonuk/DiscordExplorer/issues/new?labels=bug">Report a Bug</a>
    ·
    <a href="https://github.com/mdawsonuk/DiscordExplorer/issues/new?labels=enhancement">Request Feature</a>
  </p>
</p>

## Table of Contents

* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Contributing](#contributing)
* [License](#license)

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

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

As Discord Explorer is built with .Net Core 3.1, it doesn't require any prerequisites if it is running on Windows 10/Windows Server 2016+. Lower than Windows 10/Windows Server 2016 is not officially supported.

To set up .Net Core on a non-Windows system, follow the Microsoft documentation for [Mac OS X](https://docs.microsoft.com/en-us/dotnet/core/install/macos) or [Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux)

Discord Explorer's GUI can be run with Mono on Linux and OS X, but it is recommended to use Discord Explorer's Command Line on non-Windows systems.

### Installation

#### From Releases

1. Download the latest [release](https://github.com/mdawsonuk/DiscordExplorer/releases).

2. Unzip the compressed release to a folder of your choice.

3. That's it!

#### From Repo

1. Clone the repo
```sh
git clone https://github.com/mdawsonuk/DiscordExplorer.git
```

2. (optional) Using dotnet CLI, run the tests
```sh
dotnet test DiscordExplorer.sln
```

3. Using dotnet CLI, build the application
```sh
dotnet build DiscordExplorer.sln
```

3. That's it! If on Windows, go to the DiscordExplorer build directory, otherwise go to the DiscordExplorer.CLI build directory.

## Contributing

Contributions are what makes open source projects such an interesting and fun place to develop. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

Please ensure that there is good test coverage of your new feature.

## License

Distributed under the GPLv3 License. See [LICENSE](LICENSE) for more information.

[product-screenshot]: .github/images/screenshot.png