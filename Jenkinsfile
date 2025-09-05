pipeline {
    agent any
    environment {
        // Add dotnet to PATH so Jenkins can find it
        PATH = "/usr/local/share/dotnet:${env.PATH}"
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Dotnet Version') {
            steps {
                sh 'dotnet --version'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore ./ApiQuicktest/ApiQuicktest.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build ./ApiQuicktest/ApiQuicktest.csproj --no-restore --configuration Debug'
            }
        }

        stage('Test') {
            steps {
                sh 'mkdir -p TestResults'
                // Run tests with JUnit logger
                sh 'dotnet test ./ApiQuicktest/ApiQuicktest.csproj --no-build --logger "junit;LogFilePath=TestResults/results.xml"'
                
                // Optional: debug to see the report file exists
                sh 'ls -l TestResults'
            }
            post {
                always {
                    // Archive the test results
                    junit 'TestResults/results.xml'
                }
            }
        }
    }
}
