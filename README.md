# UnityJarExample
Example for import .jar in Unity


1. JDK 설치

2. java파일을 이용하여 class파일 생성 (java to class)
   cmd > javac {FileName}.java

3. class파일을 이용하여 jar파일 생성 (class to jar)
   cmd > jar cvf {output}.jar {input}.class

4. jar파일 Unity Project > Assets > Plugins > Android > libs에 추가

5. Unity에서 Script 작성 (JarSample.cs 참조)
