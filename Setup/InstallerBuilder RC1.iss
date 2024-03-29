; Script generated by WebDrive installer builder 1.0
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "GS1 v1.0"
#define MyMiniAppName "Customization Tool"
#define MyAppVerName "GS1 v1.0"
#define MyAppOutPutFieName "GS1 v1.0"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "TechLink 2012"
#define MyAppURL "http://techlink.vn/"
#define MyAppExeName "GS1.exe"
;#define MyPropExeName "eCustomProperties.exe"
;#define MyPropExeDisplayName "GS1 Properties Dialog"

[Setup]
VersionInfoDescription={#MyAppVerName}
VersionInfoVersion={#MyAppVersion}
AppName={#MyAppName}
AppVerName={#MyAppVerName}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename= {#MyAppOutPutFieName}
Compression=lzma
SolidCompression=yes

;Image in setup screen
WizardImageFile= Images\imageGS1.bmp
WizardSmallImageFile = Images\small-imageGS1.bmp

;Show uninstall icon in Add/Remove Panel
UninstallDisplayIcon={app}\GS1.exe
;License default English
LicenseFile=D:\Cosmos\Desktop\inno setup\License\English.txt
;Icon in setup screen
SetupIconFile = D:\Cosmos\Desktop\inno setup\Images\GS1_icon.ico
;The dir to save file after built
OutputDir=D:\Cosmos\Desktop\inno setup\Install

;SET INVIROMENT
;Promt user restart after instal
AlwaysRestart=no
;Promt user restart after uninstal
UninstallRestartComputer=no
;Auto-Detected local languages in machine
LanguageDetectionMethod=locale

[Languages]
Name: english; MessagesFile: compiler:Default.isl ;LicenseFile: "D:\Cosmos\Desktop\inno setup\License\English.txt"
;Name: vietnamese; MessagesFile: compiler:Languages\Vietnamese.isl ;LicenseFile: "D:\Cosmos\Desktop\inno setup\License\Vietnam.txt"

[Types]
;Full
Name: "full"; Description: "Full installation"
;Compact
;Name: "compact"; Description: "Compact installation"
;Custom
;Name: "custom"; Description: "Select components to install"; Flags: iscustom

[Components]
;Name: "Program"; Description: "Program Files"; Types: full compact custom; Flags: fixed
Name: "DefaultProgram"; Description: "Default Components need to install"; Types: full; Flags: fixed
;Name: "OriginTests"; Description: "Origin Tests"; Types: custom;
;Name: "Documentations"; Description: "Other Components support"; Types: custom;
;Name: "Plugins"; Description: "Plugin"; Types: custom;

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: checkedonce
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce


[Files]

;Copy components
Source: "D:\Code\Gs1\ECustoms\bin\Release\*.*"; DestDir: "{app}";Components:"DefaultProgram";Flags: uninsnosharedfileprompt ignoreversion uninsrestartdelete ;
Source: "D:\Code\Gs1\ECustoms\bin\Release\*.*"; DestDir: "{app}";Components:"DefaultProgram"; Flags: uninsnosharedfileprompt allowunsafefiles uninsrestartdelete ;

;readme file
Source: "D:\Cosmos\Desktop\inno setup\License\readme.txt"; DestDir: "{app}\Readme";Components:"DefaultProgram";Flags: ignoreversion uninsrestartdelete ;

;Copy language
;Source: "D:\Code\Gs1\ECustoms\bin\Release\Languages\*.*"; DestDir: "{app}\Languages";Components:"DefaultProgram";Flags: ignoreversion uninsrestartdelete ;

;Util install window service
;Source: "F:\Programs\ETech Projects\Oodrive\Install src\Oddrive\Unreg Components\InstallUtil.exe";DestDir: "{app}";Components:"DefaultProgram";Flags: ignoreversion;
;Source: "F:\Programs\ETech Projects\Oodrive\Install src\Oddrive\Unreg Components\StartService.bad.bat";DestDir: "{app}";Components:"DefaultProgram";Flags: ignoreversion;

;Source: "F:\Programs\ETech Projects\Oodrive\Install src\Tools\InstallUtil.exe";DestDir: "{tmp}";Components:"DefaultProgram";Flags: ignoreversion uninsrestartdelete ;
;Source: "F:\Programs\ETech Projects\Oodrive\Install src\Tools\StartService.bad.bat";DestDir: "{tmp}";Components:"DefaultProgram";Flags: ignoreversion uninsrestartdelete ;

;Customization Tools
;Source: "F:\Programs\ETech Projects\Oodrive\Install src\Tools\Customization\*.*"; DestDir: "{app}\Tool";Components:"DefaultProgram";Flags: ignoreversion uninsrestartdelete ;

[Icons]
;desktop links
Name: "{userdesktop}\GS1 v1.0"; Filename: "{app}\GS1.exe"; Tasks: desktopicon ; WorkingDir: "{app}"

;quicklaunch links
;Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\WebDrive 1.0 RC"; Filename: "{app}\TrayService.exe"; Tasks: QuickLaunchIcon; WorkingDir: "{app}"

;startmenu links
Name: "{group}\{#MyAppName}"; Filename: "{app}\GS1.exe" ; WorkingDir: "{app}"
;Name: "{group}\{#MyMiniAppName}"; Filename: "{app}\Tool\OoDriveCustomizationTool.exe" ; WorkingDir: "{app}\Tool"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
;Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: desktopicon

[Run]
  Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall skipifsilent
  ;Filename: "{app}\{#MyPropExeName}"; Description: "{cm:LaunchProgram,{#MyPropExeDisplayName}}"; Flags: nowait postinstall skipifsilent

  ;Filename: "{tmp}\InstallUtil.exe"; Parameters: "{app}\OoDrive.TransferService.exe" ; Flags: hidewizard
  ;Filename: "{app}\InstallService.bad.bat"; Flags: runhidden

[UninstallRun]
  ;Uninstall OodriveClient service when user selete uninstall webdrive
  ;Filename: "{app}\UninstallService.bad.bat"; Flags: runhidden

;Delete all files after uninstall
[UninstallDelete]
  Type: filesandordirs ; Name: "{app}"

;Delete registry path after uninstall
[Registry]
Root: HKLM; Subkey: "Software\TechLink"; Flags: uninsdeletekey

[Code]

procedure   SetDefaultOptionSelect;
var
   RadioAccept,RadioNoAccept:TRadioButton;
begin

   RadioAccept:=WizardForm.LicenseAcceptedRadio;
   RadioNoAccept:=WizardForm.LicenseNotAcceptedRadio;
   RadioNoAccept.Checked:=true;
end;

procedure InitializeWizard();
begin
 SetDefaultOptionSelect;
end;


















