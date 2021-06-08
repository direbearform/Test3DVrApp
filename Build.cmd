SET Unity=%PROGRAMFILES%\Unity\Hub\Editor\2021.1.10f1\Editor\Unity.exe
SET Project=.\
SET BuildPath=%Project%Builds
SET AndroidKeystorePassword=android

"%Unity%" -quit -batchmode -nographics -projectPath "%Project%" -logFile "%BuildPath%\build.android.log" -executeMethod "APKBuilder.build"