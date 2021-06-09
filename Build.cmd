echo off
SET Unity=%PROGRAMFILES%\Unity\Hub\Editor\2021.1.10f1\Editor\Unity.exe
SET Project=.\
SET BuildPath=%Project%Builds
SET KSPath=%Project%TestKeyStores
SET AndroidKeystorePassword=android

ECHO calling unity to build the apks ...
REM "%Unity%" -quit -batchmode -nographics -projectPath "%Project%" -logFile "%BuildPath%\build.android.log" -executeMethod "APKBuilder.Build"

ECHO updating signers ...
REM copy /y %BuildPath%\test3dvrapp.test_key_1.apk %BuildPath%\test3dvrapp.test_key_2.apk
REM CALL :RESIGN_APP %BuildPath%\test3dvrapp.test_key_1.apk test_key_1
REM CALL :RESIGN_APP %BuildPath%\test3dvrapp.test_key_2.apk test_key_2
CALL :RESIGN_APP %BuildPath%\test3dvrapp.test_key_1.demo.apk test_key_1
CALL :RESIGN_APP %BuildPath%\test3dvrapp.test_key_1.demo.renamed.apk test_key_1

ECHO all done!

EXIT /b

:RESIGN_APP
ECHO resigning apk file %1 with key %2
zip -d %1 META-INF/*

ECHO apksigner sign --ks %KSPath%\testuser1.keystore --v1-signing-enabled true --v2-signing-enabled true --ks-key-alias %2 --ks-pass pass:android --key-pass pass:android %1
call apksigner sign --ks %KSPath%\testuser1.keystore --v1-signing-enabled true --v2-signing-enabled true --ks-key-alias %2 --ks-pass pass:android --key-pass pass:android %1
EXIT /b
