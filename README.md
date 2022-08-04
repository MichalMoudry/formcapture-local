[![.NET](https://github.com/MichalMoudry/formcapture-local/actions/workflows/dotnet.yml/badge.svg)](https://github.com/MichalMoudry/formcapture-local/actions/workflows/dotnet.yml)

# Form Capture Local
<img src="https://github.com/MichalMoudry/formcapture-local/blob/main/src/FormCaptureLocalWasm/wwwroot/formcapture-icon.svg" alt="Form Capture application logo" width="150" />

**Form Capture is an app for creating complete digitalization workflow using OCR.**


# Project structure
Project is devided into the following structure:

- /src containing all the source code of this app.
    - **FormCaptureLocalWasm** - Blazor WASM project
    - **MoumComponents** - Library project containg razor components
- /test containg projects relating to tests.


# Motivation
This app is a rework of my previous version, which included a server side. The reason for purely local version was, that is app was meant to have minimal running cost for the end-user.


# Translation
This app is translated using resource files and StringLocalizer. All language resource files are located in `/src/FormCaptureLocalWasm/Resources`.

| Language | Resource file name |
|-|-|
| English | App.resx |
| Czech | App.cs.resx |
## Adding a new language
## Improving an existing language


# User guide
