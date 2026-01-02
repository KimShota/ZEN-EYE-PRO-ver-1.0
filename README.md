# ZEN-EYE-PRO

A VR application for PICO XR devices that utilizes eye-tracking technology to provide stress checker, vision training, working memory tests, and other features.

## 📹 Demo Videos

You can view the demo videos at the following link:

🔗 [Demo Videos (Google Drive)](https://drive.google.com/drive/folders/1-ldUyXFNReW1IrZmvnwWKZsZQIKcigMQ?usp=sharing)


## 📋 Overview

ZEN-EYE-PRO is a VR application that leverages the eye-tracking capabilities of PICO XR devices. It collects and analyzes user gaze data to perform stress checks, vision training, cognitive function tests, and more.

## ✨ Key Features

### 1. Stress Checker
- Gaze data collection through eye tracking
- Visual analysis with heatmaps
- Stress level measurement and visualization

### 2. Vision Training
- Dynamic target tracking training
- Static target focus training
- Soccer-themed vision training scene
- Accuracy test functionality

### 3. Working Memory Test
- Flash memory test
- Collision detection functionality
- Hand tracking integration
- Audio feedback

### 4. Focus Experiment
- Random breathing focus sphere
- Visual attention measurement

## 🛠️ Technical Specifications

### Development Environment
- **Unity Version**: 2022.3.50f1
- **Platform**: Android (PICO XR)
- **Render Pipeline**: Universal Render Pipeline (URP)

### SDKs & Packages Used
- **PICO Unity Integration SDK**: 2.5.0
- **XR Interaction Toolkit**: 2.6.4
- **XR Hands**: 1.5.1
- **OpenXR**: 1.12.1
- **AI Navigation**: 1.1.6
- **Localization Package**: 1.5.4
- **TextMeshPro**: 3.0.7

### Main Tech Stack
- C# (.NET)
- Unity XR Toolkit
- PICO Eye Tracking API
- Universal Render Pipeline

## 📁 Project Structure

```
ZEN-EYE-PRO-ver-1.0/
├── Assets/
│   ├── Scenes/              # Scene files
│   │   ├── StressChecker.unity
│   │   ├── VisionTrainingSoccer.unity
│   │   ├── WorkingMemory.unity
│   │   └── AccuracyTest.unity
│   ├── Scripts/             # Scripts
│   │   ├── StressCheckerScripts/    # Stress checker related
│   │   ├── WorkingMemory/           # Working memory related
│   │   ├── VisionTrainingController.cs
│   │   └── EyeTrackingController.cs
│   ├── Resources/           # Resource files
│   └── AssetResources/      # Asset resources
└── Packages/                # Unity packages
```

## 🚀 Setup

### Prerequisites
1. Unity Hub installed
2. Unity 2022.3.50f1 or compatible version
3. PICO XR device
4. PICO SDK set up (included in the project)

### Installation Steps

1. Clone or download the repository
```bash
git clone [repository-url]
```

2. Open the project in Unity Hub
   - Launch Unity Hub
   - Click "Open"
   - Select the project folder

3. Install dependencies
   - When Unity Editor launches, packages will be imported automatically
   - Please wait until the process completes

4. Build settings
   - Open File > Build Settings
   - Select "Android" as the Platform
   - Verify PICO XR settings in Player Settings

## 📱 Usage

1. **Stress Checker**
   - Open the `StressChecker.unity` scene
   - Build to PICO XR device
   - Start data collection with eye tracking

2. **Vision Training**
   - Open the `VisionTrainingSoccer.unity` scene
   - Execute dynamic and static target tracking training

3. **Working Memory Test**
   - Open the `WorkingMemory.unity` scene
   - Execute flash memory test

## 🔧 Developer Information

### Getting Eye Tracking Data
```csharp
var (origin, vector) = EyeTrackingController.GetGazeData();
```

### Scene Management
Scenes are managed using `SceneManagerScript.cs`.

### Configuration Files
- `PicoSdkPCConfig.json`: PICO SDK configuration
- `ProjectSettings/`: Unity project settings

## 📝 License

[Add license information here]

## 👥 Developer

**NeuralPort**

## 📧 Contact

[Add contact information here]

## 🔄 Version History

- **Version 1.0** (Alpha)
  - Initial release
  - Stress checker functionality
  - Vision training functionality
  - Working memory test functionality

---

**Note**: This project is developed specifically for PICO XR devices. Using it with other VR devices may require SDK modifications.
