# Antigravity Editor for Unity

This package provides integration between Unity and [Antigravity](https://antigravity.google/), Google's AI-powered development environment.

## Features

- Auto-detection of Antigravity installations
- Open scripts directly in Antigravity from Unity
- Generate .csproj and .sln files for IntelliSense support
- Configurable project generation settings

## Installation

1. Open the Package Manager in Unity (`Window > Package Manager`)
2. Click the `+` button and select "Add package from disk..."
3. Navigate to the `package.json` file in this package

## Usage

1. Go to `Edit > Preferences > External Tools` (Windows/Linux) or `Unity > Preferences > External Tools` (macOS)
2. Select "Antigravity" from the "External Script Editor" dropdown
3. Double-click any C# script in the Project window to open it in Antigravity

## Supported Platforms

- **macOS**: `/Applications/Antigravity.app`
- **Windows**: `C:\Program Files\Google\Antigravity\`
- **Linux**: `/usr/bin/antigravity`, `/usr/local/bin/antigravity`

## Requirements

- Unity 2019.2 or later
- Antigravity installed on your system

## License

See [LICENSE.md](LICENSE.md) for details.
