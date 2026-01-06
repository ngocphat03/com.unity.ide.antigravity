# Antigravity Editor for Unity

[![Unity 2019.2+](https://img.shields.io/badge/Unity-2019.2%2B-blue.svg)](https://unity.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE.md)

> Unity Editor integration package for **[Antigravity](https://antigravity.google/)** - Google's AI-powered development environment.

Seamlessly open and edit your Unity C# scripts in Antigravity with full IntelliSense support through automatic `.csproj` and `.sln` file generation.

---

## ✨ Features

- 🔍 **Auto-detection** of Antigravity installations on macOS, Windows, and Linux
- 📂 **One-click script opening** from Unity Editor directly in Antigravity
- 🛠️ **Project file generation** (`.csproj` / `.sln`) for IntelliSense support
- ⚙️ **Configurable settings** for project generation preferences
- 🎯 **Line & column navigation** - opens files at the exact error location

---

## 📋 Requirements

- **Unity**: 2019.2 or later
- **Antigravity**: Installed on your system
  - macOS: `/Applications/Antigravity.app`
  - Windows: `C:\Program Files\Google\Antigravity\`
  - Linux: `/usr/bin/antigravity` or `/usr/local/bin/antigravity`

---

## 📦 Installation

1. Open Unity Editor
2. Go to **Window > Package Manager**
3. Click the **+** button → **Add package from git URL...**
4. Enter:
   ```
   https://github.com/ngocphat03/com.unity.ide.antigravity.git?path=Packages/com.unity.ide.antigravity
   ```
5. Click **Add**

---

## ⚙️ Configuration

### Set Antigravity as Default Editor

1. Open Unity Editor
2. Go to:
   - **Windows/Linux**: `Edit > Preferences > External Tools`
   - **macOS**: `Unity > Preferences > External Tools`
3. In **External Script Editor** dropdown, select **Antigravity**
4. (Optional) Configure **Generate .csproj files for** options

### Project Generation Settings

| Option | Description |
|--------|-------------|
| Embedded packages | Include Unity's built-in packages |
| Local packages | Include packages from local folder |
| Git packages | Include packages from git URLs |
| Built-in packages | Include Unity engine packages |
| Local tarball | Include .tgz packages |

---

## 🖥️ Supported Platforms

| Platform | Default Installation Path |
|----------|--------------------------|
| **macOS** | `/Applications/Antigravity.app` |
| **Windows** | `C:\Program Files\Google\Antigravity\Antigravity.exe` |
| **Linux** | `/usr/bin/antigravity`, `/usr/local/bin/antigravity`, `/snap/bin/antigravity` |

---

## 🔧 Troubleshooting

### Antigravity not showing in External Script Editor dropdown

1. Ensure Antigravity is installed in one of the default paths above
2. Restart Unity Editor
3. Check `Preferences > External Tools` again

### Scripts not opening at correct line

Verify the **External Script Editor Args** in Preferences contains:
```
"$(File)" -g $(Line):$(Column)
```

### Project files not generating

1. Go to `Preferences > External Tools`
2. Click **Regenerate project files**
3. Check Unity Console for errors

---

## 🤝 Contributing

Contributions are welcome! Please read our [Contributing Guidelines](CONTRIBUTING.md) before submitting PRs.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.md](Packages/com.unity.ide.antigravity/LICENSE.md) file for details.

---

## 🙏 Acknowledgments

This package is forked from [com.unity.ide.vscode](https://github.com/Unity-Technologies/com.unity.ide.vscode) by Unity Technologies.

---

<p align="center">
  Made with ❤️ for the Unity community
</p>
